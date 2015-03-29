﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_Krekelhof.Models.Domain
{
    public class Gebruiker
    {
        public IBoekRepository BoekRepository;
        public ICategorieRepository CategorieRepository;
        public ICdRepository CdRepository;
        public IDvdRepository DvdRepository;

        public Gebruiker(IBoekRepository boekRepository, ICategorieRepository categorieRepository, ICdRepository cdRepository, IDvdRepository dvdRepository)
        {
            this.BoekRepository = boekRepository;
            this.CategorieRepository = categorieRepository;
            this.CdRepository = cdRepository;
            this.DvdRepository = dvdRepository;
        }

        #region methodesBoek
        public IEnumerable<Boek> GeefBoeken(string zoekTerm)
        {
            return !String.IsNullOrEmpty(zoekTerm) ? BoekRepository.Find(zoekTerm).ToList() : BoekRepository.FindAll().OrderBy(t => t.Naam).ToList();
        }

        public Boek GeefBoek(int id)
        {
            Boek boek = BoekRepository.FindById(id);
            return boek;
        }
        #endregion

        #region methodesCd
        public IEnumerable<Cd> GeefCds(string zoekTerm)
        {
            return !String.IsNullOrEmpty(zoekTerm) ? CdRepository.Find(zoekTerm).ToList() : CdRepository.FindAll().OrderBy(t => t.Naam).ToList();
        }

        public Cd GeefCd(int id)
        {
            Cd cd = CdRepository.FindById(id);
            return cd;
        }
        #endregion

        #region methodesDvd
        public IEnumerable<Dvd> GeefDvds(string zoekTerm)
        {
            return !String.IsNullOrEmpty(zoekTerm) ? DvdRepository.Find(zoekTerm).ToList() : DvdRepository.FindAll().OrderBy(t => t.Naam).ToList();
        }
        public Dvd GeefDvd(int id)
        {
            Dvd dvd = DvdRepository.FindById(id);
            return dvd;
        }
        #endregion

        #region methodesCategorieën
        public IEnumerable<Categorie> GeefCategorieën()
        {
            return CategorieRepository.FindAll().OrderBy(c => c.Naam);
        }

        public Categorie GeefCategorieBijNaam(string naam)
        {
            return CategorieRepository.FindBy(naam);
        }
        #endregion
    }
}