using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project_Krekelhof.Models.Domain;
using Project_Krekelhof.ViewModels;

namespace Project_Krekelhof.Controllers
{
    public class SpelController : Controller
    {
        private Medewerker medewerker;
        private Gebruiker gebruiker;

        public SpelController(ISpelRepository spelRepository, ICategorieRepository categorieRepository)
        {
            gebruiker = new Gebruiker(null, categorieRepository, null, null, spelRepository);
            medewerker = new Medewerker(null, categorieRepository, null, null, spelRepository);
        }

        // GET: Spel
        public ActionResult Index(String zoekstring = null)
        {
            IEnumerable<Spel> spellen;
            if (!String.IsNullOrEmpty(zoekstring))
            {
                spellen = gebruiker.GeefSpellen(zoekstring);
                ViewBag.Selection = "Alle spellen met " + zoekstring;
            }
            else
            {
                spellen = gebruiker.GeefSpellen(zoekstring);
                ViewBag.Selection = "Alle spellen";
            }
            if (Request.IsAjaxRequest())
                return PartialView("Lijst", new SpelIndexViewModel(spellen));

            return View(new SpelIndexViewModel(spellen));
        }
    }
}