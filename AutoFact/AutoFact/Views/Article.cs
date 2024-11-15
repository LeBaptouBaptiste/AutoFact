using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using AutoFact.ViewModel;
using AutoFact.Models;

namespace AutoFact.Views
{
    public partial class Article : Form
    {
        // Texte par défaut pour les champs de saisie
        private string nameTxt = "Nom";
        private string priceTxt = "Prix Unitaire";
        private string buypriceTxt = "Prix d'achat";
        private string quantityTxt = "Quantité";
        private string supplyTxt = "Fournisseur";
        private string articleTxt = "Article";
        private string descriptionTxt = "Description";

        private ArticleVM articlevm;
        private List<Societe> listSupply;
        private List<Produits> listProducts;

        public Article()
        {
            InitializeComponent();

            // Initialisation des objets viewmodel et de la liste des fournisseurs
            SocieteVM societevm = new SocieteVM(SupplyCB);
            listSupply = societevm.getSupplys();
            articlevm = new ArticleVM(ArticleCB, listSupply);
            listProducts = articlevm.getProducts();
        }

        // Gestion des clics dans les champs de saisie
        private void NameTB_Clicked(object sender, EventArgs e) => HandleFieldClick(sender, nameTxt);
        private void PriceTB_Clicked(object sender, EventArgs e) => HandleFieldClick(sender, priceTxt);
        private void BuypriceTB_Clicked(object sender, EventArgs e) => HandleFieldClick(sender, buypriceTxt);
        private void QuantityTB_Clicked(object sender, EventArgs e) => HandleFieldClick(sender, quantityTxt);
        private void DescriptionTB_Clicked(object sender, EventArgs e) => HandleFieldClick(sender, descriptionTxt);

        // Méthode générique pour gérer les clics sur les champs de saisie
        private void HandleFieldClick(object sender, string defaultText)
        {
            TextBox textBox = sender as TextBox;
            if (textBox.Text == defaultText)
            {
                Resets(sender, EventArgs.Empty);
                textBox.Text = string.Empty;
                ChangeText(sender, EventArgs.Empty, true);
                this.ActiveControl = textBox;
            }
        }

        // Changement de sélection pour le fournisseur
        private void SupplyCB_Changed(object sender, EventArgs e)
        {
            if (SupplyCB.SelectedIndex != -1)
            {
                Resets(sender, EventArgs.Empty);
                ChangeText(sender, EventArgs.Empty, true);
                this.ActiveControl = null;
            }
        }

        // Changement de sélection pour l'article
        private void ArticleCB_Changed(object sender, EventArgs e)
        {
            if (ArticleCB.SelectedIndex != -1)
            {
                int id = ArticleCB.SelectedIndex;
                ChangeText(sender, EventArgs.Empty, true);
                this.ActiveControl = null;

                // Effacer les champs avant de remplir les données
                ClearFields();

                // Remplir les champs avec les données de l'article sélectionné
                NameTB.Text = listProducts[id].Libelle;
                PriceTB.Text = listProducts[id].Prix.ToString();
                BuypriceTB.Text = listProducts[id].BuyPrice.ToString();
                QuantityTB.Text = listProducts[id].Quantity.ToString();
                SupplyCB.SelectedIndex = listSupply.IndexOf(listProducts[id].Fournisseur);
                DescriptionTB.Text = listProducts[id].Description ?? string.Empty;

                // Mettre à jour l'apparence des champs
                UpdateFieldAppearance();
            }
        }

        // Méthode pour effacer les champs de saisie
        private void ClearFields()
        {
            NameTB.Clear();
            PriceTB.Clear();
            BuypriceTB.Clear();
            QuantityTB.Clear();
            DescriptionTB.Clear();
        }

        // Mise à jour de l'apparence des champs (couleur du texte)
        private void UpdateFieldAppearance()
        {
            ChangeText(NameTB, EventArgs.Empty, true);
            ChangeText(PriceTB, EventArgs.Empty, true);
            ChangeText(BuypriceTB, EventArgs.Empty, true);
            ChangeText(QuantityTB, EventArgs.Empty, true);
            ChangeText(SupplyCB, EventArgs.Empty, true);
            if (!string.IsNullOrEmpty(DescriptionTB.Text))
            {
                ChangeText(DescriptionTB, EventArgs.Empty, true);
            }
        }

