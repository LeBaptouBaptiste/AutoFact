using AxAcroPDFLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AutoFact.Views
{
    public partial class PDFViewer : Form
    {
        Quote quote = new Quote();
        public PDFViewer()
        {
            InitializeComponent();
        }

        private void axAcroPDF1_OnError(object sender, EventArgs e)
        {
            MessageBox.Show("An error occurred while loading the PDF file.");
        }

        private void PDFViewer_Load(object sender, EventArgs e)
        {
            axAcroPDF1.LoadFile(quote.GenerateInvoicePDF());
            axAcroPDF1.setZoom(125); // Zoom à 125 %.
            axAcroPDF1.setShowToolbar(true);
            axAcroPDF1.Refresh();
        }
    }
}
