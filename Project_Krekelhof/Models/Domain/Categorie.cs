using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_Krekelhof.Models.Domain
{
    public class Categorie
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public virtual ICollection<Item> Items { get; set; }

        public Categorie()
        {
            Items = new HashSet<Item>();
        }

        public void Add(Item i)
        {
            Items.Add(i);
        }
    }
}