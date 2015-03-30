using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Krekelhof.Models.Domain
{
    public interface ISpelRepository
    {
        IQueryable<Spel> FindAll();
        IQueryable<Spel> Find(String zoekString);
        Spel FindById(int id);
        void Add(Spel spel);
        void SaveChanges();
        void Remove(Spel spel);
    }
}
