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
        public virtual Item Item { get; set; }

        public Uitlening()
        {
            
        }

        public Uitlening(int id, DateTime eindeUitlening, Item item)
        {
            this.Id = id;
            this.StartUitlening = DateTime.Today;
            this.EindeUitlening = eindeUitlening;
            this.IsTerug = false;
            this.Item = item;
        }

        public Uitlening(DateTime eindeUitlening, Item item)
        {
            this.StartUitlening = DateTime.Today;
            this.EindeUitlening = eindeUitlening;
            this.IsTerug = false;
            this.Item = item;
        }
    }
}