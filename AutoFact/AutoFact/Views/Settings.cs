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
        string tvaTxt = "TVA";
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
                    string logoPath = openFileDialog.FileName;

                    string projectDirectory = AppDomain.CurrentDomain.BaseDirectory; // Répertoire de l'exécutable
                    string targetDirectory = Path.Combine(projectDirectory, "Pictures");

                    string targetFilePath = Path.Combine(targetDirectory, "NewLogo" + Path.GetExtension(logoPath));

                    DeleteExistingFiles("./Pictures/", "Logo.*");
                    try
                    {
                        File.Copy(logoPath, targetFilePath, true); // 'true' pour écraser si existe déjà
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Erreur lors de la copie de l'image : {ex.Message}");
                    }

                    using (var memoryStream = new MemoryStream(File.ReadAllBytes(logoPath)))
                    {
                        LogoPB.Image = ResizeImage(Image.FromStream(memoryStream), LogoPB.Width, LogoPB.Height);
                    }

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
        private void DeleteExistingFiles(string directory, string pattern)
        {
            if (Directory.Exists(directory))
            {
                foreach (string file in Directory.GetFiles(directory, pattern))
                {
                    File.Delete(file);
                }
            }
        }

        private void NameTB_Clicked(object sender, EventArgs e)
        {
            if (NameTB.Text == nameTxt)
            {
                Resets(sender, e);
                NameTB.Text = string.Empty;
                ChangeText(sender, true);
                this.ActiveControl = NameTB;
            }
        }

        private void PhoneTB_Clicked(object sender, EventArgs e)
        {
            if (PhoneTB.Text == phoneTxt)
            {
                Resets(sender, e);
                PhoneTB.Text = string.Empty;
                ChangeText(sender, true);
                this.ActiveControl = PhoneTB;
            }
        }

        private void MailTB_Clicked(object sender, EventArgs e)
        {
            if (MailTB.Text == mailTxt)
            {
                Resets(sender, e);
                MailTB.Text = string.Empty;
                ChangeText(sender, true);
                this.ActiveControl = MailTB;
            }
        }

        private void AddressTB_Clicked(object sender, EventArgs e)
        {
            if (AddressTB.Text == addressTxt)
            {
                Resets(sender, e);
                AddressTB.Text = string.Empty;
                ChangeText(sender, true);
                this.ActiveControl = AddressTB;
            }
        }

        private void CpTB_Clicked(object sender, EventArgs e)
        {
            if (CpTB.Text == cpTxt)
            {
                Resets(sender, e);
                CpTB.Text = string.Empty;
                ChangeText(sender, true);
                this.ActiveControl = CpTB;
            }
        }

        private void CountryTB_Clicked(object sender, EventArgs e)
        {
            if (CountryTB.Text == countryTxt)
            {
                Resets(sender, e);
                CountryTB.Text = string.Empty;
                ChangeText(sender, true);
                this.ActiveControl = CountryTB;
            }
        }
        private void TVATB_Clicked(object sender, EventArgs e)
        {
            if (TVATB.Text == tvaTxt)
            {
                Resets(sender, e);
                TVATB.Text = string.Empty;
                ChangeText(sender, true);
                this.ActiveControl = TVATB;
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
        private void Resets(object sender, EventArgs e)
        {
            if (NameTB.Text == string.Empty)
            {
                NameTB.Text = nameTxt;
                ChangeText(NameTB, false);
            }
            if (PhoneTB.Text == string.Empty)
            {
                PhoneTB.Text = phoneTxt;
                ChangeText(PhoneTB, false);
            }
            if (MailTB.Text == string.Empty)
            {
                MailTB.Text = mailTxt;
                ChangeText(MailTB, false);
            }
            if (AddressTB.Text == string.Empty)
            {
                AddressTB.Text = addressTxt;
                ChangeText(AddressTB, false);
            }
            if (CpTB.Text == string.Empty)
            {
                CpTB.Text = cpTxt;
                ChangeText(CpTB, false);
            }
            if (CountryTB.Text == string.Empty)
            {
                CountryTB.Text = countryTxt;
                ChangeText(CountryTB, false);
            }
            if (TVATB.Text == string.Empty)
            {
                TVATB.Text = tvaTxt;
                ChangeText(TVATB, false);
            }
            this.ActiveControl = null;
        }
        private void SaveButton_Click(object sender, EventArgs e)
        {
            string configDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Config");
            if (!Directory.Exists(configDirectory))
            {
                Directory.CreateDirectory(configDirectory);
            }
            string configPath = Path.Combine(configDirectory, "config.ini");
            Inifile ini = new Inifile(configPath);

            // Enregistrez les informations des TextBox dans des sections et des clés du fichier ini
            ini.Write("Section", "Name", NameTB.Text);
            ini.Write("Section", "Phone", PhoneTB.Text);
            ini.Write("Section", "Mail", MailTB.Text);
            ini.Write("Section", "Address", AddressTB.Text);
            ini.Write("Section", "Cp", CpTB.Text);
            ini.Write("Section", "Country", CountryTB.Text);
            ini.Write("Section", "Delivery", DelivCB.Checked.ToString());
            ini.Write("Section", "TVA", TVATB.Text);

            string logoDirectory = "./Pictures/";
            string[] logoFiles = Directory.GetFiles(logoDirectory, "NewLogo.*");

            string logoPath = "";

            if (logoFiles.Length > 0)
            {
                logoPath = logoFiles[0]; // Prend le premier fichier trouvé
            }

            string projectDirectory = AppDomain.CurrentDomain.BaseDirectory; // Répertoire de l'exécutable
            string targetDirectory = Path.Combine(projectDirectory, "Pictures");

            string targetFilePath = Path.Combine(targetDirectory, "Logo" + Path.GetExtension(logoPath));

            DeleteExistingFiles("./Pictures/", "Logo.*");
            try
            {
                File.Copy(logoPath, targetFilePath, true); // 'true' pour écraser si existe déjà
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors de la copie de l'image : {ex.Message}");
            }
        }


        private void LoadForm(object sender, EventArgs e)
        {
            // Chargez les informations depuis le fichier .ini
            string filePath = "./Config/config.ini";
            Inifile ini = new Inifile(filePath);

            if (File.Exists(filePath))
            {
                NameTB.Text = ini.Read("Section", "Name");
                PhoneTB.Text = ini.Read("Section", "Phone");
                MailTB.Text = ini.Read("Section", "Mail");
                AddressTB.Text = ini.Read("Section", "Address");
                CpTB.Text = ini.Read("Section", "Cp");
                CountryTB.Text = ini.Read("Section", "Country");
                DelivCB.Checked = Convert.ToBoolean(ini.Read("Section", "Delivery"));
                TVATB.Text = ini.Read("Section", "TVA");

                string logoDirectory = "./Pictures/";
                string[] logoFiles = Directory.GetFiles(logoDirectory, "Logo.*");

                if (logoFiles.Length > 0)
                {
                    string logoPath = logoFiles[0]; // Prend le premier fichier trouvé
                    using (var memoryStream = new MemoryStream(File.ReadAllBytes(logoPath)))
                    {
                        LogoPB.Image = ResizeImage(Image.FromStream(memoryStream), LogoPB.Width, LogoPB.Height);
                    }

                    LogoPB.SizeMode = PictureBoxSizeMode.StretchImage;
                }

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