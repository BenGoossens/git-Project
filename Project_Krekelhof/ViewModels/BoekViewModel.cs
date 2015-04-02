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
        public int CategroieId { get; set; }
        public string Categorie { get; set; }
        public bool Beschikbaar { get; set; }

        public BoekViewModel()
        {
            
        }

        public BoekViewModel(Boek b)
        {
            Id = b.Id;
            Naam = b.Naam;
            Omschrijving = b.Omschrijving;
            Auteur = b.Auteur;
            Uitgeverij = b.Uitgeverij;
            Leeftijd = b.Leeftijd;
            Isbn = b.Isbn;
            //CategroieId = (b.Categorie == null) ? 0 : b.Categorie.Id;
            Categorie = (b.Categorie == null) ? null : b.Categorie.Naam;
            Beschikbaar = b.Beschikbaar;
        }
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
}