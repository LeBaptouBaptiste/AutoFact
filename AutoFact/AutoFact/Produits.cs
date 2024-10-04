using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoFact
{
    internal class Produits : Designation
    {
        private decimal buyPrice {  get; set; }
        private int quantity { get; set; }
        private Societe society { get; set; }
    }
}
