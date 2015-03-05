using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_Krekelhof.Models.Domain
{
    public class Verteltas : Item
    {
        public string BeschrijvingItems { get; set; }
        public virtual ICollection<Boek> Boeken { get; set; }
        public virtual ICollection<Cd> Cds { get; set; }
        public virtual ICollection<Dvd> Dvds { get; set; }
        public virtual ICollection<Spel> Spellen { get; set; }
    }
}