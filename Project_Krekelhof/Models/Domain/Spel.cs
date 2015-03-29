using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_Krekelhof.Models.Domain
{
    public class Spel : Item
    {
        public virtual Categorie Categorie { get; set; }

        public Spel(int id, string naam, string beschrijving, bool beschikbaar, Categorie categorie)
            : base(id, naam, beschrijving, beschikbaar)
        {
            Categorie = categorie;
        }

        public Spel()
            : base()
        {
        }
    }
}