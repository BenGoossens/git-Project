using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_Krekelhof.Models.Domain
{
    public class Spel : Item
    {
        public string Uitgeverij { get; set; }
        public string Leeftijd { get; set; }
        public virtual Categorie Categorie { get; set; }

        public Spel(int id, string naam, string beschrijving, bool beschikbaar, string uitgeverij, string leeftijd, Categorie categorie)
            : base(id, naam, beschrijving, beschikbaar)
        {
            Uitgeverij = uitgeverij;
            Leeftijd = leeftijd;
            Categorie = categorie;
        }

        public Spel()
            : base()
        {
        }
    }
}