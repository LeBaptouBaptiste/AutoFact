using AutoFact.Views;
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
    internal class ServiceVM
    {
        private List<Services> serviceList;
        private MySqlConnection connection;
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
                MySqlCommand cmd = new MySqlCommand("SELECT Designations.id, libelle, prix, duree, description FROM Services INNER JOIN Designations ON Services.id = Designations.id;", connection);
                MySqlDataAdapter adapter = new MySqlDataAdapter(cmd);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                foreach (DataRow row in dataTable.Rows)
                {
                    int id = Convert.ToInt32(row["id"]);
                    string name = row["libelle"].ToString();
                    decimal price = Convert.ToDecimal(row["prix"]);
                    string description = row["description"].ToString();

                    Services service = new Services(id, name, price, description);

                    if (row["duree"] != DBNull.Value)
                    {
                        int duration = Convert.ToInt32(row["duree"]);
                        service.Duration = duration;
                        service.HaveDuration = true;
                    }

                    this.box.Items.Add(service.Libelle);
                    serviceList.Add(service);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement des données : {ex.Message}", "Erreur de chargement");
            }
        }

        public List<Services> getServices()
        {
            this.serviceList.Clear();
            loadServices();
            return this.serviceList;
        }

        public void AddService(string name, decimal price, int duration, string description)
        {
            try
            {
                Services myService = new Services(name, price, duration, description = null);


                using (MySqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string designationQuery = "INSERT INTO Designations(libelle, description, prix) VALUES(@libelle, @description, @prix); SELECT LAST_INSERT_ID();";

                        using (MySqlCommand cmdDesignation = new MySqlCommand(designationQuery, connection, transaction))
                        {
                            cmdDesignation.Parameters.AddWithValue("@libelle", myService.Libelle);
                            cmdDesignation.Parameters.AddWithValue("@description", myService.Description);
                            cmdDesignation.Parameters.AddWithValue("@prix", myService.Prix);

                            int generatedId = Convert.ToInt32(cmdDesignation.ExecuteScalar());

                            string serviceQuery = "INSERT INTO Services(id, duree) VALUES(@id, @duration)";
                            using (MySqlCommand cmdService = new MySqlCommand(serviceQuery, connection, transaction))
                            {
                                cmdService.Parameters.AddWithValue("@id", generatedId); // Utiliser l'ID généré
                                cmdService.Parameters.AddWithValue("@duration", myService.Duration);
                                
                                cmdService.ExecuteNonQuery();
                            }
                        }

                        transaction.Commit();
                        loadServices();
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
        public void AddServiceWithoutDuration(string name, decimal price, string description = null)
        {
            try
            {
                Services myService = new Services(name, price, description);


                using (MySqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string designationQuery = "INSERT INTO Designations(libelle, description, prix) VALUES(@libelle, @description, @prix); SELECT LAST_INSERT_ID();";

                        using (MySqlCommand cmdDesignation = new MySqlCommand(designationQuery, connection, transaction))
                        {
                            cmdDesignation.Parameters.AddWithValue("@libelle", myService.Libelle);
                            cmdDesignation.Parameters.AddWithValue("@description", myService.Description);
                            cmdDesignation.Parameters.AddWithValue("@prix", myService.Prix);

                            int generatedId = Convert.ToInt32(cmdDesignation.ExecuteScalar());

                            string serviceQuery = "INSERT INTO Services(id) VALUES(@id)";
                            using (MySqlCommand cmdService = new MySqlCommand(serviceQuery, connection, transaction))
                            {
                                cmdService.Parameters.AddWithValue("@id", generatedId); // Utiliser l'ID généré

                                cmdService.ExecuteNonQuery();
                            }
                        }

                        transaction.Commit();
                        loadServices();
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
        public void UpdService(int id, string name, decimal price, int duration, string description = null)
        {
            try
            {
                Services myService = new Services(id, name, price, duration, description);


                using (MySqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string designationQuery = "UPDATE Designations SET libelle = @name, description = @description, prix = @price WHERE id = @id;";

                        using (MySqlCommand cmdDesignation = new MySqlCommand(designationQuery, connection, transaction))
                        {
                            cmdDesignation.Parameters.AddWithValue("@name", myService.Libelle);
                            cmdDesignation.Parameters.AddWithValue("@description", myService.Description);
                            cmdDesignation.Parameters.AddWithValue("@price", myService.Prix);
                            cmdDesignation.Parameters.AddWithValue("@id", myService.Id);

                            cmdDesignation.ExecuteNonQuery();

                            string serviceQuery = "UPDATE Services SET duree = @duration WHERE id = @id";
                            using (MySqlCommand cmdService = new MySqlCommand(serviceQuery, connection, transaction))
                            {
                                cmdService.Parameters.AddWithValue("@duration", myService.Duration);
                                cmdService.Parameters.AddWithValue("@id", myService.Id);

                                cmdService.ExecuteNonQuery();
                            }
                        }

                        transaction.Commit();
                        loadServices();
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

        public void UpdServiceWithoutDuration(int id, string name, decimal price, string description = null)
        {
            try
            {
                Services myService = new Services(id, name, price, description);


                using (MySqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        string designationQuery = "UPDATE Designations SET libelle = @name, description = @description, prix = @price WHERE id = @id;";

                        using (MySqlCommand cmdDesignation = new MySqlCommand(designationQuery, connection, transaction))
                        {
                            cmdDesignation.Parameters.AddWithValue("@name", myService.Libelle);
                            cmdDesignation.Parameters.AddWithValue("@description", myService.Description);
                            cmdDesignation.Parameters.AddWithValue("@price", myService.Prix);
                            cmdDesignation.Parameters.AddWithValue("@id", myService.Id);

                            cmdDesignation.ExecuteNonQuery();
                        }

                        transaction.Commit();
                        loadServices();
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
