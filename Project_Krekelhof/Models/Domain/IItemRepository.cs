using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Project_Krekelhof.Models.Domain
{
    public interface IItemRepository
    {
        Item FindBy(int itemId);

        IQueryable<Item> FindAll();

        void Add(Item item);

        void Delete(Item item);

        void SaveChanges();

    }
}