using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_Krekelhof.Models.Domain
{
    public class Verteltas : Item
    {
        public virtual Categorie Categorie { get; set; }
        public ICollection<Boek> Boeken { get; set; }
        public ICollection<Cd> Cds { get; set; }
        public ICollection<Dvd> Dvds { get; set; }
        public ICollection<Spel> Spellen { get; set; }

        public Verteltas(int id, string naam, string beschrijving, bool beschikbaar)
            : base(id, naam, beschrijving, beschikbaar)
        {
        }
    }
}