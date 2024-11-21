using System.Data.SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using AutoFact.Models;

namespace AutoFact.ViewModel
{
    // ViewModel pour gérer les sociétés (fournisseurs) dans l'application
    internal class SocieteVM
    {
        // Liste des sociétés
        private List<Societe> societeList = new List<Societe>();

        // Connexion à la base de données SQLite
        private SQLiteConnection connection;

        // Référence au ComboBox pour afficher les sociétés
        private ComboBox box;

        // Constructeur pour initialiser le ComboBox et charger les sociétés
        public SocieteVM(ComboBox box)
        {
            this.box = box;
            societeList = new List<Societe>(); // Initialisation de la liste des sociétés
            InitializeDatabase(); // Connexion à la base de données
            loadSupplys(); // Chargement des sociétés dans le ComboBox et la liste
        }
        public SocieteVM()
        {
            InitializeDatabase();
        }

        // Initialisation de la connexion à la base de données SQLite
        private void InitializeDatabase()
        {
            DataBaseManager data = DataBaseManager.getInstance(); // Obtention de l'instance du gestionnaire de base de données
            this.connection = data.getConnection(); // Connexion à SQLite
        }

        // Charge les sociétés depuis la base de données
        private void loadSupplys()
        {
            if (box != null)
            {
                this.box.Items.Clear(); // Vide le ComboBox pour éviter les doublons
            }
            try
            {
                // Requête SQLite pour récupérer les sociétés et leurs informations associées
                string query = @"SELECT Clients.id, siret, adresse, cp, tel, mail, nom FROM Societes INNER JOIN Clients ON Societes.id = Clients.id;";

                // Exécution de la requête avec un SQLiteCommand et SQLiteDataAdapter pour remplir le DataTable
                using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable); // Remplir le DataTable avec les résultats de la requête

                    // Parcourt les lignes du DataTable et crée des objets Societe
                    foreach (DataRow row in dataTable.Rows)
                    {
                        int id = Convert.ToInt32(row["id"]);
                        string siret = row["siret"].ToString();
                        string adresse = row["adresse"].ToString();
                        string cp = row["cp"].ToString();
                        string tel = row["tel"].ToString();
                        string mail = row["mail"].ToString();
                        string nom = row["nom"].ToString();

                        // Création de l'objet Societe et ajout dans la liste et le ComboBox
                        Societe society = new Societe(id, nom, adresse, cp, tel, mail, siret);
                        if (box != null)
                        {
                            this.box.Items.Add(society.Name); // Ajout du nom de la société dans le ComboBox
                        }
                        societeList.Add(society); // Ajout de l'objet Societe dans la liste
                    }
                }
            }
            catch (Exception ex)
            {
                // Gestion des erreurs lors du chargement des données
                MessageBox.Show($"Erreur lors du chargement des données : {ex.Message}", "Erreur de chargement");
            }
        }
        public DataTable getSuppliersForDGV()
        {
            string query = @"SELECT Clients.id, siret, adresse, cp, tel, mail, nom FROM Societes INNER JOIN Clients ON Societes.id = Clients.id;";
            DataTable dataTable = new DataTable();

            using (SQLiteCommand Servicescmd = new SQLiteCommand(query, connection))
            {
                using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(Servicescmd))
                {
                    adapter.Fill(dataTable);
                }
            }
            return dataTable;
        }

        // Retourne la liste des sociétés
        public List<Societe> getSupplys()
        {
            this.societeList.Clear(); // Réinitialisation de la liste
            loadSupplys(); // Recharge les sociétés
            return this.societeList; // Retourne la liste des sociétés
        }
        public List<int> getSupplysId()
        {
            this.societeList.Clear();
            loadSupplys();
            List<int> list = new List<int>();
            foreach(Societe societe in this.societeList)
            {
                list.Add(societe.Id);
            }
            return list;
        }

        // Ajoute une nouvelle société dans la base de données
        public void addSupplier(string name, string mail, string siret, string phone, string address, string cp)
        {
            try
            {
                // Création d'une nouvelle société à partir des paramètres fournis
                Societe mySupplier = new Societe(name, address, cp, phone, mail, siret);

                using (SQLiteTransaction transaction = connection.BeginTransaction()) // Démarrage d'une transaction SQLite
                {
                    try
                    {
                        // Insertion dans la table Clients
                        string clientQuery = "INSERT INTO Clients(nom, mail, tel, adresse, cp) VALUES(@name, @mail, @phone, @address, @cp); SELECT last_insert_rowid();";

                        using (SQLiteCommand cmdClient = new SQLiteCommand(clientQuery, connection, transaction))
                        {
                            cmdClient.Parameters.AddWithValue("@name", mySupplier.Name);
                            cmdClient.Parameters.AddWithValue("@mail", mySupplier.Mail);
                            cmdClient.Parameters.AddWithValue("@phone", mySupplier.Phone);
                            cmdClient.Parameters.AddWithValue("@address", mySupplier.Address);
                            cmdClient.Parameters.AddWithValue("@cp", mySupplier.PostalCode);

                            // Récupère l'ID généré pour le client
                            int generatedId = Convert.ToInt32(cmdClient.ExecuteScalar());

                            // Insertion dans la table Societes avec l'ID du client
                            string supplierQuery = "INSERT INTO Societes(id, siret) VALUES(@id, @siret);";
                            using (SQLiteCommand cmdSupplier = new SQLiteCommand(supplierQuery, connection, transaction))
                            {
                                cmdSupplier.Parameters.AddWithValue("@id", generatedId); // Utilisation de l'ID généré
                                cmdSupplier.Parameters.AddWithValue("@siret", mySupplier.Siret);
                                cmdSupplier.ExecuteNonQuery();
                            }
                        }

                        transaction.Commit(); // Commit de la transaction
                        loadSupplys(); // Recharge les sociétés après l'ajout
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback(); // Annule la transaction en cas d'erreur
                        MessageBox.Show(ex.Message);
                        MessageBox.Show("Problème lors de l'insertion des données");
                    }
                }
            }
            catch (Exception ex)
            {
                // Gestion des erreurs lors de la création de la société
                MessageBox.Show("Problème lors de la création de l'objet");
            }
        }

        // Met à jour une société existante dans la base de données
        public void updSupplier(int id, string name, string mail, string siret, string phone, string address, string cp)
        {
            try
            {
                // Création d'un objet Societe avec les nouvelles données
                Societe mySupplier = new Societe(id, name, address, cp, phone, mail, siret);

                // Démarrage d'une transaction SQLite
                using (SQLiteTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Mise à jour de la table Clients
                        string clientQuery = "UPDATE Clients SET nom = @name, mail = @mail, tel = @phone, adresse = @address, cp = @cp WHERE id = @id;";

                        using (SQLiteCommand cmdClient = new SQLiteCommand(clientQuery, connection, transaction))
                        {
                            cmdClient.Parameters.AddWithValue("@name", mySupplier.Name);
                            cmdClient.Parameters.AddWithValue("@mail", mySupplier.Mail);
                            cmdClient.Parameters.AddWithValue("@phone", mySupplier.Phone);
                            cmdClient.Parameters.AddWithValue("@address", mySupplier.Address);
                            cmdClient.Parameters.AddWithValue("@cp", mySupplier.PostalCode);
                            cmdClient.Parameters.AddWithValue("@id", mySupplier.Id);

                            // Exécution de la requête pour mettre à jour les données du client
                            cmdClient.ExecuteNonQuery();
                        }

                        // Mise à jour de la table Societes
                        string supplierQuery = "UPDATE Societes SET siret = @siret WHERE id = @id;";

                        using (SQLiteCommand cmdSupplier = new SQLiteCommand(supplierQuery, connection, transaction))
                        {
                            cmdSupplier.Parameters.AddWithValue("@id", mySupplier.Id);
                            cmdSupplier.Parameters.AddWithValue("@siret", mySupplier.Siret);

                            // Exécution de la requête pour mettre à jour les données du fournisseur
                            cmdSupplier.ExecuteNonQuery();
                        }

                        transaction.Commit(); // Commit de la transaction
                        loadSupplys(); // Recharge les sociétés après la mise à jour
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback(); // Annule la transaction en cas d'erreur
                        MessageBox.Show(ex.Message);
                        MessageBox.Show("Problème lors de la mise à jour des données");
                    }
                }
            }
            catch (Exception ex)
            {
                // Gestion des erreurs lors de la mise à jour de la société
                MessageBox.Show("Problème lors de la création de l'objet");
            }
        }
    }
}