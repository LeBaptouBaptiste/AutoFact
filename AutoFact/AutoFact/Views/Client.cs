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

        private int idUpd;

        public Client()
        {
            InitializeComponent();
            UpdBtn.Hide();

            clientvm = new ClientVM();
            listClients = clientvm.getClients();
        }

        public Client(Particuliers clientUpd)
        {
            InitializeComponent();
            AddBtn.Hide();

            UpdForm_Load(clientUpd);
            idUpd = clientUpd.Id;

            clientvm = new ClientVM();
            listClients = clientvm.getClients();
        }

        private void UpdForm_Load(Particuliers client)
        {
            // Effacer les champs avant de remplir les données
            ClearFields();

            // Remplir les champs avec les données du client sélectionné
            NameTB.Text = client.Name;
            MailTB.Text = client.Mail;
            FirstNameTB.Text = client.FirstName;
            PhoneTB.Text = client.Phone;
            AddressTB.Text = client.Address;
            CpTB.Text = client.PostalCode;

            if (client.Civility == "H")
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
            ChangeText(NameTB, true);
            ChangeText(MailTB, true);
            ChangeText(FirstNameTB, true);
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
            ResetField(FirstNameTB, firstNameTxt);
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

        // Réinitialisation d'une ComboBox
        private void ResetComboBox(ComboBox comboBox, string defaultText)
        {
            if (comboBox.SelectedIndex == -1)
            {
                comboBox.Text = defaultText;
                ChangeText(comboBox, false);
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
                    Resets(this, true);

                    // Rafraîchir la liste des clients
                    listClients = clientvm.getClients();

                    ClientShow form = new ClientShow();
                    form.Show();
                    this.Hide();
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
            if (IsValidClientInput())
            {
                try
                {
                    int id = idUpd;
                    string name = NameTB.Text;
                    string mail = MailTB.Text;
                    string firstName = FirstNameTB.Text;
                    string phone = PhoneTB.Text;
                    string address = AddressTB.Text;
                    string cp = CpTB.Text;
                    string civility = HommeRB.Checked ? "H" : "F";

                    clientvm.updClients(id, name, mail, phone, address, cp, civility, firstName);

                    ClearFields();
                    Resets(this, true);

                    // Rafraîchir la liste des clients
                    listClients = clientvm.getClients();

                    ClientShow form = new ClientShow();
                    form.Show();
                    this.Hide();
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
