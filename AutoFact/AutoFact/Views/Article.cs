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
        private SocieteVM societevm;
        private List<Societe> listSupply = new List<Societe>();
        private List<int> listSupplyId = new List<int>();
        private List<Produits> listProducts = new List<Produits>();

        private int idUpd;

        public Article()
        {
            InitializeComponent();
            UpBtn.Hide();

            // Initialisation des objets viewmodel et de la liste des fournisseurs
            SocieteVM societevm = new SocieteVM(SupplyCB);
            listSupply = societevm.getSupplys();
            articlevm = new ArticleVM(listSupply);
            listProducts = articlevm.getProducts();
        }
        public Article(Produits produitUpd)
        {
            InitializeComponent();
            AddBtn.Hide();

            SocieteVM societevm = new SocieteVM(SupplyCB);
            listSupply = societevm.getSupplys();
            listSupplyId = societevm.getSupplysId();

            UpdForm_Load(produitUpd);
            idUpd = produitUpd.Id;

            // Initialisation du ViewModel et récupération des services existants
            articlevm = new ArticleVM(listSupply);
            listProducts = articlevm.getProducts();
        }
        private void UpdForm_Load(Produits produit)
        {
            // Effacer les champs avant de remplir les données
            ClearFields();

            // Remplir les champs avec les données de l'article sélectionné
            NameTB.Text = produit.Libelle;
            PriceTB.Text = produit.Prix.ToString();
            BuypriceTB.Text = produit.BuyPrice.ToString();
            QuantityTB.Text = produit.Quantity.ToString();
            SupplyCB.SelectedIndex = listSupplyId.IndexOf(produit.Fournisseur.Id);
            DescriptionTB.Text = produit.Description ?? string.Empty;

            // Mettre à jour l'apparence des champs
            UpdateFieldAppearance();
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
            CustomTextBox textBox = sender as CustomTextBox;
            if (textBox.Text == defaultText)
            {
                Resets(sender, true);
                textBox.Text = string.Empty;
                ChangeText(sender, true);
                this.ActiveControl = textBox;
            }
        }

        // Changement de sélection pour le fournisseur
        private void SupplyCB_Changed(object sender, EventArgs e)
        {
            if (SupplyCB.SelectedIndex != -1)
            {
                Resets(sender, true);
                ChangeText(sender, true);
                this.ActiveControl = null;
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
            ChangeText(NameTB, true);
            ChangeText(PriceTB, true);
            ChangeText(BuypriceTB, true);
            ChangeText(QuantityTB, true);
            ChangeText(SupplyCB, true);
            if (!string.IsNullOrEmpty(DescriptionTB.Text))
            {
                ChangeText(DescriptionTB, true);
            }
        }

        // Changement de la couleur du texte des contrôles
        private void ChangeText(object sender, bool able)
        {
            Control obj = sender as Control;
            obj.ForeColor = able ? Color.Black : Color.Silver;
        }

        // Réinitialisation des champs de saisie
        private void Resets(object sender, bool resetConctroll)
        {
            ResetField(NameTB, nameTxt);
            ResetField(PriceTB, priceTxt);
            ResetField(BuypriceTB, buypriceTxt);
            ResetField(QuantityTB, quantityTxt);
            ResetField(DescriptionTB, descriptionTxt);
            ResetComboBox(SupplyCB, supplyTxt);
            if (resetConctroll)
            {
                this.ActiveControl = null;
            }
        }

        // Réinitialisation d'un champ de texte
        private void ResetField(CustomTextBox textBox, string defaultText)
        {
            if (textBox.Text == string.Empty)
            {
                textBox.Text = defaultText;
                ChangeText(textBox, false);
            }
        }

        // Réinitialisation d'une ComboBox
        private void ResetComboBox(ComboBox comboBox, string defaultText)
        {
            if (comboBox.SelectedIndex == -1)
            {
                comboBox.Text = defaultText;
                ChangeText(comboBox, false);
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

                    ArticleShow form = new ArticleShow();
                    form.Show();
                    this.Hide();
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
            if (IsValidArticleInput())
            {
                try
                {
                    int id = idUpd;
                    string name = NameTB.Text;
                    decimal price = Convert.ToDecimal(PriceTB.Text);
                    decimal buyprice = Convert.ToDecimal(BuypriceTB.Text);
                    int quantity = Convert.ToInt32(QuantityTB.Text);
                    Societe society = listSupply[SupplyCB.SelectedIndex];

                    string description = DescriptionTB.Text != descriptionTxt ? DescriptionTB.Text : null;
                    articlevm.updArticle(id, name, price, buyprice, quantity, society, description);

                    ArticleShow form = new ArticleShow();
                    form.Show();
                    this.Hide();
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