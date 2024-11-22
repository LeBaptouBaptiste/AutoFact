using AutoFact.ViewModel;

namespace AutoFact.Views
{
    partial class Client
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
            HommeRB = new RadioButton();
            FemmeRB = new RadioButton();
            NameTB = new TextBox();
            MailTB = new TextBox();
            FirstNameTB = new TextBox();
            PhoneTB = new TextBox();
            AddressTB = new TextBox();
            CpTB = new TextBox();
            AddBtn = new Button();
            UpdBtn = new Button();
            NameLbl = new Label();
            FirstNameLbl = new Label();
            AddressLbl = new Label();
            MailLbl = new Label();
            PhoneLbl = new Label();
            CpLbl = new Label();
            SuspendLayout();
            // 
            // navbarUserControl
            // 
            navbarUserControl.BackColor = Color.Transparent;
            navbarUserControl.ForeColor = SystemColors.ControlText;
            navbarUserControl.Location = new Point(0, 0);
            navbarUserControl.Name = "navbarUserControl";
            navbarUserControl.Size = new Size(450, 1080);
            navbarUserControl.TabIndex = 9;
            // 
            // AddUpLbl
            // 
            AddUpLbl.AutoSize = true;
            AddUpLbl.Font = new Font("Arial", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            AddUpLbl.Location = new Point(933, 159);
            AddUpLbl.Name = "AddUpLbl";
            AddUpLbl.Size = new Size(440, 37);
            AddUpLbl.Text = "Ajout/Modification de client";
            // 
            // HommeRB
            // 
            HommeRB.AutoSize = true;
            HommeRB.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            HommeRB.Location = new Point(933, 296);
            HommeRB.Name = "HommeRB";
            HommeRB.Size = new Size(75, 21);
            HommeRB.TabStop = true;
            HommeRB.TabIndex = 0;
            HommeRB.Text = "Homme";
            HommeRB.UseVisualStyleBackColor = true;
            // 
            // FemmeRB
            // 
            FemmeRB.AutoSize = true;
            FemmeRB.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FemmeRB.Location = new Point(1279, 296);
            FemmeRB.Name = "FemmeRB";
            FemmeRB.Size = new Size(71, 21);
            FemmeRB.TabStop = true; 
            FemmeRB.TabIndex = 1;
            FemmeRB.Text = "Femme";
            FemmeRB.UseVisualStyleBackColor = true;
            // 
            // NameTB
            // 
            NameTB.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            NameTB.ForeColor = Color.Silver;
            NameTB.Location = new Point(867, 418);
            NameTB.MaxLength = 255;
            NameTB.Name = "NameTB";
            NameTB.Size = new Size(180, 26);
            NameTB.TabIndex = 2;
            NameTB.Text = nameTxt;
            NameTB.Click += NameTB_Clicked;
            NameTB.Enter += NameTB_Clicked;
            NameTB.Leave += (sender, e) => Resets(sender, false);
            // 
            // MailTB
            // 
            MailTB.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            MailTB.ForeColor = Color.Silver;
            MailTB.Location = new Point(1228, 418);
            MailTB.MaxLength = 255;
            MailTB.Name = "MailTB";
            MailTB.Size = new Size(180, 26);
            MailTB.TabIndex = 3;
            MailTB.Text = mailTxt;
            MailTB.Click += MailTB_Clicked;
            MailTB.Enter += MailTB_Clicked;
            MailTB.Leave += (sender, e) => Resets(sender, false);
            // 
            // FirstNameTB
            // 
            FirstNameTB.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FirstNameTB.ForeColor = Color.Silver;
            FirstNameTB.Location = new Point(867, 548);
            FirstNameTB.MaxLength = 255;
            FirstNameTB.Name = "FirstNameTB";
            FirstNameTB.Size = new Size(180, 26);
            FirstNameTB.TabIndex = 4;
            FirstNameTB.Text = firstNameTxt;
            FirstNameTB.Click += FirstNameTB_Clicked;
            FirstNameTB.Enter += FirstNameTB_Clicked;
            FirstNameTB.Leave += (sender, e) => Resets(sender, false);
            // 
            // PhoneTB
            // 
            PhoneTB.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            PhoneTB.ForeColor = Color.Silver;
            PhoneTB.Location = new Point(1228, 548);
            PhoneTB.MaxLength = 255;
            PhoneTB.Name = "PhoneTB";
            PhoneTB.Size = new Size(180, 26);
            PhoneTB.TabIndex = 5;
            PhoneTB.Text = phoneTxt;
            PhoneTB.Click += PhoneTB_Clicked;
            PhoneTB.Enter += PhoneTB_Clicked;
            PhoneTB.Leave += (sender, e) => Resets(sender, false);
            // 
            // AddressTB
            // 
            AddressTB.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            AddressTB.ForeColor = Color.Silver;
            AddressTB.Location = new Point(867, 677);
            AddressTB.MaxLength = 255;
            AddressTB.Name = "AddressTB";
            AddressTB.Size = new Size(180, 26);
            AddressTB.TabIndex = 6;
            AddressTB.Text = addressTxt;
            AddressTB.Click += AddressTB_Clicked;
            AddressTB.Enter += AddressTB_Clicked;
            AddressTB.Leave += (sender, e) => Resets(sender, false);
            // 
            // CpTB
            // 
            CpTB.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CpTB.ForeColor = Color.Silver;
            CpTB.Location = new Point(1228, 677);
            CpTB.MaxLength = 255;
            CpTB.Name = "CpTB";
            CpTB.Size = new Size(180, 26);
            CpTB.TabIndex = 7;
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
            AddBtn.Location = new Point(1037, 822);
            AddBtn.Name = "AddBtn";
            AddBtn.Size = new Size(201, 70);
            AddBtn.TabIndex = 8;
            AddBtn.Text = "Ajouter";
            AddBtn.UseVisualStyleBackColor = false;
            AddBtn.Click += Add_Clicked;
            // 
            // UpdBtn
            // 
            UpdBtn.BackColor = Color.Blue;
            UpdBtn.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            UpdBtn.ForeColor = Color.White;
            UpdBtn.Location = new Point(1037, 822);
            UpdBtn.Name = "UpdBtn";
            UpdBtn.Size = new Size(201, 70);
            UpdBtn.TabIndex = 8;
            UpdBtn.Text = "Modifier";
            UpdBtn.UseVisualStyleBackColor = false;
            UpdBtn.Click += Upd_Clicked;
            // 
            // NameLbl
            // 
            NameLbl.AutoSize = true;
            NameLbl.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            NameLbl.Location = new Point(867, 398);
            NameLbl.Name = "NameLbl";
            NameLbl.Size = new Size(46, 17);
            NameLbl.Text = "Nom :";
            // 
            // FirstNameLbl
            // 
            FirstNameLbl.AutoSize = true;
            FirstNameLbl.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FirstNameLbl.Location = new Point(867, 528);
            FirstNameLbl.Name = "FirstNameLbl";
            FirstNameLbl.Size = new Size(64, 17);
            FirstNameLbl.Text = "Prénom :";
            // 
            // AddressLbl
            // 
            AddressLbl.AutoSize = true;
            AddressLbl.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            AddressLbl.Location = new Point(867, 657);
            AddressLbl.Name = "AddressLbl";
            AddressLbl.Size = new Size(64, 17);
            AddressLbl.Text = "Adresse :";
            // 
            // MailLbl
            // 
            MailLbl.AutoSize = true;
            MailLbl.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            MailLbl.Location = new Point(1228, 398);
            MailLbl.Name = "MailLbl";
            MailLbl.Size = new Size(43, 17);
            MailLbl.Text = "Mail :";
            // 
            // PhoneLbl
            // 
            PhoneLbl.AutoSize = true;
            PhoneLbl.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            PhoneLbl.Location = new Point(1228, 528);
            PhoneLbl.Name = "PhoneLbl";
            PhoneLbl.Size = new Size(80, 17);
            PhoneLbl.Text = "Téléphone :";
            // 
            // CpLbl
            // 
            CpLbl.AutoSize = true;
            CpLbl.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CpLbl.Location = new Point(1228, 657);
            CpLbl.Name = "CpLbl";
            CpLbl.Size = new Size(89, 17);
            CpLbl.Text = "Code Postal :";
            // 
            // Client
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(1904, 1041);
            Controls.Add(CpLbl);
            Controls.Add(PhoneLbl);
            Controls.Add(MailLbl);
            Controls.Add(AddressLbl);
            Controls.Add(FirstNameLbl);
            Controls.Add(NameLbl);
            Controls.Add(AddBtn);
            Controls.Add(UpdBtn);
            Controls.Add(CpTB);
            Controls.Add(AddressTB);
            Controls.Add(PhoneTB);
            Controls.Add(FirstNameTB);
            Controls.Add(MailTB);
            Controls.Add(FemmeRB);
            Controls.Add(HommeRB);
            Controls.Add(AddUpLbl);
            Controls.Add(NameTB);
            Controls.Add(navbarUserControl);
            Margin = new Padding(4, 3, 4, 3);
            Name = "Client";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Article";
            WindowState = FormWindowState.Maximized;
            Click += (sender, e) => Resets(sender, true);
            ResumeLayout(false);
            PerformLayout();
        }

        private void CpTB_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        #endregion

        private NavbarControll navbarUserControl;
        private Label AddUpLbl;
        private RadioButton HommeRB, FemmeRB;
        private TextBox NameTB, MailTB, FirstNameTB, PhoneTB, AddressTB, CpTB;
        private Button AddBtn, UpdBtn;
        private Label NameLbl;
        private Label FirstNameLbl;
        private Label AddressLbl;
        private Label MailLbl;
        private Label PhoneLbl;
        private Label CpLbl;
    }
}