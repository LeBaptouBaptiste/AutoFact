namespace AutoFact.Views
{
    partial class ModalQuantityProduct
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
            QuantityLbl = new Label();
            QuantityTB = new TextBox();
            OkBtn = new Button();
            SuspendLayout();
            // 
            // QuantityLbl
            // 
            QuantityLbl.Anchor = AnchorStyles.None;
            QuantityLbl.AutoSize = true;
            QuantityLbl.Font = new Font("Arial", 16F, FontStyle.Regular, GraphicsUnit.Point, 0);
            QuantityLbl.Location = new Point(194, 26);
            QuantityLbl.Name = "QuantityLbl";
            QuantityLbl.Size = new Size(92, 25);
            QuantityLbl.TabIndex = 6;
            QuantityLbl.Text = "Quantité";
            QuantityLbl.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // QuantityTB
            // 
            QuantityTB.Anchor = AnchorStyles.None;
            QuantityTB.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            QuantityTB.ForeColor = Color.Silver;
            QuantityTB.Location = new Point(182, 73);
            QuantityTB.MaxLength = 255;
            QuantityTB.Name = "QuantityTB";
            QuantityTB.Size = new Size(121, 26);
            QuantityTB.TabIndex = 2;
            QuantityTB.Text = "1";
            QuantityTB.TextAlign = HorizontalAlignment.Center;
            QuantityTB.KeyDown += QuantityTB_KeyDown;
            // 
            // OkBtn
            // 
            OkBtn.Anchor = AnchorStyles.None;
            OkBtn.Location = new Point(195, 121);
            OkBtn.Name = "OkBtn";
            OkBtn.Size = new Size(95, 28);
            OkBtn.TabIndex = 1;
            OkBtn.Text = "Ok";
            OkBtn.UseVisualStyleBackColor = true;
            OkBtn.Click += OkBtn_Click;
            // 
            // ModalQuantityProduct
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(515, 194);
            Controls.Add(OkBtn);
            Controls.Add(QuantityLbl);
            Controls.Add(QuantityTB);
            Location = new Point(500, 50);
            Name = "ModalQuantityProduct";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "ModalQuantityProduct";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label QuantityLbl;
        private TextBox QuantityTB;
        private Button OkBtn;
    }
}