using System;
using System.Data;
using System.Data.SQLite;
using System.IO;

namespace AutoFact.Models
{
    internal class DataBaseManager
    {
        private static DataBaseManager instance = null;
        private SQLiteConnection connection;

        private DataBaseManager()
        {
            string databasePath = "DBAutofact.db"; // Fichier SQLite
            string connectionString = $"Data Source={databasePath};Version=3;";

            if (!File.Exists(databasePath))
            {
                SQLiteConnection.CreateFile(databasePath); // Crée le fichier si non existant
                Console.WriteLine("Fichier de base de données SQLite créé.");
            }

            connection = new SQLiteConnection(connectionString);

            try
            {
                connection.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur de connexion à la base de données : {ex.Message}");
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

        public SQLiteConnection getConnection()
        {
            return connection;
        }
    }
}