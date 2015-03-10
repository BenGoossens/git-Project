using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Project_Krekelhof.Models.Domain;
using System.Data.Entity;

namespace Project_Krekelhof.Models.DAL.Mapper
{
    public class ItemRepository: IItemRepository

    {
        private KrekelschoolContext context;
        private DbSet<Item> items;

        public ItemRepository(KrekelschoolContext context)
        {
            this.context = context;
            items = context.Items;
        }

        public IQueryable<Item> FindAll()
        {
            return items;
        }

        public Item FindBy(int Id)
        {
            return items.Find(Id);
        }

        public void Add(Item item)
        {
            items.Add(item);
        }

        public void Delete(Item item)
        {
            items.Remove(item);
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }





    }
}