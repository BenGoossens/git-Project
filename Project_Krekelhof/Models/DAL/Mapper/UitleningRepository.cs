using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Project_Krekelhof.Models.Domain;

namespace Project_Krekelhof.Models.DAL.Mapper
{
    public class UitleningRepository: IUitleningRepository
    {
        private KrekelschoolContext Context;
        private DbSet<Uitlening> Uitleningen;



        public UitleningRepository(KrekelschoolContext context)
        {
            Context = context;
            Uitleningen = Context.Uitleningen;
        }


        public Uitlening FindBy(int Id)
        {
            return Uitleningen.Find(Id);
        }
        
        public IQueryable<Uitlening> FindAll()
        {
            return Uitleningen;
        }

        public void Add(Uitlening uitlening)
        {
            Uitleningen.Add(uitlening);
        }

        public void Delete(Uitlening uitlening)
        {
            Uitleningen.Remove(uitlening);
        }

        public void SaveChanges()
        {
            Context.SaveChanges();
        }
    }
}