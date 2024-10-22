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
        private string nameTxt = "Nom de la société";
        private string mailTxt = "Adresse mail";
        private string firstNameTxt = "Siret";
        private string phoneTxt = "Telephone";
        private string addressTxt = "Adresse postal";
        private string cpTxt = "Code postal";
        private string clientTxt = "Client";
        public Client()
        {
            InitializeComponent();
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
    }
}
