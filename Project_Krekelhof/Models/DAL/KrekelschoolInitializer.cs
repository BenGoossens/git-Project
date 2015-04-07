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
                Categorie c1 = new Categorie(1, "gevoelens: verlegen, blij, opgewonden, trots,….");
                Categorie c2 = new Categorie(2, "ziekenhuisverblijf");
                Categorie c3 = new Categorie(3, "ik en mijn knuffel");
                Categorie c4 = new Categorie(4, "haast hebben, tijd nemen");
                Categorie c5 = new Categorie(5, "liedjes");
                Categorie c6 = new Categorie(6, "verhaal");
                Categorie c7 = new Categorie(7, "film");
                Categorie c8 = new Categorie(8, "film & liedjes");
                Categorie c9 = new Categorie(9, "kids tegen grote mensen");
                Categorie c10 = new Categorie(10, "kleuren");
                Categorie c11 = new Categorie(11, "dieren");
                Categorie c12 = new Categorie(12, "");

                Boek b1 = new Boek(1, "Bravo klein visje", "", true, "Guido van Genechten", "", "Van In", "3", c1);
                Boek b2 = new Boek(2, "Mejuffer Muis in het ziekenhuis", "", false, "Elle van Lieshout, Erik van Os en Marije Tolman", "", "Van In", "5", c2);
                Boek b3 = new Boek(3, "Mijn dikste vriend", "Nederlands - Turks!", true, "Christine Sterkens", "", "Herkes", "3", c3);
                Boek b4 = new Boek(4, "Millie Duizendvoet", "", false, "Stijn Moekaars en Frank Daenen", "", "De Eenhoorn	haast hebben, tijd nemen", "4 +", c4);

                context.Boeken.Add(b1);
                context.Boeken.Add(b2);
                context.Boeken.Add(b3);
                context.Boeken.Add(b4);
                context.SaveChanges();

                Cd cd1 = new Cd(1, "hits voor Kids", "liedjes voor kinderen", true, "tamtam", c5);
                Cd cd2 = new Cd(2, "vakantiehits", "", true, "K3", c5);
                Cd cd3 = new Cd(3, "stand by me", "", true, "timon en pumbaa", c5);
			    Cd cd4 = new Cd(4, "rikki wordt grote broer", "", true, "luister je mee 1", c6);

                context.Cds.Add(cd1);
                context.Cds.Add(cd2);
                context.Cds.Add(cd3);
                context.Cds.Add(cd4);
                context.SaveChanges();

                Dvd dvd1 = new Dvd(1, "Plop", "kabouterfeest", true, "studio100", c7);
                Dvd dvd2 = new Dvd(2, "de kleine zeemeermin", "sprookjes", true, "Disney", c7);
                Dvd dvd3 = new Dvd(3, "happy never after 2", "", true, "Steven E. Gordon & Boyd Kirkland", c6);
                Dvd dvd4 = new Dvd(4, "de wielen van de bus", "de drie scheepjes", true, "Timothy Armstrong", c8);

                context.Dvds.Add(dvd1);
                context.Dvds.Add(dvd2);
                context.Dvds.Add(dvd3);
                context.Dvds.Add(dvd4);
                context.SaveChanges();

                Spel spel1 = new Spel(1, "beterweter", "", true, "university games", "8+", c9);
                Spel spel2 = new Spel(1, "bonte ballonnen", "", true, "ravensburger", "3-5", c10);
                Spel spel3 = new Spel(1, "de sterke man", "", true, "jumbo", "5+", c11);
                Spel spel4 = new Spel(1, "domino", "", true, "", "", c12);

                context.Spellen.Add(spel1);
                context.Spellen.Add(spel2);
                context.Spellen.Add(spel3);
                context.Spellen.Add(spel4);
                context.SaveChanges();

                Leerling lln1 = new Leerling(1, "Tuana","Agacseven","J. Verdegemstraat",72,"","3KA");
                Leerling lln2 = new Leerling(2, "Zilyan", "Kadirova", "Jean Bethunestraat", 52, "asi.kemal@live.nl", "2KC");
                Leerling lln3 = new Leerling(3, "Robin", "Coppens", "Banierstraat", 29, "", "1KA");
                Leerling lln4 = new Leerling(4, "Iclal", "Dalgic", "Klinkkouterstraat", 33, "aranhida-izzy@hotmail.com", "1KB");

                context.Leerlingen.Add(lln1);
                context.Leerlingen.Add(lln2);
                context.Leerlingen.Add(lln3);
                context.Leerlingen.Add(lln4);
                context.SaveChanges();

                Uitlening u1 = new Uitlening(1, false, new DateTime(2015, 04, 07), new DateTime(2015, 04, 22), spel1, lln1);
                //Uitlening u2 = new Uitlening(2, b1, lln3, new DateTime(2015, 04, 22));
                //Uitlening u3 = new Uitlening(3, dvd1, lln2, new DateTime(2015, 04, 18));
                //Uitlening u4 = new Uitlening(4, cd1, lln4, new DateTime(2015, 05, 01));

                context.Uitleningen.Add(u1);
                //context.Uitleningen.Add(u2);
                //context.Uitleningen.Add(u3);
                //context.Uitleningen.Add(u4);
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