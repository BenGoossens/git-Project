using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_Krekelhof.Models.Domain
{
    public interface IBoekRepository
    {
        IQueryable<Boek> FindAll();
        IQueryable<Boek> Find(String zoekString);
        Boek FindById(int id);
        void Add(Boek boek);
        void SaveChanges();
        void Remove(Boek boek);
    }
}