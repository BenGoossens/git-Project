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

        public string Leeftijd { get; set; }

        public virtual Categorie Categorie { get; set; }

        public Boek()
        {
            
        }

        public Boek(int id, string naam, string beschrijving, bool beschikbaar, string auteur, string ISBN, string uitgeverij, string leeftijd, Categorie categorie)
            : base(id, naam, beschrijving, beschikbaar)
        {
            this.Auteur = auteur;
            this.Isbn = ISBN;
            this.Uitgeverij = uitgeverij;
            this.Leeftijd = leeftijd;
            this.Categorie = categorie;
        }    
    }
}