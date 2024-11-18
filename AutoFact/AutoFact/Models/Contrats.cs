using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoFact.Models
{
    internal class Contrats
    {
        private string reference {  get; set; }
        private Clients client { get; set; }
        private DelaisPaiements delais { get; set; }
        private List<Avoirs> avoirs { get; set; }
        private decimal prixTotal;

        private Contrats(string reference, Clients client, DelaisPaiements delais, List<Avoirs> avoirs)
        {
            this.reference = reference;
            this.client = client;
            this.delais = delais;
            this.avoirs = avoirs;
        }
        public Contrats(string reference, decimal prix)
        {
            this.reference = reference;
            this.prixTotal = prix;
        }

        public decimal PrixTotal
        {
            get { return this.prixTotal; }            // Accesseur pour obtenir la valeur du champ prixTotal
            set { this.prixTotal = value; }           // Accesseur pour modifier la valeur du champ prixTotal
        }
    }
}
