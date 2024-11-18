using System.Data.SQLite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using AutoFact.Models;

namespace AutoFact.ViewModel
{
    internal class ArticleVM
    {
        // Liste des produits
        private List<Produits> articleList = new List<Produits>();

        // Connexion SQLite
        private SQLiteConnection connection;

        // Référence au ComboBox pour afficher les articles
        private ComboBox box;

        // Liste des fournisseurs
        private List<Societe> societeList;

        // Constructeur pour initialiser le ComboBox, la liste des sociétés et charger les articles
        public ArticleVM(ComboBox box, List<Societe> societeList)
        {
            this.box = box;
            this.societeList = societeList;
            InitializeDatabase(); // Connexion à la base de données
            loadArticles(); // Chargement des articles dans le ComboBox et la liste
        }

<<<<<<< HEAD
        public ArticleVM(ComboBox box)
        {
            this.box = box;
            InitializeDatabase();
            loadArticles();
        }

=======
        // Initialisation de la connexion à la base de données
>>>>>>> origin/MigrationSQLite
        private void InitializeDatabase()
        {
            DataBaseManager data = DataBaseManager.getInstance(); // Récupère l'instance du gestionnaire de base de données
            this.connection = data.getConnection(); // Connexion à SQLite
        }

        // Récupère la liste des produits
        public List<Produits> getProducts()
        {
            this.articleList.Clear(); // Réinitialise la liste
            loadArticles(); // Recharge les articles
            return this.articleList; // Retourne la liste des produits
        }

