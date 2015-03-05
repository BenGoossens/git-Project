using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_Krekelhof.Models.Domain
{
    public class Medewerker  :Gebruiker
    {
        public virtual ICollection<Uitlening> Uitleningen { get; set; }
        public Uitlening UitleningToevoegen(int id, DateTime startUitlening, DateTime eindeUitlening, bool isTerug)
        {
            //code
            return null;
        }

        public Uitlening UitleningAanpassen()
        {
            //code
            return null;
        }

        public void UitleningVerwijderen(Uitlening uitlening)
        {
            if (!Uitleningen.Contains(uitlening))
                throw new ArgumentException(string.Format("{0} bestaat niet!", uitlening.Id));
            Uitleningen.Remove(uitlening);
        }
    }
}