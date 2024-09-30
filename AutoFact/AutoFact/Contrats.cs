using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoFactTest
{
    internal class Contrats
    {
        private string reference {  get; set; }
        private Clients client { get; set; }
        private DelaisPaiements delais { get; set; }
        private List<Avoirs> avoirs { get; set; }

        private Contrats(string reference, Clients client, DelaisPaiements delais, List<Avoirs> avoirs)
        {
            this.reference = reference;
            this.client = client;
            this.delais = delais;
            this.avoirs = avoirs;
        }
    }
}
