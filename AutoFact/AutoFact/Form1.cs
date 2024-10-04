using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoFact;
using MySqlConnector;

namespace AutoFact
{
    public partial class Form1 : Form
    {
        private BackgroundPanel backgroundPanel;
        private MySqlConnection connection;
        public Form1()
        {
            InitializeComponent();
            InitializeBackground();
            InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            DataBaseManager data = DataBaseManager.getInstance();
            connection = data.getConnection();
        }
        private void InitializeBackground()
        {
            backgroundPanel = new BackgroundPanel();
            backgroundPanel.SetBackgroundImage("C:\\Users\\sipha\\Documents\\GitHub\\AutoFact\\AutoFact\\AutoFact\\background.png"); // Remplacez par le chemin réel de votre image
            backgroundPanel.Dock = DockStyle.Fill; // Remplit toute la fenêtre
            this.Controls.Add(backgroundPanel);
            backgroundPanel.SendToBack(); // Envoie le BackgroundPanel derrière tous les autres contrôles
        }
    }
}