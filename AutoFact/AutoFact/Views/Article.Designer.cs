using AutoFact.Views;

namespace AutoFact.Views

{
    partial class Article
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            navbarUserControl = new NavbarControll();
            NameTB = new TextBox();
            PriceTB = new TextBox();
            SupplyCB = new ComboBox();
            AddBtn = new Button();
            UpBtn = new Button();
            AddUpLbl = new Label();
            BuypriceTB = new TextBox();
            QuantityTB = new TextBox();
            DescriptionTB = new TextBox();
            NameLbl = new Label();
            PriceLbl = new Label();
            QuantityLbl = new Label();
            BuyPriceLbl = new Label();
            DescriptionLbl = new Label();
            SupplierLbl = new Label();
            SuspendLayout();
            // 
            // navbarUserControl
            // 
            navbarUserControl.BackColor = Color.Transparent;
            navbarUserControl.Dock = DockStyle.Left;
            navbarUserControl.ForeColor = SystemColors.ControlText;
            navbarUserControl.Location = new Point(0, 0);
            navbarUserControl.Name = "navbarUserControl";
            navbarUserControl.Size = new Size(450, 1041);
            navbarUserControl.TabIndex = 0;
            // 
            // NameTB
            // 
            NameTB.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            NameTB.ForeColor = Color.Silver;
            NameTB.Location = new Point(714, 289);
            NameTB.MaxLength = 255;
            NameTB.Name = "NameTB";
            NameTB.Size = new Size(180, 26);
            NameTB.TabIndex = 1;
            NameTB.Click += NameTB_Clicked;
            // 
            // PriceTB
            // 
            PriceTB.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            PriceTB.ForeColor = Color.Silver;
            PriceTB.Location = new Point(714, 405);
            PriceTB.Name = "PriceTB";
            PriceTB.Size = new Size(180, 26);
            PriceTB.TabIndex = 3;
            PriceTB.Click += PriceTB_Clicked;
            // 
            // SupplyCB
            // 
            SupplyCB.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            SupplyCB.ForeColor = Color.Silver;
            SupplyCB.FormattingEnabled = true;
            SupplyCB.Location = new Point(1460, 288);
            SupplyCB.Name = "SupplyCB";
            SupplyCB.Size = new Size(264, 27);
            SupplyCB.TabIndex = 4;
            SupplyCB.SelectedIndexChanged += SupplyCB_Changed;
            // 
            // AddBtn
            // 
            AddBtn.BackColor = Color.Blue;
            AddBtn.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            AddBtn.ForeColor = Color.White;
            AddBtn.Location = new Point(1022, 859);
            AddBtn.Name = "AddBtn";
            AddBtn.Size = new Size(275, 94);
            AddBtn.TabIndex = 5;
            AddBtn.Text = "Ajouter";
            AddBtn.UseVisualStyleBackColor = false;
            AddBtn.Click += Add_Clicked;
            // 
            // UpBtn
            // 
            UpBtn.BackColor = Color.Blue;
            UpBtn.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            UpBtn.ForeColor = Color.White;
            UpBtn.Location = new Point(1022, 859);
            UpBtn.Name = "UpBtn";
            UpBtn.Size = new Size(275, 94);
            UpBtn.TabIndex = 6;
            UpBtn.Text = "Modifier";
            UpBtn.UseVisualStyleBackColor = false;
            UpBtn.Click += Upd_Clicked;
            // 
            // AddUpLbl
            // 
            AddUpLbl.AutoSize = true;
            AddUpLbl.Font = new Font("Arial", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            AddUpLbl.Location = new Point(933, 159);
            AddUpLbl.Name = "AddUpLbl";
            AddUpLbl.Size = new Size(433, 37);
            AddUpLbl.TabIndex = 7;
            AddUpLbl.Text = "Ajout/Modification d'article";
            // 
            // BuypriceTB
            // 
            BuypriceTB.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BuypriceTB.ForeColor = Color.Silver;
            BuypriceTB.Location = new Point(1075, 405);
            BuypriceTB.MaxLength = 255;
            BuypriceTB.Name = "BuypriceTB";
            BuypriceTB.Size = new Size(180, 26);
            BuypriceTB.TabIndex = 8;
            BuypriceTB.Click += BuypriceTB_Clicked;
            // 
            // QuantityTB
            // 
            QuantityTB.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            QuantityTB.ForeColor = Color.Silver;
            QuantityTB.Location = new Point(1075, 288);
            QuantityTB.MaxLength = 255;
            QuantityTB.Name = "QuantityTB";
            QuantityTB.Size = new Size(180, 26);
            QuantityTB.TabIndex = 9;
            QuantityTB.Click += QuantityTB_Clicked;
            // 
            // DescriptionTB
            // 
            DescriptionTB.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            DescriptionTB.ForeColor = Color.Silver;
            DescriptionTB.Location = new Point(820, 520);
            DescriptionTB.MaxLength = 511;
            DescriptionTB.Multiline = true;
            DescriptionTB.Name = "DescriptionTB";
            DescriptionTB.Size = new Size(363, 170);
            DescriptionTB.TabIndex = 10;
            DescriptionTB.Click += DescriptionTB_Clicked;
            // 
            // NameLbl
            // 
            NameLbl.AutoSize = true;
            NameLbl.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            NameLbl.Location = new Point(714, 269);
            NameLbl.Name = "NameLbl";
            NameLbl.Size = new Size(46, 17);
            NameLbl.TabIndex = 15;
            NameLbl.Text = "Nom :";
            // 
            // PriceLbl
            // 
            PriceLbl.AutoSize = true;
            PriceLbl.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            PriceLbl.Location = new Point(714, 385);
            PriceLbl.Name = "PriceLbl";
            PriceLbl.Size = new Size(40, 17);
            PriceLbl.TabIndex = 16;
            PriceLbl.Text = "Prix :";
            // 
            // QuantityLbl
            // 
            QuantityLbl.AutoSize = true;
            QuantityLbl.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            QuantityLbl.Location = new Point(1075, 269);
            QuantityLbl.Name = "QuantityLbl";
            QuantityLbl.Size = new Size(49, 17);
            QuantityLbl.TabIndex = 17;
            QuantityLbl.Text = "Stock :";
            // 
            // BuyPriceLbl
            // 
            BuyPriceLbl.AutoSize = true;
            BuyPriceLbl.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BuyPriceLbl.Location = new Point(1075, 385);
            BuyPriceLbl.Name = "BuyPriceLbl";
            BuyPriceLbl.Size = new Size(89, 17);
            BuyPriceLbl.TabIndex = 18;
            BuyPriceLbl.Text = "Prix d'achat :";
            // 
            // DescriptionLbl
            // 
            DescriptionLbl.AutoSize = true;
            DescriptionLbl.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            DescriptionLbl.Location = new Point(820, 500);
            DescriptionLbl.Name = "DescriptionLbl";
            DescriptionLbl.Size = new Size(87, 17);
            DescriptionLbl.TabIndex = 19;
            DescriptionLbl.Text = "Description :";
            // 
            // SupplierLbl
            // 
            SupplierLbl.AutoSize = true;
            SupplierLbl.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            SupplierLbl.Location = new Point(1460, 268);
            SupplierLbl.Name = "SupplierLbl";
            SupplierLbl.Size = new Size(88, 17);
            SupplierLbl.TabIndex = 20;
            SupplierLbl.Text = "Fournisseur :";
            // 
            // Article
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(1904, 1041);
            Controls.Add(SupplierLbl);
            Controls.Add(DescriptionLbl);
            Controls.Add(BuyPriceLbl);
            Controls.Add(QuantityLbl);
            Controls.Add(PriceLbl);
            Controls.Add(NameLbl);
            Controls.Add(DescriptionTB);
            Controls.Add(QuantityTB);
            Controls.Add(BuypriceTB);
            Controls.Add(AddUpLbl);
            Controls.Add(UpBtn);
            Controls.Add(AddBtn);
            Controls.Add(SupplyCB);
            Controls.Add(PriceTB);
            Controls.Add(NameTB);
            Controls.Add(navbarUserControl);
            Margin = new Padding(4, 3, 4, 3);
            Name = "Article";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Article";
            WindowState = FormWindowState.Maximized;
            Click += Resets;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private NavbarControll navbarUserControl;
        private TextBox NameTB;
        private TextBox PriceTB;
        private ComboBox SupplyCB;
        private Button AddBtn;
        private Button UpBtn;
        private Label AddUpLbl;
        private TextBox BuypriceTB;
        private TextBox QuantityTB;
        private TextBox DescriptionTB;
        private Label NameLbl;
        private Label PriceLbl;
        private Label QuantityLbl;
        private Label BuyPriceLbl;
        private Label DescriptionLbl;
        private Label SupplierLbl;
    }
}