﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_Krekelhof.Models.Domain
{
    public class Gebruiker
    {
        //kan zonder login op systeem
        public virtual Leerling Leerling { get; set; }
        

        public Item ItemOpzoeken(string zoekWoord)
        {
            //code
            return null;
        }

        public Uitlening UitleningOpzoeken(string zoekWoord)
        {
            //code
            return null;
        }

        public bool MagUitlenen(Leerling leerling)
        {
            if (leerling.Uitleningen.Count == 3)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}