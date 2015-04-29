using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Project_Krekelhof.Models.Domain;

namespace Project_Krekelhof.Models.DAL
{
    public class ItemRepository : IItemRepository
    {
        private KrekelschoolContext Context;
        private DbSet<Item> Items;

        public ItemRepository(KrekelschoolContext context)
        {
            Context = context;
            Items = context.Items;
        }
        public IQueryable<Item> FindAll()
        {
            return Items;
        }

        public Item FindById(int id)
        {
            return Items.Find(id);
        }
    }
}