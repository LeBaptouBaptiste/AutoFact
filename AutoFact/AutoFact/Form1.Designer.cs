namespace AutoFactTest
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            btn_Devis = new Button();
            boutonCustom = new Button();
            panel1 = new Panel();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // btn_Devis
            // 
            btn_Devis.Location = new Point(105, 66);
            btn_Devis.Margin = new Padding(4, 3, 4, 3);
            btn_Devis.Name = "btn_Devis";
            btn_Devis.Size = new Size(88, 27);
            btn_Devis.TabIndex = 0;
            btn_Devis.Text = "Devis";
            btn_Devis.UseVisualStyleBackColor = true;
            // 
            // boutonCustom
            // 
            boutonCustom.BackColor = Color.DarkBlue;
            boutonCustom.FlatAppearance.BorderColor = Color.White;
            boutonCustom.FlatAppearance.BorderSize = 2;
            boutonCustom.FlatStyle = FlatStyle.Flat;
            boutonCustom.Font = new Font("Arial", 12F, FontStyle.Bold);
            boutonCustom.ForeColor = Color.White;
            boutonCustom.Location = new Point(105, 226);
            boutonCustom.Name = "boutonCustom";
            boutonCustom.Size = new Size(150, 50);
            boutonCustom.TabIndex = 0;
            boutonCustom.Text = "Clique moi";
            boutonCustom.UseVisualStyleBackColor = false;
            boutonCustom.Click += boutonCustom_Click;
            boutonCustom.MouseEnter += boutonCustom_Enter;
            boutonCustom.MouseLeave += boutonCustom_Leave;
            // 
            // panel1
            // 
            panel1.Controls.Add(boutonCustom);
            panel1.Controls.Add(btn_Devis);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(380, 801);
            panel1.TabIndex = 1;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            AutoSize = true;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(1482, 825);
            Controls.Add(panel1);
            Margin = new Padding(4, 3, 4, 3);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            WindowState = FormWindowState.Maximized;
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Button btn_Devis;
        private Button boutonCustom;
        private Panel panel1;
    }
}

