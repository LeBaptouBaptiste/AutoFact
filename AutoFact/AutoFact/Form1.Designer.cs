﻿namespace AutoFactTest
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
            this.btn_Devis = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_Devis
            // 
            this.btn_Devis.Location = new System.Drawing.Point(47, 52);
            this.btn_Devis.Name = "btn_Devis";
            this.btn_Devis.Size = new System.Drawing.Size(75, 23);
            this.btn_Devis.TabIndex = 0;
            this.btn_Devis.Text = "Devis";
            this.btn_Devis.UseVisualStyleBackColor = true;
            this.btn_Devis.Click += new System.EventHandler(this.btn_Devis_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_Devis);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_Devis;
    }
}

