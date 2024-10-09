using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoFact.ViewModel;
using MySqlConnector;

namespace AutoFact
{
    public partial class Article : Form
    {
        private BackgroundPanel backgroundPanel;
        private string nameTxt = "Nom";
        private string priceTxt = "Prix Unitaire";
        private string buypriceTxt = "Prix d'achat";
        private string quantityTxt = "Quantitée";
        private string supplyTxt = "Fournisseur";

        private ArticleVM articlevm;
        private List<Societe> listSupply;

        public Article()
        {
            InitializeComponent();
            SocieteVM societevm = new SocieteVM(SupplyCB);
            listSupply = societevm.getSupplys();
            articlevm = new ArticleVM(ArticleCB, listSupply);
        }

        private void NameTB_Clicked(object sender, EventArgs e)
        {
            if (NameTB.Text == nameTxt)
            {
                NameTB.Text = string.Empty;
                ChangeText(sender, e, true);
            }
        }

        private void PriceTB_Clicked(object sender, EventArgs e)
        {
            if (PriceTB.Text == priceTxt)
            {
                PriceTB.Text = string.Empty;
                ChangeText(sender, e, true);
            }
        }

        private void BuypriceTB_Clicked(object sender, EventArgs e)
        {
            if (BuypriceTB.Text == buypriceTxt)
            {
                BuypriceTB.Text = string.Empty;
                ChangeText(sender, e, true);
            }
        }

        private void QuantityTB_Clicked(object sender, EventArgs e)
        {
            if (QuantityTB.Text == quantityTxt)
            {
                QuantityTB.Text = string.Empty;
                ChangeText(sender, e, true);
            }
        }

        private void ChangeText(object sender, EventArgs e, bool able)
        {
            Control tb = sender as Control;

            if(able)
            {
                tb.ForeColor = Color.Black;
            }
            else
            {
                tb.ForeColor = Color.Silver;
            }
        }

        private void Form_clicked(object sender, EventArgs e)
        {
            if (NameTB.Text == string.Empty)
            {
                NameTB.Text = nameTxt;
                ChangeText(NameTB, e, false);
            }
            if (PriceTB.Text == string.Empty)
            {
                PriceTB.Text = priceTxt;
                ChangeText(PriceTB, e, false);
            }
            if (BuypriceTB.Text == string.Empty)
            {
                BuypriceTB.Text = buypriceTxt;
                ChangeText(BuypriceTB, e, false);
            }
            if (QuantityTB.Text == string.Empty)
            {
                QuantityTB.Text = quantityTxt;
                ChangeText(QuantityTB, e, false);
            }
            if(SupplyCB.SelectedIndex == -1)
            {
                SupplyCB.Text = supplyTxt;
                ChangeText(SupplyCB, e, false);
            }
            this.ActiveControl = null;
        }

        private void Add_Clicked(object sender, EventArgs e)
        {
            if (NameTB.Text != string.Empty && NameTB.Text != nameTxt && PriceTB.Text != string.Empty && PriceTB.Text != priceTxt && BuypriceTB.Text != null && BuypriceTB.Text != buypriceTxt && QuantityTB.Text != null && QuantityTB.Text != quantityTxt && SupplyCB.SelectedIndex > -1)
            {
                try
                {
                    string name = NameTB.Text;
                    decimal price = Convert.ToDecimal(PriceTB.Text);
                    decimal buyprice = Convert.ToDecimal(BuypriceTB.Text);
                    int quantity = Convert.ToInt32(QuantityTB.Text);
                    Societe society = listSupply[SupplyCB.SelectedIndex];

                    articlevm.addArticle(name, price, buyprice, quantity, society);

                    Form_clicked(this, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    MessageBox.Show("La valeur entrée dans le champs 'Nom' ou le champs 'Prix Unitaire' n'est pas valide");
                }
            }
        }
    }
}