        // Charge les articles depuis la base de données
        private void loadArticles()
        {
            try
            {
                box.Items.Clear(); // Vide le ComboBox

<<<<<<< HEAD
                MySqlCommand cmd = new MySqlCommand("SELECT Designations.id, prixAchat, quantite, id_fournisseur, libelle, prix, description FROM Produits INNER JOIN Designations ON Produits.id = Designations.id;", connection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
=======
                // Requête SQLite pour récupérer les produits
                string query = @"SELECT Designations.id, prixAchat, quantite, id_fournisseur, libelle, prix, description FROM Produits INNER JOIN Designations ON Produits.id = Designations.id;";
>>>>>>> origin/MigrationSQLite

                using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd))
                {
<<<<<<< HEAD
                    int id = Convert.ToInt32(row["id"]);
                    decimal buyPrice = Convert.ToDecimal(row["prixAchat"]);
                    int quantity = Convert.ToInt32(row["quantite"]);
                    int idFournisseur = Convert.ToInt32(row["id_fournisseur"]);
                    string libelle = row["libelle"].ToString();
                    decimal price = Convert.ToDecimal(row["prix"]);
                    string description = row["description"].ToString();

                    if (societeList != null)
                    {
                        int fournisseur = 0;
                        foreach (Societe societe in societeList)
                        {
                            if (societe.Id == idFournisseur)
                            {
                                break;
                            }
                            fournisseur += 1;
                        }
                        Produits product = new Produits(id, libelle, price, buyPrice, quantity, societeList[fournisseur], description);
                        box.Items.Add(product.Libelle);
                        articleList.Add(product);
                    }
                    else
                    {
                        Produits product = new Produits(id, libelle, price, buyPrice, quantity, description);
=======
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable); // Remplit le DataTable avec les données

                    // Parcourt les lignes du DataTable et crée les objets Produits
                    foreach (DataRow row in dataTable.Rows)
                    {
                        int id = Convert.ToInt32(row["id"]);
                        decimal buyPrice = Convert.ToDecimal(row["prixAchat"]);
                        int quantity = Convert.ToInt32(row["quantite"]);
                        int idFournisseur = Convert.ToInt32(row["id_fournisseur"]);
                        string libelle = row["libelle"].ToString();
                        decimal price = Convert.ToDecimal(row["prix"]);
                        string description = row["description"].ToString();

                        // Recherche de la société (fournisseur) correspondant à l'ID
                        int fournisseur = 0;
                        foreach (Societe societe in societeList)
                        {
                            if (societe.Id == idFournisseur) break;
                            fournisseur++;
                        }

                        // Création du produit et ajout au ComboBox et à la liste
                        Produits product = new Produits(id, libelle, description, price, buyPrice, quantity, societeList[fournisseur]);
>>>>>>> origin/MigrationSQLite
                        box.Items.Add(product.Libelle);
                        articleList.Add(product);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement des données : {ex.Message}", "Erreur de chargement");
            }
        }

        // Ajoute un nouvel article dans la base de données
        public void addArticle(string name, decimal price, decimal buyprice, int quantity, Societe society, string description = null)
        {
            try
            {
                Produits monProduit = new Produits(name, description, price, buyprice, quantity, society);

                using (SQLiteTransaction transaction = connection.BeginTransaction()) // Démarre une transaction
                {
                    try
                    {
<<<<<<< HEAD
                        string designationQuery = "INSERT INTO Designations(libelle, prix, description) VALUES(@libelle, @prix, @description); SELECT LAST_INSERT_ID();";
=======
                        // Insertion dans Designations
                        string designationQuery = @"INSERT INTO Designations(libelle, description, prix) VALUES(@libelle, @description, @prix);SELECT last_insert_rowid();";
                        int generatedId;
>>>>>>> origin/MigrationSQLite

                        using (SQLiteCommand cmdDesignation = new SQLiteCommand(designationQuery, connection, transaction))
                        {
                            cmdDesignation.Parameters.AddWithValue("@libelle", monProduit.Libelle);
                            cmdDesignation.Parameters.AddWithValue("@description", monProduit.Description ?? (object)DBNull.Value);
                            cmdDesignation.Parameters.AddWithValue("@prix", monProduit.Prix);
<<<<<<< HEAD
                            cmdDesignation.Parameters.AddWithValue("@description", monProduit.Description);

                            int generatedId = Convert.ToInt32(cmdDesignation.ExecuteScalar());

                            string produitQuery = "INSERT INTO Produits(id, prixAchat, quantite, id_fournisseur) VALUES(@id, @prixAchat, @quantite, @id_fournisseur)";
                            using (MySqlCommand cmdProduct = new MySqlCommand(produitQuery, connection, transaction))
                            {
                                cmdProduct.Parameters.AddWithValue("@id", generatedId); // Utiliser l'ID généré
                                cmdProduct.Parameters.AddWithValue("@prixAchat", monProduit.BuyPrice);
                                cmdProduct.Parameters.AddWithValue("@quantite", monProduit.Quantity);
                                cmdProduct.Parameters.AddWithValue("@id_fournisseur", monProduit.Fournisseur.Id);

                                cmdProduct.ExecuteNonQuery();
                            }
=======
                            generatedId = Convert.ToInt32(cmdDesignation.ExecuteScalar()); // Récupère l'ID généré
>>>>>>> origin/MigrationSQLite
                        }

                        // Insertion dans Produits
                        string produitQuery = @"INSERT INTO Produits(id, prixAchat, quantite, id_fournisseur) VALUES(@id, @prixAchat, @quantite, @id_fournisseur);";

<<<<<<< HEAD
        public void updArticle(int id, string name, decimal price, decimal buyprice, int quantity, Societe society, string description)
        {
            try
            {
                Produits monProduit = new Produits(id, name, price, buyprice, quantity, society, description);


                using (MySqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string designationQuery = "UPDATE Designations SET libelle = @name, prix = @price, description = @description WHERE id = @id;";

                        using (MySqlCommand cmdDesignation = new MySqlCommand(designationQuery, connection, transaction))
                        {
                            cmdDesignation.Parameters.AddWithValue("@name", monProduit.Libelle);
                            cmdDesignation.Parameters.AddWithValue("@price", monProduit.Prix);
                            cmdDesignation.Parameters.AddWithValue("@description", monProduit.Description);
                            cmdDesignation.Parameters.AddWithValue("@id", monProduit.Id);

                            cmdDesignation.ExecuteNonQuery();

                            string produitQuery = "UPDATE Produits SET prixAchat = @buyPrice, quantite = @quantity, id_fournisseur = @supplyId WHERE id = @id";
                            using (MySqlCommand cmdProduct = new MySqlCommand(produitQuery, connection, transaction))
                            {
                                cmdProduct.Parameters.AddWithValue("@id", monProduit.Id);
                                cmdProduct.Parameters.AddWithValue("@buyPrice", monProduit.BuyPrice);
                                cmdProduct.Parameters.AddWithValue("@quantity", monProduit.Quantity);
                                cmdProduct.Parameters.AddWithValue("@supplyId", monProduit.Fournisseur.Id);

                                cmdProduct.ExecuteNonQuery();
                            }
=======
                        using (SQLiteCommand cmdProduct = new SQLiteCommand(produitQuery, connection, transaction))
                        {
                            cmdProduct.Parameters.AddWithValue("@id", generatedId); // Utilise l'ID généré
                            cmdProduct.Parameters.AddWithValue("@prixAchat", monProduit.BuyPrice);
                            cmdProduct.Parameters.AddWithValue("@quantite", monProduit.Quantity);
                            cmdProduct.Parameters.AddWithValue("@id_fournisseur", monProduit.Fournisseur.Id);
                            cmdProduct.ExecuteNonQuery();
>>>>>>> origin/MigrationSQLite
                        }

                        transaction.Commit(); // Valide la transaction
                        loadArticles(); // Recharge les articles après l'ajout
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

        // Met à jour un article existant dans la base de données
        public void updArticle(int id, string name, decimal price, decimal buyprice, int quantity, Societe society, string description = null)
        {
            try
            {
                Produits monProduit = new Produits(id, name, description, price, buyprice, quantity, society);

                using (SQLiteTransaction transaction = connection.BeginTransaction()) // Démarre une transaction
                {
                    try
                    {
                        // Mise à jour dans Designations
                        string designationQuery = @"UPDATE Designations SET libelle = @name, description = @description, prix = @price WHERE id = @id;";

                        using (SQLiteCommand cmdDesignation = new SQLiteCommand(designationQuery, connection, transaction))
                        {
                            cmdDesignation.Parameters.AddWithValue("@name", monProduit.Libelle);
                            cmdDesignation.Parameters.AddWithValue("@description", monProduit.Description ?? (object)DBNull.Value);
                            cmdDesignation.Parameters.AddWithValue("@price", monProduit.Prix);
                            cmdDesignation.Parameters.AddWithValue("@id", monProduit.Id);
                            cmdDesignation.ExecuteNonQuery();
                        }

                        // Mise à jour dans Produits
                        string produitQuery = @"UPDATE Produits SET prixAchat = @buyPrice, quantite = @quantity, id_fournisseur = @supplyId WHERE id = @id;";

                        using (SQLiteCommand cmdProduct = new SQLiteCommand(produitQuery, connection, transaction))
                        {
                            cmdProduct.Parameters.AddWithValue("@id", monProduit.Id);
                            cmdProduct.Parameters.AddWithValue("@buyPrice", monProduit.BuyPrice);
                            cmdProduct.Parameters.AddWithValue("@quantity", monProduit.Quantity);
                            cmdProduct.Parameters.AddWithValue("@supplyId", monProduit.Fournisseur.Id);
                            cmdProduct.ExecuteNonQuery();
                        }

                        transaction.Commit(); // Valide la transaction
                        loadArticles(); // Recharge les articles après la mise à jour
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