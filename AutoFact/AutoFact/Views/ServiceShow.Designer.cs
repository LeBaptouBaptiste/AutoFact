﻿namespace AutoFact.Views
{
    partial class ServiceShow
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
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            navbarUserControl = new NavbarControll();
            AddBtn = new Button();
            ServicesDGV = new DataGridView();
            id = new DataGridViewTextBoxColumn();
            name = new DataGridViewTextBoxColumn();
            price = new DataGridViewTextBoxColumn();
            duree = new DataGridViewTextBoxColumn();
            description = new DataGridViewTextBoxColumn();
            update = new DataGridViewButtonColumn();
            ShowServicesLbl = new Label();
            ((System.ComponentModel.ISupportInitialize)ServicesDGV).BeginInit();
            SuspendLayout();
            // 
            // navbarUserControl
            // 
            navbarUserControl.BackColor = Color.Transparent;
            navbarUserControl.ForeColor = SystemColors.ControlText;
            navbarUserControl.Location = new Point(12, 12);
            navbarUserControl.Name = "navbarUserControl";
            navbarUserControl.Size = new Size(450, 1080);
            navbarUserControl.TabIndex = 0;
            navbarUserControl.ParentForm = this;
            // 
            // AddBtn
            // 
            AddBtn.BackColor = Color.Blue;
            AddBtn.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            AddBtn.ForeColor = Color.White;
            AddBtn.Location = new Point(1009, 937);
            AddBtn.Name = "AddBtn";
            AddBtn.Size = new Size(307, 64);
            AddBtn.TabIndex = 13;
            AddBtn.Text = "Ajouter";
            AddBtn.UseVisualStyleBackColor = false;
            AddBtn.Click += AddBtn_Click;
            // 
            // ServicesDGV
            // 
            ServicesDGV.AllowUserToAddRows = false;
            ServicesDGV.BackgroundColor = Color.LightCoral;
            ServicesDGV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ServicesDGV.Columns.AddRange(new DataGridViewColumn[] { id, name, price, duree, description, update });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Arial", 12F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            ServicesDGV.DefaultCellStyle = dataGridViewCellStyle2;
            ServicesDGV.Location = new Point(512, 222);
            ServicesDGV.Name = "ServicesDGV";
            ServicesDGV.ReadOnly = true;
            ServicesDGV.Size = new Size(1319, 661);
            ServicesDGV.TabIndex = 12;
            ServicesDGV.CellClick += UpdBtn_Click;
            ServicesDGV.RowHeadersVisible = false;
            // 
            // id
            // 
            id.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            id.DataPropertyName = "id";
            id.HeaderText = "Id";
            id.Name = "id";
            id.ReadOnly = true;
            id.Width = 42;
            // 
            // name
            // 
            name.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            name.DataPropertyName = "libelle";
            name.HeaderText = "Libelle";
            name.Name = "name";
            name.ReadOnly = true;
            name.Width = 66;
            // 
            // price
            // 
            price.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            price.DataPropertyName = "prix";
            price.HeaderText = "Prix";
            price.Name = "price";
            price.ReadOnly = true;
            price.Width = 52;
            // 
            // duree
            // 
            duree.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            duree.DataPropertyName = "duree";
            duree.HeaderText = "Durée";
            duree.Name = "duree";
            duree.ReadOnly = true;
            duree.Width = 63;
            // 
            // description
            // 
            description.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            description.DataPropertyName = "description";
            description.HeaderText = "Description";
            description.Name = "description";
            description.ReadOnly = true;
            // 
            // update
            // 
            update.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            update.HeaderText = "Modifier";
            update.Name = "update";
            update.ReadOnly = true;
            update.Text = "Modifier";
            update.UseColumnTextForButtonValue = true;
            update.Width = 58;
            // 
            // ShowServicesLbl
            // 
            ShowServicesLbl.AutoSize = true;
            ShowServicesLbl.Font = new Font("Arial", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ShowServicesLbl.Location = new Point(991, 138);
            ShowServicesLbl.Name = "ShowServicesLbl";
            ShowServicesLbl.Size = new Size(367, 37);
            ShowServicesLbl.TabIndex = 11;
            ShowServicesLbl.Text = "Affichage des services";
            // 
            // ServiceShow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1904, 1041);
            Controls.Add(AddBtn);
            Controls.Add(ServicesDGV);
            Controls.Add(ShowServicesLbl);
            Controls.Add(navbarUserControl);
            Name = "ServiceShow";
            Text = "ServiceShow";
            WindowState = FormWindowState.Maximized;
            Load += ServicesShow_Load;
            ((System.ComponentModel.ISupportInitialize)ServicesDGV).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private NavbarControll navbarUserControl;
        private Button AddBtn;
        private DataGridView ServicesDGV;
        private Label ShowServicesLbl;
        private DataGridViewTextBoxColumn id;
        private DataGridViewTextBoxColumn name;
        private DataGridViewTextBoxColumn price;
        private DataGridViewTextBoxColumn duree;
        private DataGridViewTextBoxColumn description;
        private DataGridViewButtonColumn update;
    }
}