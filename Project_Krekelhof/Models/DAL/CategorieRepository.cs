using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Project_Krekelhof.Models.Domain;

namespace Project_Krekelhof.Models.DAL
{
    public class CategorieRepository : ICategorieRepository
    {
        private KrekelschoolContext Context;

        public CategorieRepository(KrekelschoolContext context)
        {
            Context = context;
        }

        public IQueryable<Categorie> FindAll()
        {
            return Context.Categorieen;
        }

        public Categorie FindById(int id)
        {
            return Context.Categorieen.SingleOrDefault(d => d.Id == id);
        }

        public Categorie FindBy(string categorienaam)
        {
            return Context.Categorieen.SingleOrDefault(t => t.Naam == categorienaam);
        }

        public void Add(Categorie categorie)
        {
            Context.Categorieen.Add(categorie);
        }

        public void Remove(Categorie categorie)
        {
            Context.Categorieen.Remove(categorie);
        }

        public void SaveChanges()
        {
            Context.SaveChanges();
        }
    }
}