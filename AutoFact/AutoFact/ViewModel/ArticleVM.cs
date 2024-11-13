using MySqlConnector;
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
        private MySqlConnection connection;
        private ComboBox box;
        private List<Societe> societeList;

        public ArticleVM(ComboBox box, List<Societe> societeList)
        {
            this.box = box;
            this.societeList = societeList;
            InitializeDatabase();
            loadArticles();
        }

        public ArticleVM(ComboBox box)
        {
            this.box = box;
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

                MySqlCommand cmd = new MySqlCommand("SELECT Designations.id, prixAchat, quantite, id_fournisseur, libelle, prix, description FROM Produits INNER JOIN Designations ON Produits.id = Designations.id;", connection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
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

        public void addArticle(string name, decimal price, decimal buyprice, int quantity, Societe society)
        {
            try
            {
                Produits monProduit = new Produits(name, price, buyprice, quantity, society);

                using (MySqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string designationQuery = "INSERT INTO Designations(libelle, prix, description) VALUES(@libelle, @prix, @description); SELECT LAST_INSERT_ID();";

                        using (MySqlCommand cmdDesignation = new MySqlCommand(designationQuery, connection, transaction))
                        {
                            cmdDesignation.Parameters.AddWithValue("@libelle", monProduit.Libelle);
                            cmdDesignation.Parameters.AddWithValue("@prix", monProduit.Prix);
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
                        }

                        transaction.Commit();
                        loadArticles();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show(ex.Message);
                        MessageBox.Show("Probleme lors de l'insertion des données");
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Probleme lors de la creation de l'objet");
            }
        }

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
                        }

                        transaction.Commit();
                        loadArticles();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show(ex.Message);
                        MessageBox.Show("Probleme lors de l'insertion des données");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Probleme lors de la creation de l'objet");
            }
        }
    }
}
