using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using AutoFact.ViewModel;
using AutoFact.Models;

namespace AutoFact.Views
{
    public partial class Service : Form
    {
        // Texte par défaut pour les champs de saisie
        private string nameTxt = "Designation";
        private string priceTxt = "Prix";
        private string descriptionTxt = "Description";
        private string durationTxt = "Durée";
        private string serviceTxt = "Service";

        private ServiceVM servicevm;
        private List<Services> listServices;

        public Service()
        {
            InitializeComponent();

            // Initialisation du ViewModel et récupération des services existants
            servicevm = new ServiceVM(ServiceCB);
            listServices = servicevm.getServices();
        }

        // Gestion des clics dans les champs de saisie
        private void NameTB_Clicked(object sender, EventArgs e) => HandleFieldClick(sender, nameTxt);
        private void PriceTB_Clicked(object sender, EventArgs e) => HandleFieldClick(sender, priceTxt);
        private void DurationTB_Clicked(object sender, EventArgs e) => HandleFieldClick(sender, durationTxt);
        private void DescriptionTB_Clicked(object sender, EventArgs e) => HandleFieldClick(sender, descriptionTxt);

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

        // Changement de sélection pour le service
        private void ServiceCB_Changed(object sender, EventArgs e)
        {
            if (ServiceCB.SelectedIndex != -1)
            {
                int id = ServiceCB.SelectedIndex;
                ChangeText(sender, EventArgs.Empty, true);
                this.ActiveControl = null;

                // Effacer les champs avant de remplir les données
                ClearFields();

                // Remplir les champs avec les données du service sélectionné
                NameTB.Text = listServices[id].Libelle;
                PriceTB.Text = listServices[id].Prix.ToString();
                DescriptionTB.Text = listServices[id].Description ?? string.Empty;

                if (listServices[id].HaveDuration)
                {
                    TimeChB.Checked = true;
                    TimeChB_CheckedChanged(sender, EventArgs.Empty);
                    DurationTB.Text = listServices[id].Duration.ToString();
                }

                // Mettre à jour l'apparence des champs
                UpdateFieldAppearance();
            }
        }

        // Méthode pour effacer les champs de saisie
        private void ClearFields()
        {
            NameTB.Clear();
            PriceTB.Clear();
            DurationTB.Clear();
            DescriptionTB.Clear();
            TimeChB.Checked = false;
        }

        // Mise à jour de l'apparence des champs (couleur du texte)
        private void UpdateFieldAppearance()
        {
            ChangeText(NameTB, EventArgs.Empty, true);
            ChangeText(PriceTB, EventArgs.Empty, true);
            ChangeText(DurationTB, EventArgs.Empty, true);
            if (!string.IsNullOrEmpty(DescriptionTB.Text))
            {
                ChangeText(DescriptionTB, EventArgs.Empty, true);
            }
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
            ResetField(PriceTB, priceTxt, e);
            ResetField(DurationTB, durationTxt, e);
            ResetField(DescriptionTB, descriptionTxt, e);
            ResetComboBox(ServiceCB, serviceTxt, e);
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

        // Ajout d'un nouveau service
        private void Add_Clicked(object sender, EventArgs e)
        {
            if (IsValidServiceInput())
            {
                try
                {
                    string name = NameTB.Text;
                    decimal price = Convert.ToDecimal(PriceTB.Text);
                    string description = DescriptionTB.Text != descriptionTxt ? DescriptionTB.Text : null;

                    if (TimeChB.Checked && DurationTB.Text != durationTxt && DurationTB.Text != string.Empty)
                    {
                        int duration = Convert.ToInt32(DurationTB.Text);
                        servicevm.addService(name, price, duration, description);
                    }
                    else
                    {
                        servicevm.addServiceWithoutDuration(name, price, description);
                    }

                    ClearFields();
                    Resets(this, EventArgs.Empty);

                    // Rafraîchir la liste des services
                    listServices = servicevm.getServices();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    MessageBox.Show("La valeur entrée dans les champs n'est pas valide.");
                }
            }
        }

        // Mise à jour d'un service existant
        private void Upd_Clicked(object sender, EventArgs e)
        {
            if (IsValidServiceInput() && ServiceCB.SelectedIndex != -1)
            {
                try
                {
                    int id = listServices[ServiceCB.SelectedIndex].Id;
                    string name = NameTB.Text;
                    decimal price = Convert.ToDecimal(PriceTB.Text);
                    string description = DescriptionTB.Text != descriptionTxt ? DescriptionTB.Text : null;

                    if (TimeChB.Checked && DurationTB.Text != durationTxt && DurationTB.Text != string.Empty)
                    {
                        int duration = Convert.ToInt32(DurationTB.Text);
                        servicevm.updService(id, name, price, duration, description);
                    }
                    else
                    {
                        servicevm.updServiceWithoutDuration(id, name, price, description);
                    }

                    ClearFields();
                    ServiceCB.SelectedIndex = -1;
                    Resets(this, EventArgs.Empty);

                    // Rafraîchir la liste des services
                    listServices = servicevm.getServices();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    MessageBox.Show("La valeur entrée dans les champs n'est pas valide.");
                }
            }
        }

        // Vérification que l'entrée du service est valide
        private bool IsValidServiceInput()
        {
            return NameTB.Text != string.Empty && NameTB.Text != nameTxt &&
                   PriceTB.Text != string.Empty && PriceTB.Text != priceTxt &&
                   DescriptionTB.Text != null && DescriptionTB.Text != descriptionTxt;
        }

        // Gestion de la visibilité du champ "Durée"
        private void TimeChB_CheckedChanged(object sender, EventArgs e)
        {
            DurationTB.Visible = TimeChB.Checked;
            DurationTB.Enabled = TimeChB.Checked;
        }
    }
}