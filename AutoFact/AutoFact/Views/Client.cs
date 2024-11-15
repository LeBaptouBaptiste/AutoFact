using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using AutoFact.ViewModel;
using AutoFact.Models;

namespace AutoFact.Views
{
    public partial class Client : Form
    {
        // Texte par défaut pour les champs de saisie
        private string nameTxt = "Nom";
        private string mailTxt = "Adresse mail";
        private string firstNameTxt = "Prénom";
        private string phoneTxt = "Téléphone";
        private string addressTxt = "Adresse postale";
        private string cpTxt = "Code postal";
        private string clientTxt = "Client";

        private ClientVM clientvm;
        private List<Particuliers> listClients;

        public Client()
        {
            InitializeComponent();

            // Initialisation du ViewModel et de la liste des clients
            clientvm = new ClientVM(ClientsCB);
            listClients = clientvm.getClients();
        }

        // Gestion des clics dans les champs de saisie
        private void NameTB_Clicked(object sender, EventArgs e) => HandleFieldClick(sender, nameTxt);
        private void MailTB_Clicked(object sender, EventArgs e) => HandleFieldClick(sender, mailTxt);
        private void FirstNameTB_Clicked(object sender, EventArgs e) => HandleFieldClick(sender, firstNameTxt);
        private void PhoneTB_Clicked(object sender, EventArgs e) => HandleFieldClick(sender, phoneTxt);
        private void AddressTB_Clicked(object sender, EventArgs e) => HandleFieldClick(sender, addressTxt);
        private void CpTB_Clicked(object sender, EventArgs e) => HandleFieldClick(sender, cpTxt);

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

        // Changement de sélection pour le client
        private void ClientsCB_Changed(object sender, EventArgs e)
        {
            if (ClientsCB.SelectedIndex != -1)
            {
                int id = ClientsCB.SelectedIndex;

                // Effacer les champs avant de remplir les données
                ClearFields();

                // Remplir les champs avec les données du client sélectionné
                NameTB.Text = listClients[id].Name;
                MailTB.Text = listClients[id].Mail;
                FirstNameTB.Text = listClients[id].FirstName;
                PhoneTB.Text = listClients[id].Phone;
                AddressTB.Text = listClients[id].Address;
                CpTB.Text = listClients[id].PostalCode;

                if (listClients[id].Civility == "H")
                {
                    HommeRB.Checked = true;
                }
                else
                {
                    FemmeRB.Checked = true;
                }

                // Mettre à jour l'apparence des champs
                UpdateFieldAppearance();
            }
        }

        // Méthode pour effacer les champs de saisie
        private void ClearFields()
        {
            NameTB.Clear();
            MailTB.Clear();
            FirstNameTB.Clear();
            PhoneTB.Clear();
            AddressTB.Clear();
            CpTB.Clear();
            HommeRB.Checked = false;
            FemmeRB.Checked = false;
        }

        // Mise à jour de l'apparence des champs (couleur du texte)
        private void UpdateFieldAppearance()
        {
            ChangeText(NameTB, EventArgs.Empty, true);
            ChangeText(MailTB, EventArgs.Empty, true);
            ChangeText(FirstNameTB, EventArgs.Empty, true);
            ChangeText(PhoneTB, EventArgs.Empty, true);
            ChangeText(AddressTB, EventArgs.Empty, true);
            ChangeText(CpTB, EventArgs.Empty, true);
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
            ResetField(MailTB, mailTxt, e);
            ResetField(FirstNameTB, firstNameTxt, e);
            ResetField(PhoneTB, phoneTxt, e);
            ResetField(AddressTB, addressTxt, e);
            ResetField(CpTB, cpTxt, e);
            ResetComboBox(ClientsCB, clientTxt, e);
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

        // Ajout d'un nouveau client
        private void Add_Clicked(object sender, EventArgs e)
        {
            if (IsValidClientInput())
            {
                try
                {
                    string name = NameTB.Text;
                    string mail = MailTB.Text;
                    string firstName = FirstNameTB.Text;
                    string phone = PhoneTB.Text;
                    string address = AddressTB.Text;
                    string cp = CpTB.Text;
                    string civility = HommeRB.Checked ? "H" : "F";

                    clientvm.addClients(name, mail, phone, address, cp, civility, firstName);

                    ClearFields();
                    Resets(this, EventArgs.Empty);

                    // Rafraîchir la liste des clients
                    listClients = clientvm.getClients();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    MessageBox.Show("Erreur dans les données saisies.");
                }
            }
        }

        // Mise à jour d'un client existant
        private void Upd_Clicked(object sender, EventArgs e)
        {
            if (IsValidClientInput() && ClientsCB.SelectedIndex != -1)
            {
                try
                {
                    int id = listClients[ClientsCB.SelectedIndex].Id;
                    string name = NameTB.Text;
                    string mail = MailTB.Text;
                    string firstName = FirstNameTB.Text;
                    string phone = PhoneTB.Text;
                    string address = AddressTB.Text;
                    string cp = CpTB.Text;
                    string civility = HommeRB.Checked ? "H" : "F";

                    clientvm.updClients(id, name, mail, phone, address, cp, civility, firstName);

                    ClearFields();
                    Resets(this, EventArgs.Empty);

                    // Rafraîchir la liste des clients
                    listClients = clientvm.getClients();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    MessageBox.Show("Erreur dans les données saisies.");
                }
            }
        }

        // Vérification que l'entrée du client est valide
        private bool IsValidClientInput()
        {
            return NameTB.Text != string.Empty && NameTB.Text != nameTxt &&
                   MailTB.Text != string.Empty && MailTB.Text != mailTxt &&
                   FirstNameTB.Text != string.Empty && FirstNameTB.Text != firstNameTxt &&
                   PhoneTB.Text != string.Empty && PhoneTB.Text != phoneTxt &&
                   AddressTB.Text != string.Empty && AddressTB.Text != addressTxt &&
                   CpTB.Text != string.Empty && CpTB.Text != cpTxt &&
                   (HommeRB.Checked || FemmeRB.Checked);
        }
    }
}
