using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project_Krekelhof.Models.DAL;
using Project_Krekelhof.Models.Domain;
using Project_Krekelhof.ViewModels;

namespace Project_Krekelhof.Controllers
{
    public class LeerlingController : Controller
    {
        private ILeerlingRepository leerlingRepository;
        //private IUitleningRepository UitleningRepository;

        private Medewerker medewerker;
        private Gebruiker gebruiker;

        public LeerlingController(ILeerlingRepository leerlingRepository)
        {
            gebruiker = new Gebruiker(null, null, null, null, null, leerlingRepository);
            medewerker = new Medewerker(null, null, null, null, null, leerlingRepository);
            this.leerlingRepository = leerlingRepository;
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

        [HttpGet]
        public ActionResult Create()
        {
            Leerling leerling = new Leerling();
            ViewBag.Title = "Leerling toevoegen";
            return View(new LeerlingViewModel(leerling));
        }

        [HttpPost]
        public ActionResult Create(LeerlingViewModel lvm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Leerling leerling = new Leerling();
                    MapToLeerling(lvm, leerling);
                    leerlingRepository.Add(leerling);
                    leerlingRepository.SaveChanges();
                    TempData["Message"] = String.Format("{0} werd gecreëerd.", leerling.Voornaam);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            return View(lvm);
        }

        private void MapToLeerling(LeerlingViewModel lvm, Leerling leerling)
        {
            leerling.Id = lvm.Id;
            leerling.Voornaam = lvm.Voornaam;
            leerling.Familienaam = lvm.Familienaam;
            leerling.Straat = lvm.Straat;
            leerling.Huisnummer = lvm.Huisnummer;
            leerling.Email = lvm.Email;
            leerling.Klas = lvm.Klas;
        }
    }
}