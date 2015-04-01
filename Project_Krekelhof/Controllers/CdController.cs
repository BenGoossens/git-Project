using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project_Krekelhof.Models.Domain;
using Project_Krekelhof.ViewModels;

namespace Project_Krekelhof.Controllers
{
    public class CdController : Controller
    {
        private Medewerker medewerker;
        private Gebruiker gebruiker;

        public CdController(ICdRepository cdRepository, ICategorieRepository categorieRepository)
        {
            gebruiker = new Gebruiker(null, categorieRepository, cdRepository, null, null, null);
            medewerker = new Medewerker(null, categorieRepository, cdRepository, null, null, null);
        }

        // GET: Cd
        public ActionResult Index(String zoekstring = null)
        {
            IEnumerable<Cd> cds;
            if (!String.IsNullOrEmpty(zoekstring))
            {
                cds = gebruiker.GeefCds(zoekstring);
                ViewBag.Selection = "Alle cd's met '" + zoekstring + "'";
            }
            else
            {
                cds = gebruiker.GeefCds(zoekstring);
                ViewBag.Selection = "Alle cd's";
            }
            if (Request.IsAjaxRequest())
                return PartialView("Lijst", new CdIndexViewModel(cds));

            return View(new CdIndexViewModel(cds));
        }
    }
}