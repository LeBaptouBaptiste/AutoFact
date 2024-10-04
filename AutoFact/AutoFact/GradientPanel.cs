using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoFact
{
    public class GradientPanel : Panel
    {
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Créer un objet Graphics pour dessiner
            Graphics g = e.Graphics;

            // Créer un rectangle couvrant tout le Panel
            Rectangle rect = new Rectangle(0, 0, this.Width, this.Height);
            int cornerRadius = 90; // Rayon des coins arrondis

            // Créer un GraphicsPath pour le rectangle arrondi
            using (GraphicsPath path = new GraphicsPath())
            {
                // Ajouter un rectangle arrondi au GraphicsPath
                path.AddArc(rect.X, rect.Y, cornerRadius, cornerRadius, 180, 90); // Haut gauche
                path.AddArc(rect.Right - cornerRadius, rect.Y, cornerRadius, cornerRadius, 270, 90); // Haut droit
                path.AddArc(rect.Right - cornerRadius, rect.Bottom - cornerRadius, cornerRadius, cornerRadius, 0, 90); // Bas droit
                path.AddArc(rect.X, rect.Bottom - cornerRadius, cornerRadius, cornerRadius, 90, 90); // Bas gauche
                path.CloseFigure();

                // Créer un LinearGradientBrush pour le dégradé
                using (LinearGradientBrush brush = new LinearGradientBrush(rect, Color.FromArgb(255, 0, 128, 255), Color.FromArgb(231, 58, 58), 90F))
                {
                    // Remplir le GraphicsPath avec le dégradé
                    g.FillPath(brush, path);
                }

                // Si tu veux dessiner le contour arrondi, tu peux le faire ici
                using (Pen pen = new Pen(Color.Transparent, 2)) // Choisir la couleur et l'épaisseur du contour
                {
                    g.DrawPath(pen, path);
                }
            }
        }
    }
}
