using System.Windows.Forms;

namespace AutoFact.Views
{
    partial class ClientShow
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
            ShowClientLbl = new Label();
            ClientsDGV = new DataGridView();
            id = new DataGridViewTextBoxColumn();
            civilitee = new DataGridViewTextBoxColumn();
            address = new DataGridViewTextBoxColumn();
            cp = new DataGridViewTextBoxColumn();
            tel = new DataGridViewTextBoxColumn();
            mail = new DataGridViewTextBoxColumn();
            name = new DataGridViewTextBoxColumn();
            firstname = new DataGridViewTextBoxColumn();
            update = new DataGridViewButtonColumn();
            AddBtn = new Button();
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
            // ShowClientLbl
            // 
            ShowClientLbl.AutoSize = true;
            ShowClientLbl.Font = new Font("Arial", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ShowClientLbl.Location = new Point(988, 146);
            ShowClientLbl.Name = "ShowClientLbl";
            ShowClientLbl.Size = new Size(341, 37);
            ShowClientLbl.TabIndex = 8;
            ShowClientLbl.Text = "Affichage des clients";
            // 
            // ClientsDGV
            // 
            ClientsDGV.AllowUserToAddRows = false;
            ClientsDGV.BackgroundColor = Color.LightCoral;
            ClientsDGV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ClientsDGV.Columns.AddRange(new DataGridViewColumn[] { id, civilitee, address, cp, tel, mail, name, firstname, update });
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = SystemColors.Window;
            dataGridViewCellStyle2.Font = new Font("Arial", 12F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.False;
            ClientsDGV.DefaultCellStyle = dataGridViewCellStyle2;
            ClientsDGV.Location = new Point(509, 230);
            ClientsDGV.Name = "ClientsDGV";
            ClientsDGV.ReadOnly = true;
            ClientsDGV.Size = new Size(1319, 661);
            ClientsDGV.TabIndex = 9;
            ClientsDGV.CellClick += UpdBtn_Click;
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
            // civilitee
            // 
            civilitee.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            civilitee.DataPropertyName = "civilitee";
            civilitee.HeaderText = "Civilitée";
            civilitee.Name = "civilitee";
            civilitee.ReadOnly = true;
            civilitee.Width = 74;
            // 
            // address
            // 
            address.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            address.DataPropertyName = "adresse";
            address.HeaderText = "Adresse";
            address.Name = "address";
            address.ReadOnly = true;
            // 
            // cp
            // 
            cp.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            cp.DataPropertyName = "cp";
            cp.HeaderText = "Code postal";
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
            name.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            name.DataPropertyName = "nom";
            name.HeaderText = "Nom";
            name.Name = "name";
            name.ReadOnly = true;
            // 
            // firstname
            // 
            firstname.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            firstname.DataPropertyName = "prenom";
            firstname.HeaderText = "Prénom";
            firstname.Name = "firstname";
            firstname.ReadOnly = true;
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
            // AddBtn
            // 
            AddBtn.BackColor = Color.Blue;
            AddBtn.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            AddBtn.ForeColor = Color.White;
            AddBtn.Location = new Point(1006, 945);
            AddBtn.Name = "AddBtn";
            AddBtn.Size = new Size(307, 64);
            AddBtn.TabIndex = 10;
            AddBtn.Text = "Ajouter";
            AddBtn.UseVisualStyleBackColor = false;
            AddBtn.Click += AddBtn_Click;
            // 
            // ClientShow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1904, 1041);
            Controls.Add(AddBtn);
            Controls.Add(ClientsDGV);
            Controls.Add(ShowClientLbl);
            Controls.Add(navbarControll1);
            Name = "ClientShow";
            Text = "ClientShow";
            Load += ClientShow_Load;
            ((System.ComponentModel.ISupportInitialize)ClientsDGV).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private NavbarControll navbarControll1;
        private Label ShowClientLbl;
        private DataGridView ClientsDGV;
        private DataGridViewTextBoxColumn id;
        private DataGridViewTextBoxColumn civilitee;
        private DataGridViewTextBoxColumn address;
        private DataGridViewTextBoxColumn cp;
        private DataGridViewTextBoxColumn tel;
        private DataGridViewTextBoxColumn mail;
        private DataGridViewTextBoxColumn name;
        private DataGridViewTextBoxColumn firstname;
        private DataGridViewButtonColumn update;
        private Button AddBtn;
    }
}