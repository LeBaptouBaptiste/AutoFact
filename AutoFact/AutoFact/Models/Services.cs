﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoFact
{
    internal class Services : Designation
    {
        private int duree {  get; set; }

        public Services(int id, string libelle, decimal prix, int duree) : base(id, libelle, prix)
        {
            this.duree = duree;
        }
    }

}