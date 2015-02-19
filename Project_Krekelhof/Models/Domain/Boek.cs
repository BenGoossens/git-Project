using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace Project_Krekelhof
{
    public class Boek : IItem
    {
        public int Id { get; set; }
        

        public string Omschrijving { get; set; }
        

        public string Naam { get; set; }
        

        public int Beschikbaar { get; set; }

        public Categorie Categorie { get; set; }

        public int Isbn { get; set; }
    }
}
