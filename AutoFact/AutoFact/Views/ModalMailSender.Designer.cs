namespace AutoFact.Views
{
    partial class ModalMailSender
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
            TitleMailSenderLbl = new Label();
            NameTB = new TextBox();
            label1 = new Label();
            label2 = new Label();
            DescriptionTB = new TextBox();
            SendInvoiceByMailBtn = new Button();
            SuspendLayout();
            // 
            // TitleMailSenderLbl
            // 
            TitleMailSenderLbl.AutoSize = true;
            TitleMailSenderLbl.Font = new Font("Arial", 24F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TitleMailSenderLbl.Location = new Point(316, 62);
            TitleMailSenderLbl.Name = "TitleMailSenderLbl";
            TitleMailSenderLbl.Size = new Size(331, 36);
            TitleMailSenderLbl.TabIndex = 2;
            TitleMailSenderLbl.Text = "Envoi du mail au client";
            TitleMailSenderLbl.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // NameTB
            // 
            NameTB.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            NameTB.ForeColor = Color.Silver;
            NameTB.Location = new Point(151, 199);
            NameTB.MaxLength = 255;
            NameTB.Name = "NameTB";
            NameTB.Size = new Size(665, 26);
            NameTB.TabIndex = 3;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 16F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(151, 160);
            label1.Name = "label1";
            label1.Size = new Size(183, 25);
            label1.TabIndex = 4;
            label1.Text = "Sujet du message";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial", 16F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(151, 280);
            label2.Name = "label2";
            label2.Size = new Size(194, 25);
            label2.TabIndex = 5;
            label2.Text = "Corps du message";
            label2.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // DescriptionTB
            // 
            DescriptionTB.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            DescriptionTB.ForeColor = Color.Silver;
            DescriptionTB.Location = new Point(151, 308);
            DescriptionTB.MaxLength = 511;
            DescriptionTB.Multiline = true;
            DescriptionTB.Name = "DescriptionTB";
            DescriptionTB.Size = new Size(665, 170);
            DescriptionTB.TabIndex = 6;
            // 
            // SendInvoiceByMailBtn
            // 
            SendInvoiceByMailBtn.BackColor = Color.Blue;
            SendInvoiceByMailBtn.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            SendInvoiceByMailBtn.ForeColor = Color.White;
            SendInvoiceByMailBtn.Location = new Point(351, 529);
            SendInvoiceByMailBtn.Name = "SendInvoiceByMailBtn";
            SendInvoiceByMailBtn.Size = new Size(251, 43);
            SendInvoiceByMailBtn.TabIndex = 12;
            SendInvoiceByMailBtn.Text = "Envoyer";
            SendInvoiceByMailBtn.UseVisualStyleBackColor = false;
            // 
            // ModalMailSender
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(994, 624);
            Controls.Add(SendInvoiceByMailBtn);
            Controls.Add(DescriptionTB);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(NameTB);
            Controls.Add(TitleMailSenderLbl);
            Name = "ModalMailSender";
            Text = "ModalMailSender";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label TitleMailSenderLbl;
        private TextBox NameTB;
        private Label label1;
        private Label label2;
        private TextBox DescriptionTB;
        private Button SendInvoiceByMailBtn;
    }
}