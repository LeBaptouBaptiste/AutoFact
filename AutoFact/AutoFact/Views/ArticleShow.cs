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
    public partial class ArticleShow : Form
    {
        ArticleVM articlevm;
        SocieteVM societevm;
        List<Produits> listArticles;
        List<Societe> listSuppliers;
        public ArticleShow()
        {
            InitializeComponent();
            societevm = new SocieteVM();
            listSuppliers = societevm.getSupplys();
            articlevm = new ArticleVM(listSuppliers);
            listArticles = articlevm.getProducts();
        }

        private void ArticlesShow_Load(object sender, EventArgs e)
        {
            DataTable data = articlevm.getProductsForDGV();
            ArticlesDGV.DataSource = data;
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            Article form = new Article();
            form.Show();
            this.Hide();
        }

        private void UpdBtn_Click(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == ArticlesDGV.Columns["update"].Index)
            {
                Article form = new Article(listArticles[e.RowIndex]);
                form.Show();
                this.Hide();
            }
        }
    }
}
