using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_Krekelhof.Models.Domain
{
    public class Dvd : Item
    {
        public string Regiseur { get; set; }
        public virtual Categorie Categorie { get; set; } 
    }
}