using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoFact.Models
{
    internal class Designation
    {
        private int id;
        private string libelle;
        private decimal prix;

        public Designation (int id, string libelle, decimal prix)
        {
            this.id = id;
            this.libelle = libelle;
            this.prix = prix;
        }

        public Designation(string libelle, decimal prix)
        {
            this.id = id;
            this.libelle = libelle;
            this.prix = prix;
        }

        public int Id
        {
            get { return this.id; }            // Accesseur pour obtenir la valeur du champ id
            set { this.id = value; }           // Accesseur pour modifier la valeur du champ id
        }

        public string Libelle
        {
            get { return this.libelle; }       // Accesseur pour obtenir la valeur du champ libelle
            set { this.libelle = value; }      // Accesseur pour modifier la valeur du champ libelle
        }

        public decimal Prix
        {
            get { return this.prix; }          // Accesseur pour obtenir la valeur du champ prix
            set { this.prix = value; }         // Accesseur pour modifier la valeur du champ prix
        }
    }
}
