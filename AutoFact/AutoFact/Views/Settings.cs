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
        public Settings()
        {
            InitializeComponent();
        }

        private void SelectLogoBtn_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Sélectionnez une image";
                openFileDialog.Filter = "Fichiers d'image (*.jpg;*.jpeg;*.png;*.bmp;*.gif)|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                openFileDialog.Multiselect = false;

                // Affiche la boîte de dialogue et vérifie si l'utilisateur a sélectionné un fichier
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Récupère le chemin du fichier sélectionné
                    string filePath = openFileDialog.FileName;

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
    }
}
