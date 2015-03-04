using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Project_Krekelhof.Models.DAL;
using Project_Krekelhof.Models.Domain;

namespace Project_Krekelhof
{
    public class Program
    {
        private static IEnumerable<Categorie> categories;
        private static Categorie categorie;

        private static void Main(string[] args)
        {
            KrekelschoolContext context = new KrekelschoolContext();

            categories = context.Categorieen.ToList();
            Console.WriteLine("Database aangemaakt");
            //      context.Database.Log = Console.Write;

            #region "Linq to entities"

            ReadDbContext(context);

            #endregion

            Console.ReadKey();
        }

        private static void ReadDbContext(KrekelschoolContext context)
        {
            Console.WriteLine("\n---Opvragen alle brouwers---");
            categories = from c in context.Categorieen
                       orderby c.Naam
                       select c;
            //OF
            // brouwers = context.Brouwers.OrderBy(b => b.Naam);
            foreach (Categorie br in categories)
                Console.WriteLine(br.Naam);
        }
    }
}