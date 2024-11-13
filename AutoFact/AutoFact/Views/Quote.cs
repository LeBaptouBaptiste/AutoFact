using AutoFact.Models;
using AutoFact.ViewModel;
using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoFact.Views
{
    public partial class Quote : Form
    {
        private List<Produits> listProducts;
        private List<Services> listServices;
        private List<Particuliers> listClientsP;
        private List<Societe> listClientsS;
        private ArticleVM articlevm;
        private ServiceVM servicevm;
        private ClientVM clientPvm;
        private SocieteVM clientSvm;

        // Initialisation des variables pour les totaux
        decimal totalProduits = 0;
        decimal totalServices = 0;
        decimal totalTaxes = 0;
        decimal totalHT = 0;
        decimal totalTTC = 0;

        public Quote()
        {
            InitializeComponent();
            articlevm = new ArticleVM(AProduitCB);
            servicevm = new ServiceVM(AServiceCB);
            clientPvm = new ClientVM(TheClientCB);
            clientSvm = new SocieteVM(TheClientCB);
            listProducts = articlevm.getProducts();
            listServices = servicevm.getServices();
            listClientsP = clientPvm.getClients();
            listClientsS = clientSvm.getSupplys();
        }

        private void ChangeText(object sender, EventArgs e, bool able)
        {
            Control obj = sender as Control;

            if (able)
            {
                obj.ForeColor = Color.Black;
            }
            else
            {
                obj.ForeColor = Color.Silver;
            }
        }

        private void AProduit_Choose(Object sender, EventArgs e)
        {
            if (AProduitCB.SelectedIndex != -1)
            {
                int id = AProduitCB.SelectedIndex;

                ChangeText(sender, e, true);
                this.ActiveControl = null;

                // Clear la textBox
                //AnArticleCB.Items.Clear();

                // Ajouter l'article séléctionné dans le tableau du devis
                AllArticlesDGV.Rows.Add(listProducts[id].Id, listProducts[id].Libelle, listProducts[id].Description, "20%", listProducts[id].Prix, listProducts[id].Quantity, listProducts[id].Prix * listProducts[id].Quantity);

                //// Ajouter la taxe correspondante dans le tableau des taxes
                decimal resultat = listProducts[id].Prix * 0.2m;

                TaxesDGV.Rows.Add("Produits", "20%", resultat + " €");

                ChangeText(AProduitCB, e, true);

                UpdateTotal(id, true);
            }
        }

        private void AService_Choose(Object sender, EventArgs e)
        {
            if (AServiceCB.SelectedIndex != -1)
            {
                int id = AServiceCB.SelectedIndex;

                ChangeText(sender, e, true);
                this.ActiveControl = null;

                // Clear la textBox
                //AnArticleCB.Items.Clear();

                // Ajouter l'article séléctionné dans le tableau du devis
                AllArticlesDGV.Rows.Add(listServices[id].Id, listServices[id].Libelle, listServices[id].Description, "0%", listServices[id].Prix, 1, listServices[id].Prix);

                ChangeText(AServiceCB, e, true);

                UpdateTotal(id, false);
            }
        }

        private void UpdateTotal(int idArticle, bool typeArticle) // typeArticle --> True : Produits | False : Services
        {
            if (typeArticle)
            {
                // Calculer le total HT des produits
                totalProduits += listProducts[idArticle].Prix;
                LeTotalProduits.Text = $"{totalProduits} €";

                // Calculer le total des taxes
                totalTaxes += listProducts[idArticle].Prix * 0.2m;
                LeTotalTaxes.Text = $"{totalTaxes} €";
            } else
            {
                // Calculer le total HT des services
                totalServices += listServices[idArticle].Prix;
                LeTotalServices.Text = $"{totalServices} €";

                //// Calculer le total des taxes
                //totalTaxes += listServices[idArticle].Prix * 0.2m;
                //LeTotalTaxes.Text = $"{totalTaxes} €";
            }

            // Calculer le total HT final
            totalHT = totalProduits + totalServices;
            LeTotalHT.Text = $"{totalHT} €";

            // Calculer le total TTC final
            totalTTC = totalHT + totalTaxes;
            LeTotalTTC.Text = $"{totalTTC} €";
        }
    }
}
