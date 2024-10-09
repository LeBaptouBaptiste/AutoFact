using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoFact.ViewModel
{
    internal class SocieteVM
    {
        private List<Societe> societeList;
        private MySqlConnection connection;

        public SocieteVM(ComboBox box)
        {
            societeList = new List<Societe>();
            InitializeDatabase();
            loadSupplys(box);

        }

        private void InitializeDatabase()
        {
            DataBaseManager data = DataBaseManager.getInstance();
            this.connection = data.getConnection();
        }

        private void loadSupplys(ComboBox box)
        {
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
                    box.Items.Add(society.Name);
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
            return this.societeList;
        }
    }
}
