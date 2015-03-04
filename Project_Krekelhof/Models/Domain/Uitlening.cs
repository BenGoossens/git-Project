using System;

namespace Project_Krekelhof.Models.Domain
{
    public class Uitlening
    {
        public virtual Item Item { get; set; }
        
        public int Id { get; set; }
        

        public DateTime StartOntlening { get; set; }
        

        public DateTime EindeOntlening { get; set; }

        public bool IsTerug { get; set; }
        
    }
}
