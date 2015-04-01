using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_Krekelhof.Models.Domain
{
    public interface ILeerlingRepository
    {
        Leerling FindById(int itemId);
        IQueryable<Leerling> FindAll();
        IQueryable<Leerling> Find(String zoekString);
        void Add(Leerling leerling);
        void Delete(Leerling leerling);
        void SaveChanges();

    }
}