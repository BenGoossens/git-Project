using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Project_Krekelhof.Models.Domain;

namespace Project_Krekelhof.ViewModels
{
    public class LeerlingViewModel
    {
        public LeerlingViewModel(Leerling l)
        {
            Id = l.Id;
            Voornaam = l.Voornaam;
            Familienaam = l.Familienaam;
            Straat = l.Straat;
            Huisnummer = l.Huisnummer;
            Email = l.Email;
            Klas = l.Klas;
        }
        public int Id { get; set; }
        public string Voornaam { get; set; }
        public string Familienaam { get; set; }
        public string Straat { get; set; }
        public int Huisnummer { get; set; }
        public string Email { get; set; }
        public string Klas { get; set; }
    }

    public class LeerlingIndexViewModel
    {
        public LeerlingIndexViewModel(Leerling l)
        {
            Id = l.Id;
            Voornaam = l.Voornaam;
            Familienaam = l.Familienaam;
            Straat = l.Straat;
            Huisnummer = l.Huisnummer;
            Email = l.Email;
            Klas = l.Klas;
        }
        public int Id { get; set; }
        public string Voornaam { get; set; }
        public string Familienaam { get; set; }
        public string Straat { get; set; }
        public int Huisnummer { get; set; }
        public string Email { get; set; }
        public string Klas { get; set; }
    }
}