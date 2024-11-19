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
    public partial class SupplierShow : Form
    {
        SocieteVM societevm;
        List<Societe> listSuppliers;
        public SupplierShow()
        {
            InitializeComponent();
            societevm = new SocieteVM();
            listSuppliers = societevm.getSupplys();
        }

        private void SupplierShow_Load(object sender, EventArgs e)
        {
            DataTable data = societevm.getSuppliersForDGV();
            SuppliersDGV.DataSource = data;
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            Supplier form = new Supplier();
            form.Show();
            this.Hide();
        }

        private void UpdBtn_Click(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == SuppliersDGV.Columns["update"].Index)
            {
                Supplier form = new Supplier(listSuppliers[e.RowIndex]);
                form.Show();
                this.Hide();
            }
        }
    }
}
