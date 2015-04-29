using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_Krekelhof.Models.Domain
{
    public interface IItemRepository
    {
        IQueryable<Item> FindAll();
        Item FindById(int id);
    }
}
