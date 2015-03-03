using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace Project_Krekelhof
{
    public abstract class Item
    {
        public Item() { }
        int Id { get; set; }
        string Omschrijving { get; set; }
        string Naam { get; set; }
        int Beschikbaar { get; set; }

        public String isBeschikbaar()
        {
            if (Beschikbaar == 0)
            {
                return "No";
            } else
            {
                return "Yes";
            }
        }
        public Categorie categorie {  get; set; }
    }
}
