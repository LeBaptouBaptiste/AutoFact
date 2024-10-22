namespace AutoFact.Views
{
    partial class Service
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
            DescriptionTB = new TextBox();
            PriceTB = new TextBox();
            TimeChB = new CheckBox();
            DurationTB = new TextBox();
            AddBtn = new Button();
            UpdBtn = new Button();
            ServiceCB = new ComboBox();
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
            AddUpLbl.Size = new Size(484, 37);
            AddUpLbl.TabIndex = 7;
            AddUpLbl.Text = "Ajout/Modification de services";
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
            NameTB.Text = nameTxt;
            NameTB.Click += NameTB_Clicked;
            // 
            // DescriptionTB
            // 
            DescriptionTB.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            DescriptionTB.ForeColor = Color.Silver;
            DescriptionTB.Location = new Point(1022, 334);
            DescriptionTB.MaxLength = 511;
            DescriptionTB.Multiline = true;
            DescriptionTB.Name = "DescriptionTB";
            DescriptionTB.Size = new Size(363, 170);
            DescriptionTB.TabIndex = 2;
            DescriptionTB.Text = descriptionTxt;
            DescriptionTB.Click += DescriptionTB_Clicked;
            // 
            // PriceTB
            // 
            PriceTB.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            PriceTB.ForeColor = Color.Silver;
            PriceTB.Location = new Point(731, 450);
            PriceTB.MaxLength = 511;
            PriceTB.Name = "PriceTB";
            PriceTB.Size = new Size(180, 26);
            PriceTB.TabIndex = 3;
            PriceTB.Text = priceTxt;
            PriceTB.Click += PriceTB_Clicked;
            // 
            // TimeChB
            // 
            TimeChB.AutoSize = true;
            TimeChB.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TimeChB.ForeColor = Color.Black;
            TimeChB.Location = new Point(772, 614);
            TimeChB.Name = "TimeChB";
            TimeChB.Size = new Size(206, 23);
            TimeChB.TabIndex = 4;
            TimeChB.Text = "Designation temporaire";
            TimeChB.UseVisualStyleBackColor = true;
            TimeChB.CheckedChanged += TimeChB_CheckedChanged;
            // 
            // DurationTB
            // 
            DurationTB.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            DurationTB.ForeColor = Color.Silver;
            DurationTB.Location = new Point(1095, 614);
            DurationTB.MaxLength = 511;
            DurationTB.Name = "DurationTB";
            DurationTB.Size = new Size(180, 26);
            DurationTB.TabIndex = 3;
            DurationTB.Visible = false;
            DurationTB.Text = durationTxt;
            DurationTB.Click += DurationTB_Clicked;
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
            // ServiceCB
            // 
            ServiceCB.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ServiceCB.ForeColor = Color.Silver;
            ServiceCB.FormattingEnabled = true;
            ServiceCB.Location = new Point(1548, 333);
            ServiceCB.Name = "ServiceCB";
            ServiceCB.Size = new Size(180, 27);
            ServiceCB.TabIndex = 9;
            ServiceCB.Text = serviceTxt;
            ServiceCB.SelectedIndexChanged += ServiceCB_Changed;
            // 
            // Service
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(1904, 1041);
            Controls.Add(ServiceCB);
            Controls.Add(TimeChB);
            Controls.Add(AddUpLbl);
            Controls.Add(NameTB);
            Controls.Add(DescriptionTB);
            Controls.Add(PriceTB);
            Controls.Add(DurationTB);
            Controls.Add(AddBtn);
            Controls.Add(UpdBtn);
            Controls.Add(navbarUserControl);
            Margin = new Padding(4, 3, 4, 3);
            Name = "Service";
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
        private TextBox NameTB, DescriptionTB, PriceTB, DurationTB;
        private CheckBox TimeChB;
        private Button AddBtn, UpdBtn;
        private ComboBox ServiceCB;
    }
}