namespace AutoFact.Views
{
    partial class TestForm
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
            roundedButton1 = new RoundedButton();
            customTextBox1 = new CustomTextBox();
            SuspendLayout();
            // 
            // roundedButton1
            // 
            roundedButton1.BorderColor = Color.Red;
            roundedButton1.BorderRadius = 20;
            roundedButton1.BorderThickness = 4;
            roundedButton1.Location = new Point(662, 443);
            roundedButton1.Name = "roundedButton1";
            roundedButton1.Size = new Size(211, 45);
            roundedButton1.TabIndex = 1;
            roundedButton1.Text = "roundedButton1";
            roundedButton1.UseVisualStyleBackColor = true;
            // 
            // customTextBox1
            // 
            customTextBox1.BackColor = Color.White;
            customTextBox1.BorderStyle = BorderStyle.None;
            customTextBox1.Font = new Font("Arial", 12F, FontStyle.Bold);
            customTextBox1.ForeColor = Color.Gray;
            customTextBox1.Location = new Point(516, 182);
            customTextBox1.Name = "customTextBox1";
            customTextBox1.Size = new Size(109, 19);
            customTextBox1.TabIndex = 2;
            // 
            // TestForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1768, 914);
            Controls.Add(customTextBox1);
            Controls.Add(roundedButton1);
            Name = "TestForm";
            Text = "TestForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private RoundedButton roundedButton1;
        private CustomTextBox customTextBox1;
    }
}