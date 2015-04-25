using System.Data.Entity;
using System.Linq;
using Project_Krekelhof.Models.Domain;

namespace Project_Krekelhof.Models.DAL
{
    public class VerteltasRepository: IVerteltasRepository
    {
        private KrekelschoolContext Context;
        private DbSet<Verteltas> Verteltassen;

           public VerteltasRepository(KrekelschoolContext context)
        {
            Context = context;
            Verteltassen = Context.Verteltassen;
        }


        public Verteltas FindById(int id)
        {
            return Verteltassen.Find(id);
        }
        
        public IQueryable<Verteltas> FindAll()
        {
            return Verteltassen;
        }

        public IQueryable<Uitlening> Find(string zoekString)
        {
            return null;
        }

        public void Add(Verteltas verteltas)
        {
            Verteltassen.Add(verteltas);
        }

        public void Delete(Verteltas verteltas)
        {
            Verteltassen.Remove(verteltas);
        }

        public void SaveChanges()
        {
            Context.SaveChanges();
        }
    }
    }
