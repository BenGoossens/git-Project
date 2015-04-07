using System.Data.Entity;
using System.Linq;
using Project_Krekelhof.Models.Domain;

namespace Project_Krekelhof.Models.DAL
{
    public class UitleningRepository: IUitleningRepository
    {
        private KrekelschoolContext Context;
        private DbSet<Uitlening> Uitleningen;



        public UitleningRepository(KrekelschoolContext context)
        {
            Context = context;
            Uitleningen = Context.Uitleningen;
        }


        public Uitlening FindById(int id)
        {
            return Uitleningen.Find(id);
        }
        
        public IQueryable<Uitlening> FindAll()
        {
            return Uitleningen;
        }

        public IQueryable<Uitlening> Find(string zoekString)
        {
            return Uitleningen.Where(p => p.Leerling.Voornaam.ToLower().Contains(zoekString.ToLower()) ||
                                             p.Leerling.Familienaam.ToLower().Contains(zoekString.ToLower()) ||
                                             p.Item.Naam.ToLower().Contains(zoekString.ToLower())).OrderBy(p => p.BeginDatumUitlening);
        }

        public void Add(Uitlening uitlening)
        {
            Uitleningen.Add(uitlening);
        }

        public void Delete(Uitlening uitlening)
        {
            Uitleningen.Remove(uitlening);
        }

        public void SaveChanges()
        {
            Context.SaveChanges();
        }
    }
}