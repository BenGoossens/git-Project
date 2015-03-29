using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project_Krekelhof.Models.Domain;
using Project_Krekelhof.ViewModels;

namespace Project_Krekelhof.Controllers
{
    public class DvdController : Controller
    {
        private Gebruiker gebruiker;
        private Medewerker medewerker;

        public DvdController(IDvdRepository dvdRepository, ICategorieRepository categorieRepository)
        {
            gebruiker = new Gebruiker(null, categorieRepository, null, dvdRepository);
            medewerker = new Medewerker(null, categorieRepository, null, dvdRepository);
        }
        // GET: Dvd
        public ActionResult Index(String zoekstring = null)
        {
            IEnumerable<Dvd> dvds;
            if (!String.IsNullOrEmpty(zoekstring))
            {
                dvds = gebruiker.GeefDvds(zoekstring);
                ViewBag.Selection = "Alle dvd's met " + zoekstring;
            }
            else
            {
                dvds = gebruiker.GeefDvds(zoekstring);
                ViewBag.Selection = "Alle dvd's";
            }
            if (Request.IsAjaxRequest())
                return PartialView("Lijst", new DvdIndexViewModel(dvds));

            return View(new DvdIndexViewModel(dvds));
        }
    }
}