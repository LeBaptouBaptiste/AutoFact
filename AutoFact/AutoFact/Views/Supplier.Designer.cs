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
            SuppliersCB = new ComboBox();
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
            // AddUpLbl
            // 
            AddUpLbl.AutoSize = true;
            AddUpLbl.Font = new Font("Arial", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            AddUpLbl.Location = new Point(933, 159);
            AddUpLbl.Name = "AddUpLbl";
            AddUpLbl.Size = new Size(549, 37);
            AddUpLbl.TabIndex = 7;
            AddUpLbl.Text = "Ajout/Modification de fournisseurs";
            // 
            // NameTB
            // 
            NameTB.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            NameTB.ForeColor = Color.Silver;
            NameTB.Location = new Point(731, 334);
            NameTB.MaxLength = 255;
            NameTB.Name = "NameTB";
            NameTB.Size = new Size(180, 26);
            NameTB.TabIndex = 1;
            NameTB.Click += NameTB_Clicked;
            // 
            // MailTB
            // 
            MailTB.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            MailTB.ForeColor = Color.Silver;
            MailTB.Location = new Point(1093, 334);
            MailTB.MaxLength = 255;
            MailTB.Name = "MailTB";
            MailTB.Size = new Size(180, 26);
            MailTB.TabIndex = 2;
            MailTB.Click += MailTB_Clicked;
            // 
            // SiretTB
            // 
            SiretTB.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            SiretTB.ForeColor = Color.Silver;
            SiretTB.Location = new Point(731, 460);
            SiretTB.MaxLength = 255;
            SiretTB.Name = "SiretTB";
            SiretTB.Size = new Size(180, 26);
            SiretTB.TabIndex = 3;
            SiretTB.Click += SiretTB_Clicked;
            // 
            // PhoneTB
            // 
            PhoneTB.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            PhoneTB.ForeColor = Color.Silver;
            PhoneTB.Location = new Point(1093, 460);
            PhoneTB.MaxLength = 255;
            PhoneTB.Name = "PhoneTB";
            PhoneTB.Size = new Size(180, 26);
            PhoneTB.TabIndex = 4;
            PhoneTB.Click += PhoneTB_Clicked;
            // 
            // AddressTB
            // 
            AddressTB.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            AddressTB.ForeColor = Color.Silver;
            AddressTB.Location = new Point(731, 600);
            AddressTB.MaxLength = 255;
            AddressTB.Name = "AddressTB";
            AddressTB.Size = new Size(180, 26);
            AddressTB.TabIndex = 5;
            AddressTB.Click += AddressTB_Clicked;
            // 
            // CpTB
            // 
            CpTB.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CpTB.ForeColor = Color.Silver;
            CpTB.Location = new Point(1093, 600);
            CpTB.MaxLength = 255;
            CpTB.Name = "CpTB";
            CpTB.Size = new Size(180, 26);
            CpTB.TabIndex = 6;
            CpTB.Click += CpTB_Clicked;
            // 
            // AddBtn
            // 
            AddBtn.BackColor = Color.Blue;
            AddBtn.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            AddBtn.ForeColor = Color.White;
            AddBtn.Location = new Point(933, 762);
            AddBtn.Name = "AddBtn";
            AddBtn.Size = new Size(144, 43);
            AddBtn.TabIndex = 5;
            AddBtn.Text = "Ajouter";
            AddBtn.UseVisualStyleBackColor = false;
            AddBtn.Click += Add_Clicked;
            // 
            // UpdBtn
            // 
            UpdBtn.BackColor = Color.Blue;
            UpdBtn.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            UpdBtn.ForeColor = Color.White;
            UpdBtn.Location = new Point(1570, 762);
            UpdBtn.Name = "UpdBtn";
            UpdBtn.Size = new Size(144, 43);
            UpdBtn.TabIndex = 5;
            UpdBtn.Text = "Modifier";
            UpdBtn.UseVisualStyleBackColor = false;
            UpdBtn.Click += Upd_Clicked;
            // 
            // SuppliersCB
            // 
            SuppliersCB.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            SuppliersCB.ForeColor = Color.Silver;
            SuppliersCB.FormattingEnabled = true;
            SuppliersCB.Location = new Point(1555, 334);
            SuppliersCB.Name = "SuppliersCB";
            SuppliersCB.Size = new Size(180, 27);
            SuppliersCB.TabIndex = 8;
            SuppliersCB.SelectedIndexChanged += SuppliersCB_Changed;
            // 
            // Supplier
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(1904, 1041);
            Controls.Add(SuppliersCB);
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
            Click += Resets;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private NavbarControll navbarUserControl;
        private Label AddUpLbl;
        private TextBox NameTB, MailTB, SiretTB, PhoneTB, AddressTB, CpTB;
        private Button AddBtn, UpdBtn;
        private ComboBox SuppliersCB;
    }
}