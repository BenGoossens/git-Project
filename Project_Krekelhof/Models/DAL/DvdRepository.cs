using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Project_Krekelhof.Models.Domain;

namespace Project_Krekelhof.Models.DAL
{
    public class DvdRepository : IDvdRepository
    {
        private KrekelschoolContext Context;
        private DbSet<Dvd> Dvds;

        public DvdRepository(KrekelschoolContext context)
        {
            Context = context;
            Dvds = Context.Dvds;
        }

        public IQueryable<Dvd> FindAll()
        {
            return Dvds;
        }

        public IQueryable<Dvd> Find(string zoekString)
        {
            return Dvds.Where(p => p.Naam.ToLower().Contains(zoekString.ToLower()) ||
                                             p.Omschrijving.ToLower().Contains(zoekString.ToLower()) ||
                                             p.Regisseur.ToLower().Contains(zoekString.ToLower())).OrderBy(p => p.Naam);
        }

        public Dvd FindById(int id)
        {
            return Dvds.Find(id);
        }

        public void Add(Dvd dvd)
        {
            Dvds.Add(dvd);
        }

        public void SaveChanges()
        {
            Context.SaveChanges();
        }

        public void Remove(Dvd dvd)
        {
            Dvds.Remove(dvd);
        }
    }
}