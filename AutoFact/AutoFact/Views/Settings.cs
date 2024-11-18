using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using AutoFact.ViewModel;
using AutoFact.Models;

namespace AutoFact.Views
{
    public partial class Settings : Form // Définit la fenêtre de paramètres de l'application.
    {
        // Texte par défaut pour différents champs de texte.
        string nameTxt = "Denomination de la société";
        string cpTxt = "Code postale";
        string phoneTxt = "Telephone professionel";
        string addressTxt = "Adresse postale";
        string mailTxt = "Email professionel";
        string countryTxt = "Pays";
        string tvaTxt = "TVA";

        public Settings()
        {
            InitializeComponent(); // Initialisation des composants de la fenêtre.
        }

        // Les méthodes déclenchées lorsqu'un champ de texte est cliqué.
        private void NameTB_Clicked(object sender, EventArgs e) => HandleFieldClick(sender, nameTxt);
        private void CpTB_Clicked(object sender, EventArgs e) => HandleFieldClick(sender, cpTxt);
        private void PhoneTB_Clicked(object sender, EventArgs e) => HandleFieldClick(sender, phoneTxt);
        private void AddressTB_Clicked(object sender, EventArgs e) => HandleFieldClick(sender, addressTxt);
        private void MailTB_Clicked(object sender, EventArgs e) => HandleFieldClick(sender, mailTxt);
        private void CountryTB_Clicked(object sender, EventArgs e) => HandleFieldClick(sender, countryTxt);
        private void TVATB_Clicked(object sender, EventArgs e) => HandleFieldClick(sender, tvaTxt);

        // Méthode générique pour gérer le clic sur un champ.
        private void HandleFieldClick(object sender, string defaultText)
        {
            TextBox textBox = sender as TextBox; // Cast l'objet déclencheur en TextBox.
            if (textBox.Text == defaultText) // Si le champ contient le texte par défaut :
            {
                Resets(sender, EventArgs.Empty); // Réinitialise les autres champs.
                textBox.Text = string.Empty; // Vide le texte.
                ChangeText(sender, EventArgs.Empty, true); // Change l'apparence (texte noir).
                this.ActiveControl = textBox; // Place le focus sur ce champ.
            }
        }

        // Efface tous les champs de texte.
        private void ClearFields()
        {
            NameTB.Clear();
            CpTB.Clear();
            PhoneTB.Clear();
            AddressTB.Clear();
            MailTB.Clear();
            CountryTB.Clear();
            TVATB.Clear();
        }

        // Change l'apparence de tous les champs.
        private void UpdateFieldAppearance()
        {
            ChangeText(NameTB, EventArgs.Empty, true);
            ChangeText(CpTB, EventArgs.Empty, true);
            ChangeText(PhoneTB, EventArgs.Empty, true);
            ChangeText(AddressTB, EventArgs.Empty, true);
            ChangeText(MailTB, EventArgs.Empty, true);
            ChangeText(CountryTB, EventArgs.Empty, true);
            ChangeText(TVATB, EventArgs.Empty, true);
        }

        // Change la couleur du texte d'un contrôle (noir ou gris).
        private void ChangeText(object sender, EventArgs e, bool able)
        {
            Control obj = sender as Control; // Cast en contrôle générique.
            obj.ForeColor = able ? Color.Black : Color.Silver; // Définit la couleur.
        }

        // Réinitialise les champs avec les textes par défaut.
        private void Resets(object sender, EventArgs e)
        {
            ResetField(NameTB, nameTxt, e);
            ResetField(CpTB, cpTxt, e);
            ResetField(PhoneTB, phoneTxt, e);
            ResetField(AddressTB, addressTxt, e);
            ResetField(MailTB, mailTxt, e);
            ResetField(CountryTB, countryTxt, e);
            ResetField(TVATB, tvaTxt, e);
            this.ActiveControl = null; // Enlève le focus.
        }

        // Réinitialise un champ spécifique s'il est vide.
        private void ResetField(TextBox textBox, string defaultText, EventArgs e)
        {
            if (textBox.Text == string.Empty) // Si le champ est vide :
            {
                textBox.Text = defaultText; // Remet le texte par défaut.
                ChangeText(textBox, e, false); // Change la couleur (texte gris).
            }
        }

        // Sélectionne et redimensionne un logo.
        private void SelectLogoBtn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Sélectionnez une image"; // Titre de la boîte de dialogue.
                openFileDialog.Filter = "Images Files|*.jpg;*.jpeg;*.png;*.bmp"; // Filtre les fichiers image.
                openFileDialog.Multiselect = false; // Permet de sélectionner un seul fichier.

