using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoFact
{
    public class RoundedButton : Button
    {
        public int BorderRadius { get; set; } = 20; // Rayon des coins arrondis
        public Color BorderColor { get; set; } = Color.Red; // Couleur de la bordure
        public int BorderThickness { get; set; } = 4; // Épaisseur de la bordure

        protected override void OnPaint(PaintEventArgs pevent)
        {
            // Dessiner le fond arrondi
            using (GraphicsPath path = new GraphicsPath())
            {
                path.StartFigure();
                path.AddArc(0, 0, BorderRadius, BorderRadius, 180, 90); // Coin supérieur gauche
                path.AddArc(Width - BorderRadius, 0, BorderRadius, BorderRadius, 270, 90); // Coin supérieur droit
                path.AddArc(Width - BorderRadius, Height - BorderRadius, BorderRadius, BorderRadius, 0, 90); // Coin inférieur droit
                path.AddArc(0, Height - BorderRadius, BorderRadius, BorderRadius, 90, 90); // Coin inférieur gauche
                path.CloseFigure();

                this.Region = new Region(path); // Définir la région du bouton pour qu'elle soit arrondie
                pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias; // Améliorer l'apparence des bords
                pevent.Graphics.FillPath(new SolidBrush(BackColor), path); // Remplir le fond
            }

            // Dessiner la bordure
            using (GraphicsPath path = new GraphicsPath())
            {
                path.StartFigure();
                path.AddArc(0, 0, BorderRadius, BorderRadius, 180, 90);
                path.AddArc(Width - BorderRadius, 0, BorderRadius, BorderRadius, 270, 90);
                path.AddArc(Width - BorderRadius, Height - BorderRadius, BorderRadius, BorderRadius, 0, 90);
                path.AddArc(0, Height - BorderRadius, BorderRadius, BorderRadius, 90, 90);
                path.CloseFigure();

                // Dessiner la bordure rouge
                using (Pen borderPen = new Pen(BorderColor, BorderThickness))
                {
                    pevent.Graphics.DrawPath(borderPen, path);
                }
            }

            // Dessiner le texte du bouton
            TextRenderer.DrawText(pevent.Graphics, this.Text, this.Font, this.ClientRectangle, this.ForeColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            // Ne pas dessiner le fond pour garder l'effet arrondi
        }
    }
}
