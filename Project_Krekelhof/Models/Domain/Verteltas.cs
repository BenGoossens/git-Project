using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_Krekelhof.Models.Domain
{
    public class Verteltas : Item
    {
        public virtual ICollection<Boek> Boeken { get; set; }
        public virtual ICollection<Cd> Cds { get; set; }
        public virtual ICollection<Dvd> Dvds { get; set; }
        public virtual ICollection<Spel> Spellen { get; set; }

        public virtual Categorie Categorie { get; set; }

        public Verteltas()
        {
            
        }

        public Verteltas(int id, string naam, string omschijving, bool beschikbaar, List<Boek> boekenList, List<Cd> cds, List<Dvd> dvds, List<Spel> spellen, Categorie categorie )
        {
            this.Id = id;
            this.Naam = naam;
            this.Omschrijving = omschijving;
            this.Beschikbaar = beschikbaar;
            this.Boeken = boekenList;
            this.Cds = cds;
            this.Dvds = dvds;
            this.Spellen = spellen;
            this.Categorie = categorie;
        }

    }
}