using AutoFact.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoFact.ViewModel
{
    internal class CAClientVM
    {
        // Liste des Clients
        private List<Contrats> listContrats = new List<Contrats>();

        // Connexion SQLite
        private SQLiteConnection connection;

        public CAClientVM()
        {
            InitializeDatabase(); // Connexion à la base de données
        }
        private void InitializeDatabase()
        {
            DataBaseManager data = DataBaseManager.getInstance(); // Récupère l'instance du gestionnaire de base de données
            this.connection = data.getConnection(); // Connexion à SQLite
        }

        private void load
    }
}
