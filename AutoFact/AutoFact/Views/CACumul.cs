using AutoFact.Models;
using AutoFact.ViewModel;
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
    public partial class CACumul : Form
    {
        private CACumulVM cacumulvm;
        private List<Contrats> listFactures;
        private decimal CAcalcule = 0m;
        public CACumul()
        {
            InitializeComponent();
            cacumulvm = new CACumulVM();
        }

        private void CalculBtn_Click(object sender, EventArgs e)
        {
            CAcalcule = 0m;
            if (StartDP.Value < EndDP.Value)
            {
                listFactures = cacumulvm.getFactures(StartDP.Value, EndDP.Value);

                foreach (Contrats facture in listFactures)
                {
                    CAcalcule += facture.PrixTotal;
                }

                CALbl.Text = CAcalcule.ToString() + " €";
            }
            else
            {
                MessageBox.Show("La date de fin est plus récente que la date de début");
            }
        }
    }
}
