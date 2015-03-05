using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_Krekelhof.Models.Domain
{
    public class Uitlening
    {
        public int Id { get; set; }
        public DateTime StartUitlening { get; set; }
        public DateTime EindeUitlening { get; set; }
        public bool IsTerug { get; set; }

        public virtual ICollection<Item> Items { get; set; }

        public Uitlening()
        {
            
        }

        public Uitlening(int id, DateTime startUitlening, DateTime eindeUitlening, bool isTerug, ICollection<Item> items)
        {
            this.Id = id;
            this.StartUitlening = startUitlening;
            this.EindeUitlening = eindeUitlening;
            this.IsTerug = isTerug;
            this.Items = items;
        }

        public Uitlening(DateTime startUitlening, DateTime eindeUitlening, bool isTerug, ICollection<Item> items)
        {
            this.StartUitlening = startUitlening;
            this.EindeUitlening = eindeUitlening;
            this.IsTerug = isTerug;
            this.Items = items;
        }
    }
}