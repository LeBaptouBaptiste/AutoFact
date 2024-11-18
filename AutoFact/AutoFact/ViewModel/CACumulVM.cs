using System.Data.SQLite;
using System;
using System.Collections.Generic;
using System.Data;
using AutoFact.Models;
using System.Transactions;

namespace AutoFact.ViewModel
{
    internal class CACumulVM
    {
        // Liste des factures
        private List<Contrats> listContrats = new List<Contrats>();

        // Connexion SQLite
        private SQLiteConnection connection;

        public CACumulVM()
        {
            InitializeDatabase(); // Connexion à la base de données
        }
        private void InitializeDatabase()
        {
            DataBaseManager data = DataBaseManager.getInstance(); // Récupère l'instance du gestionnaire de base de données
            this.connection = data.getConnection(); // Connexion à SQLite
        }

        public List<Contrats> getFactures(DateTime StartDate, DateTime EndDate)
        {
            listContrats.Clear();
            try
            {
                // Requête SQLite pour récupérer la refence et le prix total de chaque factures dans l'interval donné
                string facturesQuery = @"SELECT Contrats.reference, ServicesClients.prix * ServicesClients.quantité as prixTotal FROM ServicesClients INNER JOIN Contrats ON Contrats.reference = ServicesClients.reference INNER JOIN StatutsContrats ON Contrats.reference = StatutsContrats.reference WHERE StatutsContrats.etat = 5 AND StatutsContrats.dateAction BETWEEN @StartDate AND @EndDate;";

                using (SQLiteCommand cmdFactures = new SQLiteCommand(facturesQuery, connection))
                {
                    cmdFactures.Parameters.AddWithValue("@StartDate", StartDate.ToString("yyyy-MM-dd HH:mm:ss"));
                    cmdFactures.Parameters.AddWithValue("@EndDate", EndDate.ToString("yyyy-MM-dd HH:mm:ss"));

                    using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmdFactures))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable); // Remplit le DataTable avec les données

                        // Parcourt les lignes du DataTable et crée les objets Contrats
                        foreach (DataRow row in dataTable.Rows)
                        {
                            string reference = row["reference"].ToString();
                            decimal prix = Convert.ToDecimal(row["prixTotal"]);

                            // Création du produit et ajout au ComboBox et à la liste
                            Contrats contrat = new Contrats(reference, prix);
                            listContrats.Add(contrat);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement des données : {ex.Message}", "Erreur de chargement");
            }

            return listContrats;
        }

    }
}
