using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AutoFact.Models
{
    public class Clients
    {
        private int id;
        private string name;
        private string address;
        private string postalCode;
        private string phone;
        private string mail;
        private List<Avoirs> avoirs;
        private List<Contrats> contrats;

        public Clients(int id, string name, string address, string postalCode, string phone, string mail, List<Avoirs> avoirs)
        {
            this.id = id;
            this.name = name;
            this.address = address;
            this.postalCode = postalCode;
            this.phone = phone;
            this.mail = mail;
            this.avoirs = avoirs;
        }

        public Clients(int id, string name, string address, string postalCode, string phone, string mail)
        {
            this.id = id;
            this.name = name;
            this.address = address;
            this.postalCode = postalCode;
            this.phone = phone;
            this.mail = mail;
        }

        public Clients(string name, string address, string cp, string phone, string mail)
        {
            this.name = name;
            this.address = address;
            this.postalCode = cp;
            this.phone = phone;
            this.mail = mail;
        }

        public int Id
        {
            get { return this.id; }           // Accesseur pour obtenir la valeur du champ _id
            set { this.id = value; }          // Accesseur pour modifier la valeur du champ _id
        }

        public string Name
        {
            get { return this.name; }         // Accesseur pour obtenir la valeur du champ _name
            set { this.name = value; }        // Accesseur pour modifier la valeur du champ _name
        }

        public string Address
        {
            get { return this.address; }      // Accesseur pour obtenir la valeur du champ _address
            set { this.address = value; }     // Accesseur pour modifier la valeur du champ _address
        }

        public string PostalCode
        {
            get { return this.postalCode; }   // Accesseur pour obtenir la valeur du champ _postalCode
            set { this.postalCode = value; }  // Accesseur pour modifier la valeur du champ _postalCode
        }

        public string Phone
        {
            get { return this.phone; }        // Accesseur pour obtenir la valeur du champ _phone
            set { this.phone = value; }       // Accesseur pour modifier la valeur du champ _phone
        }

        public string Mail
        {
            get { return this.mail; }         // Accesseur pour obtenir la valeur du champ _mail
            set { this.mail = value; }        // Accesseur pour modifier la valeur du champ _mail
        }
        public List<Contrats> Contrats
        {
            get { return this.contrats; }         // Accesseur pour obtenir la valeur du champ _mail
            set { this.contrats = value; }        // Accesseur pour modifier la valeur du champ _mail
        }

        public override string ToString()
        {
            return $"{name}";
        }
    }
}
