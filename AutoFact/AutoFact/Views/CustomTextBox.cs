using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoFact.Views
{
    public class CustomTextBox : UserControl
    {
        private TextBox innerTextBox;
        private Color borderColor = Color.Red;

        public CustomTextBox()
        {
            // Initialisation de la TextBox interne
            innerTextBox = new TextBox
            {
                BorderStyle = BorderStyle.None, // Supprimer la bordure
                Font = new Font("Arial", 25, FontStyle.Regular), // Style du texte
                BackColor = Color.White,       // Couleur de fond
                ForeColor = Color.Black,        // Couleur du texte
                Dock = DockStyle.Fill,         // Remplit le UserControl
                Margin = new Padding(10, 5, 10, 5), // Espacement interne
            };

            // Ajouter la TextBox au UserControl
            this.Controls.Add(innerTextBox);

            // Propriétés visuelles du UserControl
            this.Padding = new Padding(15); // Espacement pour la bordure
            this.MinimumSize = new Size(250, 50);
            this.Size = new Size(250, 50);  // Taille par défaut

            innerTextBox.Click += InnerTextBox_Click;
            innerTextBox.MouseClick += InnerTextBox_MouseClick;
            innerTextBox.MouseDown += InnerTextBox_MouseDown;
        }
        private void InnerTextBox_Click(object sender, EventArgs e)
        {
            innerTextBox.Focus();
        }

        private void InnerTextBox_MouseClick(object sender, MouseEventArgs e)
        {
            innerTextBox.Focus();
        }

        private void InnerTextBox_MouseDown(object sender, MouseEventArgs e)
        {
            innerTextBox.Focus();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            PaintBackground(e);

            // Dessiner une bordure arrondie
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rect = new Rectangle(0, 0, this.Width - 1, this.Height - 1);
            using (Pen pen = new Pen(Color.Red, 10))
            {
                DrawRoundedRectangle(g, pen, rect, 40); // Rayon : 25
            }
        }

        private void PaintBackground(PaintEventArgs e)
        {
            if (Parent != null)
            {
                // Copier l'arrière-plan du contrôle parent
                using (Brush brush = new SolidBrush(Parent.BackColor))
                {
                    e.Graphics.FillRectangle(brush, this.ClientRectangle);
                }
            }
        }

        /// <summary>
        /// Méthode pour dessiner un rectangle arrondi
        /// </summary>
        private void DrawRoundedRectangle(Graphics g, Pen pen, Rectangle rect, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            path.AddArc(rect.X, rect.Y, radius, radius, 180, 90);
            path.AddArc(rect.X + rect.Width - radius, rect.Y, radius, radius, 270, 90);
            path.AddArc(rect.X + rect.Width - radius, rect.Y + rect.Height - radius, radius, radius, 0, 90);
            path.AddArc(rect.X, rect.Y + rect.Height - radius, radius, radius, 90, 90);
            path.CloseFigure();

            g.DrawPath(pen, path);
        }

        // Expose les propriétés de la TextBox interne
        public override string Text
        {
            get => innerTextBox.Text;
            set => innerTextBox.Text = value;
        }

        public new Font Font
        {
            get => innerTextBox.Font;
            set => innerTextBox.Font = value;
        }

        public new Color BackColor
        {
            get => innerTextBox.BackColor;
            set => innerTextBox.BackColor = value;
        }

        public new Color ForeColor
        {
            get => innerTextBox.ForeColor;
            set => innerTextBox.ForeColor = value;
        }

        public bool Multiline
        {
            get => innerTextBox.Multiline;
            set => innerTextBox.Multiline = value;
        }
        public Color BorderColor
        {
            get => borderColor;
            set
            {
                borderColor = value;
                this.Invalidate();  // Redessiner pour appliquer la nouvelle couleur
            }
        }
        public int MaxLength
        {
            get => innerTextBox.MaxLength;
            set => innerTextBox.MaxLength = value;
        }
        protected override void OnLayout(LayoutEventArgs e)
        {
            base.OnLayout(e);
            innerTextBox.Location = new Point(this.Padding.Left, this.Padding.Top);
            innerTextBox.Size = new Size(
                this.Width - this.Padding.Left - this.Padding.Right,
                this.Height - this.Padding.Top - this.Padding.Bottom
            );
        }

        public event EventHandler TextChanged
        {
            add => innerTextBox.TextChanged += value;
            remove => innerTextBox.TextChanged -= value;
        }

        public void Clear()
        {
            innerTextBox.Clear();
        }

    }
}
