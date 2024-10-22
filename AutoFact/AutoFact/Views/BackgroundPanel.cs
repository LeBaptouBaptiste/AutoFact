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
    public partial class BackgroundPanel : UserControl
    {
        private Image backgroundImage;
        public BackgroundPanel()
        {
            InitializeComponent();
        }
        public void SetBackgroundImage(string imagePath)
        {
            backgroundImage = Image.FromFile(imagePath);
            this.Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            DrawBackgroundImage(e.Graphics);
        }

        private void DrawBackgroundImage(Graphics graphics)
        {
            if (backgroundImage != null)
            {
                int formWidth = this.ClientSize.Width;
                int formHeight = this.ClientSize.Height;

                for (int x = 0; x < formWidth; x += backgroundImage.Width)
                {
                    for (int y = 0; y < formHeight; y += backgroundImage.Height)
                    {
                        graphics.DrawImage(backgroundImage, x, y);
                    }
                }
            }
        }
    }
}
