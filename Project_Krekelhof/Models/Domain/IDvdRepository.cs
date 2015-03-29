using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Krekelhof.Models.Domain
{
    public interface IDvdRepository
    {
        IQueryable<Dvd> FindAll();
        IQueryable<Dvd> Find(String zoekString);
        Dvd FindById(int id);
        void Add(Dvd dvd);
        void SaveChanges();
        void Remove(Dvd dvd);
    }
}
