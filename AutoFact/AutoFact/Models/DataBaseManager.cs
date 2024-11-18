using System;
using System.Data;
using System.Data.SQLite;
using System.IO;

namespace AutoFact.Models
{
    internal class DataBaseManager
    {
        // Instance unique (singleton)
        private static DataBaseManager instance = null;

        // Connexion SQLite à la base de données
        private SQLiteConnection connection;

        // Constructeur privé pour initialiser la connexion à la base de données
        private DataBaseManager()
        {
            string databasePath = "DBAutofact.db"; // Fichier SQLite
            string connectionString = $"Data Source={databasePath};Version=3;"; // Chaîne de connexion

            // Crée le fichier si il n'existe pas
            if (!File.Exists(databasePath))
            {
                SQLiteConnection.CreateFile(databasePath);
                Console.WriteLine("Fichier de base de données SQLite créé.");
            }

            connection = new SQLiteConnection(connectionString);

            try
            {
                connection.Open(); // Tente d'ouvrir la connexion
            }
            catch (Exception ex)
            {
                // Affiche un message d'erreur en cas de problème
                MessageBox.Show($"Erreur de connexion à la base de données : {ex.Message}");
            }
        }

        // Retourne l'instance unique de la classe (singleton)
        public static DataBaseManager getInstance()
        {
            if (DataBaseManager.instance == null)
            {
                DataBaseManager.instance = new DataBaseManager();
            }
            return DataBaseManager.instance;
        }

        // Retourne la connexion à la base de données
        public SQLiteConnection getConnection()
        {
            return connection;
        }
    }
}