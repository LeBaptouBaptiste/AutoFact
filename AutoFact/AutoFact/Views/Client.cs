using AutoFact.Models;
using AutoFact.ViewModel;
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
    public partial class Client : Form
    {
        private string nameTxt = "Nom";
        private string mailTxt = "Adresse mail";
        private string firstNameTxt = "Prénom";
        private string phoneTxt = "Telephone";
        private string addressTxt = "Adresse postal";
        private string cpTxt = "Code postal";
        private string clientTxt = "Client";

        private ClientVM clientvm;
        private List<Particuliers> listClients;
        public Client()
        {
            InitializeComponent();
            clientvm = new ClientVM(ClientsCB);
            listClients = clientvm.getClients();
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
        private void MailTB_Clicked(object sender, EventArgs e)
        {
            if (MailTB.Text == mailTxt)
            {
                Resets(sender, e);
                MailTB.Text = string.Empty;
                ChangeText(sender, e, true);
                this.ActiveControl = MailTB;
            }
        }
        private void FirstNameTB_Clicked(object sender, EventArgs e)
        {
            if (FirstNameTB.Text == firstNameTxt)
            {
                Resets(sender, e);
                FirstNameTB.Text = string.Empty;
                ChangeText(sender, e, true);
                this.ActiveControl = FirstNameTB;
            }
        }
        private void PhoneTB_Clicked(object sender, EventArgs e)
        {
            if (PhoneTB.Text == phoneTxt)
            {
                Resets(sender, e);
                PhoneTB.Text = string.Empty;
                ChangeText(sender, e, true);
                this.ActiveControl = PhoneTB;
            }
        }
        private void AddressTB_Clicked(object sender, EventArgs e)
        {
            if (AddressTB.Text == addressTxt)
            {
                Resets(sender, e);
                AddressTB.Text = string.Empty;
                ChangeText(sender, e, true);
                this.ActiveControl = AddressTB;
            }
        }
        private void CpTB_Clicked(object sender, EventArgs e)
        {
            if (CpTB.Text == cpTxt)
            {
                Resets(sender, e);
                CpTB.Text = string.Empty;
                ChangeText(sender, e, true);
                this.ActiveControl = CpTB;
            }
        }
        private void ClientsCB_Changed(Object sender, EventArgs e)
        {
            if (ClientsCB.SelectedIndex != -1)
            {
                int id = ClientsCB.SelectedIndex;

                ChangeText(sender, e, true);
                this.ActiveControl = null;

                NameTB.Clear();
                MailTB.Clear();
                FirstNameTB.Clear();
                PhoneTB.Clear();
                AddressTB.Clear();
                CpTB.Clear();

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

                ChangeText(NameTB, e, true);
                ChangeText(MailTB, e, true);
                ChangeText(FirstNameTB, e, true);
                ChangeText(PhoneTB, e, true);
                ChangeText(AddressTB, e, true);
                ChangeText(CpTB, e, true);
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

        private void Resets(object sender, EventArgs e)
        {
            if (NameTB.Text == string.Empty)
            {
                NameTB.Text = nameTxt;
                ChangeText(NameTB, e, false);
            }
            if (MailTB.Text == string.Empty)
            {
                MailTB.Text = mailTxt;
                ChangeText(MailTB, e, false);
            }
            if (FirstNameTB.Text == string.Empty)
            {
                FirstNameTB.Text = firstNameTxt;
                ChangeText(FirstNameTB, e, false);
            }
            if (PhoneTB.Text == string.Empty)
            {
                PhoneTB.Text = phoneTxt;
                ChangeText(PhoneTB, e, false);
            }
            if (AddressTB.Text == string.Empty)
            {
                AddressTB.Text = addressTxt;
                ChangeText(AddressTB, e, false);
            }
            if (CpTB.Text == string.Empty)
            {
                CpTB.Text = cpTxt;
                ChangeText(CpTB, e, false);
            }
            this.ActiveControl = null;
        }
        private void Add_Clicked(object sender, EventArgs e)
        {
            if (NameTB.Text != string.Empty && NameTB.Text != nameTxt && MailTB.Text != string.Empty && MailTB.Text != mailTxt && FirstNameTB.Text != null && FirstNameTB.Text != firstNameTxt && PhoneTB.Text != null && PhoneTB.Text != phoneTxt && AddressTB.Text != null && AddressTB.Text != addressTxt && CpTB.Text != null && CpTB.Text != cpTxt && (HommeRB.Checked || FemmeRB.Checked))
            {
                try
                {
                    string name = NameTB.Text;
                    string mail = MailTB.Text;
                    string firstName = FirstNameTB.Text;
                    string phone = PhoneTB.Text;
                    string address = AddressTB.Text;
                    string cp = CpTB.Text;
                    string civility = "F";

                    if (HommeRB.Checked)
                    {
                        civility = "H";
                    }


                    clientvm.AddClients(name, mail, firstName, phone, address, cp, civility);

                    NameTB.Clear();
                    MailTB.Clear();
                    FirstNameTB.Clear();
                    PhoneTB.Clear();
                    AddressTB.Clear();
                    CpTB.Clear();
                    HommeRB.Checked = false;
                    FemmeRB.Checked = false;
                    Resets(this, e);

                    listClients = clientvm.getClients();
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
            if (NameTB.Text != string.Empty && NameTB.Text != nameTxt && MailTB.Text != string.Empty && MailTB.Text != mailTxt && FirstNameTB.Text != null && FirstNameTB.Text != firstNameTxt && PhoneTB.Text != null && PhoneTB.Text != phoneTxt && AddressTB.Text != null && AddressTB.Text != addressTxt && CpTB.Text != null && CpTB.Text != cpTxt && (HommeRB.Checked || FemmeRB.Checked) && ClientsCB.SelectedIndex != -1)
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
                    string civility = "F";

                    if (HommeRB.Checked)
                    {
                        civility = "H";
                    }

                    ClientsCB.SelectedIndex = -1;

                    clientvm.UpdSupplier(id, name, mail, firstName, phone, address, cp, civility);

                    NameTB.Clear();
                    MailTB.Clear();
                    FirstNameTB.Clear();
                    PhoneTB.Clear();
                    AddressTB.Clear();
                    CpTB.Clear();
                    HommeRB.Checked = false;
                    FemmeRB.Checked = false;
                    Resets(this, e);

                    listClients = clientvm.getClients();
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
