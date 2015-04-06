using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Project_Krekelhof.Models.Domain;

namespace Project_Krekelhof.ViewModels
{
    public class SpelViewModel
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public string Omschrijving { get; set; }
        public bool Beschikbaar { get; set; }
        public string Uitgeverij { get; set; }
        public string Leeftijd { get; set; }
        public string Categorie { get; set; }

        public SpelViewModel()
        {
            
        }

        public SpelViewModel(Spel s)
        {
            Id = s.Id;
            Naam = s.Naam;
            Omschrijving = s.Omschrijving;
            Uitgeverij = s.Uitgeverij;
            Leeftijd = s.Leeftijd;
            Categorie = (s.Categorie == null) ? null : s.Categorie.Naam;
            Beschikbaar = s.Beschikbaar;
        }
    }

    public class SpelIndexViewModel
    {
        public IEnumerable<SpelViewModel> Spellen { get; set; }

        public SpelIndexViewModel(IEnumerable<Spel> spellen)
        {
            Spellen = spellen.Select(s => new SpelViewModel()
            {
                Id = s.Id,
                Naam = s.Naam,
                Omschrijving = s.Omschrijving,
                Beschikbaar = s.Beschikbaar,
                Uitgeverij = s.Uitgeverij,
                Leeftijd = s.Leeftijd,
                Categorie = s.Categorie.Naam
            });
        }
    }
}