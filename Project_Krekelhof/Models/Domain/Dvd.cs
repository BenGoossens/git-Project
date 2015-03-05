using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_Krekelhof.Models.Domain
{
    public class Dvd : Item
    {
        public string Regisseur { get; set; }
        public virtual Categorie Categorie { get; set; }

        public Dvd()
        {
            
        }

        public Dvd(int id, string naam, string omschrijving, bool beschikbaar, string regisseur, Categorie categorie)
        {
            this.Id = id;
            this.Naam = naam;
            this.Omschrijving = omschrijving;
            this.Beschikbaar = beschikbaar;
            this.Regisseur = regisseur;
            this.Categorie = categorie;
        }
        public Dvd(string naam, string omschrijving, bool beschikbaar, string regisseur, Categorie categorie)
        {
            this.Naam = naam;
            this.Omschrijving = omschrijving;
            this.Beschikbaar = beschikbaar;
            this.Regisseur = regisseur;
            this.Categorie = categorie;
        }
    }
}