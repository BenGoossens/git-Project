using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project_Krekelhof.Models.Domain;

namespace Project_Krekelhof.ViewModels
{

    public class BoekViewModel
    {
        public int Id { get; set; }
        public string Naam { get; set; }
        public string Omschrijving { get; set; }
        public string Auteur { get; set; }
        public string Uitgeverij { get; set; }
        public string Leeftijd { get; set; }
        public string Isbn { get; set; }
        public string Categorie { get; set; }
        public bool Beschikbaar { get; set; }
    }
    
    public class BoekIndexViewModel
    {      
        public IEnumerable<BoekViewModel> Boeken { get; set; }

        public BoekIndexViewModel(IEnumerable<Boek> boeken)
        {
            Boeken = boeken.Select(b => new BoekViewModel(){
                Id = b.Id,
                Naam = b.Naam,
                Omschrijving = b.Omschrijving,
                Auteur = b.Auteur,
                Uitgeverij = b.Uitgeverij,
                Leeftijd = b.Leeftijd,
                Isbn = b.Isbn,
                Categorie = b.Categorie.Naam,
                Beschikbaar = b.Beschikbaar
            });
        }
    }

    public class BoekCreateViewModel
    {
        public SelectList Categorieën { get; set; }
        public BoekViewModel Boek { get; set; }

        public BoekCreateViewModel(IEnumerable<Categorie> categories, Boek boek)
        {
            Boek = new BoekViewModel()
            {
                Id = Boek.Id,
                Naam = Boek.Naam,
                Omschrijving = Boek.Omschrijving,
                Auteur = Boek.Auteur,
                Uitgeverij = Boek.Uitgeverij,
                Leeftijd = Boek.Leeftijd,
                Isbn = Boek.Isbn,
                Beschikbaar = Boek.Beschikbaar,
                Categorie = (boek.Categorie == null ? "" : boek.Categorie.Naam)
            };

            Categorieën = new SelectList(categories, "Categorie", "Categorie", Boek.Categorie ?? "");
        }
    }
}