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
    public partial class Supplier : Form
    {
        private string nameTxt = "Nom de la société";
        private string mailTxt = "Adresse mail";
        private string siretTxt = "Siret";
        private string phoneTxt = "Telephone";
        private string addressTxt = "Adresse postal";
        private string cpTxt = "Code postal";
        private string suppTxt = "Fournisseurs";

        SocieteVM societevm;
        private List<Societe> listSupply;
        public Supplier()
        {
            InitializeComponent();
            societevm = new SocieteVM(SuppliersCB);
            listSupply = societevm.getSupplys();
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
        private void SiretTB_Clicked(object sender, EventArgs e)
        {
            if (SiretTB.Text == siretTxt)
            {
                Resets(sender, e);
                SiretTB.Text = string.Empty;
                ChangeText(sender, e, true);
                this.ActiveControl = SiretTB;
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
        private void SuppliersCB_Changed(Object sender, EventArgs e)
        {
            if (SuppliersCB.SelectedIndex != -1)
            {
                int id = SuppliersCB.SelectedIndex;

                ChangeText(sender, e, true);
                this.ActiveControl = null;

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

                ChangeText(NameTB, e, true);
                ChangeText(MailTB, e, true);
                ChangeText(SiretTB, e, true);
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
            if (SiretTB.Text == string.Empty)
            {
                SiretTB.Text = siretTxt;
                ChangeText(SiretTB, e, false);
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

                    societevm.AddSupplier(name, mail, siret, phone, address, cp);

                    NameTB.Clear();
                    MailTB.Clear();
                    SiretTB.Clear();
                    PhoneTB.Clear();
                    AddressTB.Clear();
                    CpTB.Clear();
                    Resets(this, e);

                    listSupply = societevm.getSupplys();
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
            if (NameTB.Text != string.Empty && NameTB.Text != nameTxt && MailTB.Text != string.Empty && MailTB.Text != mailTxt && SiretTB.Text != null && SiretTB.Text != siretTxt && PhoneTB.Text != null && PhoneTB.Text != phoneTxt && AddressTB.Text != null && AddressTB.Text != addressTxt && CpTB.Text != null && CpTB.Text != cpTxt && SuppliersCB.SelectedIndex != -1)
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

                    SuppliersCB.SelectedIndex = -1;

                    societevm.UpdSupplier(id, name, mail, siret, phone, address, cp);

                    NameTB.Clear();
                    MailTB.Clear();
                    SiretTB.Clear();
                    PhoneTB.Clear();
                    AddressTB.Clear();
                    CpTB.Clear();
                    Resets(this, e);

                    listSupply = societevm.getSupplys();
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
