using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace Project_Krekelhof
{
    public class Uitlening
    {
        public virtual IItem Iitem { get; set; }
        
        public int Id { get; set; }
        

        public DateTime StartOntlening { get; set; }
        

        public DateTime EindeOntlening { get; set; }

        public bool IsTerug { get; set; }
        
    }
}
