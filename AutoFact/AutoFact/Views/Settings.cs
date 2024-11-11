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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using AutoFact.ViewModel;

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
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erreur lors de la copie de l'image : {ex.Message}");
                    }

                    LogoPB.Image = ResizeImage(Image.FromFile(filePath), LogoPB.Width, LogoPB.Height);
                    LogoPB.SizeMode = PictureBoxSizeMode.StretchImage; // Ajuste l'image au contrôle PictureBox
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
        private void SaveButton_Click(object sender, EventArgs e)
        {
            // Définissez le chemin de votre fichier .ini
            Inifile ini = new Inifile("config.ini");

            // Enregistrez les informations des TextBox dans des sections et des clés du fichier ini
            ini.Write("Section", "Name", NameTB.Text);
            ini.Write("Section", "Phone", PhoneTB.Text);
            ini.Write("Section", "Mail", MailTB.Text);
            ini.Write("Section", "Address", AddressTB.Text);
            ini.Write("Section", "Cp", CpTB.Text);
            ini.Write("Section", "Country", CountryTB.Text);

            MessageBox.Show("Données enregistrées dans le fichier .ini");
        }

        private void LoadForm(object sender, EventArgs e)
        {
            // Chargez les informations depuis le fichier .ini
            string filePath = "config.ini";
            Inifile ini = new Inifile(filePath);

            if (File.Exists(filePath))
            {
                NameTB.Text = ini.Read("Section", "Name");
                PhoneTB.Text = ini.Read("Section", "Phone");
                MailTB.Text = ini.Read("Section", "Mail");
                AddressTB.Text = ini.Read("Section", "Address");
                CpTB.Text = ini.Read("Section", "Cp");
                CountryTB.Text = ini.Read("Section", "Country");

                MessageBox.Show("Données chargées depuis le fichier .ini");
            }
        }
    }
}