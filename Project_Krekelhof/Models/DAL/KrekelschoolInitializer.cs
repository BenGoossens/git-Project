using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Project_Krekelhof.Models.DAL
{
    public class KrekelschoolInitializer : DropCreateDatabaseAlways<KrekelschoolContext>
    {
        protected override void Seed(KrekelschoolContext context)
        {
           //base.Seed(context);
            Leerling lln1 = new Leerling("Wouter", "Koen", 1);

            Leerling lln2 = new Leerling("Beke", "Wouter", 2);

            context.leerlingen.Add(lln1);
            context.leerlingen.Add(lln2);
            context.SaveChanges();


        }


    }
}