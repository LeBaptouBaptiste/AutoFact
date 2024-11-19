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
        private decimal oldCAcalcul = 0m;
        public CACumul()
        {
            InitializeComponent();
            cacumulvm = new CACumulVM();
        }

        private void CalculBtn_Click(object sender, EventArgs e)
        {
            CAcalcule = 0m;
            oldCAcalcul = 0m;
            if (StartDP.Value < EndDP.Value)
            {
                listFactures = cacumulvm.getFactures(StartDP.Value, EndDP.Value);

                foreach (Contrats facture in listFactures)
                {
                    CAcalcule += facture.PrixTotal;
                }

                CALbl.Text = CAcalcule.ToString() + " €";

                int difference = (EndDP.Value - StartDP.Value).Days;

                TimeSpan dayDiff = TimeSpan.FromDays(difference);
                listFactures = cacumulvm.getFactures(StartDP.Value - dayDiff, EndDP.Value - dayDiff);

                foreach (Contrats facture in listFactures)
                {
                    oldCAcalcul += facture.PrixTotal;
                }

                if (oldCAcalcul == 0)
                {
                    PercentLbl.Text = "+ 100 %";
                }
                else if (CAcalcule < oldCAcalcul)
                {
                    PercentLbl.Text = $"- {((oldCAcalcul - CAcalcule) * 100 / oldCAcalcul):0.##} %";
                }
                else if (CAcalcule > oldCAcalcul)
                {
                    PercentLbl.Text = $"+ {((CAcalcule - oldCAcalcul) * 100 / oldCAcalcul):0.##} %";
                }
                else
                {
                    PercentLbl.Text = "+ 0 %";
                }

                PercentLbl.Visible = true;
                CALbl.Visible = true;
            }
            else
            {
                MessageBox.Show("La date de fin est plus récente que la date de début");
            }
        }
    }
}
