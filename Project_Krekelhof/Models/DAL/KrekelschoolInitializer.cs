using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            try
            {
                Categorie cat1 = new Categorie(1, "horror");
                context.Categorieen.Add(cat1);
                context.SaveChanges();

                context.Boeken.Add(new Boek(1, "boek1", "dit is een boek", true, "auteur", "ISBN", "uitgeverij", cat1));
                context.SaveChanges();
                context.Items.Add(new Boek(2, "boek2", "dit is een 2de boek", false, "auteur", "ISBN", "uitgeverij", new Categorie(2, "Thriller")));
                context.SaveChanges();

                Item dvd1 = new Dvd(1, "cd", "dit is een cd", true, "regisseur", cat1);
                context.Items.Add(dvd1);
                context.SaveChanges();

                Uitlening uitlening1 = new Uitlening(1, new DateTime(2015, 4, 17), dvd1);
                context.Uitleningen.Add(uitlening1);
                context.SaveChanges();

                Leerling lln1 = new Leerling("Ben", "Goossens", "Straat", 2, "Aalst", 9300, "nummer", new Collection<Uitlening>());
                context.Leerlingen.Add(lln1);
                context.SaveChanges();
            }
            catch (Exception e)
            {

                throw (e);
            }
            context.SaveChanges();
            base.Seed(context);
        }
    }
}