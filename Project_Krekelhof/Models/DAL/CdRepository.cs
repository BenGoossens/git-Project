using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Project_Krekelhof.Models.Domain;

namespace Project_Krekelhof.Models.DAL
{
    public class CdRepository : ICdRepository
    {
        private KrekelschoolContext Context;
        private DbSet<Cd> Cds;

        public CdRepository(KrekelschoolContext context)
        {
            Context = context;
            Cds = Context.Cds;
        }


        public IQueryable<Cd> FindAll()
        {
            return Cds;
        }

        public IQueryable<Cd> Find(string zoekString)
        {
            return Cds.Where(p => p.Naam.ToLower().Contains(zoekString.ToLower()) ||
                                             p.Omschrijving.ToLower().Contains(zoekString.ToLower()) ||
                                             p.ArtiestNaam.ToLower().Contains(zoekString.ToLower())).OrderBy(p => p.Naam);
        }

        public Cd FindById(int id)
        {
            return Cds.Find(id);
        }

        public void Add(Cd cd)
        {
            Cds.Add(cd);
        }

        public void SaveChanges()
        {
            Context.SaveChanges();
        }

        public void Remove(Cd cd)
        {
            Cds.Remove(cd);
        }
    }
}