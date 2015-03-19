using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_Krekelhof.Models.Domain
{
    public abstract class Item
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public string Omschrijving { get; set; }
        public bool Beschikbaar { get; set; }

        protected Item()
        {
            
        }

        protected Item(int id, string naam, string omschrijving, bool beschikbaar)
        {
            Id = id;
            Naam = naam;
            Omschrijving = omschrijving;
            Beschikbaar = beschikbaar;
        }

        public void WordUitgeleend()
        {
            if (!Beschikbaar)
            {
                throw new ApplicationException("Item is al uitgeleend");
            }
            else
            {
                Beschikbaar = false;
            }
        }

        public void WordTerugGebracht()
        {
            if (Beschikbaar)
            {
                throw new ApplicationException("Dit item was al terug in de Lettertuin");
            }
            Beschikbaar = true;
        }
    }
}