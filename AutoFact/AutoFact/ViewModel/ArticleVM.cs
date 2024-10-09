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

namespace AutoFact.ViewModel
{
    internal class ArticleVM
    {
        private List<Produits> articleList;
        private MySqlConnection connection;

        public ArticleVM(ComboBox box, List<Societe> societeList)
        {
            articleList = new List<Produits>();
            InitializeDatabase();
            loadArticles(box, societeList);
        }

        private void InitializeDatabase()
        {
            DataBaseManager data = DataBaseManager.getInstance();
            this.connection = data.getConnection();
        }

        private void loadArticles(ComboBox box, List<Societe> societeList)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT Designations.id, prixAchat, quantite, id_fournisseur, libelle, prix FROM Produits INNER JOIN Designations ON Produits.id = Designations.id;", connection);
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

                    int fournisseur = 0;
                    foreach (Societe societe in societeList)
                    {
                        if (societe.Id == idFournisseur)
                        {
                            break;
                        }
                    fournisseur += 1;
                    }

                    Produits product = new Produits(id, libelle, price, buyPrice, quantity, societeList[fournisseur]);
                    box.Items.Add(product.Libelle);
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
                        string designationQuery = "INSERT INTO Designations(libelle, prix) VALUES(@libelle, @prix); SELECT LAST_INSERT_ID();";

                        using (MySqlCommand cmdDesignation = new MySqlCommand(designationQuery, connection, transaction))
                        {
                            cmdDesignation.Parameters.AddWithValue("@libelle", monProduit.Libelle);
                            cmdDesignation.Parameters.AddWithValue("@prix", monProduit.Prix);

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
    }
}
