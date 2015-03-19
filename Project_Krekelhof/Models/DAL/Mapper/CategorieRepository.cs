using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Project_Krekelhof.Models.Domain;

namespace Project_Krekelhof.Models.DAL.Mapper
{
    public class CategorieRepository : ICategorieRepository
    {
        private KrekelschoolContext Context;
        private DbSet<Categorie> categories;

        public CategorieRepository(KrekelschoolContext context)
        {
            Context = context;
            categories = Context.Categorieen;
        }

        public IQueryable<Categorie> FindAll()
        {
            return categories;
        }

        public Categorie FindById(int id)
        {
            return categories.SingleOrDefault(d => d.Id == id);
        }

        public Categorie FindBy(string categorie)
        {
            return categories.SingleOrDefault(t => t.Naam == categorie);
        }

        public void Add(Categorie categorie)
        {
            categories.Add(categorie);
        }

        public void Remove(Categorie categorie)
        {
            categories.Remove(categorie);
        }

        public void SaveChanges()
        {
            Context.SaveChanges();
        }
    }
}