using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoFact.Models
{
    internal class Services : Designation
    {
        private int duration;
        private bool haveDuration;

        public Services(int id, string libelle, decimal prix, int duree, string description) : base(id, libelle, prix, description)
        {
            this.duration = duree;
            this.haveDuration = true;
        }
        public Services(string libelle, decimal prix, int duree, string description) : base(libelle, prix, description)
        {
            this.duration = duree;
            this.haveDuration = true;
        }
        public Services(int id, string libelle, decimal prix, string description) : base(id, libelle, prix, description)
        {
            this.haveDuration = false;
        }
        public Services(string libelle, decimal prix, string description) : base(libelle, prix, description)
        {
            this.haveDuration = false;
        }

        public int Duration
        {
            get { return this.duration; }       // Accesseur pour obtenir la valeur du champ buyPrice
            set { this.duration = value; }      // Accesseur pour modifier la valeur du champ buyPrice
        }

        public bool HaveDuration
        {
            get { return this.haveDuration; }
            set { this.haveDuration = value; }
        }
    }
}
