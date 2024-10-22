using MySqlConnector;
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
        private List<Societe> clientList;
        private MySqlConnection connection;
        private ComboBox box;

        public ClientVM(ComboBox box)
        {
            this.box = box;
            clientList = new List<Clients>();
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
                MySqlCommand cmd = new MySqlCommand("SELECT Clients.id, siret, adresse, cp, tel, mail, nom FROM Societes INNER JOIN Clients ON Societes.id = Clients.id;", connection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                foreach (DataRow row in dataTable.Rows)
                {
                    int id = Convert.ToInt32(row["id"]);
                    string siret = row["siret"].ToString();
                    string adresse = row["adresse"].ToString();
                    string cp = row["cp"].ToString();
                    string tel = row["tel"].ToString();
                    string mail = row["mail"].ToString();
                    string nom = row["nom"].ToString();

                    Societe society = new Societe(id, nom, adresse, cp, tel, mail, siret);
                    this.box.Items.Add(society.Name);
                    societeList.Add(society);
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

        public void AddSupplier(string name, string mail, string siret, string phone, string address, string cp)
        {
            try
            {
                Societe mySupplier = new Societe(name, address, cp, phone, mail, siret);


                using (MySqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string clientQuery = "INSERT INTO Clients(nom, mail, tel, adresse, cp) VALUES(@name, @mail, @phone, @address, @cp); SELECT LAST_INSERT_ID();";

                        using (MySqlCommand cmdClient = new MySqlCommand(clientQuery, connection, transaction))
                        {
                            cmdClient.Parameters.AddWithValue("@name", mySupplier.Name);
                            cmdClient.Parameters.AddWithValue("@mail", mySupplier.Mail);
                            cmdClient.Parameters.AddWithValue("@phone", mySupplier.Phone);
                            cmdClient.Parameters.AddWithValue("@address", mySupplier.Address);
                            cmdClient.Parameters.AddWithValue("@cp", mySupplier.PostalCode);

                            int generatedId = Convert.ToInt32(cmdClient.ExecuteScalar());

                            string SupplierQuery = "INSERT INTO Societes(id, siret) VALUES(@id, @siret);";
                            using (MySqlCommand cmdSupplier = new MySqlCommand(SupplierQuery, connection, transaction))
                            {
                                cmdSupplier.Parameters.AddWithValue("@id", generatedId); // Utiliser l'ID généré
                                cmdSupplier.Parameters.AddWithValue("@siret", mySupplier.Siret);

                                cmdSupplier.ExecuteNonQuery();
                            }
                        }

                        transaction.Commit();
                        loadSupplys();
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
        public void UpdSupplier(int id, string name, string mail, string siret, string phone, string address, string cp)
        {
            try
            {
                Societe mySupplier = new Societe(id, name, address, cp, phone, mail, siret);


                using (MySqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string ClientQuery = "UPDATE Clients SET nom = @name, mail = @mail, tel = @phone, adresse = @address, cp = @cp WHERE id = @id;";

                        using (MySqlCommand cmdClient = new MySqlCommand(ClientQuery, connection, transaction))
                        {
                            cmdClient.Parameters.AddWithValue("@name", mySupplier.Name);
                            cmdClient.Parameters.AddWithValue("@mail", mySupplier.Mail);
                            cmdClient.Parameters.AddWithValue("@phone", mySupplier.Phone);
                            cmdClient.Parameters.AddWithValue("@address", mySupplier.Address);
                            cmdClient.Parameters.AddWithValue("@cp", mySupplier.PostalCode);
                            cmdClient.Parameters.AddWithValue("@id", mySupplier.Id);

                            cmdClient.ExecuteNonQuery();

                            string supplierQuery = "UPDATE Societes SET siret = @siret WHERE id = @id";
                            using (MySqlCommand cmdSupplier = new MySqlCommand(supplierQuery, connection, transaction))
                            {
                                cmdSupplier.Parameters.AddWithValue("@id", mySupplier.Id);
                                cmdSupplier.Parameters.AddWithValue("@siret", mySupplier.Siret);

                                cmdSupplier.ExecuteNonQuery();
                            }
                        }

                        transaction.Commit();
                        loadSupplys();
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
