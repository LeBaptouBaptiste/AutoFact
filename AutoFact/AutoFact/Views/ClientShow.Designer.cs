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
            navbarControll1 = new NavbarControll();
            ShowClientLbl = new Label();
            dataGridView1 = new DataGridView();
            id = new DataGridViewTextBoxColumn();
            civilitee = new DataGridViewTextBoxColumn();
            address = new DataGridViewTextBoxColumn();
            cp = new DataGridViewTextBoxColumn();
            tel = new DataGridViewTextBoxColumn();
            mail = new DataGridViewTextBoxColumn();
            name = new DataGridViewTextBoxColumn();
            firstname = new DataGridViewTextBoxColumn();
            update = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
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
            ShowClientLbl.Location = new Point(1063, 145);
            ShowClientLbl.Name = "ShowClientLbl";
            ShowClientLbl.Size = new Size(341, 37);
            ShowClientLbl.TabIndex = 8;
            ShowClientLbl.Text = "Affichage des clients";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { id, civilitee, address, cp, tel, mail, name, firstname, update });
            dataGridView1.Location = new Point(509, 230);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(1319, 747);
            dataGridView1.TabIndex = 9;
            // 
            // id
            // 
            id.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            id.HeaderText = "Id";
            id.Name = "id";
            // 
            // civilitee
            // 
            civilitee.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            civilitee.HeaderText = "Civilitée";
            civilitee.Name = "civilitee";
            // 
            // address
            // 
            address.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            address.HeaderText = "Adresse";
            address.Name = "address";
            // 
            // cp
            // 
            cp.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            cp.HeaderText = "Code postal";
            cp.Name = "cp";
            // 
            // tel
            // 
            tel.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            tel.HeaderText = "Téléphone";
            tel.Name = "tel";
            // 
            // mail
            // 
            mail.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            mail.HeaderText = "Mail";
            mail.Name = "mail";
            // 
            // name
            // 
            name.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            name.HeaderText = "Nom";
            name.Name = "name";
            // 
            // firstname
            // 
            firstname.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            firstname.HeaderText = "Prénom";
            firstname.Name = "firstname";
            // 
            // update
            // 
            update.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            update.HeaderText = "Modifier";
            update.Name = "update";
            update.Width = 77;
            // 
            // ClientShow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1904, 1041);
            Controls.Add(dataGridView1);
            Controls.Add(ShowClientLbl);
            Controls.Add(navbarControll1);
            Name = "ClientShow";
            Text = "ClientShow";
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private NavbarControll navbarControll1;
        private Label ShowClientLbl;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn id;
        private DataGridViewTextBoxColumn civilitee;
        private DataGridViewTextBoxColumn address;
        private DataGridViewTextBoxColumn cp;
        private DataGridViewTextBoxColumn tel;
        private DataGridViewTextBoxColumn mail;
        private DataGridViewTextBoxColumn name;
        private DataGridViewTextBoxColumn firstname;
        private DataGridViewTextBoxColumn update;
    }
}