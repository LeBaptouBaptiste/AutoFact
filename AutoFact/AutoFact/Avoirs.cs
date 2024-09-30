using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoFactTest
{
    internal class Avoirs
    {
        private int id { get; set; }
        private decimal montant { get; set; }
        private Clients client { get; set; }
        private Contrats contrat { get; set; }
    }
}
