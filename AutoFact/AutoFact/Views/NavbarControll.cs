using AutoFact.Views;
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
    public partial class NavbarControll : UserControl
    {
        private BackgroundPanel backgroundPanel;
        public Form ParentForm { get; set; }
        public NavbarControll()
        {
            InitializeComponent();
            SetupNavbar();
            this.BackColor = Color.Transparent;
            this.DoubleBuffered = true;
        }
        private void SetupNavbar()
        {
            // Initialisation et configuration des composants
            Navbar = new GradientPanel();
            lblStats = new Label();
            lblPresta = new Label();
            btnDevis = new RoundedButton();
            btnFact = new RoundedButton();
            btnAvoir = new RoundedButton();
            separator1 = new Panel();
            btnCAc = new RoundedButton();
            btnCAca = new RoundedButton();
            separator2 = new Panel();
            btnArticle = new RoundedButton();
            btnFourn = new RoundedButton();
            btnServ = new RoundedButton();
            btnClient = new RoundedButton();
            separator3 = new Panel();
            btnAllfact = new RoundedButton();
            separator4 = new Panel();
            btnParam = new RoundedButton();

            Navbar.Controls.Add(lblStats);
            Navbar.Controls.Add(lblPresta);
            Navbar.Controls.Add(btnDevis);
            Navbar.Controls.Add(btnFact);
            Navbar.Controls.Add(btnAvoir);
            Navbar.Controls.Add(separator1);
            Navbar.Controls.Add(btnCAc);
            Navbar.Controls.Add(btnCAca);
            Navbar.Controls.Add(separator2);
            Navbar.Controls.Add(btnArticle);
            Navbar.Controls.Add(btnFourn);
            Navbar.Controls.Add(btnServ);
            Navbar.Controls.Add(btnClient);
            Navbar.Controls.Add(separator3);
            Navbar.Controls.Add(btnAllfact);
            Navbar.Controls.Add(separator4);
            Navbar.Controls.Add(btnParam);
            Navbar.Location = new Point(12, 80);
            Navbar.Name = "Navbar";
            Navbar.Size = new Size(400, 890);
            Navbar.TabIndex = 1;

            // 
            // btnDevis
            // 
            btnDevis.BackColor = Color.FromArgb(217, 217, 217);
            btnDevis.BorderColor = Color.Red;
            btnDevis.BorderRadius = 20;
            btnDevis.BorderThickness = 4;
            btnDevis.FlatAppearance.BorderColor = Color.Red;
            btnDevis.FlatStyle = FlatStyle.Flat;
            btnDevis.Font = new Font("Arial", 12F);
            btnDevis.Location = new Point(110, 30);
            btnDevis.Name = "btnDevis";
            btnDevis.Size = new Size(180, 40);
            btnDevis.TabIndex = 1;
            btnDevis.Text = "Devis";
            btnDevis.UseVisualStyleBackColor = false;
            btnDevis.MouseEnter += btn_Enter;
            btnDevis.MouseLeave += btn_Leave;
            // 
            // btnFact
            // 
            btnFact.BackColor = Color.FromArgb(217, 217, 217);
            btnFact.BorderColor = Color.Red;
            btnFact.BorderRadius = 20;
            btnFact.BorderThickness = 4;
            btnFact.FlatAppearance.BorderColor = Color.Red;
            btnFact.FlatStyle = FlatStyle.Flat;
            btnFact.Font = new Font("Arial", 12F);
            btnFact.Location = new Point(110, 90);
            btnFact.Name = "btnFact";
            btnFact.Size = new Size(180, 40);
            btnFact.TabIndex = 1;
            btnFact.Text = "Facturation";
            btnFact.UseVisualStyleBackColor = false;
            btnFact.MouseEnter += btn_Enter;
            btnFact.MouseLeave += btn_Leave;
            // 
            // btnAvoir
            // 
            btnAvoir.BackColor = Color.FromArgb(217, 217, 217);
            btnAvoir.BorderColor = Color.Red;
            btnAvoir.BorderRadius = 20;
            btnAvoir.BorderThickness = 4;
            btnAvoir.FlatAppearance.BorderColor = Color.Red;
            btnAvoir.FlatStyle = FlatStyle.Flat;
            btnAvoir.Font = new Font("Arial", 12F);
            btnAvoir.Location = new Point(110, 150);
            btnAvoir.Name = "btnAvoir";
            btnAvoir.Size = new Size(180, 40);
            btnAvoir.TabIndex = 1;
            btnAvoir.Text = "Avoirs";
            btnAvoir.UseVisualStyleBackColor = false;
            btnAvoir.MouseEnter += btn_Enter;
            btnAvoir.MouseLeave += btn_Leave;
            // 
            // separator1
            // 
            separator1.BackColor = Color.Black;
            separator1.Location = new Point(100, 210);
            separator1.Name = "separator1";
            separator1.Size = new Size(200, 2);
            separator1.TabIndex = 2;
            // 
            // lblStats
            // 
            lblStats.BackColor = Color.Transparent;
            lblStats.Font = new Font("Arial", 12F, FontStyle.Bold | FontStyle.Underline);
            lblStats.Location = new Point(110, 230);
            lblStats.Name = "lblStats";
            lblStats.Size = new Size(180, 40);
            lblStats.TabIndex = 6;
            lblStats.Text = "Statitiques";
            lblStats.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnCAc
            // 
            btnCAc.BackColor = Color.FromArgb(217, 217, 217);
            btnCAc.BorderColor = Color.Red;
            btnCAc.BorderRadius = 20;
            btnCAc.BorderThickness = 4;
            btnCAc.FlatAppearance.BorderColor = Color.Red;
            btnCAc.FlatStyle = FlatStyle.Flat;
            btnCAc.Font = new Font("Arial", 12F);
            btnCAc.Location = new Point(110, 290);
            btnCAc.Name = "btnCAc";
            btnCAc.Size = new Size(180, 40);
            btnCAc.TabIndex = 1;
            btnCAc.Text = "Calcul CA cumulé";
            btnCAc.UseVisualStyleBackColor = false;
            btnCAc.MouseEnter += btn_Enter;
            btnCAc.MouseLeave += btn_Leave;
            btnCAc.Click += btn_CAc_Click;
            // 
            // btnCAca
            // 
            btnCAca.BackColor = Color.FromArgb(217, 217, 217);
            btnCAca.BorderColor = Color.Red;
            btnCAca.BorderRadius = 20;
            btnCAca.BorderThickness = 4;
            btnCAca.FlatAppearance.BorderColor = Color.Red;
            btnCAca.FlatStyle = FlatStyle.Flat;
            btnCAca.Font = new Font("Arial", 12F);
            btnCAca.Location = new Point(110, 350);
            btnCAca.Name = "btnCAca";
            btnCAca.Size = new Size(180, 40);
            btnCAca.TabIndex = 1;
            btnCAca.Text = "Calcul CA client/année";
            btnCAca.UseVisualStyleBackColor = false;
            btnCAca.MouseEnter += btn_Enter;
            btnCAca.MouseLeave += btn_Leave;
            // 
            // separator2
            // 
            separator2.BackColor = Color.Black;
            separator2.Location = new Point(100, 410);
            separator2.Name = "separator2";
            separator2.Size = new Size(200, 2);
            separator2.TabIndex = 3;
            // 
            // lblPresta
            // 
            lblPresta.BackColor = Color.Transparent;
            lblPresta.Font = new Font("Arial", 12F, FontStyle.Bold | FontStyle.Underline);
            lblPresta.Location = new Point(110, 430);
            lblPresta.Name = "lblPresta";
            lblPresta.Size = new Size(180, 40);
            lblPresta.TabIndex = 6;
            lblPresta.Text = "Prestations";
            lblPresta.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // btnArticle
            // 
            btnArticle.BackColor = Color.FromArgb(217, 217, 217);
            btnArticle.BorderColor = Color.Red;
            btnArticle.BorderRadius = 20;
            btnArticle.BorderThickness = 4;
            btnArticle.FlatAppearance.BorderColor = Color.Red;
            btnArticle.FlatStyle = FlatStyle.Flat;
            btnArticle.Font = new Font("Arial", 12F);
            btnArticle.Location = new Point(110, 490);
            btnArticle.Name = "btnArticle";
            btnArticle.Size = new Size(180, 40);
            btnArticle.TabIndex = 1;
            btnArticle.Text = "Article";
            btnArticle.UseVisualStyleBackColor = false;
            btnArticle.MouseEnter += btn_Enter;
            btnArticle.MouseLeave += btn_Leave;
            btnArticle.Click += btn_Article_Click;
            // 
            // btnFourn
            // 
            btnFourn.BackColor = Color.FromArgb(217, 217, 217);
            btnFourn.BorderColor = Color.Red;
            btnFourn.BorderRadius = 20;
            btnFourn.BorderThickness = 4;
            btnFourn.FlatAppearance.BorderColor = Color.Red;
            btnFourn.FlatStyle = FlatStyle.Flat;
            btnFourn.Font = new Font("Arial", 12F);
            btnFourn.Location = new Point(110, 550);
            btnFourn.Name = "btnFourn";
            btnFourn.Size = new Size(180, 40);
            btnFourn.TabIndex = 1;
            btnFourn.Text = "Fournisseur";
            btnFourn.UseVisualStyleBackColor = false;
            btnFourn.MouseEnter += btn_Enter;
            btnFourn.MouseLeave += btn_Leave;
            btnFourn.Click += btn_Supplier_Click;
            // 
            // btnServ
            // 
            btnServ.BackColor = Color.FromArgb(217, 217, 217);
            btnServ.BorderColor = Color.Red;
            btnServ.BorderRadius = 20;
            btnServ.BorderThickness = 4;
            btnServ.FlatAppearance.BorderColor = Color.Red;
            btnServ.FlatStyle = FlatStyle.Flat;
            btnServ.Font = new Font("Arial", 12F);
            btnServ.Location = new Point(110, 610);
            btnServ.Name = "btnServ";
            btnServ.Size = new Size(180, 40);
            btnServ.TabIndex = 1;
            btnServ.Text = "Service";
            btnServ.UseVisualStyleBackColor = false;
            btnServ.MouseEnter += btn_Enter;
            btnServ.MouseLeave += btn_Leave;
            btnServ.Click += btn_Service_Click;
            // 
            // btnClient
            // 
            btnClient.BackColor = Color.FromArgb(217, 217, 217);
            btnClient.BorderColor = Color.Red;
            btnClient.BorderRadius = 20;
            btnClient.BorderThickness = 4;
            btnClient.FlatAppearance.BorderColor = Color.Red;
            btnClient.FlatStyle = FlatStyle.Flat;
            btnClient.Font = new Font("Arial", 12F);
            btnClient.Location = new Point(110, 670);
            btnClient.Name = "btnClient";
            btnClient.Size = new Size(180, 40);
            btnClient.TabIndex = 1;
            btnClient.Text = "Client";
            btnClient.UseVisualStyleBackColor = false;
            btnClient.MouseEnter += btn_Enter;
            btnClient.MouseLeave += btn_Leave;
            btnClient.Click += btn_Client_Click;
            // 
            // separator3
            // 
            separator3.BackColor = Color.Black;
            separator3.Location = new Point(100, 730);
            separator3.Name = "separator3";
            separator3.Size = new Size(200, 2);
            separator3.TabIndex = 4;
            // 
            // btnAllfact
            // 
            btnAllfact.BackColor = Color.FromArgb(217, 217, 217);
            btnAllfact.BorderColor = Color.Red;
            btnAllfact.BorderRadius = 20;
            btnAllfact.BorderThickness = 4;
            btnAllfact.FlatAppearance.BorderColor = Color.Red;
            btnAllfact.FlatStyle = FlatStyle.Flat;
            btnAllfact.Font = new Font("Arial", 12F);
            btnAllfact.Location = new Point(110, 750);
            btnAllfact.Name = "btnAllfact";
            btnAllfact.Size = new Size(180, 45);
            btnAllfact.TabIndex = 1;
            btnAllfact.Text = "Voir toutes les factures";
            btnAllfact.UseVisualStyleBackColor = false;
            btnAllfact.MouseEnter += btn_Enter;
            btnAllfact.MouseLeave += btn_Leave;
            // 
            // separator4
            // 
            separator4.BackColor = Color.Black;
            separator4.Location = new Point(100, 810);
            separator4.Name = "separator4";
            separator4.Size = new Size(200, 2);
            separator4.TabIndex = 5;
            // 
            // btnParam
            // 
            btnParam.BackColor = Color.FromArgb(217, 217, 217);
            btnParam.BorderColor = Color.Red;
            btnParam.BorderRadius = 20;
            btnParam.BorderThickness = 4;
            btnParam.FlatAppearance.BorderColor = Color.Red;
            btnParam.FlatStyle = FlatStyle.Flat;
            btnParam.Font = new Font("Arial", 12F);
            btnParam.Location = new Point(110, 830);
            btnParam.Name = "btnParam";
            btnParam.Size = new Size(180, 45);
            btnParam.TabIndex = 1;
            btnParam.Text = "Parametres";
            btnParam.UseVisualStyleBackColor = false;
            btnParam.MouseEnter += btn_Enter;
            btnParam.MouseLeave += btn_Leave;
            btnParam.Click += btn_Settings_Click;

            // Ajouter le panel Navbar au UserControl
            this.Controls.Add(Navbar);
        }

        private void btn_Enter(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            btn.BackColor = Color.DarkGray;
            btn.Font = new Font(btn.Font, FontStyle.Bold | FontStyle.Underline);
        }

        private void btn_Leave(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            btn.BackColor = Color.FromArgb(217, 217, 217);
            btn.Font = new Font("Arial", 12F, FontStyle.Regular);
        }

        private void btn_CAc_Click(object sender, EventArgs e)
        {
            CACumul form = new CACumul();
            Parent.Hide();
            form.Show();
        }

        private void btn_Article_Click(object sender, EventArgs e)
        {
            Article form = new Article();
            Parent.Hide();
            form.Show();
        }

        private void btn_Supplier_Click(object sender, EventArgs e)
        {
            SupplierShow form = new SupplierShow();
            Parent.Hide();
            form.Show();
        }

        private void btn_Service_Click(object sender, EventArgs e)
        {
            ServiceShow form = new ServiceShow();
            Parent.Hide();
            form.Show();
        }

        private void btn_Client_Click(object sender, EventArgs e)
        {
            ClientShow form = new ClientShow();
            Parent.Hide();
            form.Show();
        }

        private void btn_Settings_Click(object sender, EventArgs e)
        {
            Settings form = new Settings();
            Parent.Hide();
            form.Show();
        }

        // Composants
        private GradientPanel Navbar;
        private Panel separator1, separator2, separator3, separator4;
        private Label lblStats, lblPresta;
        private RoundedButton btnDevis, btnFact, btnAvoir, btnCAc, btnCAca, btnArticle, btnFourn, btnServ, btnClient, btnAllfact, btnParam;
    }
}
