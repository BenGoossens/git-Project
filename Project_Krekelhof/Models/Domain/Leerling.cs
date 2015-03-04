using System.Collections.Generic;

namespace Project_Krekelhof.Models.Domain
{
    public class Leerling
    {
        public int Id { get; set; }
        

        public string FamilieNaam { get; set; }
        
        public virtual ICollection<Uitlening> Uitleningen { get; set; }

        public string Voornaam { get; set; }

      //  public Leerling(String familieNaam, String voornaam, int id)
      //  {        }

    }
}
