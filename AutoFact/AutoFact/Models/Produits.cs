using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoFact
{
    internal class Produits : Designation
    {
        private decimal buyPrice;
        private int quantity;
        private Societe fournisseur;

        public Produits(int id, string libelle, decimal prix, decimal buyPrice, int quantity, Societe fournisseur) : base(id, libelle, prix)
        {
            this.buyPrice = buyPrice;
            this.quantity = quantity;
            this.fournisseur = fournisseur;
        }

        public Produits(string libelle, decimal prix, decimal buyPrice, int quantity, Societe fournisseur) : base(libelle, prix)
        {
            this.buyPrice = buyPrice;
            this.quantity = quantity;
            this.fournisseur = fournisseur;
        }

        public decimal BuyPrice
        {
            get { return this.buyPrice; }       // Accesseur pour obtenir la valeur du champ buyPrice
            set { this.buyPrice = value; }      // Accesseur pour modifier la valeur du champ buyPrice
        }

        public int Quantity
        {
            get { return this.quantity; }       // Accesseur pour obtenir la valeur du champ quantity
            set { this.quantity = value; }      // Accesseur pour modifier la valeur du champ quantity
        }

        public Societe Fournisseur
        {
            get { return this.fournisseur; }    // Accesseur pour obtenir la valeur du champ fournisseur
            set { this.fournisseur = value; }   // Accesseur pour modifier la valeur du champ fournisseur
        }
    }
}
