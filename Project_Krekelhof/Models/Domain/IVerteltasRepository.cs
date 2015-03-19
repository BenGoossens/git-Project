using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_Krekelhof.Models.Domain
{
    public interface IVerteltasRepository
    {
        IQueryable<Verteltas> FindAll();
        Verteltas FindById(int id);
        void Add(Verteltas verteltas);
        void SaveChanges();
    }
}