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

        public Gebruiker(IBoekRepository boekRepository, ICategorieRepository categorieRepository)
        {
            this.BoekRepository = boekRepository;
            this.CategorieRepository = categorieRepository;
        }

        public IEnumerable<Boek> GeefBoeken(string zoekTerm)
        {
            return !String.IsNullOrEmpty(zoekTerm) ? BoekRepository.Find(zoekTerm).ToList() : BoekRepository.FindAll().OrderBy(t => t.Naam).ToList();
        }

        public IEnumerable<Categorie> GeefCategorieën()
        {
            return CategorieRepository.FindAll().OrderBy(c => c.Naam);
        }

        public Categorie GeefCategorieBijNaam(string naam)
        {
            return CategorieRepository.FindBy(naam);
        }

        public Boek GeefBoek(int id)
        {
            Boek boek = BoekRepository.FindById(id);
            return boek;
        }

    }
}