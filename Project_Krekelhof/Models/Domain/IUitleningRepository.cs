using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_Krekelhof.Models.Domain
{
    public interface IUitleningRepository
    {
       
        Uitlening FindBy(int uitleningId);
        
        IQueryable<Uitlening> FindAll();

        void Add(Uitlening uitlening);

        void Delete(Uitlening uitlening);

        void SaveChanges();
    
    }
}