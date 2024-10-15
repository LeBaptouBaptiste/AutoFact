using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoFact.Views
{
    public class CustomTextBox : TextBox
    {
        public CustomTextBox()
        {
            this.BorderStyle = BorderStyle.None; // Supprime la bordure par défaut
            this.BackColor = Color.White;        // Couleur de fond
            this.ForeColor = Color.Gray;         // Couleur du texte
            this.TextAlign = HorizontalAlignment.Center; // Centrer le texte
            this.Font = new Font("Arial", 12, FontStyle.Bold); // Style du texte
            this.Padding = new Padding(10, 5, 10, 5); // Espacement interne
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Dessiner la bordure rouge arrondie
            Graphics g = e.Graphics;
            Rectangle rect = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
            using (Pen pen = new Pen(Color.Red, 3))
            {
                g.DrawArc(pen, rect, 0, 360); // Arc pour les coins arrondis
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            this.Invalidate(); // Forcer le contrôle à se redessiner lors du redimensionnement
        }
    }
}