                if (openFileDialog.ShowDialog() == DialogResult.OK) // Si un fichier est sélectionné :
                {
                    string logoPath = openFileDialog.FileName; // Chemin du fichier sélectionné.

                    // Répertoires pour enregistrer le fichier.
                    string projectDirectory = AppDomain.CurrentDomain.BaseDirectory;
                    string targetDirectory = Path.Combine(projectDirectory, "Pictures");
                    string targetFilePath = Path.Combine(targetDirectory, "NewLogo" + Path.GetExtension(logoPath));

                    DeleteExistingFiles("./Pictures/", "Logo.*"); // Supprime les anciens fichiers logo.
                    try
                    {
                        File.Copy(logoPath, targetFilePath, true); // Copie le fichier sélectionné.
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erreur lors de la copie de l'image : {ex.Message}");
                    }

                    // Charge et redimensionne l'image pour l'afficher dans PictureBox.
                    using (var memoryStream = new MemoryStream(File.ReadAllBytes(logoPath)))
                    {
                        LogoPB.Image = ResizeImage(Image.FromStream(memoryStream), LogoPB.Width, LogoPB.Height);
                    }
                    LogoPB.SizeMode = PictureBoxSizeMode.StretchImage; // Ajuste l'image.
                }
            }
        }

        // Redimensionne une image.
        Image ResizeImage(Image imgToResize, int width, int height)
        {
            Bitmap b = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage(b))
            {
                g.DrawImage(imgToResize, 0, 0, width, height); // Redimensionne l'image.
            }
            return b;
        }

        // Supprime les fichiers existants dans un répertoire selon un motif.
        private void DeleteExistingFiles(string directory, string pattern)
        {
            if (Directory.Exists(directory))
            {
                foreach (string file in Directory.GetFiles(directory, pattern))
                {
                    File.Delete(file); // Supprime chaque fichier correspondant au motif.
                }
            }
        }

        private void ChangeText(object sender, bool able)
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

        // Sauvegarde les paramètres dans un fichier .ini.
        private void SaveButton_Click(object sender, EventArgs e)
        {
            string configDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Config");
            if (!Directory.Exists(configDirectory))
            {
                Directory.CreateDirectory(configDirectory); // Crée le dossier s'il n'existe pas.
            }

            string configPath = Path.Combine(configDirectory, "config.ini");
            Inifile ini = new Inifile(configPath);

            // Écrit les valeurs des TextBox dans le fichier ini.
            ini.Write("Section", "Name", NameTB.Text);
            ini.Write("Section", "Phone", PhoneTB.Text);
            ini.Write("Section", "Mail", MailTB.Text);
            ini.Write("Section", "Address", AddressTB.Text);
            ini.Write("Section", "Cp", CpTB.Text);
            ini.Write("Section", "Country", CountryTB.Text);
            ini.Write("Section", "Delivery", DelivCB.Checked.ToString());
            ini.Write("Section", "TVA", TVATB.Text);

            // Gère le logo
            string logoDirectory = "./Pictures/";
            string[] logoFiles = Directory.GetFiles(logoDirectory, "NewLogo.*");

            if (logoFiles.Length > 0)
            {
                string logoPath = logoFiles[0];
                string targetFilePath = Path.Combine(logoDirectory, "Logo" + Path.GetExtension(logoPath));

                DeleteExistingFiles("./Pictures/", "Logo.*");
                try
                {
                    File.Copy(logoPath, targetFilePath, true);
                    DeleteExistingFiles("./Pictures/", "NewLogo.*");
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Erreur lors de la copie de l'image : {ex.Message}");
                }
            }
        }

        // Charge les paramètres depuis un fichier .ini.
        private void LoadForm(object sender, EventArgs e)
        {
            string filePath = "./Config/config.ini";
            Inifile ini = new Inifile(filePath);

            if (File.Exists(filePath)) // Si le fichier existe :
            {
                NameTB.Text = ini.Read("Section", "Name");
                PhoneTB.Text = ini.Read("Section", "Phone");
                MailTB.Text = ini.Read("Section", "Mail");
                AddressTB.Text = ini.Read("Section", "Address");
                CpTB.Text = ini.Read("Section", "Cp");
                CountryTB.Text = ini.Read("Section", "Country");
                DelivCB.Checked = Convert.ToBoolean(ini.Read("Section", "Delivery"));
                TVATB.Text = ini.Read("Section", "TVA");

                // Charge le logo.
                string logoDirectory = "./Pictures/";
                string[] logoFiles = Directory.GetFiles(logoDirectory, "Logo.*");

                if (logoFiles.Length > 0)
                {
                    string logoPath = logoFiles[0];
                    using (var memoryStream = new MemoryStream(File.ReadAllBytes(logoPath)))
                    {
                        LogoPB.Image = ResizeImage(Image.FromStream(memoryStream), LogoPB.Width, LogoPB.Height);
                    }
                    LogoPB.SizeMode = PictureBoxSizeMode.StretchImage;
                }

                // Met à jour l'apparence des champs.
                ChangeText(NameTB, true);
                ChangeText(PhoneTB, true);
                ChangeText(MailTB, true);
                ChangeText(AddressTB, true);
                ChangeText(CpTB, true);
                ChangeText(CountryTB, true);
                ChangeText(TVATB, true);
            }
        }
    }
}
