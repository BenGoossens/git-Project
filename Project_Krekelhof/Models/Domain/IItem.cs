using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;

namespace Project_Krekelhof
{
    public interface IItem
    {
        int Id { get; set; }

        string Omschrijving { get; set; }

        string Naam { get; set; }

        int Beschikbaar { get; set; }

       /* public Categorie categorie { get; set; }*/
    }
}
