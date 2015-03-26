using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Project_Krekelhof.Models.Domain;

namespace Project_Krekelhof.ViewModels
{

    public class BoekViewModel
    {
        public BoekViewModel(Boek b)
        {
            Id = b.Id;
            Naam = b.Naam;
            Omschrijving = b.Omschrijving;
            Auteur = b.Auteur;
            Uitgeverij = b.Uitgeverij;
            Leeftijd = b.Leeftijd;
            Isbn = b.Isbn;

        }

        public int Id { get; set; }
        public string Naam { get; set; }
        public string Omschrijving { get; set; }
        public string Auteur { get; set; }
        public string Uitgeverij { get; set; }
        public int Leeftijd { get; set; }
        public string Isbn { get; set; }
    }
    
    public class BoekIndexViewModel
    {
        public BoekIndexViewModel(Boek b)
        {
            Id = b.Id;
            Naam = b.Naam;
            Omschrijving = b.Omschrijving;
            Auteur = b.Auteur;
            Uitgeverij = b.Uitgeverij;
            Leeftijd = b.Leeftijd;
            Isbn = b.Isbn;

        }

        public int Id { get; set; }
        public string Naam { get; set; }
        public string Omschrijving { get; set; }
        public string Auteur { get; set; }
        public string Uitgeverij { get; set; }
        public int Leeftijd { get; set; }
        public string Isbn { get; set; }
       
    }

    public class BoeksIndexViewModel
    {
        public IEnumerable<BoekIndexViewModel> Boeks { get; set; }

        public BoeksIndexViewModel(IEnumerable<Boek> boeks)
        {
            Boeks = boeks.Select(p => new BoekIndexViewModel(p));
        }
    }
}