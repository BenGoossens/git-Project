using System;
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
        public ISpelRepository SpelRepository;
        public ILeerlingRepository LeerlingRepository;

        public Gebruiker(IBoekRepository boekRepository, ICategorieRepository categorieRepository, ICdRepository cdRepository, IDvdRepository dvdRepository, ISpelRepository spelRepository, ILeerlingRepository leerlingRepository)
        {
            this.BoekRepository = boekRepository;
            this.CategorieRepository = categorieRepository;
            this.CdRepository = cdRepository;
            this.DvdRepository = dvdRepository;
            this.SpelRepository = spelRepository;
            this.LeerlingRepository = leerlingRepository;
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

        #region methodesSpel
        public IEnumerable<Spel> GeefSpellen(string zoekTerm)
        {
            return !String.IsNullOrEmpty(zoekTerm) ? SpelRepository.Find(zoekTerm).ToList() : SpelRepository.FindAll().OrderBy(t => t.Naam).ToList();
        }
        public Spel GeefSpel(int id)
        {
            Spel spel = SpelRepository.FindById(id);
            return spel;
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

        #region methodesLeerling
        public IEnumerable<Leerling> GeefLeerlingen(string zoekTerm)
        {
            return !String.IsNullOrEmpty(zoekTerm) ? LeerlingRepository.Find(zoekTerm).ToList() : LeerlingRepository.FindAll().OrderBy(t => t.Id).ToList();
        }
        public Leerling GeefLeerling(int id)
        {
            Leerling leerling = LeerlingRepository.FindById(id);
            return leerling;
        }
        #endregion
    }
}