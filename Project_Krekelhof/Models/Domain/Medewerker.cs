using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Project_Krekelhof.ViewModels;

namespace Project_Krekelhof.Models.Domain
{
    public class Medewerker : Gebruiker
    {
        public Medewerker(IBoekRepository boekRepository, ICategorieRepository categorieRepository, ICdRepository cdRepository, IDvdRepository dvdRepository, ISpelRepository spelRepository) : base(boekRepository, categorieRepository, cdRepository, dvdRepository, spelRepository)
        {
        }

        public void AddBoek(BoekViewModel boek)
        {
            Boek newBoek = new Boek
            {
                Id = boek.Id,
                Naam = boek.Naam,
                Auteur = boek.Auteur,
                Uitgeverij = boek.Uitgeverij,
                Leeftijd = boek.Leeftijd,
                Omschrijving = boek.Omschrijving,
                Isbn = boek.Isbn,
                Beschikbaar = boek.Beschikbaar,
                Categorie = (String.IsNullOrEmpty(boek.Categorie) ? null : GeefCategorieBijNaam(boek.Categorie))
            };
            BoekRepository.Add(newBoek);
            BoekRepository.SaveChanges();
        }

        public void VerwijderBoek(int id)
        {
            BoekRepository.Remove(GeefBoek(id));
            BoekRepository.SaveChanges();
        }
    }
}