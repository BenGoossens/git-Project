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

        public Dvd(int id, string naam, string beschrijving, bool beschikbaar, string regisseur, Categorie categorie)
            : base(id, naam, beschrijving, beschikbaar)
        {
            Regisseur = regisseur;
            Categorie = categorie;
        }

        public Dvd()
        {

        }
        
    }
}