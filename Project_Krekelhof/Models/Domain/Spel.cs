using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_Krekelhof.Models.Domain
{
    public class Spel : Item
    {
        public virtual Categorie Categorie { get; set; }

        public Spel()
        {
            
        }

        public Spel(int id, string naam, string omschrijvng, bool beschikbaar, Categorie categorie)
        {
            this.Id = id;
            this.Naam = naam;
            this.Omschrijving = omschrijvng;
            this.Beschikbaar = beschikbaar;
            this.Categorie = categorie;
        }
    }
}