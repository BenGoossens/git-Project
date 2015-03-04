using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Project_Krekelhof.Models.Domain;

namespace Project_Krekelhof.Models.DAL
{
    public class KrekelschoolInitializer : DropCreateDatabaseAlways<KrekelschoolContext>
    {
        protected override void Seed(KrekelschoolContext context)
        {
      //      Leerling lln1 = new Leerling { FamilieNaam = "Wouters", Voornaam = "Koen", Uitleningen = 5Id = 1 };

            Categorie cat = new Categorie { Id = 1, Naam = "Thriller" };
            Categorie cat2 = new Categorie { Id = 2, Naam = "Horror" };
            Categorie[] categorieen = (new Categorie[] { cat, cat2 });
            context.Categorieen.AddRange(categorieen);
            context.SaveChanges();


            
        }


    }
}