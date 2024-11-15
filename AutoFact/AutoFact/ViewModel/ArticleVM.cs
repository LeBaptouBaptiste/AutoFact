using System.Data.SQLite;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using static System.Runtime.InteropServices.JavaScript.JSType;
using AutoFact.Models;

namespace AutoFact.ViewModel
{
    internal class ArticleVM
    {
        private List<Produits> articleList = new List<Produits>();
        private SQLiteConnection connection;
        private ComboBox box;
        private List<Societe> societeList;

        public ArticleVM(ComboBox box, List<Societe> societeList)
        {
            this.box = box;
            this.societeList = societeList;
            InitializeDatabase();
            loadArticles();
        }

        private void InitializeDatabase()
        {
            DataBaseManager data = DataBaseManager.getInstance();
            this.connection = data.getConnection();
        }

        public List<Produits> getProducts()
        {
            this.articleList.Clear();
            loadArticles();
            return this.articleList;
        }

        private void loadArticles()
        {
            try
            {
                box.Items.Clear();

                // Préparation de la requête SQLite
                string query = @"SELECT Designations.id, prixAchat, quantite, id_fournisseur, libelle, prix, description FROM Produits INNER JOIN Designations ON Produits.id = Designations.id;";

                using (SQLiteCommand cmd = new SQLiteCommand(query, connection))
                using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd))
                {
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);

                    foreach (DataRow row in dataTable.Rows)
                    {
                        int id = Convert.ToInt32(row["id"]);
                        decimal buyPrice = Convert.ToDecimal(row["prixAchat"]);
                        int quantity = Convert.ToInt32(row["quantite"]);
                        int idFournisseur = Convert.ToInt32(row["id_fournisseur"]);
                        string libelle = row["libelle"].ToString();
                        decimal price = Convert.ToDecimal(row["prix"]);
                        string description = row["description"].ToString();

                        // Recherche de la société correspondante
                        int fournisseur = 0;
                        foreach (Societe societe in societeList)
                        {
                            if (societe.Id == idFournisseur)
                            {
                                break;
                            }
                            fournisseur += 1;
                        }

                        // Création de l'article et ajout à la liste et au ComboBox
                        Produits product = new Produits(id, libelle, description, price, buyPrice, quantity, societeList[fournisseur]);
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

        public void addArticle(string name, decimal price, decimal buyprice, int quantity, Societe society, string description = null)
        {
            try
            {
                Produits monProduit = new Produits(name, description, price, buyprice, quantity, society);

                using (SQLiteTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Première requête : insertion dans Designations
                        string designationQuery = @"INSERT INTO Designations(libelle, description, prix) VALUES(@libelle, @description, @prix);SELECT last_insert_rowid();";

                        int generatedId;

                        using (SQLiteCommand cmdDesignation = new SQLiteCommand(designationQuery, connection, transaction))
                        {
                            cmdDesignation.Parameters.AddWithValue("@libelle", monProduit.Libelle);
                            cmdDesignation.Parameters.AddWithValue("@description", monProduit.Description ?? (object)DBNull.Value);
                            cmdDesignation.Parameters.AddWithValue("@prix", monProduit.Prix);

                            // Récupérer l'ID généré
                            generatedId = Convert.ToInt32(cmdDesignation.ExecuteScalar());
                        }

                        // Deuxième requête : insertion dans Produits
                        string produitQuery = @"INSERT INTO Produits(id, prixAchat, quantite, id_fournisseur) VALUES(@id, @prixAchat, @quantite, @id_fournisseur);";

                        using (SQLiteCommand cmdProduct = new SQLiteCommand(produitQuery, connection, transaction))
                        {
                            cmdProduct.Parameters.AddWithValue("@id", generatedId); // Utilise l'ID généré
                            cmdProduct.Parameters.AddWithValue("@prixAchat", monProduit.BuyPrice);
                            cmdProduct.Parameters.AddWithValue("@quantite", monProduit.Quantity);
                            cmdProduct.Parameters.AddWithValue("@id_fournisseur", monProduit.Fournisseur.Id);

                            cmdProduct.ExecuteNonQuery();
                        }

                        // Valider la transaction
                        transaction.Commit();

                        // Recharger les articles après insertion
                        loadArticles();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback(); // Annuler les modifications en cas d'erreur
                        MessageBox.Show($"Erreur lors de l'insertion des données : {ex.Message}");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la création de l'objet : {ex.Message}");
            }
        }

        public void updArticle(int id, string name, decimal price, decimal buyprice, int quantity, Societe society, string description = null)
        {
            try
            {
                Produits monProduit = new Produits(id, name, description, price, buyprice, quantity, society);

                using (SQLiteTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        // Mise à jour dans la table Designations
                        string designationQuery = @"UPDATE Designations SET libelle = @name, description = @description, prix = @price WHERE id = @id;";

                        using (SQLiteCommand cmdDesignation = new SQLiteCommand(designationQuery, connection, transaction))
                        {
                            cmdDesignation.Parameters.AddWithValue("@name", monProduit.Libelle);
                            cmdDesignation.Parameters.AddWithValue("@description", monProduit.Description ?? (object)DBNull.Value);
                            cmdDesignation.Parameters.AddWithValue("@price", monProduit.Prix);
                            cmdDesignation.Parameters.AddWithValue("@id", monProduit.Id);

                            cmdDesignation.ExecuteNonQuery();
                        }

                        // Mise à jour dans la table Produits
                        string produitQuery = @"UPDATE Produits SET prixAchat = @buyPrice, quantite = @quantity, id_fournisseur = @supplyId WHERE id = @id;";

                        using (SQLiteCommand cmdProduct = new SQLiteCommand(produitQuery, connection, transaction))
                        {
                            cmdProduct.Parameters.AddWithValue("@id", monProduit.Id);
                            cmdProduct.Parameters.AddWithValue("@buyPrice", monProduit.BuyPrice);
                            cmdProduct.Parameters.AddWithValue("@quantity", monProduit.Quantity);
                            cmdProduct.Parameters.AddWithValue("@supplyId", monProduit.Fournisseur.Id);

                            cmdProduct.ExecuteNonQuery();
                        }

                        // Valider la transaction
                        transaction.Commit();

                        // Recharger les articles après mise à jour
                        loadArticles();
                    }
                    catch (Exception ex)
                    {
                        // Annuler la transaction en cas d'échec
                        transaction.Rollback();
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
