using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_Krekelhof.Models.Domain
{
    public interface ICategorieRepository
    {
        IQueryable<Categorie> FindAll();
        Categorie FindById(int id);
        Categorie FindBy(string naam);
        void Add(Categorie categorie);
        void Remove(Categorie categorie);
        void SaveChanges();
    }
}