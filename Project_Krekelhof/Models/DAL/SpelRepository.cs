using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Project_Krekelhof.Models.Domain;

namespace Project_Krekelhof.Models.DAL
{
    public class SpelRepository :ISpelRepository
    {
        private KrekelschoolContext Context;
        private DbSet<Spel> Spellen;

        public SpelRepository(KrekelschoolContext context)
        {
            Context = context;
            Spellen = Context.Spellen;
        }

        public IQueryable<Spel> FindAll()
        {
            return Spellen;
        }

        public IQueryable<Spel> Find(string zoekString)
        {
            return Spellen.Where(p => p.Naam.ToLower().Contains(zoekString.ToLower()) ||
                                             p.Omschrijving.ToLower().Contains(zoekString.ToLower()) ||
                                             p.Uitgeverij.ToLower().Contains(zoekString.ToLower())).OrderBy(p => p.Naam);
        }

        public Spel FindById(int id)
        {
            return Spellen.Find(id);
        }

        public void Add(Spel spel)
        {
            Spellen.Add(spel);
        }

        public void SaveChanges()
        {
            Context.SaveChanges();
        }

        public void Remove(Spel spel)
        {
            Spellen.Remove(spel);
        }
    }
}