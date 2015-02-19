using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace Project_Krekelhof
{
    public class Leerling
    {
        public int Id { get; set; }
        

        public string FamilieNaam { get; set; }
        
        public virtual ICollection<Uitlening> Uitleningen { get; set; }

        public string Voornaam { get; set; }
        
    }
}
