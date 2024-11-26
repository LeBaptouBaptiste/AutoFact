using AutoFact.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoFact.ViewModel
{
    internal class CAClientVM
    {
        // Liste des Clients
        private List<Particuliers> listClients = new List<Particuliers>();

        // Connexion SQLite
        private SQLiteConnection connection;

        public CAClientVM()
        {
            InitializeDatabase(); // Connexion à la base de données
        }

        private void InitializeDatabase()
        {
            DataBaseManager data = DataBaseManager.getInstance(); // Récupère l'instance du gestionnaire de base de données
            this.connection = data.getConnection(); // Connexion à SQLite
        }

        private void loadContratsClients(string date)
        {
            try
            {
                // Conversion de l'année en DateTime pour définir les bornes
                if (!int.TryParse(date, out int anneeNumerique))
                {
                    MessageBox.Show("Année invalide. Veuillez saisir une année valide (exemple : 2024).", "Erreur");
                    return;
                }

                DateTime dateDebut = new DateTime(anneeNumerique, 1, 1);
                DateTime dateFin = new DateTime(anneeNumerique + 1, 1, 1);
                this.listClients.Clear();

                // Transaction pour la gestion de la requête
                using (SQLiteTransaction transaction = connection.BeginTransaction())
                {
                    // Requête SQLite pour récupérer les clients
                    string queryClients = @"SELECT * FROM Clients INNER JOIN Particuliers ON Particuliers.id = Clients.id;";
                    using (SQLiteCommand cmdClients = new SQLiteCommand(queryClients, connection))
                    using (SQLiteDataAdapter adapterClients = new SQLiteDataAdapter(cmdClients))
                    {
                        DataTable dataTableClients = new DataTable();
                        adapterClients.Fill(dataTableClients); // Remplit le DataTable avec les données des clients

                        // Parcourt les lignes du DataTable et crée les objets Particuliers
                        foreach (DataRow row in dataTableClients.Rows)
                        {
                            int id = Convert.ToInt32(row["id"]);
                            string address = row["adresse"].ToString();
                            string cp = row["cp"].ToString();
                            string tel = row["tel"].ToString();
                            string mail = row["mail"].ToString();
                            string nom = row["nom"].ToString();
                            string civilitee = row["civilitee"].ToString();
                            string prenom = row["prenom"].ToString();

                            // Création du client
                            Particuliers client = new Particuliers(id, nom, address, cp, tel, mail, civilitee, prenom);

                            // Liste pour stocker les contrats du client
                            List<Contrats> listContrats = new List<Contrats>();

                            // Requête pour récupérer les contrats du client
                            string queryCA = @"
                        SELECT Contrats.reference, SUM(ServicesClients.quantité * ServicesClients.prix) AS Total
                        FROM Contrats
                        INNER JOIN StatutsContrats ON StatutsContrats.reference = Contrats.reference
                        INNER JOIN ServicesClients ON ServicesClients.reference = Contrats.reference
                        WHERE Contrats.client = 2 AND (StatutsContrats.dateAction BETWEEN @dateDebut AND @dateFin) AND StatutsContrats.etat = 5
                        GROUP BY Contrats.reference;";

                            using (SQLiteCommand cmdCA = new SQLiteCommand(queryCA, connection))
                            {
                                // Ajout du paramètre pour identifier le client spécifique
                                cmdCA.Parameters.AddWithValue("@idClient", client.Id);
                                cmdCA.Parameters.AddWithValue("@dateDebut", dateDebut);
                                cmdCA.Parameters.AddWithValue("@dateFin", dateFin);

                                // Exécution de la requête et récupération des résultats
                                using (SQLiteDataReader reader = cmdCA.ExecuteReader())
                                {
                                    while (reader.Read())
                                    {
                                        string reference = reader["reference"].ToString();
                                        decimal total = reader.IsDBNull(reader.GetOrdinal("Total")) ? 0 : reader.GetDecimal(reader.GetOrdinal("Total"));

                                        // Création du contrat avec la référence et le chiffre d'affaires calculé
                                        Contrats contrat = new Contrats(reference, total);

                                        // Ajout du contrat à la liste des contrats
                                        listContrats.Add(contrat);
                                    }
                                }
                            }

                            // Affectation de la liste des contrats au client
                            client.Contrats = listContrats;

                            // Ajout du client à la liste des clients
                            listClients.Add(client);
                        }
                    }

                    // Commit de la transaction une fois toutes les opérations terminées
                    transaction.Commit();
                }
            }
            catch (Exception ex)
            {
                // En cas d'erreur, on rollback la transaction pour annuler toute modification
                MessageBox.Show($"Erreur lors du chargement des données ou du calcul des contrats : {ex.Message}", "Erreur");
            }
        }

        public List<Particuliers> getClients(string annee)
        { 
            loadContratsClients(annee);
            return this.listClients;
        }
        public DataTable getClientsForDGV()
        {
            string query = @"SELECT Clients.id, Clients.nom, Particuliers.prenom, SUM(ServicesClients.quantité * ServicesClients.prix) AS total
                            FROM Contrats
                            INNER JOIN Clients ON Clients.id = Contrats.client
                            INNER JOIN Particuliers ON Particuliers.id = Clients.id
                            INNER JOIN StatutsContrats ON StatutsContrats.reference = Contrats.reference
                            INNER JOIN ServicesClients ON ServicesClients.reference = Contrats.reference
                            WHERE (StatutsContrats.dateAction BETWEEN '2024-01-01' AND '2025-01-01') AND StatutsContrats.etat = 5
                            GROUP BY Clients.id
                            ORDER BY total DESC;";
            DataTable dataTable = new DataTable();

            using (SQLiteCommand Clientscmd = new SQLiteCommand(query, connection))
            {
                using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(Clientscmd))
                {
                    adapter.Fill(dataTable);
                }
            }
            return dataTable;
        }
        public DataTable getClientsForDGVWithParams(string name, string firstname)
        {
            name = $"%{name}%";
            firstname = $"%{firstname}%";
            string query = @"SELECT Clients.id, Clients.nom, Particuliers.prenom, SUM(ServicesClients.quantité * ServicesClients.prix) AS total
                            FROM Contrats
                            INNER JOIN Clients ON Clients.id = Contrats.client
                            INNER JOIN Particuliers ON Particuliers.id = Clients.id
                            INNER JOIN StatutsContrats ON StatutsContrats.reference = Contrats.reference
                            INNER JOIN ServicesClients ON ServicesClients.reference = Contrats.reference
                            WHERE (StatutsContrats.dateAction BETWEEN '2024-01-01' AND '2025-01-01') AND StatutsContrats.etat = 5 AND Clients.nom LIKE @name AND Particuliers.prenom LIKE @prenom
                            GROUP BY Clients.id
                            ORDER BY total DESC;";
            DataTable dataTable = new DataTable();

            using (SQLiteCommand Clientscmd = new SQLiteCommand(query, connection))
            {
                Clientscmd.Parameters.AddWithValue("@name", name);
                Clientscmd.Parameters.AddWithValue("@prenom", firstname);
                using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(Clientscmd))
                {
                    adapter.Fill(dataTable);
                }
            }
            return dataTable;
        }
    }
}
