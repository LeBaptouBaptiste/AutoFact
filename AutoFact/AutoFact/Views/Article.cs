using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
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
        private string articleTxt = "Article";

        private ArticleVM articlevm;
        private List<Societe> listSupply;
        private List<Produits> listProducts;

        public Article()
        {
            InitializeComponent();
            SocieteVM societevm = new SocieteVM(SupplyCB);
            listSupply = societevm.getSupplys();
            articlevm = new ArticleVM(ArticleCB, listSupply);
            listProducts = articlevm.getProducts();
        }

        private void NameTB_Clicked(object sender, EventArgs e)
        {
            if (NameTB.Text == nameTxt)
            {
                Resets(sender, e);
                NameTB.Text = string.Empty;
                ChangeText(sender, e, true);
                this.ActiveControl = NameTB;
            }
        }

        private void PriceTB_Clicked(object sender, EventArgs e)
        {
            if (PriceTB.Text == priceTxt)
            {
                Resets(sender, e);
                PriceTB.Text = string.Empty;
                ChangeText(sender, e, true);
                this.ActiveControl = PriceTB;
            }
        }

        private void BuypriceTB_Clicked(object sender, EventArgs e)
        {
            if (BuypriceTB.Text == buypriceTxt)
            {
                Resets(sender, e);
                BuypriceTB.Text = string.Empty;
                ChangeText(sender, e, true);
                this.ActiveControl = BuypriceTB;
            }
        }

        private void QuantityTB_Clicked(object sender, EventArgs e)
        {
            if (QuantityTB.Text == quantityTxt)
            {
                Resets(sender, e);
                QuantityTB.Text = string.Empty;
                ChangeText(sender, e, true);
                this.ActiveControl = QuantityTB;
            }
        }

        private void SupplyCB_Changed(object sender, EventArgs e)
        {
            if(SupplyCB.SelectedIndex != -1)
            {
                Resets(sender, e);
                ChangeText(sender, e, true);
                this.ActiveControl = null;
            }
        }

        private void ArticleCB_Changed(Object sender, EventArgs e)
        {
            if (ArticleCB.SelectedIndex != -1)
            {
                int id = ArticleCB.SelectedIndex;

                ChangeText(sender, e, true); 
                this.ActiveControl = null;

                NameTB.Clear();
                PriceTB.Clear();
                BuypriceTB.Clear();
                QuantityTB.Clear();

                NameTB.Text = listProducts[id].Libelle;
                PriceTB.Text = listProducts[id].Prix.ToString();
                BuypriceTB.Text = listProducts[id].BuyPrice.ToString();
                QuantityTB.Text = listProducts[id].Quantity.ToString();
                SupplyCB.SelectedIndex = listSupply.IndexOf(listProducts[id].Fournisseur);

                ChangeText(NameTB, e, true);
                ChangeText(PriceTB, e, true);
                ChangeText(BuypriceTB, e, true);
                ChangeText(QuantityTB, e, true);
                ChangeText(SupplyCB, e, true);
            }
        }

        private void ChangeText(object sender, EventArgs e, bool able)
        {
            Control obj = sender as Control;
                 
            if(able)
            {
                obj.ForeColor = Color.Black;
            }
            else
            {
                obj.ForeColor = Color.Silver;
            }
        }

        private void Resets(object sender, EventArgs e)
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
            if (ArticleCB.SelectedIndex == -1)
            {
                ArticleCB.Text = articleTxt;
                ChangeText(ArticleCB, e, false);
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

                    NameTB.Clear();
                    PriceTB.Clear();
                    BuypriceTB.Clear();
                    QuantityTB.Clear();
                    SupplyCB.SelectedIndex = -1;
                    Resets(this, e);

                    listProducts = articlevm.getProducts();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    MessageBox.Show("La valeur entrée dans le champs 'Nom' ou le champs 'Prix Unitaire' n'est pas valide");
                }
            }
        }

        private void Upd_Clicked(object sender, EventArgs e)
        {
            if (NameTB.Text != string.Empty && NameTB.Text != nameTxt && PriceTB.Text != string.Empty && PriceTB.Text != priceTxt && BuypriceTB.Text != null && BuypriceTB.Text != buypriceTxt && QuantityTB.Text != null && QuantityTB.Text != quantityTxt && SupplyCB.SelectedIndex > -1 && ArticleCB.SelectedIndex != -1)
            {
                try
                {
                    int id = listProducts[ArticleCB.SelectedIndex].Id;
                    string name = NameTB.Text;
                    decimal price = Convert.ToDecimal(PriceTB.Text);
                    decimal buyprice = Convert.ToDecimal(BuypriceTB.Text);
                    int quantity = Convert.ToInt32(QuantityTB.Text);
                    Societe society = listSupply[SupplyCB.SelectedIndex];

                    ArticleCB.SelectedIndex = -1;

                    articlevm.updArticle(id, name, price, buyprice, quantity, society);

                    NameTB.Clear();
                    PriceTB.Clear();
                    BuypriceTB.Clear();
                    QuantityTB.Clear();
                    SupplyCB.SelectedIndex = -1;
                    Resets(this, e);

                    listProducts = articlevm.getProducts();
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
