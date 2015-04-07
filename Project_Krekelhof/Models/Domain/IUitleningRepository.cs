using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_Krekelhof.Models.Domain
{
    public interface IUitleningRepository
    {
       
        Uitlening FindById(int id);
        
        IQueryable<Uitlening> FindAll();

        IQueryable<Uitlening> Find(String zoekString);

        void Add(Uitlening uitlening);

        void Delete(Uitlening uitlening);

        void SaveChanges();
    
    }
}