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
        private List<Particuliers> clientList;
        private MySqlConnection connection;
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
                MySqlCommand cmd = new MySqlCommand("SELECT Clients.id, civilitee, adresse, cp, tel, mail, nom, prenom FROM Particuliers INNER JOIN Clients ON Particuliers.id = Clients.id;", connection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

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

                    Particuliers particulier = new Particuliers(id, nom, adresse, cp, tel, mail, civilitee, prenom);
                    this.box.Items.Add($"{particulier.Name} {particulier.FirstName}");
                    clientList.Add(particulier);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement des données : {ex.Message}", "Erreur de chargement");
            }
        }

        public List<Particuliers> getClients()
        {
            this.clientList.Clear();
            this.box.Items.Clear();
            loadClients();
            return this.clientList;
        }

        public void AddClients(string name, string mail, string phone, string address, string cp, string civility, string firstName)
        {
            try
            {
                Particuliers myClient = new Particuliers(name, address, cp, phone, mail, civility, firstName);


                using (MySqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string clientQuery = "INSERT INTO Clients(nom, mail, tel, adresse, cp) VALUES(@name, @mail, @phone, @address, @cp); SELECT LAST_INSERT_ID();";

                        using (MySqlCommand cmdClient = new MySqlCommand(clientQuery, connection, transaction))
                        {
                            cmdClient.Parameters.AddWithValue("@name", myClient.Name);
                            cmdClient.Parameters.AddWithValue("@mail", myClient.Mail);
                            cmdClient.Parameters.AddWithValue("@phone", myClient.Phone);
                            cmdClient.Parameters.AddWithValue("@address", myClient.Address);
                            cmdClient.Parameters.AddWithValue("@cp", myClient.PostalCode);

                            int generatedId = Convert.ToInt32(cmdClient.ExecuteScalar());

                            string individualQuery = "INSERT INTO Particuliers(id, civilitee, prenom) VALUES(@id, @civility, @firstName);";
                            using (MySqlCommand cmdIndividual = new MySqlCommand(individualQuery, connection, transaction))
                            {
                                cmdIndividual.Parameters.AddWithValue("@id", generatedId); // Utiliser l'ID généré
                                cmdIndividual.Parameters.AddWithValue("@civility", myClient.Civility);
                                cmdIndividual.Parameters.AddWithValue("@fisrtName", myClient.FirstName);

                                cmdIndividual.ExecuteNonQuery();
                            }
                        }

                        transaction.Commit();
                        loadClients();
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
        public void UpdClients(int id, string name, string mail, string phone, string address, string cp, string civility, string firstName)
        {
            try
            {
                Particuliers myClient = new Particuliers(id, name, address, cp, phone, mail, civility, firstName);


                using (MySqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string ClientQuery = "UPDATE Clients SET nom = @name, mail = @mail, tel = @phone, adresse = @address, cp = @cp WHERE id = @id;";

                        using (MySqlCommand cmdClient = new MySqlCommand(ClientQuery, connection, transaction))
                        {
                            cmdClient.Parameters.AddWithValue("@name", myClient.Name);
                            cmdClient.Parameters.AddWithValue("@mail", myClient.Mail);
                            cmdClient.Parameters.AddWithValue("@phone", myClient.Phone);
                            cmdClient.Parameters.AddWithValue("@address", myClient.Address);
                            cmdClient.Parameters.AddWithValue("@cp", myClient.PostalCode);
                            cmdClient.Parameters.AddWithValue("@id", myClient.Id);

                            cmdClient.ExecuteNonQuery();

                            string individualQuery = "UPDATE Particuliers SET civilitee = @civility, prenom = @firstName WHERE id = @id";
                            using (MySqlCommand cmdIndividual = new MySqlCommand(individualQuery, connection, transaction))
                            {
                                cmdIndividual.Parameters.AddWithValue("@id", myClient.Id);
                                cmdIndividual.Parameters.AddWithValue("@civility", myClient.Civility);
                                cmdIndividual.Parameters.AddWithValue("@firstName", myClient.FirstName);

                                cmdIndividual.ExecuteNonQuery();
                            }
                        }

                        transaction.Commit();
                        loadClients();
                    }
                    catch (Exception ex)
                    {
                        transaction.Rollback();
                        MessageBox.Show($"Probleme lors de l'insertion des données :{ex.Message}");
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
