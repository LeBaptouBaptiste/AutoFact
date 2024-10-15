using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoFact
{
    internal class Services : Designation
    {
        private int duration;
        private string description;

        public Services(int id, string libelle, decimal prix, int duree, string description) : base(id, libelle, prix)
        {
            this.duration = duree;
            this.description = description;
        }
        public Services(string libelle, decimal prix, int duree, string description) : base(libelle, prix)
        {
            this.duration = duree;
            this.description = description;
        }

        public int Duration
        {
            get { return this.duration; }       // Accesseur pour obtenir la valeur du champ buyPrice
            set { this.duration = value; }      // Accesseur pour modifier la valeur du champ buyPrice
        }

        public string Description
        {
            get { return this.description; }       // Accesseur pour obtenir la valeur du champ quantity
            set { this.description = value; }      // Accesseur pour modifier la valeur du champ quantity
        }
    }

}
