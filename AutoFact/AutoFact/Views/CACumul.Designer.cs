namespace AutoFact.Views
{
    partial class CACumul
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
            CACumulLbl = new Label();
            navbarUserControl = new NavbarControll();
            StartDP = new DateTimePicker();
            EndDP = new DateTimePicker();
            CalculBtn = new Button();
            CALbl = new Label();
            PercentLbl = new Label();
            SuspendLayout();
            // 
            // CACumulLbl
            // 
            CACumulLbl.AutoSize = true;
            CACumulLbl.Font = new Font("Arial", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CACumulLbl.Location = new Point(1005, 120);
            CACumulLbl.Name = "CACumulLbl";
            CACumulLbl.Size = new Size(424, 37);
            CACumulLbl.TabIndex = 8;
            CACumulLbl.Text = "Calcul du chiffre d'affaires";
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
            // StartDP
            // 
            StartDP.Location = new Point(808, 280);
            StartDP.Name = "StartDP";
            StartDP.Size = new Size(200, 23);
            StartDP.TabIndex = 9;
            // 
            // EndDP
            // 
            EndDP.Location = new Point(1371, 280);
            EndDP.Name = "EndDP";
            EndDP.Size = new Size(200, 23);
            EndDP.TabIndex = 10;
            // 
            // CalculBtn
            // 
            CalculBtn.BackColor = Color.Blue;
            CalculBtn.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CalculBtn.ForeColor = Color.White;
            CalculBtn.Location = new Point(1065, 544);
            CalculBtn.Name = "CalculBtn";
            CalculBtn.Size = new Size(267, 89);
            CalculBtn.TabIndex = 17;
            CalculBtn.Text = "Calculer";
            CalculBtn.UseVisualStyleBackColor = false;
            CalculBtn.Click += CalculBtn_Click;
            // 
            // CALbl
            // 
            CALbl.AutoSize = true;
            CALbl.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CALbl.Location = new Point(882, 797);
            CALbl.Name = "CALbl";
            CALbl.Size = new Size(306, 65);
            CALbl.TabIndex = 18;
            CALbl.Text = "Chargement";
            CALbl.Visible = false;
            // 
            // PercentLbl
            // 
            PercentLbl.AutoSize = true;
            PercentLbl.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            PercentLbl.Location = new Point(1354, 797);
            PercentLbl.Name = "PercentLbl";
            PercentLbl.Size = new Size(306, 65);
            PercentLbl.TabIndex = 19;
            PercentLbl.Text = "Chargement";
            PercentLbl.Visible = false;
            // 
            // CACumul
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1904, 1041);
            Controls.Add(PercentLbl);
            Controls.Add(CALbl);
            Controls.Add(EndDP);
            Controls.Add(StartDP);
            Controls.Add(CalculBtn);
            Controls.Add(CACumulLbl);
            Controls.Add(navbarUserControl);
            Margin = new Padding(4, 3, 4, 3);
            Name = "CACumul";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "CACumul";
            WindowState = FormWindowState.Maximized;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private NavbarControll navbarUserControl;
        private Label CACumulLbl;
        private DateTimePicker StartDP;
        private DateTimePicker EndDP;
        private Button CalculBtn;
        private Label CALbl;
        private Label PercentLbl;
    }
}