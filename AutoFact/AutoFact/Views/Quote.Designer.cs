namespace AutoFact.Views
{
    partial class Quote
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
            QuoteLbl = new Label();
            AddProduitsLbl = new Label();
            AProduitCB = new ComboBox();
            AllArticlesDGV = new DataGridView();
            Ref = new DataGridViewTextBoxColumn();
            name = new DataGridViewTextBoxColumn();
            Desc = new DataGridViewTextBoxColumn();
            tva = new DataGridViewTextBoxColumn();
            PrixUnitaire = new DataGridViewTextBoxColumn();
            Quantite = new DataGridViewTextBoxColumn();
            PrixTotal = new DataGridViewTextBoxColumn();
            DelProduct = new DataGridViewButtonColumn();
            TaxesDGV = new DataGridView();
            detailsTaxe = new DataGridViewTextBoxColumn();
            tauxTaxe = new DataGridViewTextBoxColumn();
            taxeSousTotale = new DataGridViewTextBoxColumn();
            AServiceCB = new ComboBox();
            AddServicesLbl = new Label();
            PanelRecap = new Panel();
            TotalTTCLbl = new Label();
            label3 = new Label();
            label4 = new Label();
            TotalServicesLbl = new Label();
            TotalProduitsLbl = new Label();
            panel1 = new Panel();
            LeTotalTTC = new Label();
            LeTotalProduits = new Label();
            LeTotalTaxes = new Label();
            LeTotalServices = new Label();
            LeTotalHT = new Label();
            TheClientCB = new ComboBox();
            AddClientsLbl = new Label();
            SendInvoiceByMailBtn = new Button();
            PrintInvoiceBtn = new Button();
            GenerateInvoiceWordBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)AllArticlesDGV).BeginInit();
            ((System.ComponentModel.ISupportInitialize)TaxesDGV).BeginInit();
            PanelRecap.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // navbarUserControl
            // 
            navbarUserControl.BackColor = Color.Transparent;
            navbarUserControl.ForeColor = SystemColors.ControlText;
            navbarUserControl.Location = new Point(0, 0);
            navbarUserControl.Name = "navbarUserControl";
            navbarUserControl.Size = new Size(450, 1080);
            navbarUserControl.TabIndex = 0;
            navbarUserControl.ParentForm = this;
            // 
            // QuoteLbl
            // 
            QuoteLbl.AutoSize = true;
            QuoteLbl.Font = new Font("Arial", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            QuoteLbl.Location = new Point(1103, 60);
            QuoteLbl.Name = "QuoteLbl";
            QuoteLbl.Size = new Size(93, 36);
            QuoteLbl.TabIndex = 1;
            QuoteLbl.Text = "Devis";
            QuoteLbl.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // AddProduitsLbl
            // 
            AddProduitsLbl.AutoSize = true;
            AddProduitsLbl.Font = new Font("Arial", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            AddProduitsLbl.Location = new Point(565, 178);
            AddProduitsLbl.Name = "AddProduitsLbl";
            AddProduitsLbl.Size = new Size(205, 27);
            AddProduitsLbl.TabIndex = 1;
            AddProduitsLbl.Text = "Ajouter un produit";
            AddProduitsLbl.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // AProduitCB
            // 
            AProduitCB.FormattingEnabled = true;
            AProduitCB.Location = new Point(491, 229);
            AProduitCB.Name = "AProduitCB";
            AProduitCB.Size = new Size(338, 23);
            AProduitCB.TabIndex = 2;
            AProduitCB.SelectedIndexChanged += AProduit_Choose;
            // 
            // AllArticlesDGV
            // 
            AllArticlesDGV.AllowUserToAddRows = false;
            AllArticlesDGV.AllowUserToDeleteRows = false;
            AllArticlesDGV.BackgroundColor = Color.FromArgb(183, 192, 255);
            AllArticlesDGV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            AllArticlesDGV.Columns.AddRange(new DataGridViewColumn[] { Ref, name, Desc, tva, PrixUnitaire, Quantite, PrixTotal, DelProduct });
            AllArticlesDGV.Location = new Point(491, 347);
            AllArticlesDGV.Name = "AllArticlesDGV";
            AllArticlesDGV.ReadOnly = true;
            AllArticlesDGV.Size = new Size(1343, 253);
            AllArticlesDGV.TabIndex = 3;
            AllArticlesDGV.CellClick += DeleteProductBtn_Click;
            // 
            // Ref
            // 
            Ref.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Ref.HeaderText = "Référence";
            Ref.Name = "Ref";
            Ref.ReadOnly = true;
            // 
            // name
            // 
            name.FillWeight = 280.851074F;
            name.HeaderText = "Désignation";
            name.Name = "name";
            name.ReadOnly = true;
            name.Width = 250;
            // 
            // Desc
            // 
            Desc.FillWeight = 63.8297844F;
            Desc.HeaderText = "Description";
            Desc.Name = "Desc";
            Desc.ReadOnly = true;
            Desc.Width = 400;
            // 
            // tva
            // 
            tva.FillWeight = 63.8297844F;
            tva.HeaderText = "TVA";
            tva.Name = "tva";
            tva.ReadOnly = true;
            // 
            // PrixUnitaire
            // 
            PrixUnitaire.FillWeight = 63.8297844F;
            PrixUnitaire.HeaderText = "Prix Unitaire (HT)";
            PrixUnitaire.Name = "PrixUnitaire";
            PrixUnitaire.ReadOnly = true;
            PrixUnitaire.Width = 150;
            // 
            // Quantite
            // 
            Quantite.FillWeight = 63.8297844F;
            Quantite.HeaderText = "Quantité";
            Quantite.Name = "Quantite";
            Quantite.ReadOnly = true;
            // 
            // PrixTotal
            // 
            PrixTotal.FillWeight = 63.8297844F;
            PrixTotal.HeaderText = "Prix Total (HT)";
            PrixTotal.Name = "PrixTotal";
            PrixTotal.ReadOnly = true;
            PrixTotal.Width = 150;
            // 
            // DelProduct
            // 
            DelProduct.HeaderText = "";
            DelProduct.Name = "DelProduct";
            DelProduct.ReadOnly = true;
            DelProduct.Text = "Supprimer";
            DelProduct.ToolTipText = "Supprimer le produit du devis";
            DelProduct.UseColumnTextForButtonValue = true;
            // 
            // TaxesDGV
            // 
            TaxesDGV.AllowUserToAddRows = false;
            TaxesDGV.AllowUserToDeleteRows = false;
            TaxesDGV.BackgroundColor = Color.Moccasin;
            TaxesDGV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            TaxesDGV.Columns.AddRange(new DataGridViewColumn[] { detailsTaxe, tauxTaxe, taxeSousTotale });
            TaxesDGV.Location = new Point(491, 657);
            TaxesDGV.Name = "TaxesDGV";
            TaxesDGV.ReadOnly = true;
            TaxesDGV.Size = new Size(531, 150);
            TaxesDGV.TabIndex = 4;
            // 
            // detailsTaxe
            // 
            detailsTaxe.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            detailsTaxe.HeaderText = "Détails des taxes";
            detailsTaxe.Name = "detailsTaxe";
            detailsTaxe.ReadOnly = true;
            // 
            // tauxTaxe
            // 
            tauxTaxe.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            tauxTaxe.HeaderText = "Taux de taxe";
            tauxTaxe.Name = "tauxTaxe";
            tauxTaxe.ReadOnly = true;
            // 
            // taxeSousTotale
            // 
            taxeSousTotale.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            taxeSousTotale.HeaderText = "Taxe sous-totale";
            taxeSousTotale.Name = "taxeSousTotale";
            taxeSousTotale.ReadOnly = true;
            // 
            // AServiceCB
            // 
            AServiceCB.FormattingEnabled = true;
            AServiceCB.Location = new Point(994, 229);
            AServiceCB.Name = "AServiceCB";
            AServiceCB.Size = new Size(338, 23);
            AServiceCB.TabIndex = 6;
            AServiceCB.SelectedIndexChanged += AService_Choose;
            // 
            // AddServicesLbl
            // 
            AddServicesLbl.AutoSize = true;
            AddServicesLbl.Font = new Font("Arial", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            AddServicesLbl.Location = new Point(1062, 178);
            AddServicesLbl.Name = "AddServicesLbl";
            AddServicesLbl.Size = new Size(204, 27);
            AddServicesLbl.TabIndex = 5;
            AddServicesLbl.Text = "Ajouter un service";
            AddServicesLbl.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // PanelRecap
            // 
            PanelRecap.BackColor = Color.LightGray;
            PanelRecap.BorderStyle = BorderStyle.FixedSingle;
            PanelRecap.Controls.Add(TotalTTCLbl);
            PanelRecap.Controls.Add(label3);
            PanelRecap.Controls.Add(label4);
            PanelRecap.Controls.Add(TotalServicesLbl);
            PanelRecap.Controls.Add(TotalProduitsLbl);
            PanelRecap.Location = new Point(1420, 657);
            PanelRecap.Name = "PanelRecap";
            PanelRecap.Size = new Size(172, 307);
            PanelRecap.TabIndex = 7;
            // 
            // TotalTTCLbl
            // 
            TotalTTCLbl.AutoSize = true;
            TotalTTCLbl.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            TotalTTCLbl.Location = new Point(22, 260);
            TotalTTCLbl.Name = "TotalTTCLbl";
            TotalTTCLbl.Size = new Size(138, 37);
            TotalTTCLbl.TabIndex = 5;
            TotalTTCLbl.Text = "Total TTC";
            TotalTTCLbl.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 15F);
            label3.Location = new Point(41, 194);
            label3.Name = "label3";
            label3.Size = new Size(96, 28);
            label3.TabIndex = 3;
            label3.Text = "Total Taxe";
            label3.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            label4.Location = new Point(45, 136);
            label4.Name = "label4";
            label4.Size = new Size(92, 28);
            label4.TabIndex = 2;
            label4.Text = "Total HT";
            label4.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // TotalServicesLbl
            // 
            TotalServicesLbl.AutoSize = true;
            TotalServicesLbl.Font = new Font("Segoe UI", 15F);
            TotalServicesLbl.Location = new Point(22, 69);
            TotalServicesLbl.Name = "TotalServicesLbl";
            TotalServicesLbl.Size = new Size(129, 28);
            TotalServicesLbl.TabIndex = 1;
            TotalServicesLbl.Text = "Total Services";
            TotalServicesLbl.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // TotalProduitsLbl
            // 
            TotalProduitsLbl.AutoSize = true;
            TotalProduitsLbl.Font = new Font("Segoe UI", 15F);
            TotalProduitsLbl.Location = new Point(19, 20);
            TotalProduitsLbl.Name = "TotalProduitsLbl";
            TotalProduitsLbl.Size = new Size(132, 28);
            TotalProduitsLbl.TabIndex = 0;
            TotalProduitsLbl.Text = "Total Produits";
            TotalProduitsLbl.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Transparent;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(LeTotalTTC);
            panel1.Controls.Add(LeTotalProduits);
            panel1.Controls.Add(LeTotalTaxes);
            panel1.Controls.Add(LeTotalServices);
            panel1.Controls.Add(LeTotalHT);
            panel1.Location = new Point(1592, 657);
            panel1.Name = "panel1";
            panel1.Size = new Size(172, 307);
            panel1.TabIndex = 8;
            // 
            // LeTotalTTC
            // 
            LeTotalTTC.AutoSize = true;
            LeTotalTTC.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            LeTotalTTC.Location = new Point(9, 260);
            LeTotalTTC.Name = "LeTotalTTC";
            LeTotalTTC.Size = new Size(56, 37);
            LeTotalTTC.TabIndex = 10;
            LeTotalTTC.Text = "0 €";
            LeTotalTTC.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // LeTotalProduits
            // 
            LeTotalProduits.AutoSize = true;
            LeTotalProduits.Font = new Font("Segoe UI", 15F);
            LeTotalProduits.Location = new Point(9, 20);
            LeTotalProduits.Name = "LeTotalProduits";
            LeTotalProduits.Size = new Size(39, 28);
            LeTotalProduits.TabIndex = 6;
            LeTotalProduits.Text = "0 €";
            LeTotalProduits.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // LeTotalTaxes
            // 
            LeTotalTaxes.AutoSize = true;
            LeTotalTaxes.Font = new Font("Segoe UI", 15F);
            LeTotalTaxes.Location = new Point(9, 194);
            LeTotalTaxes.Name = "LeTotalTaxes";
            LeTotalTaxes.Size = new Size(39, 28);
            LeTotalTaxes.TabIndex = 9;
            LeTotalTaxes.Text = "0 €";
            LeTotalTaxes.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // LeTotalServices
            // 
            LeTotalServices.AutoSize = true;
            LeTotalServices.Font = new Font("Segoe UI", 15F);
            LeTotalServices.Location = new Point(9, 69);
            LeTotalServices.Name = "LeTotalServices";
            LeTotalServices.Size = new Size(39, 28);
            LeTotalServices.TabIndex = 7;
            LeTotalServices.Text = "0 €";
            LeTotalServices.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // LeTotalHT
            // 
            LeTotalHT.AutoSize = true;
            LeTotalHT.Font = new Font("Segoe UI", 15F, FontStyle.Bold);
            LeTotalHT.Location = new Point(9, 136);
            LeTotalHT.Name = "LeTotalHT";
            LeTotalHT.Size = new Size(42, 28);
            LeTotalHT.TabIndex = 8;
            LeTotalHT.Text = "0 €";
            LeTotalHT.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // TheClientCB
            // 
            TheClientCB.FormattingEnabled = true;
            TheClientCB.Location = new Point(1496, 229);
            TheClientCB.Name = "TheClientCB";
            TheClientCB.Size = new Size(338, 23);
            TheClientCB.TabIndex = 10;
            TheClientCB.SelectedIndexChanged += TheClient_Choose;
            // 
            // AddClientsLbl
            // 
            AddClientsLbl.AutoSize = true;
            AddClientsLbl.Font = new Font("Arial", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            AddClientsLbl.Location = new Point(1560, 178);
            AddClientsLbl.Name = "AddClientsLbl";
            AddClientsLbl.Size = new Size(178, 27);
            AddClientsLbl.TabIndex = 9;
            AddClientsLbl.Text = "Ajouter le client";
            AddClientsLbl.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // SendInvoiceByMailBtn
            // 
            SendInvoiceByMailBtn.BackColor = Color.Blue;
            SendInvoiceByMailBtn.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            SendInvoiceByMailBtn.ForeColor = Color.White;
            SendInvoiceByMailBtn.Location = new Point(631, 921);
            SendInvoiceByMailBtn.Name = "SendInvoiceByMailBtn";
            SendInvoiceByMailBtn.Size = new Size(251, 43);
            SendInvoiceByMailBtn.TabIndex = 11;
            SendInvoiceByMailBtn.Text = "Envoyer la facture par mail";
            SendInvoiceByMailBtn.UseVisualStyleBackColor = false;
            SendInvoiceByMailBtn.Click += SendInvoiceByMailBtn_Click;
            // 
            // PrintInvoiceBtn
            // 
            PrintInvoiceBtn.BackColor = Color.Blue;
            PrintInvoiceBtn.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            PrintInvoiceBtn.ForeColor = Color.White;
            PrintInvoiceBtn.Location = new Point(994, 921);
            PrintInvoiceBtn.Name = "PrintInvoiceBtn";
            PrintInvoiceBtn.Size = new Size(251, 43);
            PrintInvoiceBtn.TabIndex = 12;
            PrintInvoiceBtn.Text = "Imprimer la facture";
            PrintInvoiceBtn.UseVisualStyleBackColor = false;
            // 
            // GenerateInvoiceWordBtn
            // 
            GenerateInvoiceWordBtn.BackColor = Color.Blue;
            GenerateInvoiceWordBtn.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            GenerateInvoiceWordBtn.ForeColor = Color.White;
            GenerateInvoiceWordBtn.Location = new Point(816, 863);
            GenerateInvoiceWordBtn.Name = "GenerateInvoiceWordBtn";
            GenerateInvoiceWordBtn.Size = new Size(251, 43);
            GenerateInvoiceWordBtn.TabIndex = 13;
            GenerateInvoiceWordBtn.Text = "Générer la facture";
            GenerateInvoiceWordBtn.UseVisualStyleBackColor = false;
            GenerateInvoiceWordBtn.Click += GenerateInvoiceBtn_Click;
            // 
            // Quote
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1904, 1041);
            Controls.Add(GenerateInvoiceWordBtn);
            Controls.Add(PrintInvoiceBtn);
            Controls.Add(SendInvoiceByMailBtn);
            Controls.Add(TheClientCB);
            Controls.Add(AddClientsLbl);
            Controls.Add(panel1);
            Controls.Add(PanelRecap);
            Controls.Add(AServiceCB);
            Controls.Add(AddServicesLbl);
            Controls.Add(TaxesDGV);
            Controls.Add(AllArticlesDGV);
            Controls.Add(AProduitCB);
            Controls.Add(AddProduitsLbl);
            Controls.Add(QuoteLbl);
            Controls.Add(navbarUserControl);
            Name = "Quote";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quotes";
            WindowState = FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)AllArticlesDGV).EndInit();
            ((System.ComponentModel.ISupportInitialize)TaxesDGV).EndInit();
            PanelRecap.ResumeLayout(false);
            PanelRecap.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        NavbarControll navbarUserControl;
        private Label QuoteLbl;
        private Label AddProduitsLbl;
        private ComboBox AProduitCB;
        private DataGridView AllArticlesDGV;
        private DataGridView TaxesDGV;
        private DataGridViewTextBoxColumn detailsTaxe;
        private DataGridViewTextBoxColumn tauxTaxe;
        private DataGridViewTextBoxColumn taxeTotale;
        private ComboBox AServiceCB;
        private Label AddServicesLbl;
        private DataGridViewTextBoxColumn taxeSousTotale;
        private Panel PanelRecap;
        private Panel panel1;
        private Label TotalTTCLbl;
        private Label label3;
        private Label label4;
        private Label TotalServicesLbl;
        private Label TotalProduitsLbl;
        private Label LeTotalTTC;
        private Label LeTotalProduits;
        private Label LeTotalTaxes;
        private Label LeTotalServices;
        private Label LeTotalHT;
        private ComboBox TheClientCB;
        private Label AddClientsLbl;
        private Button SendInvoiceByMailBtn;
        private Button PrintInvoiceBtn;
        private DataGridViewTextBoxColumn Ref;
        private DataGridViewTextBoxColumn name;
        private DataGridViewTextBoxColumn Desc;
        private DataGridViewTextBoxColumn tva;
        private DataGridViewTextBoxColumn PrixUnitaire;
        private DataGridViewTextBoxColumn Quantite;
        private DataGridViewTextBoxColumn PrixTotal;
        private DataGridViewButtonColumn DelProduct;
        private Button GenerateInvoiceWordBtn;
    }
}