using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_Krekelhof.Models.Domain
{
    public class Categorie
    {
        public int Id { get; set; }
        public string Naam { get; set; }

        public Categorie()
        {
            
        }

        public Categorie(int id, string naam)
        {
            Id = id;
            Naam = naam;
        }

        public Categorie(string naam)
        {
            Naam = naam;
        }
    }
}