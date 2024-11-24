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
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            navbarControll1 = new NavbarControll();
            ClientsDGV = new DataGridView();
            id = new DataGridViewTextBoxColumn();
            name = new DataGridViewTextBoxColumn();
            firstName = new DataGridViewTextBoxColumn();
            ca = new DataGridViewTextBoxColumn();
            taux = new DataGridViewTextBoxColumn();
            ShowClientLbl = new Label();
            ((System.ComponentModel.ISupportInitialize)ClientsDGV).BeginInit();
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
            ClientsDGV.Columns.AddRange(new DataGridViewColumn[] { id, name, firstName, ca, taux });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Arial", 12F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            ClientsDGV.DefaultCellStyle = dataGridViewCellStyle2;
            ClientsDGV.Location = new Point(1092, 251);
            ClientsDGV.Name = "ClientsDGV";
            ClientsDGV.ReadOnly = true;
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
            name.HeaderText = "Nom";
            name.Name = "name";
            name.ReadOnly = true;
            // 
            // firstName
            // 
            firstName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            firstName.HeaderText = "Prénom";
            firstName.Name = "firstName";
            firstName.ReadOnly = true;
            // 
            // ca
            // 
            ca.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            ca.HeaderText = "Chiffre d'Affaire";
            ca.Name = "ca";
            ca.ReadOnly = true;
            ca.Width = 106;
            // 
            // taux
            // 
            taux.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            taux.HeaderText = "Taux";
            taux.Name = "taux";
            taux.ReadOnly = true;
            taux.Width = 56;
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
            // CACumulClient
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1904, 1041);
            Controls.Add(ShowClientLbl);
            Controls.Add(ClientsDGV);
            Controls.Add(navbarControll1);
            Name = "CACumulClient";
            Text = "CACumulClient";
            ((System.ComponentModel.ISupportInitialize)ClientsDGV).EndInit();
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
    }
}