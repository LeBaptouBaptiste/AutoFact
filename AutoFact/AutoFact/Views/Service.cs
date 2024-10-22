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
    public partial class Service : Form
    {
        private string nameTxt = "Designation";
        private string descriptionTxt = "Description";
        private string priceTxt = "Prix";
        private string durationTxt = "Durée";
        private string serviceTxt = "Service";

        ServiceVM servicevm;
        List<Services> listServices;
        public Service()
        {
            InitializeComponent();
            servicevm = new ServiceVM(ServiceCB);
            listServices = servicevm.getServices();
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

        private void PriceTB_Clicked(object sender, EventArgs e)
        {
            if (PriceTB.Text == priceTxt)
            {
                Resets(sender, e);
                PriceTB.Text = string.Empty;
                ChangeText(sender, e, true);
                this.ActiveControl = PriceTB;
            }
        }
        private void DurationTB_Clicked(Object sender, EventArgs e)
        {
            if (DurationTB.Text == durationTxt)
            {
                Resets(sender, e);
                DurationTB.Text = string.Empty;
                ChangeText(sender, e, true);
                this.ActiveControl = DurationTB;
            }
        }
        private void DescriptionTB_Clicked(Object sender, EventArgs e)
        {
            if (DescriptionTB.Text == descriptionTxt)
            {
                Resets(sender, e);
                DescriptionTB.Text = string.Empty;
                ChangeText(sender, e, true);
                this.ActiveControl = DescriptionTB;
            }
        }
        private void ServiceCB_Changed(Object sender, EventArgs e)
        {
            if (ServiceCB.SelectedIndex != -1)
            {
                int id = ServiceCB.SelectedIndex;

                ChangeText(sender, e, true);
                this.ActiveControl = null;

                NameTB.Clear();
                PriceTB.Clear();
                DescriptionTB.Clear();
                DurationTB.Clear();
                TimeChB.Checked = false;

                NameTB.Text = listServices[id].Libelle;
                PriceTB.Text = listServices[id].Prix.ToString();
                DescriptionTB.Text = listServices[id].Description;
                if (listServices[id].HaveDuration)
                {
                    TimeChB.Checked = true;
                    TimeChB_CheckedChanged(sender, e);
                    DurationTB.Text = listServices[id].Duration.ToString();
                }

                ChangeText(NameTB, e, true);
                ChangeText(PriceTB, e, true);
                ChangeText(DescriptionTB, e, true);
                ChangeText(DurationTB, e, true);
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
            if (PriceTB.Text == string.Empty)
            {
                PriceTB.Text = priceTxt;
                ChangeText(PriceTB, e, false);
            }
            if (DurationTB.Text == string.Empty)
            {
                DurationTB.Text = durationTxt;
                ChangeText(DurationTB, e, false);
            }
            if (DescriptionTB.Text == string.Empty)
            {
                DescriptionTB.Text = descriptionTxt;
                ChangeText(DescriptionTB, e, false);
            }
            this.ActiveControl = null;
        }
        private void Add_Clicked(object sender, EventArgs e)
        {
            if (NameTB.Text != string.Empty && NameTB.Text != nameTxt && PriceTB.Text != string.Empty && PriceTB.Text != priceTxt && DescriptionTB.Text != null && DescriptionTB.Text != descriptionTxt)
            {   
                try
                {
                    string name = NameTB.Text;
                    decimal price = Convert.ToDecimal(PriceTB.Text);
                    string description = DescriptionTB.Text;
                    if (TimeChB.Checked && DurationTB.Text != durationTxt && DurationTB.Text != string.Empty)
                    {
                        int duration = Convert.ToInt32(DurationTB.Text);

                        servicevm.AddService(name, price, duration, description);
                    }
                    else
                    {
                        servicevm.AddServiceWithoutDuration(name, price, description);
                    }

                    NameTB.Clear();
                    PriceTB.Clear();
                    DurationTB.Clear();
                    DescriptionTB.Clear();
                    Resets(this, e);
                    listServices = servicevm.getServices();
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
            if (NameTB.Text != string.Empty && NameTB.Text != nameTxt && PriceTB.Text != string.Empty && PriceTB.Text != priceTxt && DescriptionTB.Text != null && DescriptionTB.Text != descriptionTxt)
            {
                try
                {
                    int id = listServices[ServiceCB.SelectedIndex].Id;
                    string name = NameTB.Text;
                    decimal price = Convert.ToDecimal(PriceTB.Text);
                    string description = DescriptionTB.Text;
                    if (TimeChB.Checked && DurationTB.Text != durationTxt && DurationTB.Text != string.Empty)
                    {
                        int duration = Convert.ToInt32(DurationTB.Text);

                        servicevm.UpdService(id, name, price, duration, description);
                    }
                    else
                    {
                        servicevm.UpdServiceWithoutDuration(id, name, price, description);
                    }

                    NameTB.Clear();
                    PriceTB.Clear();
                    DurationTB.Clear();
                    DescriptionTB.Clear();
                    Resets(this, e);
                    listServices = servicevm.getServices();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    MessageBox.Show("La valeur entrée dans le champs 'Nom' ou le champs 'Prix Unitaire' n'est pas valide");
                }
            }
        }

        private void TimeChB_CheckedChanged(object sender, EventArgs e)
        {
            if (TimeChB.Checked)
            {
                DurationTB.Visible = true;
                DurationTB.Enabled = true;
            }
            else
            {
                DurationTB.Visible = false;
                DurationTB.Enabled = false;
            }
        }
    }
}
