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
                Leerling lln1 = new Leerling(1, "Tuana","Agacseven","J. Verdegemstraat",72,"","3KA");
                Leerling lln2 = new Leerling(2, "Zilyan", "Kadirova", "Jean Bethunestraat", 52, "asi.kemal@live.nl", "2KC");
                Leerling lln3 = new Leerling(3, "Robin", "Coppens", "Banierstraat", 29, "", "1KA");
                Leerling lln4 = new Leerling(4, "Iclal", "Dalgic", "Klinkkouterstraat", 33, "aranhida-izzy@hotmail.com", "1KB");


                context.Leerlingen.Add(lln1);
                context.Leerlingen.Add(lln2);
                context.Leerlingen.Add(lln3);
                context.Leerlingen.Add(lln4);
                context.SaveChanges();

                Boek b1 = new Boek(1, "Bravo klein visje", "", true, "Guido van Genechten", "", "Van In", 3);
                Boek b2 = new Boek(2, "Mejuffer Muis in het ziekenhuis", "", true, "Elle van Lieshout, Erik van Os en Marije Tolman", "", "Van In", 5);
                Boek b3 = new Boek(3, "Mijn dikste vriend", "Nederlands - Turks!", true, "Christine Sterkens", "", "Herkes", 3);

                context.Boeken.Add(b1);
                context.Boeken.Add(b2);
                context.Boeken.Add(b3);
                context.SaveChanges();

            }
            catch (DbEntityValidationException e)
            {
                string message = String.Empty;
                foreach (var eve in e.EntityValidationErrors)
                {

                    message +=
                        String.Format("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                                      eve.Entry.Entity.GetType().Name, eve.Entry.GetValidationResult());
                    foreach (var ve in eve.ValidationErrors)
                    {
                        message +=
                      String.Format("- Property: \"{0}\", Error: \"{1}\"",
                          ve.PropertyName, ve.ErrorMessage);
                    }
                }
                throw new ApplicationException("Fout bij aanmaken database " + message);
            }
            context.SaveChanges();
            base.Seed(context);
        }
    }
}