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
            ClientsCB = new ComboBox();
            AddBtn = new Button();
            UpdBtn = new Button();
            SuspendLayout();
            // 
            // navbarUserControl
            // 
            navbarUserControl.BackColor = Color.Transparent;
            navbarUserControl.ForeColor = SystemColors.ControlText;
            navbarUserControl.Location = new Point(0, 0);
            navbarUserControl.Name = "navbarUserControl";
            navbarUserControl.Size = new Size(450, 1080);
            navbarUserControl.TabIndex = 8;
            // 
            // AddUpLbl
            // 
            AddUpLbl.AutoSize = true;
            AddUpLbl.Font = new Font("Arial", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            AddUpLbl.Location = new Point(933, 159);
            AddUpLbl.Name = "AddUpLbl";
            AddUpLbl.Size = new Size(440, 37);
            AddUpLbl.TabIndex = 7;
            AddUpLbl.Text = "Ajout/Modification de client";
            // 
            // HommeRB
            // 
            HommeRB.AutoSize = true;
            HommeRB.Location = new Point(933, 296);
            HommeRB.Name = "HommeRB";
            HommeRB.Size = new Size(69, 19);
            HommeRB.TabIndex = 9;
            HommeRB.TabStop = true;
            HommeRB.Text = "Homme";
            HommeRB.UseVisualStyleBackColor = true;
            // 
            // FemmeRB
            // 
            FemmeRB.AutoSize = true;
            FemmeRB.Location = new Point(1279, 296);
            FemmeRB.Name = "FemmeRB";
            FemmeRB.Size = new Size(65, 19);
            FemmeRB.TabIndex = 10;
            FemmeRB.TabStop = true;
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
            NameTB.TabIndex = 1;
            NameTB.Text = nameTxt;
            NameTB.Click += NameTB_Clicked;
            // 
            // MailTB
            // 
            MailTB.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            MailTB.ForeColor = Color.Silver;
            MailTB.Location = new Point(1228, 418);
            MailTB.MaxLength = 255;
            MailTB.Name = "MailTB";
            MailTB.Size = new Size(180, 26);
            MailTB.TabIndex = 2;
            MailTB.Text = mailTxt;
            MailTB.Click += MailTB_Clicked;
            // 
            // FirstNameTB
            // 
            FirstNameTB.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FirstNameTB.ForeColor = Color.Silver;
            FirstNameTB.Location = new Point(867, 548);
            FirstNameTB.MaxLength = 255;
            FirstNameTB.Name = "FirstNameTB";
            FirstNameTB.Size = new Size(180, 26);
            FirstNameTB.TabIndex = 3;
            FirstNameTB.Text = firstNameTxt;
            FirstNameTB.Click += FirstNameTB_Clicked;
            // 
            // PhoneTB
            // 
            PhoneTB.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            PhoneTB.ForeColor = Color.Silver;
            PhoneTB.Location = new Point(1228, 548);
            PhoneTB.MaxLength = 255;
            PhoneTB.Name = "PhoneTB";
            PhoneTB.Size = new Size(180, 26);
            PhoneTB.TabIndex = 4;
            PhoneTB.Text = phoneTxt;
            PhoneTB.Click += PhoneTB_Clicked;
            // 
            // AddressTB
            // 
            AddressTB.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            AddressTB.ForeColor = Color.Silver;
            AddressTB.Location = new Point(867, 677);
            AddressTB.MaxLength = 255;
            AddressTB.Name = "AddressTB";
            AddressTB.Size = new Size(180, 26);
            AddressTB.TabIndex = 5;
            AddressTB.Text = addressTxt;
            AddressTB.Click += AddressTB_Clicked;
            // 
            // CpTB
            // 
            CpTB.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CpTB.ForeColor = Color.Silver;
            CpTB.Location = new Point(1228, 677);
            CpTB.MaxLength = 255;
            CpTB.Name = "CpTB";
            CpTB.Size = new Size(180, 26);
            CpTB.TabIndex = 6;
            CpTB.Text = cpTxt;
            CpTB.Click += CpTB_Clicked;
            // 
            // ClientsCB
            // 
            ClientsCB.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ClientsCB.ForeColor = Color.Silver;
            ClientsCB.FormattingEnabled = true;
            ClientsCB.Location = new Point(1597, 295);
            ClientsCB.Name = "ClientsCB";
            ClientsCB.Size = new Size(180, 23);
            ClientsCB.TabIndex = 11;
            ClientsCB.Text = clientTxt;
            ClientsCB.SelectedIndexChanged += ClientsCB_Changed;
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
            // Client
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(1904, 1041);
            Controls.Add(AddBtn);
            Controls.Add(UpdBtn);
            Controls.Add(ClientsCB);
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
            Click += Resets;
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
        private ComboBox ClientsCB;
        private Button AddBtn, UpdBtn;
    }
}