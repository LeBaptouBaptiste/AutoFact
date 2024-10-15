using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace AutoFact
{
    internal class Societe : Clients
    {
        private string siret;
        private List<Produits> produits { get; set; }

        public Societe(int id, string name, string address, string postalCode, string phone, string mail, string siret, List<Produits> produits) : base(id, name, address, postalCode, phone, mail)
        {
            this.siret = siret;
            this.produits = produits;
        }

        public Societe(int id, string name, string address, string postalCode, string phone, string mail, string siret) : base(id, name, address, postalCode, phone, mail)
        {
            this.siret = siret;
        }
        public Societe(string name, string address, string cp, string phone, string mail, string siret) : base(name, address, cp, phone, mail)
        {
            this.siret=siret;
        }

        public string Siret 
        { 
            get { return this.siret; } 
            set { this.siret = value; } 
        }
    }
}
