using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoFact.Models;
using AutoFact.ViewModel;

namespace AutoFact.Views
{
    public partial class ClientShow : Form
    {
        ClientVM clientvm;
        List<Particuliers> listClients;
        public ClientShow()
        {
            InitializeComponent();
            clientvm = new ClientVM();
            listClients = clientvm.getClients();
        }

        private void ClientShow_Load(object sender, EventArgs e)
        {
            DataTable data = clientvm.getClientsForDGV();
            ClientsDGV.DataSource = data;
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            Client form = new Client();
            form.Show();
            this.Hide();
        }

        private void UpdBtn_Click (object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == ClientsDGV.Columns["update"].Index)
            {
                Client form = new Client(listClients[e.RowIndex]);
                form.Show();
                this.Hide();
            }
        }
    }
}
