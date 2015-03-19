using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Project_Krekelhof.Models.Domain;

namespace Project_Krekelhof.Models.DAL
{
    public class BoekRepository : IBoekRepository
    {
         private KrekelschoolContext Context;
         private DbSet<Boek> Boeken;

         public BoekRepository(KrekelschoolContext context) 
        {
            Context = context;
            Boeken = Context.Boeken;
        }

        public IQueryable<Boek> FindAll()
        {
            return Boeken;
        }

        public IQueryable<Boek> Find(string zoekString)
        {
            return Boeken.Where(p => p.Naam.ToLower().Contains(zoekString.ToLower()) ||
                                             p.Omschrijving.ToLower().Contains(zoekString.ToLower()) ||
                                             p.Auteur.ToLower().Contains(zoekString.ToLower()) ||
                                             p.Uitgeverij.ToLower().Contains(zoekString.ToLower())).OrderBy(p => p.Naam);
        }

        public Boek FindById(int id)
        {
            return Boeken.Find(id);
        }

        public void Add(Boek boek)
        {
            Boeken.Add(boek);
        }

        public void SaveChanges()
        {
            //context.Entry(boek.Themaa).State = EntityState.Modified;    //Zorgt dat het thema niet aangemaakt wordt.
            Context.SaveChanges();
        }

        public void Remove(Boek boek)
        {
            Boeken.Remove(boek);
        }
    }
}