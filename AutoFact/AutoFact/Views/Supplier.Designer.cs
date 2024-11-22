namespace AutoFact.Views
{
    partial class Supplier
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
            AddUpLbl = new Label();
            NameTB = new TextBox();
            MailTB = new TextBox();
            SiretTB = new TextBox();
            PhoneTB = new TextBox();
            AddressTB = new TextBox();
            CpTB = new TextBox();
            AddBtn = new Button();
            UpdBtn = new Button();
            NameLbl = new Label();
            SiretLbl = new Label();
            AddressLbl = new Label();
            MailLbl = new Label();
            PhoneLbl = new Label();
            CpLbl = new Label();
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
            navbarUserControl.TabIndex = 7;
            // 
            // AddUpLbl
            // 
            AddUpLbl.AutoSize = true;
            AddUpLbl.Font = new Font("Arial", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            AddUpLbl.Location = new Point(933, 159);
            AddUpLbl.Name = "AddUpLbl";
            AddUpLbl.Size = new Size(549, 37);
            AddUpLbl.Text = "Ajout/Modification de fournisseurs";
            // 
            // NameTB
            // 
            NameTB.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            NameTB.ForeColor = Color.Silver;
            NameTB.Location = new Point(837, 321);
            NameTB.MaxLength = 255;
            NameTB.Name = "NameTB";
            NameTB.Size = new Size(180, 26);
            NameTB.TabIndex = 0;
            NameTB.Text = nameTxt;
            NameTB.Click += NameTB_Clicked;
            NameTB.Enter += NameTB_Clicked;
            NameTB.Leave += (sender, e) => Resets(sender, false);
            // 
            // MailTB
            // 
            MailTB.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            MailTB.ForeColor = Color.Silver;
            MailTB.Location = new Point(1369, 321);
            MailTB.MaxLength = 255;
            MailTB.Name = "MailTB";
            MailTB.Size = new Size(180, 26);
            MailTB.TabIndex = 1;
            MailTB.Text = mailTxt;
            MailTB.Click += MailTB_Clicked;
            MailTB.Enter += MailTB_Clicked;
            MailTB.Leave += (sender, e) => Resets(sender, false);
            // 
            // SiretTB
            // 
            SiretTB.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            SiretTB.ForeColor = Color.Silver;
            SiretTB.Location = new Point(837, 447);
            SiretTB.MaxLength = 255;
            SiretTB.Name = "SiretTB";
            SiretTB.Size = new Size(180, 26);
            SiretTB.TabIndex = 2;
            SiretTB.Text = siretTxt;
            SiretTB.Click += SiretTB_Clicked;
            SiretTB.Enter += SiretTB_Clicked;
            SiretTB.Leave += (sender, e) => Resets(sender, false);
            // 
            // PhoneTB
            // 
            PhoneTB.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            PhoneTB.ForeColor = Color.Silver;
            PhoneTB.Location = new Point(1369, 447);
            PhoneTB.MaxLength = 255;
            PhoneTB.Name = "PhoneTB";
            PhoneTB.Size = new Size(180, 26);
            PhoneTB.TabIndex = 3;
            PhoneTB.Text = phoneTxt;
            PhoneTB.Click += PhoneTB_Clicked;
            PhoneTB.Enter += PhoneTB_Clicked;
            PhoneTB.Leave += (sender, e) => Resets(sender, false);
            // 
            // AddressTB
            // 
            AddressTB.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            AddressTB.ForeColor = Color.Silver;
            AddressTB.Location = new Point(837, 598);
            AddressTB.MaxLength = 255;
            AddressTB.Name = "AddressTB";
            AddressTB.Size = new Size(180, 26);
            AddressTB.TabIndex = 4;
            AddressTB.Text = addressTxt;
            AddressTB.Click += AddressTB_Clicked;
            AddressTB.Enter += AddressTB_Clicked;
            AddressTB.Leave += (sender, e) => Resets(sender, false);
            // 
            // CpTB
            // 
            CpTB.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CpTB.ForeColor = Color.Silver;
            CpTB.Location = new Point(1369, 598);
            CpTB.MaxLength = 255;
            CpTB.Name = "CpTB";
            CpTB.Size = new Size(180, 26);
            CpTB.TabIndex = 5;
            CpTB.Text = cpTxt;
            CpTB.Click += CpTB_Clicked;
            CpTB.Enter += CpTB_Clicked;
            CpTB.Leave += (sender, e) => Resets(sender, false);
            // 
            // AddBtn
            // 
            AddBtn.BackColor = Color.Blue;
            AddBtn.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            AddBtn.ForeColor = Color.White;
            AddBtn.Location = new Point(1049, 770);
            AddBtn.Name = "AddBtn";
            AddBtn.Size = new Size(282, 91);
            AddBtn.TabIndex = 6;
            AddBtn.Text = "Ajouter";
            AddBtn.UseVisualStyleBackColor = false;
            AddBtn.Click += Add_Clicked;
            // 
            // UpdBtn
            // 
            UpdBtn.BackColor = Color.Blue;
            UpdBtn.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            UpdBtn.ForeColor = Color.White;
            UpdBtn.Location = new Point(1049, 770);
            UpdBtn.Name = "UpdBtn";
            UpdBtn.Size = new Size(282, 91);
            UpdBtn.TabIndex = 6;
            UpdBtn.Text = "Modifier";
            UpdBtn.UseVisualStyleBackColor = false;
            UpdBtn.Click += Upd_Clicked;
            // 
            // NameLbl
            // 
            NameLbl.AutoSize = true;
            NameLbl.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            NameLbl.Location = new Point(837, 301);
            NameLbl.Name = "NameLbl";
            NameLbl.Size = new Size(46, 17);
            NameLbl.Text = "Nom :";
            // 
            // SiretLbl
            // 
            SiretLbl.AutoSize = true;
            SiretLbl.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            SiretLbl.Location = new Point(837, 427);
            SiretLbl.Name = "SiretLbl";
            SiretLbl.Size = new Size(44, 17);
            SiretLbl.Text = "Siret :";
            // 
            // AddressLbl
            // 
            AddressLbl.AutoSize = true;
            AddressLbl.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            AddressLbl.Location = new Point(837, 578);
            AddressLbl.Name = "AddressLbl";
            AddressLbl.Size = new Size(64, 17);
            AddressLbl.Text = "Adresse :";
            // 
            // MailLbl
            // 
            MailLbl.AutoSize = true;
            MailLbl.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            MailLbl.Location = new Point(1369, 301);
            MailLbl.Name = "MailLbl";
            MailLbl.Size = new Size(43, 17);
            MailLbl.Text = "Mail :";
            // 
            // PhoneLbl
            // 
            PhoneLbl.AutoSize = true;
            PhoneLbl.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            PhoneLbl.Location = new Point(1369, 427);
            PhoneLbl.Name = "PhoneLbl";
            PhoneLbl.Size = new Size(80, 17);
            PhoneLbl.Text = "Téléphone :";
            // 
            // CpLbl
            // 
            CpLbl.AutoSize = true;
            CpLbl.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CpLbl.Location = new Point(1366, 578);
            CpLbl.Name = "CpLbl";
            CpLbl.Size = new Size(89, 17);
            CpLbl.Text = "Code Postal :";
            // 
            // Supplier
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(1904, 1041);
            Controls.Add(CpLbl);
            Controls.Add(PhoneLbl);
            Controls.Add(MailLbl);
            Controls.Add(AddressLbl);
            Controls.Add(SiretLbl);
            Controls.Add(NameLbl);
            Controls.Add(NameTB);
            Controls.Add(MailTB);
            Controls.Add(SiretTB);
            Controls.Add(PhoneTB);
            Controls.Add(AddressTB);
            Controls.Add(CpTB);
            Controls.Add(AddBtn);
            Controls.Add(UpdBtn);
            Controls.Add(AddUpLbl);
            Controls.Add(navbarUserControl);
            Margin = new Padding(4, 3, 4, 3);
            Name = "Supplier";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Supplier";
            WindowState = FormWindowState.Maximized;
            Click += (sender, e) => Resets(sender, true);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private NavbarControll navbarUserControl;
        private Label AddUpLbl;
        private TextBox NameTB, MailTB, SiretTB, PhoneTB, AddressTB, CpTB;
        private Button AddBtn, UpdBtn;
        private Label NameLbl;
        private Label SiretLbl;
        private Label AddressLbl;
        private Label MailLbl;
        private Label PhoneLbl;
        private Label CpLbl;
    }
}