        // Changement de la couleur du texte des contrôles
        private void ChangeText(object sender, EventArgs e, bool able)
        {
            Control obj = sender as Control;
            obj.ForeColor = able ? Color.Black : Color.Silver;
        }

        // Réinitialisation des champs de saisie
        private void Resets(object sender, EventArgs e)
        {
            ResetField(NameTB, nameTxt, e);
            ResetField(PriceTB, priceTxt, e);
            ResetField(BuypriceTB, buypriceTxt, e);
            ResetField(QuantityTB, quantityTxt, e);
            ResetField(DescriptionTB, descriptionTxt, e);
            ResetComboBox(SupplyCB, supplyTxt, e);
            ResetComboBox(ArticleCB, articleTxt, e);
            this.ActiveControl = null;
        }

        // Réinitialisation d'un champ de texte
        private void ResetField(TextBox textBox, string defaultText, EventArgs e)
        {
            if (textBox.Text == string.Empty)
            {
                textBox.Text = defaultText;
                ChangeText(textBox, e, false);
            }
        }

        // Réinitialisation d'une ComboBox
        private void ResetComboBox(ComboBox comboBox, string defaultText, EventArgs e)
        {
            if (comboBox.SelectedIndex == -1)
            {
                comboBox.Text = defaultText;
                ChangeText(comboBox, e, false);
            }
        }

        // Ajout d'un nouvel article
        private void Add_Clicked(object sender, EventArgs e)
        {
            if (IsValidArticleInput())
            {
                try
                {
                    string name = NameTB.Text;
                    decimal price = Convert.ToDecimal(PriceTB.Text);
                    decimal buyprice = Convert.ToDecimal(BuypriceTB.Text);
                    int quantity = Convert.ToInt32(QuantityTB.Text);
                    Societe society = listSupply[SupplyCB.SelectedIndex];

                    string description = DescriptionTB.Text != descriptionTxt ? DescriptionTB.Text : null;
                    articlevm.addArticle(name, price, buyprice, quantity, society, description);

                    ClearFields();
                    SupplyCB.SelectedIndex = -1;
                    Resets(this, EventArgs.Empty);

                    // Rafraîchir la liste des produits
                    listProducts = articlevm.getProducts();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    MessageBox.Show("La valeur entrée dans le champs 'Nom' ou 'Prix Unitaire' n'est pas valide");
                }
            }
        }

        // Mise à jour d'un article existant
        private void Upd_Clicked(object sender, EventArgs e)
        {
            if (IsValidArticleInput() && ArticleCB.SelectedIndex != -1)
            {
                try
                {
                    int id = listProducts[ArticleCB.SelectedIndex].Id;
                    string name = NameTB.Text;
                    decimal price = Convert.ToDecimal(PriceTB.Text);
                    decimal buyprice = Convert.ToDecimal(BuypriceTB.Text);
                    int quantity = Convert.ToInt32(QuantityTB.Text);
                    Societe society = listSupply[SupplyCB.SelectedIndex];

                    string description = DescriptionTB.Text != descriptionTxt ? DescriptionTB.Text : null;
                    articlevm.updArticle(id, name, price, buyprice, quantity, society, description);

                    // Réinitialiser après mise à jour
                    ArticleCB.SelectedIndex = -1;
                    ClearFields();
                    SupplyCB.SelectedIndex = -1;
                    Resets(this, EventArgs.Empty);

                    // Rafraîchir la liste des produits
                    listProducts = articlevm.getProducts();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    MessageBox.Show("La valeur entrée dans le champs 'Nom' ou 'Prix Unitaire' n'est pas valide");
                }
            }
        }

        // Vérification que l'entrée de l'article est valide
        private bool IsValidArticleInput()
        {
            return NameTB.Text != string.Empty && NameTB.Text != nameTxt &&
                   PriceTB.Text != string.Empty && PriceTB.Text != priceTxt &&
                   BuypriceTB.Text != null && BuypriceTB.Text != buypriceTxt &&
                   QuantityTB.Text != null && QuantityTB.Text != quantityTxt &&
                   SupplyCB.SelectedIndex > -1;
        }
    }
}