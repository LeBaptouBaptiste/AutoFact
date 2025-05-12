namespace AutoFact.Views
{
    partial class SupplierShow
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            AddBtn = new Button();
            SuppliersDGV = new DataGridView();
            ShowSuppliersLbl = new Label();
            navbarUserControl = new NavbarControll();
            id = new DataGridViewTextBoxColumn();
            siret = new DataGridViewTextBoxColumn();
            address = new DataGridViewTextBoxColumn();
            cp = new DataGridViewTextBoxColumn();
            tel = new DataGridViewTextBoxColumn();
            mail = new DataGridViewTextBoxColumn();
            name = new DataGridViewTextBoxColumn();
            update = new DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)SuppliersDGV).BeginInit();
            SuspendLayout();
            // 
            // AddBtn
            // 
            AddBtn.BackColor = Color.Blue;
            AddBtn.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            AddBtn.ForeColor = Color.White;
            AddBtn.Location = new Point(1014, 961);
            AddBtn.Name = "AddBtn";
            AddBtn.Size = new Size(307, 64);
            AddBtn.TabIndex = 17;
            AddBtn.Text = "Ajouter";
            AddBtn.UseVisualStyleBackColor = false;
            AddBtn.Click += AddBtn_Click;
            // 
            // SuppliersDGV
            // 
            SuppliersDGV.AllowUserToAddRows = false;
            SuppliersDGV.BackgroundColor = Color.LightCoral;
            SuppliersDGV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            SuppliersDGV.Columns.AddRange(new DataGridViewColumn[] { id, siret, address, cp, tel, mail, name, update });
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Arial", 12F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            SuppliersDGV.DefaultCellStyle = dataGridViewCellStyle1;
            SuppliersDGV.Location = new Point(517, 246);
            SuppliersDGV.Name = "SuppliersDGV";
            SuppliersDGV.ReadOnly = true;
            SuppliersDGV.Size = new Size(1319, 661);
            SuppliersDGV.TabIndex = 16;
            SuppliersDGV.CellClick += UpdBtn_Click;
            SuppliersDGV.RowHeadersVisible = false;
            // 
            // ShowSuppliersLbl
            // 
            ShowSuppliersLbl.AutoSize = true;
            ShowSuppliersLbl.Font = new Font("Arial", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ShowSuppliersLbl.Location = new Point(996, 162);
            ShowSuppliersLbl.Name = "ShowSuppliersLbl";
            ShowSuppliersLbl.Size = new Size(432, 37);
            ShowSuppliersLbl.TabIndex = 15;
            ShowSuppliersLbl.Text = "Affichage des fournisseurs";
            // 
            // navbarUserControl
            // 
            navbarUserControl.BackColor = Color.Transparent;
            navbarUserControl.ForeColor = SystemColors.ControlText;
            navbarUserControl.Location = new Point(12, 12);
            navbarUserControl.Name = "navbarUserControl";
            navbarUserControl.Size = new Size(450, 1080);
            navbarUserControl.TabIndex = 14;
            navbarUserControl.ParentForm = this;
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
            // siret
            // 
            siret.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            siret.DataPropertyName = "siret";
            siret.HeaderText = "Siret";
            siret.Name = "siret";
            siret.ReadOnly = true;
            siret.Width = 55;
            // 
            // address
            // 
            address.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            address.DataPropertyName = "adresse";
            address.HeaderText = "Adresse";
            address.Name = "address";
            address.ReadOnly = true;
            address.Width = 73;
            // 
            // cp
            // 
            cp.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            cp.DataPropertyName = "cp";
            cp.HeaderText = "Code Postal";
            cp.Name = "cp";
            cp.ReadOnly = true;
            cp.Width = 95;
            // 
            // tel
            // 
            tel.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            tel.DataPropertyName = "tel";
            tel.HeaderText = "Téléphone";
            tel.Name = "tel";
            tel.ReadOnly = true;
            tel.Width = 86;
            // 
            // mail
            // 
            mail.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            mail.DataPropertyName = "mail";
            mail.HeaderText = "Mail";
            mail.Name = "mail";
            mail.ReadOnly = true;
            // 
            // name
            // 
            name.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            name.DataPropertyName = "nom";
            name.HeaderText = "Dénomination";
            name.Name = "name";
            name.ReadOnly = true;
            name.Width = 108;
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
            // SupplierShow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1904, 1041);
            Controls.Add(AddBtn);
            Controls.Add(SuppliersDGV);
            Controls.Add(ShowSuppliersLbl);
            Controls.Add(navbarUserControl);
            Name = "SupplierShow";
            Text = "SupplierShow";
            WindowState = FormWindowState.Maximized;
            Load += SupplierShow_Load;
            ((System.ComponentModel.ISupportInitialize)SuppliersDGV).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button AddBtn;
        private DataGridView SuppliersDGV;
        private Label ShowSuppliersLbl;
        private NavbarControll navbarUserControl;
        private DataGridViewTextBoxColumn id;
        private DataGridViewTextBoxColumn siret;
        private DataGridViewTextBoxColumn address;
        private DataGridViewTextBoxColumn cp;
        private DataGridViewTextBoxColumn tel;
        private DataGridViewTextBoxColumn mail;
        private DataGridViewTextBoxColumn name;
        private DataGridViewButtonColumn update;
    }
}