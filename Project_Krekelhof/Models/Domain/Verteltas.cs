using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace Project_Krekelhof
{
    public class Verteltas : IItem
    {

        public int Id { get; set; }
        
        public string Omschrijving { get; set; }
        
        public string Naam { get; set; }
        
        public int Beschikbaar { get; set; }
        
        public virtual ICollection<IItem> Items { get; set; }
        
        public virtual Categorie Categorie { get; set; }
        }
}
