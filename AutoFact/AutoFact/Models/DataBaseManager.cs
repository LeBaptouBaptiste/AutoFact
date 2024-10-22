using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;

namespace AutoFact.Models
{
    internal class DataBaseManager
    {
        private static DataBaseManager instance = null;
        private MySqlConnection connection;

        private DataBaseManager()
        {
            var builder = new MySqlConnectionStringBuilder
            {
                //Server = "172.16.119.56",
                Server = "192.168.1.170",
                //Server = "192.168.56.5",
                Port = 20125,
                UserID = "adminAutofact",
                Password = "AjXg$%Auc~B?K\"fl5q#.#aYbG",
                Database = "Autofact",
            };
            connection = new MySqlConnection(builder.ConnectionString);
            try
            {
                connection.Open();
                Console.WriteLine("Connexion à la base de données réussie!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur de connexion à la base de données : {ex.Message}", "Erreur de connexion");
            }
        }

        public static DataBaseManager getInstance()
        {
            if (DataBaseManager.instance == null)
            {
                DataBaseManager.instance = new DataBaseManager();
            }
            return DataBaseManager.instance;
        }

        public MySqlConnection getConnection()
        {
            return connection;
        }
    }
}
