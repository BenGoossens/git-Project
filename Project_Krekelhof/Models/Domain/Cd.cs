using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_Krekelhof.Models.Domain
{
    public class Cd : Item
    {
        public string ArtiestNaam { get; set; }
        public virtual Categorie Categorie { get; set; }

        public Cd()
        {
            
        }

        public Cd(int id, string naam, string omschrijving, bool beschikbaar, string artiestnaam, Categorie categorie)
        {
            this.Id = id;
            this.Naam = naam;
            this.Omschrijving = omschrijving;
            this.Beschikbaar = beschikbaar;
            this.ArtiestNaam = artiestnaam;
            this.Categorie = categorie;
        }

        public Cd(string naam, string omschrijving, bool beschikbaar, string artiestnaam, Categorie categorie)
        {
            this.Naam = naam;
            this.Omschrijving = omschrijving;
            this.Beschikbaar = beschikbaar;
            this.ArtiestNaam = artiestnaam;
            this.Categorie = categorie;
        }
    }
}