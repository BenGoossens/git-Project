using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_Krekelhof.Models.Domain
{
    public class Dvd : Item
    {
        public string Regisseur { get; set; }
        public virtual ICollection<Categorie> Categories { get; set; }

        public Dvd(int id, string naam, string beschrijving, bool beschikbaar, string regisseur)
            : base(id, naam, beschrijving, beschikbaar)
        {
            Regisseur = regisseur;
        }

        public Dvd()
        {

        }
        
    }
}