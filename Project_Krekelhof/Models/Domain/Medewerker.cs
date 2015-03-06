using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_Krekelhof.Models.Domain
{
    public class Medewerker  :Gebruiker
    {
        public string LoginNaam { get; set; }
        public string Passwoord { get; set; }

        public Medewerker()
        {
            
        }

        public Medewerker(string loginNaam, string passwoord)
        {
            this.LoginNaam = loginNaam;
            this.Passwoord = passwoord;
        }

        public virtual ICollection<Uitlening> Uitleningen { get; set; }
        public void UitleningToevoegen(int id, DateTime startUitlening, DateTime eindeUitlening, bool isTerug, Item item )
        {
            if (!MagUitlenen(Leerling))
              throw new ApplicationException("Leerling heeft maximum uitleningen bereikt");
            Uitlening nieuweUitlening = new Uitlening(eindeUitlening, item);
            if (Uitleningen.Contains(nieuweUitlening))
                throw new ApplicationException("Uitlening bestaat al");

            Uitleningen.Add(nieuweUitlening);
            Leerling.Uitleningen.Add(nieuweUitlening);
            item.Beschikbaar = false;
        }

        public void UitleningAanpassen()
        {
            //code
            
        }

        public void UitleningVerwijderen(Uitlening uitlening)
        {
            if (!Uitleningen.Contains(uitlening))
                throw new ArgumentException(string.Format("{0} bestaat niet!", uitlening.Id));
            Uitleningen.Remove(uitlening);
        }
    }
}