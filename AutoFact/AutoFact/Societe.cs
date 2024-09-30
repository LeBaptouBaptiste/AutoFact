using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoFactTest
{
    internal class Societe : Clients
    {
        private string siret {  get; set; }
        private List<Produits> produits { get; set; }
    }
}
