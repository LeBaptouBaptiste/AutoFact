using AutoFact.Models;
using AutoFact.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Runtime.Intrinsics.X86;
using System.Diagnostics;
using System.IO;
using Aspose.Email;
using Aspose.Pdf.Facades;


namespace AutoFact.Views
{
    public partial class Quote : System.Windows.Forms.Form
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
            clientSvm = new SocieteVM(TheClientCB);
            articlevm = new ArticleVM(AProduitCB, clientSvm.getSupplys());
            servicevm = new ServiceVM(AServiceCB);
            clientPvm = new ClientVM(TheClientCB);
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

        private int showQuantityModal(object sender, EventArgs e)
        {
            int theQuantity = 0;
            ModalQuantityProduct modal = new ModalQuantityProduct();

            // Afficher le modal et vérifier si l'utilisateur a cliqué sur "OK"
            if (modal.ShowDialog() == DialogResult.OK)
            {
                // Récupérer la quantité saisie
                string enteredQuantity = modal.EnteredQuantity;

                theQuantity = Convert.ToInt32(enteredQuantity);
            }
            return theQuantity;

        }

        private void AProduit_Choose(Object sender, EventArgs e)
        {
            if (AProduitCB.SelectedIndex != -1)
            {
                int id = AProduitCB.SelectedIndex;

                ChangeText(sender, e, true);
                this.ActiveControl = null;

                // Clear la textBox
                //AProduitCB.Items.Clear();

                int theQuantity = showQuantityModal(sender, e);

                if (theQuantity != 0)
                {

                    // Ajouter l'article séléctionné dans le tableau du devis
                    AllArticlesDGV.Rows.Add(listProducts[id].Id, listProducts[id].Libelle, listProducts[id].Description, "20%", listProducts[id].Prix, theQuantity, listProducts[id].Prix * theQuantity);

                    //// Ajouter la taxe correspondante dans le tableau des taxes
                    decimal resultat = listProducts[id].Prix * 0.2m * theQuantity;

                    TaxesDGV.Rows.Add("Produits", "20%", resultat + " €");

                    ChangeText(AProduitCB, e, true);

                    UpdateTotal(id, true, theQuantity);

                    //MessageBox.Show("Produit ajouté au devis");
                }
                else
                {
                    MessageBox.Show("produit annulé");
                }
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
                //AServiceCB.Items.Clear();

                int theQuantity = showQuantityModal(sender, e);

                if (theQuantity != 0)
                {
                    // Ajouter l'article séléctionné dans le tableau du devis avec la quantité entrée dans le modal
                    AllArticlesDGV.Rows.Add(listServices[id].Id, listServices[id].Libelle, listServices[id].Description, "0%", listServices[id].Prix, theQuantity, listServices[id].Prix * theQuantity);

                    ChangeText(AServiceCB, e, true);

                    UpdateTotal(id, false, theQuantity);

                    //MessageBox.Show("Service ajouté au devis");
                }
                else
                {
                    MessageBox.Show("service annulé");
                }
            }
        }

