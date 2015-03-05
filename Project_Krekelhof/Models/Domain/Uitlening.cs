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
    }
}