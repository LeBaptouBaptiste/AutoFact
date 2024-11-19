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
    public partial class ModalQuantityProduct : Form
    {
        public string EnteredQuantity { get; private set; } // Propriété pour stocker la quantité

        public ModalQuantityProduct()
        {
            InitializeComponent();
            this.ActiveControl = QuantityTB;
        }

        private void OkBtn_Click(object sender, EventArgs e)
        {
            // Récupérer la valeur entrée dans le TextBox et la stocker dans la propriété
            EnteredQuantity = QuantityTB.Text;

            // Fermer le modal
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void QuantityTB_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OkBtn_Click(sender, e);
            }
        }
    }
}