        private void UpdateTotal(int idArticle, bool typeArticle, int quantity)
        {
            if (typeArticle) // Products
            {
                // Calculer le total HT des produits
                totalProduits += listProducts[idArticle].Prix * quantity;
                LeTotalProduits.Text = $"{totalProduits} €";

                // Calculer le total des taxes
                totalTaxes += listProducts[idArticle].Prix * 0.2m * quantity;
                LeTotalTaxes.Text = $"{totalTaxes} €";
            }
            else // Services
            {
                // Calculer le total HT des services
                totalServices += listServices[idArticle].Prix * quantity;
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

        private void DeleteProductBtn_Click(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == AllArticlesDGV.Columns["DelProduct"].Index)
            {
                // Récupérer l'index de la ligne sélectionnée
                int index = e.RowIndex;
                // Récupérer le montant de la ligne sélectionnée
                decimal amount = Convert.ToDecimal(AllArticlesDGV.Rows[index].Cells[6].Value);
                // Soustraire le montant de la ligne sélectionnée du total HT
                totalHT -= amount;
                LeTotalHT.Text = $"{totalHT} €";
                if (AllArticlesDGV.Rows[index].Cells[3].Value.ToString() == "20%") // S'il y a une taxe
                {
                    // Soustraire le montant de la ligne sélectionnée du total produits
                    totalProduits -= amount;
                    LeTotalProduits.Text = $"{totalProduits} €";
                    // Récupérer le montant de la taxe de la ligne sélectionnée
                    decimal taxAmount = Convert.ToDecimal(TaxesDGV.Rows[index].Cells[2].Value.ToString().Replace(" €", ""));
                    // Soustraire le montant de la ligne sélectionnée du total taxes
                    totalTaxes -= taxAmount;
                    LeTotalTaxes.Text = $"{totalTaxes} €";
                    // Supprimer la ligne sélectionnée du tableau des taxes
                    TaxesDGV.Rows.RemoveAt(index);
                }
                else
                {
                    // Soustraire le montant de la ligne sélectionnée du total services
                    totalServices -= amount;
                    LeTotalServices.Text = $"{totalServices} €";
                }
                // Soustraire le montant de la ligne sélectionnée du total TTC
                totalTTC = totalHT + totalTaxes;
                LeTotalTTC.Text = $"{totalTTC} €";
                // Supprimer la ligne sélectionnée du tableau des articles
                AllArticlesDGV.Rows.RemoveAt(index);
            }
        }

        private void SendInvoiceByMailBtn_Click(object sender, EventArgs e)
        {
            // Définir les informations de l'email
            string destinataire = "client@example.com"; // Remplacez par l'adresse du client
            string sujet = "Votre facture n°123";
            string corps = "Bonjour,\n\nVeuillez trouver ci-joint votre facture.\n\nCordialement,\nVotre entreprise";

            // Facultatif : générer un fichier de facture en pièce jointe (exemple PDF)
            string attachmentPath = GenerateInvoicePDF();

            // Attendre que le fichier soit généré
            if (string.IsNullOrEmpty(attachmentPath))
            {
                MessageBox.Show("Impossible de générer la facture. Veuillez réessayer.", "Erreur");
                return;
            }

            // Construire l'URI mailto (attention : il n'inclut pas les pièces jointes)
            string mailtoUri = $"mailto:{destinataire}?subject={Uri.EscapeDataString(sujet)}&body={Uri.EscapeDataString(corps)}";

            try
            {
                // Configurer ProcessStartInfo
                var psi = new ProcessStartInfo
                {
                    FileName = mailtoUri, // Lien mailto
                    UseShellExecute = true // Important pour exécuter via le shell par défaut
                };

                // Ouvrir l'application de messagerie par défaut avec mailto
                Process.Start(psi);

                // Afficher un message pour guider l'utilisateur sur la pièce jointe
                if (!string.IsNullOrEmpty(attachmentPath))
                {
                    MessageBox.Show($"La facture a été générée à l'emplacement suivant :\n\n{attachmentPath}\n\nAjoutez-la manuellement dans votre e-mail.", "Ajout de la pièce jointe");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de l'ouverture de l'application de messagerie : {ex.Message}", "Erreur");
            }
        }

        public string GenerateInvoicePDF()
        {
            try
            {
                // Définir le chemin pour enregistrer le PDF (ex. : sur le bureau)
                string filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "Facture123.pdf");

                // Créer un document PDF
                Aspose.Pdf.Document document = new Aspose.Pdf.Document();

                // Ajouter une page au document
                Aspose.Pdf.Page page = document.Pages.Add();

                // Ajouter un contenu exemple à la page (remplacez cela par le contenu réel de votre facture)
                page.Paragraphs.Add(new Aspose.Pdf.Text.TextFragment("Facture n°123"));
                page.Paragraphs.Add(new Aspose.Pdf.Text.TextFragment("Client : Nom du client"));
                page.Paragraphs.Add(new Aspose.Pdf.Text.TextFragment("Montant : 123 €"));
                page.Paragraphs.Add(new Aspose.Pdf.Text.TextFragment("Merci pour votre achat !"));

                // Enregistrer le document PDF
                document.Save(filePath);

                return filePath;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la génération du PDF : {ex.Message}", "Erreur");
                return null;
            }
        }

        private void PrintInvoiceBtn_Click(object sender, EventArgs e)
        {
            PDFViewer pdfViewer = new PDFViewer();
            pdfViewer.Show();
        }
    }
}
