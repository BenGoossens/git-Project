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

        public Item()
        {
            
        }

        public Item(string naam, string omschrijving, bool beschikbaar)
        {
            Naam = naam;
            Omschrijving = omschrijving;
            Beschikbaar = beschikbaar;
        }

        public Item(int id, string naam, string omschrijving, bool beschikbaar)
        {
            Id = id;
            Naam = naam;
            Omschrijving = omschrijving;
            Beschikbaar = beschikbaar;
        }
    }
}