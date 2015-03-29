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
    public class BoekController : Controller
    {

        private Gebruiker gebruiker;
        private Medewerker medewerker;

        public BoekController(IBoekRepository boekRepository, ICategorieRepository categorieRepository)
        {
            gebruiker = new Gebruiker(boekRepository, categorieRepository);
            medewerker = new Medewerker(boekRepository, categorieRepository);
        }

        public ActionResult Index(String zoekstring = null)
        {
            IEnumerable<Boek> boeken;
            if (!String.IsNullOrEmpty(zoekstring))
            {
                boeken = gebruiker.GeefBoeken(zoekstring);
                ViewBag.Selection = "Alle boeken met " + zoekstring;
            }
            else
            {
                boeken = gebruiker.GeefBoeken(zoekstring);
                ViewBag.Selection = "Alle boeken";
            }
            if (Request.IsAjaxRequest())
                return PartialView("Lijst", new BoekIndexViewModel(boeken));

            return View(new BoekIndexViewModel(boeken));
        }

        public ActionResult Create()
        {
            return View(new BoekCreateViewModel(medewerker.GeefCategorieën(), new Boek()));
        }

        [HttpPost]
        public ActionResult Create(BoekViewModel boek)
        {
            if (ModelState.IsValid)
            {
                medewerker.AddBoek(boek);
                TempData["Info"] = "Het boek werd toegevoegd...";
                return RedirectToAction("Index");
            }
            return RedirectToAction("Create");
        }
    }
}