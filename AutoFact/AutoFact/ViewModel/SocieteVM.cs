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
    internal class SocieteVM
    {
        private List<Societe> societeList;
        private SQLiteConnection connection;
        private ComboBox box;

        public SocieteVM(ComboBox box)
        {
            this.box = box;
            societeList = new List<Societe>();
            InitializeDatabase();
            loadSupplys();

        }

        private void InitializeDatabase()
        {
            DataBaseManager data = DataBaseManager.getInstance();
            this.connection = data.getConnection();
        }

        private void loadSupplys()
        {
            this.box.Items.Clear();
            try
            {
                // Requête SQLite pour récupérer les données
                string query = @"SELECT Clients.id, siret, adresse, cp, tel, mail, nom FROM Societes INNER JOIN Clients ON Societes.id = Clients.id;";

                // Utilisation de SQLiteCommand et SQLiteDataAdapter pour interagir avec la base de données SQLite
                using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Remplir la liste des sociétés à partir des données récupérées
                    foreach (DataRow row in dataTable.Rows)
                    {
                        int id = Convert.ToInt32(row["id"]);
                        string siret = row["siret"].ToString();
                        string adresse = row["adresse"].ToString();
                        string cp = row["cp"].ToString();
                        string tel = row["tel"].ToString();
                        string mail = row["mail"].ToString();
                        string nom = row["nom"].ToString();

                        // Création de l'objet Societe et ajout dans la liste
                        Societe society = new Societe(id, nom, adresse, cp, tel, mail, siret);
                        this.box.Items.Add(society.Name);
                        societeList.Add(society);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement des données : {ex.Message}", "Erreur de chargement");
            }
        }


        public List<Societe> getSupplys()
        {
            this.societeList.Clear();
            loadSupplys();
            return this.societeList;
        }

        public void addSupplier(string name, string mail, string siret, string phone, string address, string cp)
        {
            try
            {
                Societe mySupplier = new Societe(name, address, cp, phone, mail, siret);

                using (SQLiteTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Requête d'insertion dans la table Clients
                        string clientQuery = "INSERT INTO Clients(nom, mail, tel, adresse, cp) VALUES(@name, @mail, @phone, @address, @cp); SELECT last_insert_rowid();";

                        using (SQLiteCommand cmdClient = new SQLiteCommand(clientQuery, connection, transaction))
                        {
                            cmdClient.Parameters.AddWithValue("@name", mySupplier.Name);
                            cmdClient.Parameters.AddWithValue("@mail", mySupplier.Mail);
                            cmdClient.Parameters.AddWithValue("@phone", mySupplier.Phone);
                            cmdClient.Parameters.AddWithValue("@address", mySupplier.Address);
                            cmdClient.Parameters.AddWithValue("@cp", mySupplier.PostalCode);

                            // Récupérer l'ID généré de la table Clients
                            int generatedId = Convert.ToInt32(cmdClient.ExecuteScalar());

                            // Requête d'insertion dans la table Societes
                            string supplierQuery = "INSERT INTO Societes(id, siret) VALUES(@id, @siret);";
                            using (SQLiteCommand cmdSupplier = new SQLiteCommand(supplierQuery, connection, transaction))
                            {
                                cmdSupplier.Parameters.AddWithValue("@id", generatedId); // Utilise l'ID généré
                                cmdSupplier.Parameters.AddWithValue("@siret", mySupplier.Siret);

                                cmdSupplier.ExecuteNonQuery();
                            }
                        }

                        // Commit de la transaction si tout s'est bien passé
                        transaction.Commit();
                        loadSupplys(); // Recharge la liste des fournisseurs
                    }
                    catch (Exception ex)
                    {
                        // Annuler la transaction en cas d'erreur
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
        public void updSupplier(int id, string name, string mail, string siret, string phone, string address, string cp)
        {
            try
            {
                // Créer un objet Societe avec les nouvelles données
                Societe mySupplier = new Societe(id, name, address, cp, phone, mail, siret);

                // Démarrer une transaction SQLite
                using (SQLiteTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Requête d'update dans la table Clients
                        string clientQuery = "UPDATE Clients SET nom = @name, mail = @mail, tel = @phone, adresse = @address, cp = @cp WHERE id = @id;";

                        using (SQLiteCommand cmdClient = new SQLiteCommand(clientQuery, connection, transaction))
                        {
                            // Ajouter les paramètres à la commande SQLite
                            cmdClient.Parameters.AddWithValue("@name", mySupplier.Name);
                            cmdClient.Parameters.AddWithValue("@mail", mySupplier.Mail);
                            cmdClient.Parameters.AddWithValue("@phone", mySupplier.Phone);
                            cmdClient.Parameters.AddWithValue("@address", mySupplier.Address);
                            cmdClient.Parameters.AddWithValue("@cp", mySupplier.PostalCode);
                            cmdClient.Parameters.AddWithValue("@id", mySupplier.Id);

                            // Exécuter la requête pour mettre à jour la table Clients
                            cmdClient.ExecuteNonQuery();
                        }

                        // Requête d'update dans la table Societes
                        string supplierQuery = "UPDATE Societes SET siret = @siret WHERE id = @id;";

                        using (SQLiteCommand cmdSupplier = new SQLiteCommand(supplierQuery, connection, transaction))
                        {
                            // Ajouter les paramètres à la commande SQLite
                            cmdSupplier.Parameters.AddWithValue("@id", mySupplier.Id);
                            cmdSupplier.Parameters.AddWithValue("@siret", mySupplier.Siret);

                            // Exécuter la requête pour mettre à jour la table Societes
                            cmdSupplier.ExecuteNonQuery();
                        }

                        // Valider la transaction après succès
                        transaction.Commit();
                        loadSupplys(); // Recharger les fournisseurs après la mise à jour
                    }
                    catch (Exception ex)
                    {
                        // Annuler la transaction en cas d'erreur
                        transaction.Rollback();
                        MessageBox.Show(ex.Message);
                        MessageBox.Show("Problème lors de la mise à jour des données");
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
