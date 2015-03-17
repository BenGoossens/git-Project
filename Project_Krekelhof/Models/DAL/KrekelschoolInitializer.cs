using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using Project_Krekelhof.Models.Domain;

namespace Project_Krekelhof.Models.DAL
{
    public class KrekelschoolInitializer : DropCreateDatabaseAlways<KrekelschoolContext>
    {
        protected override void Seed(KrekelschoolContext context)
        {
            //database aanmaken?
            //new KrekelschoolContext().Database.Initialize(true);

            try
            {
                Categorie cat = new Categorie { Id = 1, Naam = "Thriller" };
                Categorie cat2 = new Categorie { Id = 2, Naam = "Horror" };
                Categorie[] categorieen = (new Categorie[] { cat, cat2 });
                context.Categorieen.AddRange(categorieen);
                

                Boek boek1 = new Boek(1, "boek1", "dit is een boek", true, "bla", "123456789111", "hogent", cat);

                Uitlening uitlening1 = new Uitlening(1, new DateTime(2015, 3, 22), boek1);
                context.Uitleningen.Add(uitlening1);

                context.SaveChanges();

            }
            catch (DbEntityValidationException e)
            {
                string s = "Fout creatie database ";
                foreach (var eve in e.EntityValidationErrors)
                {
                    s += String.Format("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                         eve.Entry.Entity.GetType().Name, eve.Entry.GetValidationResult());
                    foreach (var ve in eve.ValidationErrors)
                    {
                        s += String.Format("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw new Exception(s);
            }
        }
    }
}