﻿namespace AutoFact.Views
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
            NameTB = new CustomTextBox();
            DescriptionTB = new CustomTextBox();
            PriceTB = new CustomTextBox();
            TimeChB = new CheckBox();
            DurationTB = new CustomTextBox();
            AddBtn = new Button();
            UpdBtn = new Button();
            NameLbl = new Label();
            PriceLbl = new Label();
            DurationLbl = new Label();
            DescriptionLbl = new Label();
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
            navbarUserControl.ParentForm = this;
            // 
            // AddUpLbl
            // 
            AddUpLbl.AutoSize = true;
            AddUpLbl.Font = new Font("Arial", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            AddUpLbl.Location = new Point(933, 159);
            AddUpLbl.Name = "AddUpLbl";
            AddUpLbl.Size = new Size(484, 37);
            AddUpLbl.Text = "Ajout/Modification de services";
            // 
            // NameTB
            // 
            NameTB.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            NameTB.ForeColor = Color.Silver;
            NameTB.Location = new Point(828, 345);
            NameTB.MaxLength = 255;
            NameTB.Name = "NameTB";
            NameTB.Size = new Size(180, 26);
            NameTB.TabIndex = 0;
            NameTB.Text = nameTxt;
            NameTB.Click += NameTB_Clicked;
            NameTB.Enter += NameTB_Clicked;
            NameTB.Leave += (sender, e) => Resets(sender, false);
            // 
            // DescriptionTB
            // 
            DescriptionTB.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            DescriptionTB.ForeColor = Color.Silver;
            DescriptionTB.Location = new Point(1297, 294);
            DescriptionTB.MaxLength = 1023;
            DescriptionTB.Multiline = true;
            DescriptionTB.Name = "DescriptionTB";
            DescriptionTB.Size = new Size(469, 261);
            DescriptionTB.TabIndex = 1;
            DescriptionTB.Text = descriptionTxt;
            DescriptionTB.Click += DescriptionTB_Clicked;
            DescriptionTB.Enter += DescriptionTB_Clicked;
            DescriptionTB.Leave += (sender, e) => Resets(sender, false);
            // 
            // PriceTB
            // 
            PriceTB.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            PriceTB.ForeColor = Color.Silver;
            PriceTB.Location = new Point(828, 508);
            PriceTB.MaxLength = 17;
            PriceTB.Name = "PriceTB";
            PriceTB.Size = new Size(180, 26);
            PriceTB.TabIndex = 2;
            PriceTB.Text = priceTxt;
            PriceTB.Click += PriceTB_Clicked;
            PriceTB.Enter += PriceTB_Clicked;
            PriceTB.Leave += (sender, e) => Resets(sender, false);
            // 
            // TimeChB
            // 
            TimeChB.AutoSize = true;
            TimeChB.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TimeChB.ForeColor = Color.Black;
            TimeChB.Location = new Point(897, 689);
            TimeChB.Name = "TimeChB";
            TimeChB.Size = new Size(206, 23);
            TimeChB.TabIndex = 3;
            TimeChB.Text = "Designation temporaire";
            TimeChB.UseVisualStyleBackColor = true;
            TimeChB.CheckedChanged += TimeChB_CheckedChanged;
            TimeChB.KeyDown += TimeChB_Press;
            // 
            // DurationTB
            // 
            DurationTB.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            DurationTB.ForeColor = Color.Silver;
            DurationTB.Location = new Point(1237, 689);
            DurationTB.MaxLength = 5;
            DurationTB.Name = "DurationTB";
            DurationTB.Size = new Size(180, 26);
            DurationTB.TabIndex = 4;
            DurationTB.Visible = false;
            DescriptionTB.Text = descriptionTxt;
            DurationTB.Click += DurationTB_Clicked;
            DurationTB.Enter += DurationTB_Clicked;
            DurationTB.Leave += (sender, e) => Resets(sender, false);
            // 
            // AddBtn
            // 
            AddBtn.BackColor = Color.Blue;
            AddBtn.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            AddBtn.ForeColor = Color.White;
            AddBtn.Location = new Point(1026, 790);
            AddBtn.Name = "AddBtn";
            AddBtn.Size = new Size(249, 87);
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
            UpdBtn.Location = new Point(1026, 790);
            UpdBtn.Name = "UpdBtn";
            UpdBtn.Size = new Size(249, 87);
            UpdBtn.TabIndex = 5;
            UpdBtn.Text = "Modifier";
            UpdBtn.UseVisualStyleBackColor = false;
            UpdBtn.Click += Upd_Clicked;
            // 
            // NameLbl
            // 
            NameLbl.AutoSize = true;
            NameLbl.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            NameLbl.Location = new Point(828, 325);
            NameLbl.Name = "NameLbl";
            NameLbl.Size = new Size(46, 17);
            NameLbl.Text = "Nom :";
            // 
            // PriceLbl
            // 
            PriceLbl.AutoSize = true;
            PriceLbl.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            PriceLbl.Location = new Point(828, 488);
            PriceLbl.Name = "PriceLbl";
            PriceLbl.Size = new Size(40, 17);
            PriceLbl.Text = "Prix :";
            // 
            // DurationLbl
            // 
            DurationLbl.AutoSize = true;
            DurationLbl.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            DurationLbl.Location = new Point(1237, 669);
            DurationLbl.Name = "DurationLbl";
            DurationLbl.Size = new Size(53, 17);
            DurationLbl.Visible = false;
            DurationLbl.Text = "Durée :";
            // 
            // DescriptionLbl
            // 
            DescriptionLbl.AutoSize = true;
            DescriptionLbl.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            DescriptionLbl.Location = new Point(1297, 274);
            DescriptionLbl.Name = "DescriptionLbl";
            DescriptionLbl.Size = new Size(87, 17);
            DescriptionLbl.Text = "Description :";
            // 
            // Service
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(1904, 1041);
            Controls.Add(DescriptionLbl);
            Controls.Add(DurationLbl);
            Controls.Add(PriceLbl);
            Controls.Add(NameLbl);
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
            Click += (sender, e) => Resets(sender, true);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private NavbarControll navbarUserControl;
        private Label AddUpLbl;
        private CustomTextBox NameTB, DescriptionTB, PriceTB, DurationTB;
        private CheckBox TimeChB;
        private Button AddBtn, UpdBtn;
        private Label NameLbl;
        private Label PriceLbl;
        private Label DurationLbl;
        private Label DescriptionLbl;
    }
}