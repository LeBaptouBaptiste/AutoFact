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

using Xceed.Words.NET;
using Aspose.Words;
using Xceed.Document.NET;

// using Aspose.Email;
// using Aspose.Pdf.Facades;


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
        Dictionary<string, string> theClientSelected = new Dictionary<string, string>();

        public Quote()
        {
            InitializeComponent();
            clientSvm = new SocieteVM();
            clientPvm = new ClientVM();
            articlevm = new ArticleVM(AProduitCB, clientSvm.getSupplys());
            servicevm = new ServiceVM(AServiceCB);
            listClientsP = clientPvm.getClients();
            listClientsS = clientSvm.getSupplys();
            listProducts = articlevm.getProducts();
            listServices = servicevm.getServices();

            foreach (var client in listClientsP)
            {
                TheClientCB.Items.Add(client); // Le ComboBox contient l’objet complet
            }

            foreach (var client in listClientsS)
            {
                TheClientCB.Items.Add(client); // Idem pour les sociétés
            }
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

        private void AProduit_Choose(object sender, EventArgs e)
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
                    MessageBox.Show("produit annulé !");
                }
            }
        }

        private void AService_Choose(object sender, EventArgs e)
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
                    MessageBox.Show("Service annulé !");
                }
            }
        }

        private void TheClient_Choose(object sender, EventArgs e)
        {
            if (TheClientCB.SelectedIndex != -1)
            {
                if (TheClientCB.SelectedItem is Clients selectedClient)
                {
                    theClientSelected.Clear();

                    StringBuilder sb = new StringBuilder();

                    // Si c'est un particulier → afficher civilité et prénom  
                    if (selectedClient is Particuliers particulier)
                    {
                        if (!string.IsNullOrEmpty(particulier.Civility))
                            sb.AppendLine($"Civilité : {particulier.Civility}");

                        if (!string.IsNullOrEmpty(particulier.FirstName))
                            sb.AppendLine($"Prénom : {particulier.FirstName}");

                        if (!string.IsNullOrEmpty(particulier.Civility))
                            theClientSelected["Civilité"] = particulier.Civility;

                        if (!string.IsNullOrEmpty(particulier.FirstName))
                            theClientSelected["Prénom"] = particulier.FirstName;
                    }

                    if (!string.IsNullOrEmpty(selectedClient.Name))
                    {
                        sb.AppendLine($"Nom : {selectedClient.Name}");
                        theClientSelected["Nom"] = selectedClient.Name;
                    }

                    if (!string.IsNullOrEmpty(selectedClient.Address))
                    {
                        sb.AppendLine($"Adresse : {selectedClient.Address}");
                        theClientSelected["Adresse"] = selectedClient.Address;
                    }

                    if (!string.IsNullOrEmpty(selectedClient.PostalCode))
                    {
                        sb.AppendLine($"Code Postal : {selectedClient.PostalCode}");
                        theClientSelected["Code Postal"] = selectedClient.PostalCode;
                    }

                    if (!string.IsNullOrEmpty(selectedClient.Phone))
                    {
                        sb.AppendLine($"Téléphone : {selectedClient.Phone}");
                        theClientSelected["Téléphone"] = selectedClient.Phone;
                    }

                    if (!string.IsNullOrEmpty(selectedClient.Mail))
                    {
                        sb.AppendLine($"Email : {selectedClient.Mail}");
                        theClientSelected["Email"] = selectedClient.Mail;
                    }

                    // Si c'est une société → afficher SIRET  
                    if (selectedClient is Societe societe && !string.IsNullOrEmpty(societe.Siret))
                    {
                        sb.AppendLine($"SIRET : {societe.Siret}");
                        theClientSelected["SIRET"] = societe.Siret;
                    }

                    MessageBox.Show(sb.ToString(), "Informations du client", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Construire le message pour le client sélectionné  
                    var selectedClientMessage = new StringBuilder("Client sélectionné : ");

                    if (theClientSelected.ContainsKey("Nom"))
                        selectedClientMessage.AppendLine($"Nom : {theClientSelected["Nom"]}, ");

                    if (theClientSelected.ContainsKey("Prénom"))
                        selectedClientMessage.AppendLine($"Prénom : {theClientSelected["Prénom"]} ");

                    if (theClientSelected.ContainsKey("Civilité"))
                        selectedClientMessage.AppendLine($"Civilité : {theClientSelected["Civilité"]}, ");

                    if (theClientSelected.ContainsKey("Adresse"))
                        selectedClientMessage.AppendLine($"Adresse : {theClientSelected["Adresse"]}, ");

                    if (theClientSelected.ContainsKey("SIRET"))
                        selectedClientMessage.AppendLine($"SIRET : {theClientSelected["SIRET"]}");

                    MessageBox.Show(selectedClientMessage.ToString(), "Client sélectionné", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                ChangeText(sender, e, true);
                this.ActiveControl = null;
            }
            else
            {
                MessageBox.Show("Pb on CB !");
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
            MessageBox.Show("Cette fonctionnalité n'est pas encore implémentée.", "Information");
            //// Définir les informations de l'email
            //string destinataire = "client@example.com"; // Remplacez par l'adresse du client
            //string sujet = "Votre facture n°123";
            //string corps = "Bonjour,\n\nVeuillez trouver ci-joint votre facture.\n\nCordialement,\nVotre entreprise";

            //GenerateInvoicePDF();

            //// Attendre que le fichier soit généré
            //if (string.IsNullOrEmpty(attachmentPath))
            //{
            //    MessageBox.Show("Impossible de générer la facture. Veuillez réessayer.", "Erreur");
            //    return;
            //}

            //// Construire l'URI mailto (attention : il n'inclut pas les pièces jointes)
            //string mailtoUri = $"mailto:{destinataire}?subject={Uri.EscapeDataString(sujet)}&body={Uri.EscapeDataString(corps)}";

            //try
            //{
            //    // Configurer ProcessStartInfo
            //    var psi = new ProcessStartInfo
            //    {
            //        FileName = mailtoUri, // Lien mailto
            //        UseShellExecute = true // Important pour exécuter via le shell par défaut
            //    };

            //    // Ouvrir l'application de messagerie par défaut avec mailto
            //    Process.Start(psi);

            //    // Afficher un message pour guider l'utilisateur sur la pièce jointe
            //    if (!string.IsNullOrEmpty(attachmentPath))
            //    {
            //        MessageBox.Show($"La facture a été générée à l'emplacement suivant :\n\n{attachmentPath}\n\nAjoutez-la manuellement dans votre e-mail.", "Ajout de la pièce jointe");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show($"Erreur lors de l'ouverture de l'application de messagerie : {ex.Message}", "Erreur");
            //}
        }

        private void GenerateInvoiceBtn_Click(object sender, EventArgs e)
        {
            GenerateInvoicePDF();
        }

        private void GenerateInvoicePDF()
        {
            try
            {
                // 1. Demander à l'utilisateur où enregistrer le PDF
                SaveFileDialog sfd = new SaveFileDialog();
                sfd.Title = "Enregistrer la facture";
                sfd.Filter = "Fichiers PDF (*.pdf)|*.pdf";
                sfd.FileName = $"Facture_{DateTime.Now:yyyyMMdd}.pdf";

                if (sfd.ShowDialog() != DialogResult.OK)
                    return;

                string tempDocxPath = Path.Combine(Path.GetTempPath(), $"TempInvoice_{Guid.NewGuid()}.docx");

                // 2. Générer le fichier Word temporaire
                string templatePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Template", "InvoiceModel.docx");

                if (!File.Exists(templatePath))
                {
                    MessageBox.Show("Modèle de facture introuvable.", "Erreur");
                    return;
                }

                var doc = DocX.Load(templatePath);

                var client = TheClientCB.SelectedItem as Societe;
                string refFacture = "FAC-" + DateTime.Now.Ticks;

                var replacements = new Dictionary<string, string>()
{
    { "nameE", "Twin Tech" },
    { "streetE", "1 rue de l'exemple" },
    { "cpE", "75000" },
    { "cityE", "Paris" },
    { "telE", "01 23 45 67 89" },
    { "emailE", "contact@twintech.fr" },
    { "sitewebE", "| www.twintech.fr" },
    { "refInvoice", refFacture },
    { "dateInvoice", DateTime.Now.ToShortDateString() },

    { "nameC", theClientSelected.ContainsKey("Nom") ? theClientSelected["Nom"] : "Client inconnu" },
{ "streetC", theClientSelected.ContainsKey("Adresse") ? theClientSelected["Adresse"] : "Aucune adresse" },
{ "cpC", theClientSelected.ContainsKey("Code Postal") ? theClientSelected["Code Postal"] : "Aucun CP" },
{ "emailC", theClientSelected.ContainsKey("Email") ? theClientSelected["Email"] : "email@exemple.com" },
{ "telC", theClientSelected.ContainsKey("Téléphone") ? "| " + theClientSelected["Téléphone"] : "Pas de numéro" },
{ "civilityC", theClientSelected.ContainsKey("Civilité") ? (theClientSelected["Civilité"] == "H" ? "Mr" : "Mme") : "" },
{ "firstNameC", theClientSelected.ContainsKey("Prénom") ? theClientSelected["Prénom"] : "" },
{ "siretC", theClientSelected.ContainsKey("SIRET") ? "| " + theClientSelected["SIRET"] : "" },



    { "productTotal", totalProduits.ToString("0.00") + " €" },
    { "serviceTotal", totalServices.ToString("0.00") + " €" },
    { "htTotal", totalHT.ToString("0.00") + " €" },
    { "taxeTotal", totalTaxes.ToString("0.00") + " €" },
    { "ttcTotal", totalTTC.ToString("0.00") + " €" },
    { "comments", "Merci pour votre confiance !" }, // A implémenter ds l'app
};

                foreach (var kv in replacements)
                {
                    doc.ReplaceText(new StringReplaceTextOptions
                    {
                        SearchValue = "{" + kv.Key + "}",
                        NewValue = kv.Value,
                    });
                }

                // Récupérer le tableau contenant les lignes des articles
                Table table = doc.Tables.FirstOrDefault(t => t.Rows.Any(r => r.Paragraphs.Any(p => p.Text.Contains("{theRef}"))));

                if (table == null)
                {
                    MessageBox.Show("Le tableau des articles n'a pas été trouvé.", "Erreur");
                    return;
                }

                // Rechercher la ligne modèle (celle avec {theRef})
                int templateRowIndex = -1;

                for (int i = 0; i < table.Rows.Count; i++)
                {
                    if (table.Rows[i].Paragraphs.Any(p => p.Text.Contains("{theRef}")))
                    {
                        templateRowIndex = i;
                        break;
                    }
                }

                if (templateRowIndex == -1)
                {
                    MessageBox.Show("La ligne modèle avec les balises {theRef}, etc. est introuvable.", "Erreur");
                    return;
                }

                // Dupliquer la ligne modèle pour chaque article/service
                var templateRow = table.Rows[templateRowIndex];

                foreach (DataGridViewRow row in AllArticlesDGV.Rows)
                {
                    if (row.IsNewRow) continue;

                    string refArt = row.Cells[0].Value?.ToString() ?? "";
                    string libelle = row.Cells[1].Value?.ToString() ?? "";
                    string desc = row.Cells[2].Value?.ToString() ?? "";
                    string prix = row.Cells[4].Value?.ToString() ?? "";
                    string qte = row.Cells[5].Value?.ToString() ?? "";
                    string total = row.Cells[6].Value?.ToString() ?? "";

                    // Cloner la ligne modèle
                    var newRow = table.InsertRow(templateRow, templateRowIndex + 1);

                    var articleRemplacements = new Dictionary<string, string>()
                    {
                        { "{theRef}", refArt },
                        { "{theDesi}", libelle },
                        { "{theDesc}", desc },
                        { "{theUnitPrice}", prix },
                        { "{theQ}", qte },
                        { "{theTotal}", total },
                    };

                    // Remplacer les balises
                    foreach (var kv in articleRemplacements)
                    {
                        newRow.ReplaceText(new StringReplaceTextOptions
                        {
                            SearchValue = kv.Key,
                            NewValue = kv.Value,
                        });
                    }
                }

                // Supprimer la ligne modèle d'origine
                table.RemoveRow(templateRowIndex);

                doc.SaveAs(tempDocxPath);

                // 3. Convertir en PDF avec Aspose.Words
                var awDoc = new Aspose.Words.Document(tempDocxPath);
                awDoc.Save(sfd.FileName, Aspose.Words.SaveFormat.Pdf);

                MessageBox.Show("Facture générée avec succès !", "Succès");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la génération de la facture : " + ex.Message, "Erreur");
            }
        }
    }
}
