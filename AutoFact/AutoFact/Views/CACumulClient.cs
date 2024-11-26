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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AutoFact.Views
{
    public partial class CACumulClient : Form
    {
        string nameTxt = "Nom";
        string prenomTxt = "Prénom";
        string anneeTxt = "Année";

        CAClientVM clientvm;
        List<Particuliers> listClients;
        public CACumulClient()
        {
            InitializeComponent();
            clientvm = new CAClientVM();
        }
        private void CACumulClient_Load(object sender, EventArgs e)
        {
            DataTable data = clientvm.getClientsForDGV();
            ClientsDGV.DataSource = data;
        }
        // Méthode générique pour gérer les clics sur les champs de saisie
        private void HandleFieldClick(object sender, string defaultText)
        {
            CustomTextBox textBox = sender as CustomTextBox;
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
            FirstNameTB.Clear();
            AnneeTB.Clear();
        }

        // Mise à jour de l'apparence des champs (couleur du texte)
        private void UpdateFieldAppearance()
        {
            ChangeText(NameTB, true);
            ChangeText(FirstNameTB, true);
            ChangeText(AnneeTB, true);
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
            ResetField(FirstNameTB, prenomTxt);
            ResetField(AnneeTB, anneeTxt);
            if (resetControll)
            {
                this.ActiveControl = null;
            }
        }

        // Réinitialisation d'un champ de texte
        private void ResetField(CustomTextBox textBox, string defaultText)
        {
            if (textBox.Text == string.Empty)
            {
                textBox.Text = defaultText;
                ChangeText(textBox, false);
            }
        }

        private void TextChanged(object sender, EventArgs e)
        {
            if (IsValidClientInput())
            {
                ClientsDGV.ClearSelection();
                DataTable data = clientvm.getClientsForDGVWithParams(NameTB.Text, FirstNameTB.Text);
                ClientsDGV.DataSource = data;
            }
            else if(NameTB.Text != string.Empty && NameTB.Text != nameTxt)
            {
                ClientsDGV.ClearSelection();
                DataTable data = clientvm.getClientsForDGVWithParams(NameTB.Text, "");
                ClientsDGV.DataSource = data;
            }
            else if (FirstNameTB.Text != string.Empty && FirstNameTB.Text != prenomTxt)
            {
                ClientsDGV.ClearSelection();
                DataTable data = clientvm.getClientsForDGVWithParams("", FirstNameTB.Text);
                ClientsDGV.DataSource = data;
            }
            else
            {
                ClientsDGV.ClearSelection();
                DataTable data = clientvm.getClientsForDGV();
                ClientsDGV.DataSource = data;
            }
        }
        private bool IsValidClientInput()
        {
            return NameTB.Text != string.Empty && NameTB.Text != nameTxt &&
                   FirstNameTB.Text != string.Empty && FirstNameTB.Text != prenomTxt;
        }
    }
}
