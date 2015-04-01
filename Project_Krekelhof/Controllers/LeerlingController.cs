using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project_Krekelhof.Models.Domain;
using Project_Krekelhof.ViewModels;

namespace Project_Krekelhof.Controllers
{
    public class LeerlingController : Controller
    {
        private ILeerlingRepository LeerlingRepository;
        //private IUitleningRepository UitleningRepository;

        private Medewerker medewerker;
        private Gebruiker gebruiker;

        public LeerlingController(ILeerlingRepository leerlingRepository)
        {
            gebruiker = new Gebruiker(null, null, null, null, null, leerlingRepository);
            medewerker = new Medewerker(null, null, null, null, null, leerlingRepository);
        }

        // GET: Leerling
        public ActionResult Index(String zoekstring = null)
        {
            IEnumerable<Leerling> leerlingen;
            if (!String.IsNullOrEmpty(zoekstring))
            {
                leerlingen = gebruiker.GeefLeerlingen(zoekstring);
                ViewBag.Selection = "Alle leerlingen met '" + zoekstring + "'";
            }
            else
            {
                leerlingen = gebruiker.GeefLeerlingen(zoekstring);
                ViewBag.Selection = "Alle leerlingen";
            }
            if (Request.IsAjaxRequest())
                return PartialView("Lijst", new LeerlingIndexViewModel(leerlingen));

            return View(new LeerlingIndexViewModel(leerlingen));
        }
    }
}