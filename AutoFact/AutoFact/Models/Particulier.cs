﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoFact
{
    internal class Particulier : Clients
    {
        private string civility {  get; set; }
        private string prenom {  get; set; }

        public Particulier(int id, string name, string address, string postalCode, string phone, string mail, string civility, string prenom) : base(id, name, address, postalCode, phone, mail)
        {
            this.civility = civility;
            this.prenom = prenom;
        }
    }
}