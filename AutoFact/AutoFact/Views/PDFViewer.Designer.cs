namespace AutoFact.Views
{
    partial class PDFViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PDFViewer));
            axAcroPDF1 = new AxAcroPDFLib.AxAcroPDF();
            ((System.ComponentModel.ISupportInitialize)axAcroPDF1).BeginInit();
            SuspendLayout();
            // 
            // axAcroPDF1
            // 
            axAcroPDF1.Dock = DockStyle.Fill;
            axAcroPDF1.Enabled = true;
            axAcroPDF1.Location = new Point(0, 0);
            axAcroPDF1.Name = "axAcroPDF1";
            axAcroPDF1.OcxState = (AxHost.State)resources.GetObject("axAcroPDF1.OcxState");
            axAcroPDF1.Size = new Size(1904, 1041);
            axAcroPDF1.TabIndex = 0;
            // 
            // PDFViewer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1904, 1041);
            Controls.Add(axAcroPDF1);
            Name = "PDFViewer";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "PDFViewer";
            WindowState = FormWindowState.Maximized;
            Load += PDFViewer_Load;
            ((System.ComponentModel.ISupportInitialize)axAcroPDF1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private AxAcroPDFLib.AxAcroPDF axAcroPDF1;
    }
}