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
    public partial class Settings : Form
    {
        string nameTxt = "Denomination de la société";
        string cpTxt = "Code postale";
        string phoneTxt = "Telephone professionel";
        string addressTxt = "Adresse postale";
        string mailTxt = "Email professionel";
        string countryTxt = "Pays";

        public Settings()
        {
            InitializeComponent();
        }

        private void SelectLogoBtn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Sélectionnez une image";
                openFileDialog.Filter = "Images Files|*.jpg;*.jpeg;*.png;*.bmp";
                openFileDialog.Multiselect = false;

                // Affiche la boîte de dialogue et vérifie si l'utilisateur a sélectionné un fichier
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Récupère le chemin du fichier sélectionné
                    string filePath = openFileDialog.FileName;

                    string projectDirectory = AppDomain.CurrentDomain.BaseDirectory; // Répertoire de l'exécutable
                    string targetDirectory = Path.Combine(projectDirectory, "Pictures");

                    string targetFilePath = Path.Combine(targetDirectory, "Logo" + Path.GetExtension(filePath));

                    string[] existingFiles = Directory.GetFiles(targetDirectory, "Logo.*");
                    foreach (string file in existingFiles)
                    {
                        File.Delete(file);
                    }

                    try
                    {
                        File.Copy(filePath, targetFilePath, true); // 'true' pour écraser si existe déjà
                        MessageBox.Show("Image copiée avec succès dans le projet.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erreur lors de la copie de l'image : {ex.Message}");
                    }

                    LogoPB.Image = ResizeImage(Image.FromFile(filePath), LogoPB.Width, LogoPB.Height);
                    LogoPB.SizeMode = PictureBoxSizeMode.StretchImage; // Ajuste l'image au contrôle PictureBox

                    // Optionnel : Affiche un message ou met à jour un label ou TextBox avec le chemin
                    MessageBox.Show("Image chargée : " + filePath, "Image Importée");
                }
            }
        }

        Image ResizeImage(Image imgToResize, int width, int height)
        {
            Bitmap b = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(b))
            {
                g.DrawImage(imgToResize, 0, 0, width, height);
            }
            return b;
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

        private void CountryTB_Clicked(object sender, EventArgs e)
        {
            if (CountryTB.Text == countryTxt)
            {
                Resets(sender, e);
                CountryTB.Text = string.Empty;
                ChangeText(sender, e, true);
                this.ActiveControl = CountryTB;
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
            if (PhoneTB.Text == string.Empty)
            {
                PhoneTB.Text = phoneTxt;
                ChangeText(PhoneTB, e, false);
            }
            if (MailTB.Text == string.Empty)
            {
                MailTB.Text = mailTxt;
                ChangeText(MailTB, e, false);
            }
            if (AddressTB.Text == string.Empty)
            {
                AddressTB.Text = addressTxt;
                ChangeText(AddressTB, e, false);
            }
            if(CpTB.Text == string.Empty)
            {
                CpTB.Text = cpTxt;
                ChangeText(CpTB, e, false);
            }
            if (CountryTB.Text == string.Empty)
            {
                CountryTB.Text = countryTxt;
                ChangeText(CountryTB, e, false);
            }
            this.ActiveControl = null;
        }
    }
}
