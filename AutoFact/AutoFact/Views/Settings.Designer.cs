namespace AutoFact.Views
{
    partial class Settings
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
            SettingsLbl = new Label();
            SocietyLbl = new Label();
            NameTB = new TextBox();
            PhoneTB = new TextBox();
            MailTB = new TextBox();
            AddressTB = new TextBox();
            CpTB = new TextBox();
            CountryTB = new TextBox();
            ImportLbl = new Label();
            openFileDialog1 = new OpenFileDialog();
            LogoPB = new PictureBox();
            SelectLogoBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)LogoPB).BeginInit();
            SuspendLayout();
            // 
            // navbarUserControl
            // 
            navbarUserControl.BackColor = Color.Transparent;
            navbarUserControl.ForeColor = SystemColors.ControlText;
            navbarUserControl.Location = new Point(0, 0);
            navbarUserControl.Name = "navbarUserControl";
            navbarUserControl.Size = new Size(450, 1080);
            navbarUserControl.TabIndex = 0;
            // 
            // SettingsLbl
            // 
            SettingsLbl.AutoSize = true;
            SettingsLbl.Font = new Font("Arial", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            SettingsLbl.Location = new Point(1063, 92);
            SettingsLbl.Name = "SettingsLbl";
            SettingsLbl.Size = new Size(192, 37);
            SettingsLbl.TabIndex = 8;
            SettingsLbl.Text = "Paramètres";
            // 
            // SocietyLbl
            // 
            SocietyLbl.AutoSize = true;
            SocietyLbl.Font = new Font("Arial", 18F, FontStyle.Bold);
            SocietyLbl.Location = new Point(1093, 164);
            SocietyLbl.Name = "SocietyLbl";
            SocietyLbl.Size = new Size(136, 29);
            SocietyLbl.TabIndex = 9;
            SocietyLbl.Text = "Ma société";
            // 
            // NameTB
            // 
            NameTB.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            NameTB.ForeColor = Color.Silver;
            NameTB.Location = new Point(630, 280);
            NameTB.MaxLength = 255;
            NameTB.Name = "NameTB";
            NameTB.Size = new Size(250, 26);
            NameTB.TabIndex = 1;
            NameTB.Text = nameTxt;
            NameTB.Click += NameTB_Clicked;
            // 
            // PhoneTB
            // 
            PhoneTB.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            PhoneTB.ForeColor = Color.Silver;
            PhoneTB.Location = new Point(1030, 280);
            PhoneTB.MaxLength = 255;
            PhoneTB.Name = "PhoneTB";
            PhoneTB.Size = new Size(250, 26);
            PhoneTB.TabIndex = 10;
            PhoneTB.Text = phoneTxt;
            PhoneTB.Click += PhoneTB_Clicked;
            // 
            // MailTB
            // 
            MailTB.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            MailTB.ForeColor = Color.Silver;
            MailTB.Location = new Point(1430, 280);
            MailTB.MaxLength = 255;
            MailTB.Name = "MailTB";
            MailTB.Size = new Size(250, 26);
            MailTB.TabIndex = 11;
            MailTB.Text = mailTxt;
            MailTB.Click += MailTB_Clicked;
            // 
            // AddressTB
            // 
            AddressTB.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            AddressTB.ForeColor = Color.Silver;
            AddressTB.Location = new Point(630, 420);
            AddressTB.MaxLength = 255;
            AddressTB.Name = "AddressTB";
            AddressTB.Size = new Size(250, 26);
            AddressTB.TabIndex = 12;
            AddressTB.Text = addressTxt;
            AddressTB.Click += AddressTB_Clicked;
            // 
            // CpTB
            // 
            CpTB.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CpTB.ForeColor = Color.Silver;
            CpTB.Location = new Point(1030, 420);
            CpTB.MaxLength = 255;
            CpTB.Name = "CpTB";
            CpTB.Size = new Size(250, 26);
            CpTB.TabIndex = 13;
            CpTB.Text = cpTxt;
            CpTB.Click += CpTB_Clicked;
            // 
            // CountryTB
            // 
            CountryTB.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CountryTB.ForeColor = Color.Silver;
            CountryTB.Location = new Point(1430, 420);
            CountryTB.MaxLength = 255;
            CountryTB.Name = "CountryTB";
            CountryTB.Size = new Size(250, 26);
            CountryTB.TabIndex = 14;
            CountryTB.Text = countryTxt;
            CountryTB.Click += CountryTB_Clicked;
            // 
            // ImportLbl
            // 
            ImportLbl.AutoSize = true;
            ImportLbl.Font = new Font("Arial", 18F, FontStyle.Bold);
            ImportLbl.Location = new Point(780, 560);
            ImportLbl.Name = "ImportLbl";
            ImportLbl.Size = new Size(358, 29);
            ImportLbl.TabIndex = 15;
            ImportLbl.Text = "Importer votre logo de société";
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // LogoPB
            // 
            LogoPB.Location = new Point(1528, 550);
            LogoPB.Name = "LogoPB";
            LogoPB.Size = new Size(66, 56);
            LogoPB.TabIndex = 16;
            LogoPB.TabStop = false;
            // 
            // SelectLogoBtn
            // 
            SelectLogoBtn.BackColor = Color.Blue;
            SelectLogoBtn.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            SelectLogoBtn.ForeColor = Color.White;
            SelectLogoBtn.Location = new Point(1228, 533);
            SelectLogoBtn.Name = "SelectLogoBtn";
            SelectLogoBtn.Size = new Size(267, 89);
            SelectLogoBtn.TabIndex = 17;
            SelectLogoBtn.Text = "Telecharger";
            SelectLogoBtn.UseVisualStyleBackColor = false;
            SelectLogoBtn.Click += SelectLogoBtn_Click;
            // 
            // Settings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1904, 1041);
            Controls.Add(SelectLogoBtn);
            Controls.Add(LogoPB);
            Controls.Add(ImportLbl);
            Controls.Add(CountryTB);
            Controls.Add(CpTB);
            Controls.Add(AddressTB);
            Controls.Add(MailTB);
            Controls.Add(PhoneTB);
            Controls.Add(NameTB);
            Controls.Add(SocietyLbl);
            Controls.Add(SettingsLbl);
            Controls.Add(navbarUserControl);
            Margin = new Padding(4, 3, 4, 3);
            Name = "Settings";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Settings";
            WindowState = FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)LogoPB).EndInit();
            Click += Resets;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private NavbarControll navbarUserControl;
        private Label SettingsLbl, SocietyLbl;
        private TextBox NameTB;
        private TextBox PhoneTB;
        private TextBox MailTB;
        private TextBox AddressTB;
        private TextBox CpTB;
        private TextBox CountryTB;
        private Label ImportLbl;
        private OpenFileDialog openFileDialog1;
        private PictureBox LogoPB;
        private Button SelectLogoBtn;
    }
}