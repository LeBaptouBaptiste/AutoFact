namespace AutoFact.Views
{
    partial class ArticleShow
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
            ArticlesDGV = new DataGridView();
            id = new DataGridViewTextBoxColumn();
            buyprice = new DataGridViewTextBoxColumn();
            quantite = new DataGridViewTextBoxColumn();
            supplier = new DataGridViewTextBoxColumn();
            name = new DataGridViewTextBoxColumn();
            price = new DataGridViewTextBoxColumn();
            description = new DataGridViewTextBoxColumn();
            update = new DataGridViewButtonColumn();
            ShowArticlesLbl = new Label();
            navbarControll1 = new NavbarControll();
            ((System.ComponentModel.ISupportInitialize)ArticlesDGV).BeginInit();
            SuspendLayout();
            // 
            // AddBtn
            // 
            AddBtn.BackColor = Color.Blue;
            AddBtn.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            AddBtn.ForeColor = Color.White;
            AddBtn.Location = new Point(1009, 937);
            AddBtn.Name = "AddBtn";
            AddBtn.Size = new Size(307, 64);
            AddBtn.TabIndex = 17;
            AddBtn.Text = "Ajouter";
            AddBtn.UseVisualStyleBackColor = false;
            AddBtn.Click += AddBtn_Click;
            // 
            // ArticlesDGV
            // 
            ArticlesDGV.AllowUserToAddRows = false;
            ArticlesDGV.BackgroundColor = Color.LightCoral;
            ArticlesDGV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ArticlesDGV.Columns.AddRange(new DataGridViewColumn[] { id, buyprice, quantite, supplier, name, price, description, update });
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.Window;
            dataGridViewCellStyle1.Font = new Font("Arial", 12F, FontStyle.Bold);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            ArticlesDGV.DefaultCellStyle = dataGridViewCellStyle1;
            ArticlesDGV.Location = new Point(512, 222);
            ArticlesDGV.Name = "ArticlesDGV";
            ArticlesDGV.ReadOnly = true;
            ArticlesDGV.Size = new Size(1319, 661);
            ArticlesDGV.TabIndex = 16;
            ArticlesDGV.CellClick += UpdBtn_Click;
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
            // buyprice
            // 
            buyprice.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            buyprice.DataPropertyName = "prixAchat";
            buyprice.HeaderText = "Prix d'achat";
            buyprice.Name = "buyprice";
            buyprice.ReadOnly = true;
            buyprice.Width = 94;
            // 
            // quantite
            // 
            quantite.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            quantite.DataPropertyName = "quantite";
            quantite.HeaderText = "Quantité";
            quantite.Name = "quantite";
            quantite.ReadOnly = true;
            quantite.Width = 78;
            // 
            // supplier
            // 
            supplier.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            supplier.DataPropertyName = "fournisseur";
            supplier.HeaderText = "Fournisseur";
            supplier.Name = "supplier";
            supplier.ReadOnly = true;
            supplier.Width = 93;
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
            // ShowArticlesLbl
            // 
            ShowArticlesLbl.AutoSize = true;
            ShowArticlesLbl.Font = new Font("Arial", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            ShowArticlesLbl.Location = new Point(991, 138);
            ShowArticlesLbl.Name = "ShowArticlesLbl";
            ShowArticlesLbl.Size = new Size(353, 37);
            ShowArticlesLbl.TabIndex = 15;
            ShowArticlesLbl.Text = "Affichage des articles";
            // 
            // navbarControll1
            // 
            navbarControll1.BackColor = Color.Transparent;
            navbarControll1.ForeColor = SystemColors.ControlText;
            navbarControll1.Location = new Point(12, 12);
            navbarControll1.Name = "navbarControll1";
            navbarControll1.Size = new Size(450, 1080);
            navbarControll1.TabIndex = 14;
            // 
            // ArticleShow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1904, 1041);
            Controls.Add(AddBtn);
            Controls.Add(ArticlesDGV);
            Controls.Add(ShowArticlesLbl);
            Controls.Add(navbarControll1);
            Name = "ArticleShow";
            Text = "ArticleShow";
            ((System.ComponentModel.ISupportInitialize)ArticlesDGV).EndInit();
            Load += ArticlesShow_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button AddBtn;
        private DataGridView ArticlesDGV;
        private Label ShowArticlesLbl;
        private NavbarControll navbarControll1;
        private DataGridViewTextBoxColumn id;
        private DataGridViewTextBoxColumn buyprice;
        private DataGridViewTextBoxColumn quantite;
        private DataGridViewTextBoxColumn supplier;
        private DataGridViewTextBoxColumn name;
        private DataGridViewTextBoxColumn price;
        private DataGridViewTextBoxColumn description;
        private DataGridViewButtonColumn update;
    }
}