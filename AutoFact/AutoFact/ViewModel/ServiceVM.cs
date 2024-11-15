using AutoFact.Views;
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
    internal class ServiceVM
    {
        private List<Services> serviceList;
        private SQLiteConnection connection;
        private ComboBox box;

        public ServiceVM(ComboBox box)
        {
            this.box = box;
            serviceList = new List<Services>();
            InitializeDatabase();
            loadServices();
        }

        private void InitializeDatabase()
        {
            DataBaseManager data = DataBaseManager.getInstance();
            this.connection = data.getConnection();
        }

        private void loadServices()
        {
            this.box.Items.Clear();
            try
            {
                // Requête SQL pour récupérer les données des services avec jointure
                string query = @"SELECT Designations.id, libelle, prix, duree, description 
                                 FROM Services 
                                 INNER JOIN Designations ON Services.id = Designations.id;";

                // Créer une commande SQLite avec la requête et la connexion
                using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd))
                {
                    // Créer un DataTable pour stocker les résultats
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    // Parcourir chaque ligne du DataTable
                    foreach (DataRow row in dataTable.Rows)
                    {
                        // Extraire les données des colonnes
                        int id = Convert.ToInt32(row["id"]);
                        string name = row["libelle"].ToString();
                        decimal price = Convert.ToDecimal(row["prix"]);
                        string description = row["description"].ToString();

                        // Créer un objet service
                        Services service = new Services(id, name, price, description);

                        // Vérifier si la durée existe dans la colonne 'duree'
                        if (row["duree"] != DBNull.Value)
                        {
                            int duration = Convert.ToInt32(row["duree"]);
                            service.Duration = duration;
                            service.HaveDuration = true;
                        }

                        // Ajouter le nom du service à la liste déroulante (box)
                        this.box.Items.Add(service.Libelle);
                        serviceList.Add(service);
                    }
                }
            }
            catch (Exception ex)
            {
                // Afficher une erreur si quelque chose échoue
                MessageBox.Show($"Erreur lors du chargement des données : {ex.Message}", "Erreur de chargement");
            }
        }

        public List<Services> getServices()
        {
            this.serviceList.Clear();
            loadServices();
            return this.serviceList;
        }

        public void addService(string name, decimal price, int duration, string description)
        {
            try
            {
                // Création de l'objet Service
                Services myService = new Services(name, price, duration, description);

                // Démarrer une transaction SQLite
                using (SQLiteTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Requête SQL pour insérer dans la table Designations
                        string designationQuery = "INSERT INTO Designations(libelle, description, prix) VALUES(@libelle, @description, @prix); SELECT last_insert_rowid();";

                        // Exécution de la requête Designations
                        using (SQLiteCommand cmdDesignation = new SQLiteCommand(designationQuery, connection, transaction))
                        {
                            cmdDesignation.Parameters.AddWithValue("@libelle", myService.Libelle);
                            cmdDesignation.Parameters.AddWithValue("@description", myService.Description ?? (object)DBNull.Value); // Utiliser DBNull pour les valeurs nulles
                            cmdDesignation.Parameters.AddWithValue("@prix", myService.Prix);

                            // Récupérer l'ID généré pour l'insertion dans Services
                            int generatedId = Convert.ToInt32(cmdDesignation.ExecuteScalar());

                            // Requête SQL pour insérer dans la table Services
                            string serviceQuery = "INSERT INTO Services(id, duree) VALUES(@id, @duration)";

                            // Exécution de la requête Services
                            using (SQLiteCommand cmdService = new SQLiteCommand(serviceQuery, connection, transaction))
                            {
                                cmdService.Parameters.AddWithValue("@id", generatedId); // Utiliser l'ID généré
                                cmdService.Parameters.AddWithValue("@duration", myService.Duration);

                                cmdService.ExecuteNonQuery();
                            }
                        }

                        // Valider la transaction
                        transaction.Commit();
                        loadServices(); // Recharger les services après insertion
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

        public void addServiceWithoutDuration(string name, decimal price, string description = null)
        {
            try
            {
                // Création de l'objet Service sans durée
                Services myService = new Services(name, price, description);

                // Démarrer une transaction SQLite
                using (SQLiteTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Requête SQL pour insérer dans la table Designations
                        string designationQuery = "INSERT INTO Designations(libelle, description, prix) VALUES(@libelle, @description, @prix); SELECT last_insert_rowid();";

                        // Exécution de la requête Designations
                        using (SQLiteCommand cmdDesignation = new SQLiteCommand(designationQuery, connection, transaction))
                        {
                            cmdDesignation.Parameters.AddWithValue("@libelle", myService.Libelle);
                            cmdDesignation.Parameters.AddWithValue("@description", myService.Description ?? (object)DBNull.Value); // Utiliser DBNull pour les valeurs nulles
                            cmdDesignation.Parameters.AddWithValue("@prix", myService.Prix);

                            // Récupérer l'ID généré pour l'insertion dans Services
                            int generatedId = Convert.ToInt32(cmdDesignation.ExecuteScalar());

                            // Requête SQL pour insérer dans la table Services (sans durée)
                            string serviceQuery = "INSERT INTO Services(id) VALUES(@id)";

                            // Exécution de la requête Services
                            using (SQLiteCommand cmdService = new SQLiteCommand(serviceQuery, connection, transaction))
                            {
                                cmdService.Parameters.AddWithValue("@id", generatedId); // Utiliser l'ID généré
                                cmdService.ExecuteNonQuery();
                            }
                        }

                        // Valider la transaction
                        transaction.Commit();
                        loadServices(); // Recharger les services après insertion
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

        public void updService(int id, string name, decimal price, int duration, string description = null)
        {
            try
            {
                // Création de l'objet Service
                Services myService = new Services(id, name, price, duration, description);

                // Démarrer une transaction SQLite
                using (SQLiteTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Requête SQL pour mettre à jour dans la table Designations
                        string designationQuery = "UPDATE Designations SET libelle = @name, description = @description, prix = @price WHERE id = @id;";

                        // Exécution de la requête Designations
                        using (SQLiteCommand cmdDesignation = new SQLiteCommand(designationQuery, connection, transaction))
                        {
                            cmdDesignation.Parameters.AddWithValue("@name", myService.Libelle);
                            cmdDesignation.Parameters.AddWithValue("@description", myService.Description ?? (object)DBNull.Value); // Utilisation de DBNull pour les valeurs nulles
                            cmdDesignation.Parameters.AddWithValue("@price", myService.Prix);
                            cmdDesignation.Parameters.AddWithValue("@id", myService.Id);

                            cmdDesignation.ExecuteNonQuery();
                        }

                        // Requête SQL pour mettre à jour dans la table Services
                        string serviceQuery = "UPDATE Services SET duree = @duration WHERE id = @id";

                        // Exécution de la requête Services
                        using (SQLiteCommand cmdService = new SQLiteCommand(serviceQuery, connection, transaction))
                        {
                            cmdService.Parameters.AddWithValue("@duration", myService.Duration);
                            cmdService.Parameters.AddWithValue("@id", myService.Id);

                            cmdService.ExecuteNonQuery();
                        }

                        // Valider la transaction
                        transaction.Commit();
                        loadServices(); // Recharger les services après mise à jour
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

        public void updServiceWithoutDuration(int id, string name, decimal price, string description = null)
        {
            try
            {
                // Création de l'objet Service sans la durée
                Services myService = new Services(id, name, price, description);

                // Démarrer une transaction SQLite
                using (SQLiteTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Requête SQL pour mettre à jour dans la table Designations
                        string designationQuery = "UPDATE Designations SET libelle = @name, description = @description, prix = @price WHERE id = @id;";

                        // Exécution de la requête Designations
                        using (SQLiteCommand cmdDesignation = new SQLiteCommand(designationQuery, connection, transaction))
                        {
                            cmdDesignation.Parameters.AddWithValue("@name", myService.Libelle);
                            cmdDesignation.Parameters.AddWithValue("@description", myService.Description ?? (object)DBNull.Value); // Utilisation de DBNull pour les valeurs nulles
                            cmdDesignation.Parameters.AddWithValue("@price", myService.Prix);
                            cmdDesignation.Parameters.AddWithValue("@id", myService.Id);

                            cmdDesignation.ExecuteNonQuery();
                        }

                        // Valider la transaction
                        transaction.Commit();
                        loadServices(); // Recharger les services après mise à jour
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