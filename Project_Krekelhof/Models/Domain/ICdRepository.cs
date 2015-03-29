using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Krekelhof.Models.Domain
{
    public interface ICdRepository
    {
        IQueryable<Cd> FindAll();
        IQueryable<Cd> Find(String zoekString);
        Cd FindById(int id);
        void Add(Cd cd);
        void SaveChanges();
        void Remove(Cd cd);
    }
}
