using AutoFact.Models;
using AutoFact.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoFact.Views
{
    public partial class ServiceShow : Form
    {
        ServiceVM servicevm;
        List<Services> listServices;
        public ServiceShow()
        {
            InitializeComponent();
            servicevm = new ServiceVM();
            listServices = servicevm.getServices();
        }

        private void ServicesShow_Load(object sender, EventArgs e)
        {
            DataTable data = servicevm.getServicesForDGV();
            ServicesDGV.DataSource = data;
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            Service form = new Service();
            form.Show();
            this.Hide();
        }

        private void UpdBtn_Click(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == ServicesDGV.Columns["update"].Index)
            {
                Service form = new Service(listServices[e.RowIndex]);
                form.Show();
                this.Hide();
            }
        }
    }
}
