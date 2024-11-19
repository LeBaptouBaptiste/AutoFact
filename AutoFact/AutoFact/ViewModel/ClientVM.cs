using System.Data.SQLite;
using System;
using System.Collections.Generic;
using System.Data;
using AutoFact.Models;

namespace AutoFact.ViewModel
{
    internal class ClientVM
    {
        // Liste des clients
        private List<Particuliers> clientList = new List<Particuliers>();

        // Connexion SQLite
        private SQLiteConnection connection;

        // Référence au ComboBox pour afficher les clients
        private ComboBox box;

        // Constructeur pour initialiser le ComboBox et charger les clients
        public ClientVM(ComboBox box)
        {
            this.box = box;
            clientList = new List<Particuliers>();
            InitializeDatabase(); // Connexion à la base de données
            loadClients(); // Chargement des clients dans le ComboBox et la liste
        }

        public ClientVM()
        {
            InitializeDatabase();
        }

        // Initialisation de la connexion à la base de données
        private void InitializeDatabase()
        {
            DataBaseManager data = DataBaseManager.getInstance(); // Récupère l'instance du gestionnaire de base de données
            this.connection = data.getConnection(); // Connexion à SQLite
        }

        // Récupère la liste des clients
        public List<Particuliers> getClients()
        {
            if (clientList != null)
            {
                this.clientList.Clear();// Réinitialise la liste
            }
            loadClients(); // Recharge les clients
            return this.clientList; // Retourne la liste des clients
        }

        // Charge les clients depuis la base de données
        private void loadClients()
        {
            try
            {
                if (this.box != null)
                {
                    this.box.Items.Clear(); // Vide le ComboBox
                }

                // Requête SQLite pour récupérer les clients
                string query = @"SELECT Clients.id, civilitee, adresse, cp, tel, mail, nom, prenom FROM Particuliers INNER JOIN Clients ON Particuliers.id = Clients.id;";

                using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable); // Remplit le DataTable avec les données

                    // Parcourt les lignes du DataTable et crée les objets Particuliers
                    foreach (DataRow row in dataTable.Rows)
                    {
                        int id = Convert.ToInt32(row["id"]);
                        string civilitee = row["civilitee"].ToString();
                        string adresse = row["adresse"].ToString();
                        string cp = row["cp"].ToString();
                        string tel = row["tel"].ToString();
                        string mail = row["mail"].ToString();
                        string nom = row["nom"].ToString();
                        string prenom = row["prenom"].ToString();

                        // Création du client et ajout au ComboBox et à la liste
                        Particuliers particulier = new Particuliers(id, nom, adresse, cp, tel, mail, civilitee, prenom);
                        if (box != null)
                        {
                            box.Items.Add($"{particulier.Name} {particulier.FirstName}");
                        }
                        clientList.Add(particulier);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement des données : {ex.Message}", "Erreur de chargement");
            }
        }

        public DataTable getClientsForDGV()
        {
            string query = @"SELECT Clients.id, civilitee, adresse, cp, tel, mail, nom, prenom FROM Particuliers INNER JOIN Clients ON Particuliers.id = Clients.id;";
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

        // Ajoute un nouveau client dans la base de données
        public void addClients(string name, string mail, string phone, string address, string cp, string civility, string firstName)
        {
            try
            {
                Particuliers myClient = new Particuliers(name, address, cp, phone, mail, civility, firstName);

                using (SQLiteTransaction transaction = connection.BeginTransaction()) // Démarre une transaction
                {
                    try
                    {
                        // Insertion dans Clients
                        string clientQuery = @"INSERT INTO Clients(nom, mail, tel, adresse, cp) VALUES(@name, @mail, @phone, @address, @cp); SELECT LAST_INSERT_ROWID();";
                        int generatedId;

                        using (SQLiteCommand cmdClient = new SQLiteCommand(clientQuery, connection, transaction))
                        {
                            cmdClient.Parameters.AddWithValue("@name", myClient.Name);
                            cmdClient.Parameters.AddWithValue("@mail", myClient.Mail);
                            cmdClient.Parameters.AddWithValue("@phone", myClient.Phone);
                            cmdClient.Parameters.AddWithValue("@address", myClient.Address);
                            cmdClient.Parameters.AddWithValue("@cp", myClient.PostalCode);
                            generatedId = Convert.ToInt32(cmdClient.ExecuteScalar()); // Récupère l'ID généré
                        }

                        // Insertion dans Particuliers
                        string individualQuery = @"INSERT INTO Particuliers(id, civilitee, prenom) VALUES(@id, @civility, @firstName);";
                        using (SQLiteCommand cmdIndividual = new SQLiteCommand(individualQuery, connection, transaction))
                        {
                            cmdIndividual.Parameters.AddWithValue("@id", generatedId);
                            cmdIndividual.Parameters.AddWithValue("@civility", myClient.Civility);
                            cmdIndividual.Parameters.AddWithValue("@firstName", myClient.FirstName);
                            cmdIndividual.ExecuteNonQuery();
                        }

                        transaction.Commit(); // Valide la transaction
                        loadClients(); // Recharge les clients après l'ajout
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback(); // Annule la transaction en cas d'erreur
                        MessageBox.Show($"Erreur lors de l'insertion des données : {ex.Message}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la création de l'objet : {ex.Message}");
            }
        }

        // Met à jour un client existant dans la base de données
        public void updClients(int id, string name, string mail, string phone, string address, string cp, string civility, string firstName)
        {
            try
            {
                Particuliers myClient = new Particuliers(id, name, address, cp, phone, mail, civility, firstName);

                using (SQLiteTransaction transaction = connection.BeginTransaction()) // Démarre une transaction
                {
                    try
                    {
                        // Mise à jour dans Clients
                        string clientQuery = @"UPDATE Clients SET nom = @name, mail = @mail, tel = @phone, adresse = @address, cp = @cp WHERE id = @id;";

                        using (SQLiteCommand cmdClient = new SQLiteCommand(clientQuery, connection, transaction))
                        {
                            cmdClient.Parameters.AddWithValue("@name", myClient.Name);
                            cmdClient.Parameters.AddWithValue("@mail", myClient.Mail);
                            cmdClient.Parameters.AddWithValue("@phone", myClient.Phone);
                            cmdClient.Parameters.AddWithValue("@address", myClient.Address);
                            cmdClient.Parameters.AddWithValue("@cp", myClient.PostalCode);
                            cmdClient.Parameters.AddWithValue("@id", myClient.Id);
                            cmdClient.ExecuteNonQuery();
                        }

                        // Mise à jour dans Particuliers
                        string individualQuery = @"UPDATE Particuliers SET civilitee = @civility, prenom = @firstName WHERE id = @id;";
                        using (SQLiteCommand cmdIndividual = new SQLiteCommand(individualQuery, connection, transaction))
                        {
                            cmdIndividual.Parameters.AddWithValue("@id", myClient.Id);
                            cmdIndividual.Parameters.AddWithValue("@civility", myClient.Civility);
                            cmdIndividual.Parameters.AddWithValue("@firstName", myClient.FirstName);
                            cmdIndividual.ExecuteNonQuery();
                        }

                        transaction.Commit(); // Valide la transaction
                        loadClients(); // Recharge les clients après la mise à jour
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback(); // Annule la transaction en cas d'erreur
                        MessageBox.Show($"Erreur lors de la mise à jour des données : {ex.Message}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la création de l'objet : {ex.Message}");
            }
        }
    }
}