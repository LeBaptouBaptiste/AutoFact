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

namespace AutoFactTest
{
    public partial class Form1 : Form
    {
        private MySqlConnection connection;
        public Form1()
        {
            InitializeComponent();
            InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            DataBaseManager data = DataBaseManager.getInstance();
            connection = data.getConnection();
        }

        private void boutonCustom_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Bouton cliqué !");
        }

        private void boutonCustom_Enter(object sender, EventArgs e)
        {
            boutonCustom.BackColor = Color.LightBlue;
            boutonCustom.Font = new Font(boutonCustom.Font, FontStyle.Underline);
        }

        private void boutonCustom_Leave(object sender, EventArgs e)
        {
            boutonCustom.BackColor = Color.DarkBlue;
            boutonCustom.Font = new Font(boutonCustom.Font, FontStyle.Regular);
        }
    }
}
