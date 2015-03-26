using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_Krekelhof.Models.Domain
{
    public class Cd : Item
    {
        public string ArtiestNaam { get; set; }
        public virtual ICollection<Categorie> Categories { get; set; }

        public Cd(int id, string naam, string beschrijving, bool beschikbaar, string artiestnaam)
            : base(id, naam, beschrijving, beschikbaar)
        {
            ArtiestNaam = artiestnaam;
        }

        public Cd()
        {

        }
 
    }
}