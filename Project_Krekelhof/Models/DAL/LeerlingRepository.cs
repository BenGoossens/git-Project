﻿using System.Data.Entity;
using System.Linq;
using Project_Krekelhof.Models.Domain;

namespace Project_Krekelhof.Models.DAL
{
    public class LeerlingRepository: ILeerlingRepository
    {
        private KrekelschoolContext Context;
        private DbSet<Leerling> Leerlingen;

        public LeerlingRepository(KrekelschoolContext context)
        {
            Context = context;
            Leerlingen = Context.Leerlingen;
        }

        public Leerling FindBy(int Id)
        {
            return Leerlingen.Find(Id);
        }

        public IQueryable<Leerling> FindAll()
        {
            return Leerlingen;
        }

        public void Add(Leerling leerling)
        {
            Leerlingen.Add(leerling);
        }

        public void Delete(Leerling leerling)
        {
            Leerlingen.Remove(leerling);
        }

        public void SaveChanges()
        {
            Context.SaveChanges();
        }

    }
}