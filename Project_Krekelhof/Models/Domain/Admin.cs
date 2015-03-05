using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_Krekelhof.Models.Domain
{
    public class Admin : Medewerker
    {
        public virtual ICollection<Item> Items { get; set; }
        public virtual ICollection<Leerling> Leerlingen { get; set; }
        public Item ItemToevoegen()
        {
            //code
            return null;
        }

        public Item ItemAanpassen()
        {
            //code
            return null;
        }

        public void ItemVerwijderen(Item item)
        {
            if (!Items.Contains(item))
                throw new ArgumentException(string.Format("{0} bestaat niet", item.Naam));
            Items.Remove(item);
        }

        public Leerling LeerlingToevoegen()
        {
            //code
            return null;
        }

        public Leerling LeerlingAanpassen()
        {
            //code
            return null;
        }

        public void LeerlingVerwijderen(Leerling leerling)
        {
            if (!Leerlingen.Contains(leerling))
                throw new ArgumentException(string.Format("{0} {0} bestaat niet", leerling.Voornaam));
            Leerlingen.Remove(leerling);
        }
    }
}