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
        private List<Societe> listSupply;

        // Constructeur
        public Supplier()
        {
            InitializeComponent();
            societevm = new SocieteVM(SuppliersCB);
            listSupply = societevm.getSupplys();
        }

        // Gestion des clics sur les champs de texte (réinitialisation du texte)
        private void NameTB_Clicked(object sender, EventArgs e) { HandleTextBoxClick(sender, e, nameTxt, NameTB); }
        private void MailTB_Clicked(object sender, EventArgs e) { HandleTextBoxClick(sender, e, mailTxt, MailTB); }
        private void SiretTB_Clicked(object sender, EventArgs e) { HandleTextBoxClick(sender, e, siretTxt, SiretTB); }
        private void PhoneTB_Clicked(object sender, EventArgs e) { HandleTextBoxClick(sender, e, phoneTxt, PhoneTB); }
        private void AddressTB_Clicked(object sender, EventArgs e) { HandleTextBoxClick(sender, e, addressTxt, AddressTB); }
        private void CpTB_Clicked(object sender, EventArgs e) { HandleTextBoxClick(sender, e, cpTxt, CpTB); }

        // Gestion de l'événement lorsque le texte est cliqué
        private void HandleTextBoxClick(object sender, EventArgs e, string defaultText, TextBox textBox)
        {
            if (textBox.Text == defaultText)
            {
                Resets(sender, e);
                textBox.Text = string.Empty;
                ChangeText(sender, e, true);
                this.ActiveControl = textBox;
            }
        }

        // Gestion de la sélection d'un fournisseur dans le ComboBox
        private void SuppliersCB_Changed(Object sender, EventArgs e)
        {
            if (SuppliersCB.SelectedIndex != -1)
            {
                int id = SuppliersCB.SelectedIndex;

                // Réinitialisation des champs
                Resets(sender, e);
                ChangeText(sender, e, true);
                this.ActiveControl = null;

                // Remplissage des champs avec les informations du fournisseur sélectionné
                NameTB.Clear();
                MailTB.Clear();
                SiretTB.Clear();
                PhoneTB.Clear();
                AddressTB.Clear();
                CpTB.Clear();

                NameTB.Text = listSupply[id].Name;
                MailTB.Text = listSupply[id].Mail;
                SiretTB.Text = listSupply[id].Siret;
                PhoneTB.Text = listSupply[id].Phone;
                AddressTB.Text = listSupply[id].Address;
                CpTB.Text = listSupply[id].PostalCode;

                // Mise à jour de la couleur du texte des champs
                ChangeText(NameTB, e, true);
                ChangeText(MailTB, e, true);
                ChangeText(SiretTB, e, true);
                ChangeText(PhoneTB, e, true);
                ChangeText(AddressTB, e, true);
                ChangeText(CpTB, e, true);
            }
        }

        // Modification de la couleur du texte pour les champs de texte
        private void ChangeText(object sender, EventArgs e, bool able)
        {
            Control obj = sender as Control;
            if (able) obj.ForeColor = Color.Black;
            else obj.ForeColor = Color.Silver;
        }

        // Réinitialisation des champs à leurs valeurs par défaut
        private void Resets(object sender, EventArgs e)
        {
            if (NameTB.Text == string.Empty) { NameTB.Text = nameTxt; ChangeText(NameTB, e, false); }
            if (MailTB.Text == string.Empty) { MailTB.Text = mailTxt; ChangeText(MailTB, e, false); }
            if (SiretTB.Text == string.Empty) { SiretTB.Text = siretTxt; ChangeText(SiretTB, e, false); }
            if (PhoneTB.Text == string.Empty) { PhoneTB.Text = phoneTxt; ChangeText(PhoneTB, e, false); }
            if (AddressTB.Text == string.Empty) { AddressTB.Text = addressTxt; ChangeText(AddressTB, e, false); }
            if (CpTB.Text == string.Empty) { CpTB.Text = cpTxt; ChangeText(CpTB, e, false); }
            this.ActiveControl = null;
        }

        // Validation et ajout d'un fournisseur
        private void Add_Clicked(object sender, EventArgs e)
        {
            if (NameTB.Text != string.Empty && NameTB.Text != nameTxt && MailTB.Text != string.Empty && MailTB.Text != mailTxt && SiretTB.Text != null && SiretTB.Text != siretTxt && PhoneTB.Text != null && PhoneTB.Text != phoneTxt && AddressTB.Text != null && AddressTB.Text != addressTxt && CpTB.Text != null && CpTB.Text != cpTxt)
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
                    Resets(sender, e);
                    SuppliersCB.SelectedIndex = -1;
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
            if (SuppliersCB.SelectedIndex != -1)
            {
                try
                {
                    int id = listSupply[SuppliersCB.SelectedIndex].Id;
                    string name = NameTB.Text;
                    string mail = MailTB.Text;
                    string siret = SiretTB.Text;
                    string phone = PhoneTB.Text;
                    string address = AddressTB.Text;
                    string cp = CpTB.Text;

                    societevm.updSupplier(id, name, mail, siret, phone, address, cp);

                    listSupply = societevm.getSupplys();
                    Resets(sender, e);
                    SuppliersCB.SelectedIndex = -1;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    MessageBox.Show("Une valeur est invalide. Vérifiez les champs.");
                }
            }
        }
    }
}