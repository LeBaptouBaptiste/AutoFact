namespace AutoFact.Views
{
    partial class CACumulClient
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
            navbarControll1 = new NavbarControll();
            ClientsDGV = new DataGridView();
            id = new DataGridViewTextBoxColumn();
            name = new DataGridViewTextBoxColumn();
            firstName = new DataGridViewTextBoxColumn();
            ca = new DataGridViewTextBoxColumn();
            ShowClientLbl = new Label();
            NameTB = new CustomTextBox();
            FirstNameTB = new CustomTextBox();
            AnneeTB = new CustomTextBox();
            AddBtn = new Button();
            panel1 = new Panel();
            TauxLbl = new Label();
            CALbl = new Label();
            AnneeLbl = new Label();
            ClientLbl = new Label();
            NameLbl = new Label();
            PrenomLbl = new Label();
            YearsLbl = new Label();
            ((System.ComponentModel.ISupportInitialize)ClientsDGV).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // navbarControll1
            // 
            navbarControll1.BackColor = Color.Transparent;
            navbarControll1.ForeColor = SystemColors.ControlText;
            navbarControll1.Location = new Point(12, 12);
            navbarControll1.Name = "navbarControll1";
            navbarControll1.Size = new Size(450, 1080);
            navbarControll1.TabIndex = 0;
            // 
            // ClientsDGV
            // 
            ClientsDGV.AllowUserToAddRows = false;
            ClientsDGV.BackgroundColor = Color.LightCoral;
            ClientsDGV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ClientsDGV.Columns.AddRange(new DataGridViewColumn[] { id, name, firstName, ca });
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Arial", 12F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            ClientsDGV.DefaultCellStyle = dataGridViewCellStyle1;
            ClientsDGV.Location = new Point(1092, 251);
            ClientsDGV.Name = "ClientsDGV";
            ClientsDGV.ReadOnly = true;
            ClientsDGV.RowHeadersVisible = false;
            ClientsDGV.Size = new Size(757, 661);
            ClientsDGV.TabIndex = 10;
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
            name.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            name.DataPropertyName = "nom";
            name.HeaderText = "Nom";
            name.Name = "name";
            name.ReadOnly = true;
            // 
            // firstName
            // 
            firstName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            firstName.DataPropertyName = "prenom";
            firstName.HeaderText = "Prénom";
            firstName.Name = "firstName";
            firstName.ReadOnly = true;
            // 
            // ca
            // 
            ca.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            ca.DataPropertyName = "total";
            ca.HeaderText = "Chiffre d'Affaire";
            ca.Name = "ca";
            ca.ReadOnly = true;
            ca.Width = 106;
            // 
            // ShowClientLbl
            // 
            ShowClientLbl.AutoSize = true;
            ShowClientLbl.Font = new Font("Arial", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ShowClientLbl.Location = new Point(889, 129);
            ShowClientLbl.Name = "ShowClientLbl";
            ShowClientLbl.Size = new Size(578, 37);
            ShowClientLbl.TabIndex = 11;
            ShowClientLbl.Text = "Calcul du chiffre d'affaire par clients\r\n";
            // 
            // NameTB
            // 
            NameTB.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            NameTB.ForeColor = Color.Silver;
            NameTB.Location = new Point(637, 290);
            NameTB.Multiline = false;
            NameTB.Name = "NameTB";
            NameTB.Size = new Size(180, 26);
            NameTB.MaxLength = 255;
            NameTB.TabIndex = 0;
            NameTB.TextChanged += TextChanged;
            // 
            // FirstNameTB
            // 
            FirstNameTB.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            FirstNameTB.ForeColor = Color.Silver;
            FirstNameTB.Location = new Point(637, 370);
            FirstNameTB.Multiline = false;
            FirstNameTB.Name = "NameTB";
            FirstNameTB.Size = new Size(180, 26);
            FirstNameTB.MaxLength = 255;
            FirstNameTB.TabIndex = 0;
            FirstNameTB.TextChanged += TextChanged;
            // 
            // AnneeTB
            //
            AnneeTB.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            AnneeTB.ForeColor = Color.Silver;
            AnneeTB.Location = new Point(637, 450);
            AnneeTB.Multiline = false;
            AnneeTB.Name = "NameTB";
            AnneeTB.Size = new Size(180, 26);
            AnneeTB.MaxLength = 255;
            AnneeTB.TabIndex = 0;
            // 
            // AddBtn
            // 
            AddBtn.BackColor = Color.Blue;
            AddBtn.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            AddBtn.ForeColor = Color.White;
            AddBtn.Location = new Point(658, 574);
            AddBtn.Name = "AddBtn";
            AddBtn.Size = new Size(201, 48);
            AddBtn.TabIndex = 15;
            AddBtn.Text = "Ajouter";
            AddBtn.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ButtonHighlight;
            panel1.Controls.Add(TauxLbl);
            panel1.Controls.Add(CALbl);
            panel1.Controls.Add(AnneeLbl);
            panel1.Controls.Add(ClientLbl);
            panel1.Location = new Point(589, 683);
            panel1.Name = "panel1";
            panel1.Size = new Size(327, 229);
            panel1.TabIndex = 16;
            // 
            // TauxLbl
            // 
            TauxLbl.AutoSize = true;
            TauxLbl.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TauxLbl.Location = new Point(12, 167);
            TauxLbl.Name = "TauxLbl";
            TauxLbl.Size = new Size(81, 32);
            TauxLbl.TabIndex = 3;
            TauxLbl.Text = "Taux :";
            // 
            // CALbl
            // 
            CALbl.AutoSize = true;
            CALbl.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CALbl.Location = new Point(12, 113);
            CALbl.Name = "CALbl";
            CALbl.Size = new Size(208, 32);
            CALbl.TabIndex = 2;
            CALbl.Text = "Chiffre d'affaire :";
            // 
            // AnneeLbl
            // 
            AnneeLbl.AutoSize = true;
            AnneeLbl.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            AnneeLbl.Location = new Point(12, 64);
            AnneeLbl.Name = "AnneeLbl";
            AnneeLbl.Size = new Size(101, 32);
            AnneeLbl.TabIndex = 1;
            AnneeLbl.Text = "Année :";
            // 
            // ClientLbl
            // 
            ClientLbl.AutoSize = true;
            ClientLbl.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ClientLbl.Location = new Point(12, 12);
            ClientLbl.Name = "ClientLbl";
            ClientLbl.Size = new Size(94, 32);
            ClientLbl.TabIndex = 0;
            ClientLbl.Text = "Client :";
            // 
            // NameLbl
            // 
            NameLbl.AutoSize = true;
            NameLbl.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            NameLbl.Location = new Point(637, 270);
            NameLbl.Name = "NameLbl";
            NameLbl.Size = new Size(46, 17);
            NameLbl.TabIndex = 0;
            NameLbl.Text = "Nom :";
            // 
            // PrenomLbl
            // 
            PrenomLbl.AutoSize = true;
            PrenomLbl.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            PrenomLbl.Location = new Point(637, 350);
            PrenomLbl.Name = "PrenomLbl";
            PrenomLbl.Size = new Size(64, 17);
            PrenomLbl.TabIndex = 17;
            PrenomLbl.Text = "Prénom :";
            // 
            // YearsLbl
            // 
            YearsLbl.AutoSize = true;
            YearsLbl.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            YearsLbl.Location = new Point(637, 430);
            YearsLbl.Name = "YearsLbl";
            YearsLbl.Size = new Size(55, 17);
            YearsLbl.TabIndex = 18;
            YearsLbl.Text = "Année :";
            // 
            // CACumulClient
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1904, 1041);
            Controls.Add(YearsLbl);
            Controls.Add(PrenomLbl);
            Controls.Add(NameLbl);
            Controls.Add(panel1);
            Controls.Add(AddBtn);
            Controls.Add(AnneeTB);
            Controls.Add(FirstNameTB);
            Controls.Add(NameTB);
            Controls.Add(ShowClientLbl);
            Controls.Add(ClientsDGV);
            Controls.Add(navbarControll1);
            Name = "CACumulClient";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CACumulClient";
            WindowState = FormWindowState.Maximized;
            Load += CACumulClient_Load;
            Click += (sender, e) => Resets(sender, true);
            ((System.ComponentModel.ISupportInitialize)ClientsDGV).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private NavbarControll navbarControll1;
        private DataGridView ClientsDGV;
        private DataGridViewTextBoxColumn id;
        private DataGridViewTextBoxColumn name;
        private DataGridViewTextBoxColumn firstName;
        private DataGridViewTextBoxColumn ca;
        private DataGridViewTextBoxColumn taux;
        private Label ShowClientLbl;
        private CustomTextBox NameTB;
        private CustomTextBox FirstNameTB;
        private CustomTextBox AnneeTB;
        private Button AddBtn;
        private Panel panel1;
        private Label ClientLbl;
        private Label TauxLbl;
        private Label CALbl;
        private Label AnneeLbl;
        private Label NameLbl;
        private Label PrenomLbl;
        private Label YearsLbl;
    }
}