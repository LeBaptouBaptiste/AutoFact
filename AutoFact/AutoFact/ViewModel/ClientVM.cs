using System.Data.SQLite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoFact.Models;

namespace AutoFact.ViewModel
{
    internal class ClientVM
    {
        private List<Particuliers> clientList;
        private SQLiteConnection connection;
        private ComboBox box;

        public ClientVM(ComboBox box)
        {
            this.box = box;
            clientList = new List<Particuliers>();
            InitializeDatabase();
            loadClients();

        }

        private void InitializeDatabase()
        {
            DataBaseManager data = DataBaseManager.getInstance();
            this.connection = data.getConnection();
        }

        private void loadClients()
        {
            this.box.Items.Clear();
            try
            {
                // Requête SQLite avec INNER JOIN entre Particuliers et Clients
                string query = "SELECT Clients.id, civilitee, adresse, cp, tel, mail, nom, prenom FROM Particuliers INNER JOIN Clients ON Particuliers.id = Clients.id;";

                // Exécution de la requête avec SQLiteCommand et SQLiteDataAdapter
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                // Parcours des lignes du DataTable
                foreach (DataRow row in dataTable.Rows)
                {
                    // Récupération des valeurs de chaque colonne
                    int id = Convert.ToInt32(row["id"]);
                    string civilitee = row["civilitee"].ToString();
                    string adresse = row["adresse"].ToString();
                    string cp = row["cp"].ToString();
                    string tel = row["tel"].ToString();
                    string mail = row["mail"].ToString();
                    string nom = row["nom"].ToString();
                    string prenom = row["prenom"].ToString();

                    // Création de l'objet Particuliers
                    Particuliers particulier = new Particuliers(id, nom, adresse, cp, tel, mail, civilitee, prenom);

                    // Ajout de l'objet à la liste et à la zone de texte (box)
                    this.box.Items.Add($"{particulier.Name} {particulier.FirstName}");
                    clientList.Add(particulier);
                }
            }
            catch (Exception ex)
            {
                // Gestion des erreurs
                MessageBox.Show($"Erreur lors du chargement des données : {ex.Message}", "Erreur de chargement");
            }
        }
        public List<Particuliers> getClients()
        {
            this.clientList.Clear();
            loadClients();
            return this.clientList;
        }
        public void addClients(string name, string mail, string phone, string address, string cp, string civility, string firstName)
        {
            try
            {
                // Création de l'objet Particuliers
                Particuliers myClient = new Particuliers(name, address, cp, phone, mail, civility, firstName);

                // Démarrage de la transaction SQLite
                using (SQLiteTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Requête d'insertion pour la table Clients
                        string clientQuery = "INSERT INTO Clients(nom, mail, tel, adresse, cp) VALUES(@name, @mail, @phone, @address, @cp); SELECT LAST_INSERT_ROWID();";

                        using (SQLiteCommand cmdClient = new SQLiteCommand(clientQuery, connection, transaction))
                        {
                            // Paramètres pour la requête Clients
                            cmdClient.Parameters.AddWithValue("@name", myClient.Name);
                            cmdClient.Parameters.AddWithValue("@mail", myClient.Mail);
                            cmdClient.Parameters.AddWithValue("@phone", myClient.Phone);
                            cmdClient.Parameters.AddWithValue("@address", myClient.Address);
                            cmdClient.Parameters.AddWithValue("@cp", myClient.PostalCode);

                            // Exécution de la requête et récupération de l'ID généré
                            int generatedId = Convert.ToInt32(cmdClient.ExecuteScalar());

                            // Requête d'insertion pour la table Particuliers
                            string individualQuery = "INSERT INTO Particuliers(id, civilitee, prenom) VALUES(@id, @civility, @firstName);";
                            using (SQLiteCommand cmdIndividual = new SQLiteCommand(individualQuery, connection, transaction))
                            {
                                // Paramètres pour la requête Particuliers
                                cmdIndividual.Parameters.AddWithValue("@id", generatedId); // Utiliser l'ID généré
                                cmdIndividual.Parameters.AddWithValue("@civility", myClient.Civility);
                                cmdIndividual.Parameters.AddWithValue("@firstName", myClient.FirstName);

                                // Exécution de l'insertion pour Particuliers
                                cmdIndividual.ExecuteNonQuery();
                            }
                        }

                        // Commit de la transaction si tout s'est bien passé
                        transaction.Commit();
                        loadClients();
                    }
                    catch (Exception ex)
                    {
                        // Rollback en cas d'erreur
                        transaction.Rollback();
                        MessageBox.Show(ex.Message);
                        MessageBox.Show("Problème lors de l'insertion des données");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problème lors de la création de l'objet");
            }
        }
        public void updClients(int id, string name, string mail, string phone, string address, string cp, string civility, string firstName)
        {
            try
            {
                // Création de l'objet Particuliers
                Particuliers myClient = new Particuliers(id, name, address, cp, phone, mail, civility, firstName);

                // Démarrage de la transaction SQLite
                using (SQLiteTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Requête de mise à jour pour la table Clients
                        string clientQuery = "UPDATE Clients SET nom = @name, mail = @mail, tel = @phone, adresse = @address, cp = @cp WHERE id = @id;";

                        using (SQLiteCommand cmdClient = new SQLiteCommand(clientQuery, connection, transaction))
                        {
                            // Paramètres pour la requête Clients
                            cmdClient.Parameters.AddWithValue("@name", myClient.Name);
                            cmdClient.Parameters.AddWithValue("@mail", myClient.Mail);
                            cmdClient.Parameters.AddWithValue("@phone", myClient.Phone);
                            cmdClient.Parameters.AddWithValue("@address", myClient.Address);
                            cmdClient.Parameters.AddWithValue("@cp", myClient.PostalCode);
                            cmdClient.Parameters.AddWithValue("@id", myClient.Id);

                            // Exécution de la requête Clients
                            cmdClient.ExecuteNonQuery();

                            // Requête de mise à jour pour la table Particuliers
                            string individualQuery = "UPDATE Particuliers SET civilitee = @civility, prenom = @firstName WHERE id = @id";
                            using (SQLiteCommand cmdIndividual = new SQLiteCommand(individualQuery, connection, transaction))
                            {
                                // Paramètres pour la requête Particuliers
                                cmdIndividual.Parameters.AddWithValue("@id", myClient.Id);
                                cmdIndividual.Parameters.AddWithValue("@civility", myClient.Civility);
                                cmdIndividual.Parameters.AddWithValue("@firstName", myClient.FirstName);

                                // Exécution de la mise à jour pour Particuliers
                                cmdIndividual.ExecuteNonQuery();
                            }
                        }

                        // Commit de la transaction si tout s'est bien passé
                        transaction.Commit();
                        loadClients();
                    }
                    catch (Exception ex)
                    {
                        // Rollback en cas d'erreur
                        transaction.Rollback();
                        MessageBox.Show($"Problème lors de l'insertion des données : {ex.Message}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Problème lors de la création de l'objet");
            }
        }
    }
}
