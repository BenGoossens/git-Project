using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_Krekelhof.Models.Domain
{
    public class Spel : Item
    {
        public ICollection<Categorie> Categories { get; set; }

        public Spel(int id, string naam, string beschrijving, bool beschikbaar)
            : base(id, naam, beschrijving, beschikbaar)
        {
        }

        public Spel()
            : base()
        {
        }
    }
}