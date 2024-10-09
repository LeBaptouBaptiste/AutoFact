namespace AutoFact
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
            ArticleCB = new ComboBox();
            PriceTB = new TextBox();
            SupplyCB = new ComboBox();
            AddBtn = new Button();
            UpBtn = new Button();
            AddUpLbl = new Label();
            BuypriceTB = new TextBox();
            QuantityTB = new TextBox();
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
            NameTB.Location = new Point(694, 289);
            NameTB.MaxLength = 255;
            NameTB.Name = "NameTB";
            NameTB.Size = new Size(180, 26);
            NameTB.TabIndex = 1;
            NameTB.Text = nameTxt;
            NameTB.Click += NameTB_Clicked;
            // 
            // ArticleCB
            // 
            ArticleCB.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ArticleCB.ForeColor = Color.Silver;
            ArticleCB.FormattingEnabled = true;
            ArticleCB.Location = new Point(1275, 289);
            ArticleCB.Name = "ArticleCB";
            ArticleCB.Size = new Size(264, 27);
            ArticleCB.TabIndex = 2;
            ArticleCB.Text = "Article";
            // 
            // PriceTB
            // 
            PriceTB.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            PriceTB.ForeColor = Color.Silver;
            PriceTB.Location = new Point(694, 405);
            PriceTB.Name = "PriceTB";
            PriceTB.Size = new Size(180, 26);
            PriceTB.TabIndex = 3;
            PriceTB.Text = priceTxt;
            PriceTB.Click += PriceTB_Clicked;
            // 
            // SupplyCB
            // 
            SupplyCB.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            SupplyCB.ForeColor = Color.Silver;
            SupplyCB.FormattingEnabled = true;
            SupplyCB.Location = new Point(1275, 529);
            SupplyCB.Name = "SupplyCB";
            SupplyCB.Size = new Size(264, 27);
            SupplyCB.TabIndex = 4;
            SupplyCB.Text = supplyTxt;
            // 
            // AddBtn
            // 
            AddBtn.BackColor = Color.Blue;
            AddBtn.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            AddBtn.ForeColor = Color.White;
            AddBtn.Location = new Point(714, 828);
            AddBtn.Name = "AddBtn";
            AddBtn.Size = new Size(144, 43);
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
            UpBtn.Location = new Point(1355, 828);
            UpBtn.Name = "UpBtn";
            UpBtn.Size = new Size(144, 43);
            UpBtn.TabIndex = 6;
            UpBtn.Text = "Modifier";
            UpBtn.UseVisualStyleBackColor = false;
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
            BuypriceTB.Location = new Point(996, 405);
            BuypriceTB.MaxLength = 255;
            BuypriceTB.Name = "BuypriceTB";
            BuypriceTB.Size = new Size(180, 26);
            BuypriceTB.TabIndex = 8;
            BuypriceTB.Text = buypriceTxt;
            BuypriceTB.Click += BuypriceTB_Clicked;
            // 
            // QuantityTB
            // 
            QuantityTB.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            QuantityTB.ForeColor = Color.Silver;
            QuantityTB.Location = new Point(996, 289);
            QuantityTB.MaxLength = 255;
            QuantityTB.Name = "QuantityTB";
            QuantityTB.Size = new Size(180, 26);
            QuantityTB.TabIndex = 9;
            QuantityTB.Text = quantityTxt;
            QuantityTB.Click += QuantityTB_Clicked;
            // 
            // Article
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(1904, 1041);
            Controls.Add(QuantityTB);
            Controls.Add(BuypriceTB);
            Controls.Add(AddUpLbl);
            Controls.Add(UpBtn);
            Controls.Add(AddBtn);
            Controls.Add(SupplyCB);
            Controls.Add(PriceTB);
            Controls.Add(ArticleCB);
            Controls.Add(NameTB);
            Controls.Add(navbarUserControl);
            Margin = new Padding(4, 3, 4, 3);
            Name = "Article";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Article";
            WindowState = FormWindowState.Maximized;
            Click += Form_clicked;
            ResumeLayout(false);
            PerformLayout();
        }

        private void InitializeBackground()
        {
            backgroundPanel = new BackgroundPanel();
            backgroundPanel.SetBackgroundImage("Pictures\\background.png");
            backgroundPanel.Dock = DockStyle.Fill;
        }

        #endregion

        private NavbarControll navbarUserControl;
        private TextBox NameTB;
        private ComboBox ArticleCB;
        private TextBox PriceTB;
        private ComboBox SupplyCB;
        private Button AddBtn;
        private Button UpBtn;
        private Label AddUpLbl;
        private TextBox BuypriceTB;
        private TextBox QuantityTB;
    }
}