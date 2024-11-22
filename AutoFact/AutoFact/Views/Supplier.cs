using AutoFact.ViewModel;
using AutoFact.Models;
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
    public partial class Supplier : Form
    {
        // Définition des textes par défaut (placeholders)
        private string nameTxt = "Nom de la société";
        private string mailTxt = "Adresse mail";
        private string siretTxt = "Siret";
        private string phoneTxt = "Telephone";
        private string addressTxt = "Adresse postal";
        private string cpTxt = "Code postal";
        private string suppTxt = "Fournisseurs";

        // Variables pour la gestion des fournisseurs
        SocieteVM societevm;
        private List<Societe> listSupply = new List<Societe>();

        private int idUpd;

        // Constructeur
        public Supplier()
        {
            InitializeComponent();
            UpdBtn.Hide();

            societevm = new SocieteVM();
            listSupply = societevm.getSupplys();
        }

        public Supplier(Societe SupplyUpd)
        {
            InitializeComponent();
            AddBtn.Hide();

            UpdForm_Load(SupplyUpd);
            idUpd = SupplyUpd.Id;

            societevm = new SocieteVM();
            listSupply = societevm.getSupplys();
        }

        private void UpdForm_Load(Societe fournisseur)
        {
            // Remplissage des champs avec les informations du fournisseur sélectionné
            NameTB.Clear();
            MailTB.Clear();
            SiretTB.Clear();
            PhoneTB.Clear();
            AddressTB.Clear();
            CpTB.Clear();

            NameTB.Text = fournisseur.Name;
            MailTB.Text = fournisseur.Mail;
            SiretTB.Text = fournisseur.Siret;
            PhoneTB.Text = fournisseur.Phone;
            AddressTB.Text = fournisseur.Address;
            CpTB.Text = fournisseur.PostalCode;

            UpdateFieldAppearance();
        }

        // Gestion des clics sur les champs de texte (réinitialisation du texte)
        private void NameTB_Clicked(object sender, EventArgs e) { HandleFieldClick(sender, nameTxt); }
        private void MailTB_Clicked(object sender, EventArgs e) { HandleFieldClick(sender, mailTxt); }
        private void SiretTB_Clicked(object sender, EventArgs e) { HandleFieldClick(sender, siretTxt); }
        private void PhoneTB_Clicked(object sender, EventArgs e) { HandleFieldClick(sender, phoneTxt); }
        private void AddressTB_Clicked(object sender, EventArgs e) { HandleFieldClick(sender, addressTxt); }
        private void CpTB_Clicked(object sender, EventArgs e) { HandleFieldClick(sender, cpTxt); }

        // Méthode générique pour gérer les clics sur les champs de saisie
        private void HandleFieldClick(object sender, string defaultText)
        {
            TextBox textBox = sender as TextBox;
            if (textBox.Text == defaultText)
            {
                Resets(sender, true);
                textBox.Text = string.Empty;
                ChangeText(sender, true);
                this.ActiveControl = textBox;
            }
        }
        // Méthode pour effacer les champs de saisie
        private void ClearFields()
        {
            NameTB.Clear();
            MailTB.Clear();
            SiretTB.Clear();
            PhoneTB.Clear();
            AddressTB.Clear();
            CpTB.Clear();
        }

        // Mise à jour de l'apparence des champs (couleur du texte)
        private void UpdateFieldAppearance()
        {
            ChangeText(NameTB, true);
            ChangeText(MailTB, true);
            ChangeText(SiretTB, true);
            ChangeText(PhoneTB, true);
            ChangeText(AddressTB, true);
            ChangeText(CpTB, true);
        }

        // Changement de la couleur du texte des contrôles
        private void ChangeText(object sender, bool able)
        {
            Control obj = sender as Control;
            obj.ForeColor = able ? Color.Black : Color.Silver;
        }

        // Réinitialisation des champs de saisie
        private void Resets(object sender, bool resetControll)
        {
            ResetField(NameTB, nameTxt);
            ResetField(MailTB, mailTxt);
            ResetField(SiretTB, siretTxt);
            ResetField(PhoneTB, phoneTxt);
            ResetField(AddressTB, addressTxt);
            ResetField(CpTB, cpTxt);
            if (resetControll)
            {
                this.ActiveControl = null;
            }
        }

        // Réinitialisation d'un champ de texte
        private void ResetField(TextBox textBox, string defaultText)
        {
            if (textBox.Text == string.Empty)
            {
                textBox.Text = defaultText;
                ChangeText(textBox, false);
            }
        }

        // Validation et ajout d'un fournisseur
        private void Add_Clicked(object sender, EventArgs e)
        {
            if (IsValidServiceInput())
            {
                try
                {
                    string name = NameTB.Text;
                    string mail = MailTB.Text;
                    string siret = SiretTB.Text;
                    string phone = PhoneTB.Text;
                    string address = AddressTB.Text;
                    string cp = CpTB.Text;

                    societevm.addSupplier(name, mail, siret, phone, address, cp);

                    listSupply = societevm.getSupplys();
                    Resets(sender, true);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    MessageBox.Show("Une valeur est invalide. Vérifiez les champs.");
                }
            }
        }

        // Validation et mise à jour d'un fournisseur
        private void Upd_Clicked(object sender, EventArgs e)
        {
            if (IsValidServiceInput())
            {
                try
                {
                    int id = idUpd;
                    string name = NameTB.Text;
                    string mail = MailTB.Text;
                    string siret = SiretTB.Text;
                    string phone = PhoneTB.Text;
                    string address = AddressTB.Text;
                    string cp = CpTB.Text;

                    societevm.updSupplier(id, name, mail, siret, phone, address, cp);

                    listSupply = societevm.getSupplys();
                    Resets(sender, true);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    MessageBox.Show("Une valeur est invalide. Vérifiez les champs.");
                }
            }
        }
        // Vérification que l'entrée du service est valide
        private bool IsValidServiceInput()
        {
            return NameTB.Text != string.Empty && NameTB.Text != nameTxt &&
                   MailTB.Text != string.Empty && MailTB.Text != mailTxt &&
                   SiretTB.Text != string.Empty && SiretTB.Text != siretTxt &&
                   PhoneTB.Text != string.Empty && PhoneTB.Text != phoneTxt &&
                   AddressTB.Text != string.Empty && AddressTB.Text != addressTxt &&
                   CpTB.Text != string.Empty && CpTB.Text != cpTxt;
        }
    }
}