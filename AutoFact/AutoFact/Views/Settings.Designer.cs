namespace AutoFact.Views
{
    partial class Settings
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
            SettingsLbl = new Label();
            SocietyLbl = new Label();
            NameTB = new TextBox();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            textBox5 = new TextBox();
            label1 = new Label();
            openFileDialog1 = new OpenFileDialog();
            LogoPB = new PictureBox();
            SelectLogoBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)LogoPB).BeginInit();
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
            // 
            // SettingsLbl
            // 
            SettingsLbl.AutoSize = true;
            SettingsLbl.Font = new Font("Arial", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            SettingsLbl.Location = new Point(1063, 92);
            SettingsLbl.Name = "SettingsLbl";
            SettingsLbl.Size = new Size(192, 37);
            SettingsLbl.TabIndex = 8;
            SettingsLbl.Text = "Paramètres";
            // 
            // SocietyLbl
            // 
            SocietyLbl.AutoSize = true;
            SocietyLbl.Font = new Font("Arial", 18F, FontStyle.Bold);
            SocietyLbl.Location = new Point(1093, 164);
            SocietyLbl.Name = "SocietyLbl";
            SocietyLbl.Size = new Size(136, 29);
            SocietyLbl.TabIndex = 9;
            SocietyLbl.Text = "Ma société";
            // 
            // NameTB
            // 
            NameTB.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            NameTB.ForeColor = Color.Silver;
            NameTB.Location = new Point(694, 289);
            NameTB.MaxLength = 255;
            NameTB.Name = "NameTB";
            NameTB.Size = new Size(180, 26);
            NameTB.TabIndex = 1;
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox1.ForeColor = Color.Silver;
            textBox1.Location = new Point(1063, 289);
            textBox1.MaxLength = 255;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(180, 26);
            textBox1.TabIndex = 10;
            // 
            // textBox2
            // 
            textBox2.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox2.ForeColor = Color.Silver;
            textBox2.Location = new Point(1431, 289);
            textBox2.MaxLength = 255;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(180, 26);
            textBox2.TabIndex = 11;
            // 
            // textBox3
            // 
            textBox3.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox3.ForeColor = Color.Silver;
            textBox3.Location = new Point(694, 422);
            textBox3.MaxLength = 255;
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(180, 26);
            textBox3.TabIndex = 12;
            // 
            // textBox4
            // 
            textBox4.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox4.ForeColor = Color.Silver;
            textBox4.Location = new Point(1063, 422);
            textBox4.MaxLength = 255;
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(180, 26);
            textBox4.TabIndex = 13;
            // 
            // textBox5
            // 
            textBox5.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            textBox5.ForeColor = Color.Silver;
            textBox5.Location = new Point(1431, 422);
            textBox5.MaxLength = 255;
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(180, 26);
            textBox5.TabIndex = 14;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 18F, FontStyle.Bold);
            label1.Location = new Point(796, 560);
            label1.Name = "label1";
            label1.Size = new Size(358, 29);
            label1.TabIndex = 15;
            label1.Text = "Importer votre logo de société";
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // LogoPB
            // 
            LogoPB.Location = new Point(1541, 560);
            LogoPB.Name = "LogoPB";
            LogoPB.Size = new Size(53, 46);
            LogoPB.TabIndex = 16;
            LogoPB.TabStop = false;
            // 
            // SelectLogoBtn
            // 
            SelectLogoBtn.BackColor = Color.Blue;
            SelectLogoBtn.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            SelectLogoBtn.ForeColor = Color.White;
            SelectLogoBtn.Location = new Point(1228, 533);
            SelectLogoBtn.Name = "SelectLogoBtn";
            SelectLogoBtn.Size = new Size(267, 89);
            SelectLogoBtn.TabIndex = 17;
            SelectLogoBtn.Text = "Telecharger";
            SelectLogoBtn.UseVisualStyleBackColor = false;
            SelectLogoBtn.Click += SelectLogoBtn_Click;
            // 
            // Settings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1904, 1041);
            Controls.Add(SelectLogoBtn);
            Controls.Add(LogoPB);
            Controls.Add(label1);
            Controls.Add(textBox5);
            Controls.Add(textBox4);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(NameTB);
            Controls.Add(SocietyLbl);
            Controls.Add(SettingsLbl);
            Controls.Add(navbarUserControl);
            Margin = new Padding(4, 3, 4, 3);
            Name = "Settings";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Settings";
            WindowState = FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)LogoPB).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private NavbarControll navbarUserControl;
        private Label SettingsLbl, SocietyLbl;
        private TextBox NameTB;
        private TextBox textBox1;
        private TextBox textBox2;
        private TextBox textBox3;
        private TextBox textBox4;
        private TextBox textBox5;
        private Label label1;
        private OpenFileDialog openFileDialog1;
        private PictureBox LogoPB;
        private Button SelectLogoBtn;
    }
}