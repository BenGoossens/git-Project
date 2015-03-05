using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_Krekelhof.Models.Domain
{
    public class Boek : Item
    {
        public string Auteur { get; set; }
        public string Isbn { get; set; }
        public string Uitgeverij { get; set; }
        public virtual Categorie Categorie { get; set; }

        public Boek()
        {
            
        }

        public Boek(int id, string naam, string omschrijving, bool beschikbaar, string auteur, string ISBN, string uitgeverij, Categorie categorie)
        {
            this.Id = id;
            this.Naam = naam;
            this.Omschrijving = omschrijving;
            this.Beschikbaar = beschikbaar;
            this.Auteur = auteur;
            this.Isbn = ISBN;
            this.Uitgeverij = uitgeverij;
            this.Categorie = categorie;
        }

        public Boek(string naam, string omschrijving, bool beschikbaar, string auteur, string ISBN, string uitgeverij, Categorie categorie)
        {
            this.Naam = naam;
            this.Omschrijving = omschrijving;
            this.Beschikbaar = beschikbaar;
            this.Auteur = auteur;
            this.Isbn = ISBN;
            this.Uitgeverij = uitgeverij;
            this.Categorie = categorie;
        }
    }
}