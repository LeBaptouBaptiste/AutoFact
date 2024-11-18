using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace AutoFact.Models
{
    internal class Services : Designation
    {
        private int duration;
        private string description;
        private bool haveDuration;

        public Services(int id, string libelle, decimal prix, int duree, string description) : base(id, libelle, prix, description)
        {
            this.duration = duree;
            this.description = description;
            this.haveDuration = true;
        }
        public Services(string libelle, decimal prix, int duree, string description) : base(libelle, prix)
        {
            this.duration = duree;
            this.description = description;
            this.haveDuration = true;
        }
        public Services(int id, string libelle, decimal prix, string description) : base(id, libelle, prix, description)
        {
            this.description = description;
            this.haveDuration = false;
        }
        public Services(string libelle, decimal prix, string description) : base(libelle, prix)
        {
            this.description = description;
            this.haveDuration = false;
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

        public bool HaveDuration
        {
            get { return this.haveDuration; }
            set { this.haveDuration = value; }
        }
    }
}