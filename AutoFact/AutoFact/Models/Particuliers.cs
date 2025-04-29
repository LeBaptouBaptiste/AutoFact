using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoFact.Models
{
    public class Particuliers : Clients
    {
        private string civility {  get; set; }
        private string firstName {  get; set; }

        public Particuliers(int id, string name, string address, string postalCode, string phone, string mail, string civility, string prenom) : base(id, name, address, postalCode, phone, mail)
        {
            this.civility = civility;
            this.firstName = prenom;
        }

        public Particuliers(string name, string address, string postalCode, string phone, string mail, string civility, string prenom) : base(name, address, postalCode, phone, mail)
        {
            this.civility = civility;
            this.firstName = prenom;
        }

        public string FirstName
        {
            get { return this.firstName; }           // Accesseur pour obtenir la valeur du champ _id
            set { this.firstName = value; }          // Accesseur pour modifier la valeur du champ _id
        }

        public string Civility
        {
            get { return this.civility; }           // Accesseur pour obtenir la valeur du champ _id
            set { this.civility = value; }          // Accesseur pour modifier la valeur du champ _id
        }

        public override string ToString()
        {
            return $"{Name} {FirstName}";
        }
    }
}
