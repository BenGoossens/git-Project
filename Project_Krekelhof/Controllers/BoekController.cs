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
    public class BoekController : Controller
    {

        private Gebruiker gebruiker;
        private Medewerker medewerker;

        private IBoekRepository boekRepository;
        private ICategorieRepository categorieRepository;

        public BoekController(IBoekRepository boekRepository, ICategorieRepository categorieRepository)
        {
            gebruiker = new Gebruiker(boekRepository, categorieRepository, null, null, null, null);
            medewerker = new Medewerker(boekRepository, categorieRepository, null, null, null, null);
            this.boekRepository = boekRepository;
            this.categorieRepository = categorieRepository;
        }

        public ActionResult Index(String zoekstring)
        {
            IEnumerable<Boek> boeken;
            if (!String.IsNullOrEmpty(zoekstring))
            {
                boeken = gebruiker.GeefBoeken(zoekstring);
                ViewBag.Selection = "Alle boeken met '"  + zoekstring + "'";
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

        [HttpGet]
        public ActionResult Create()
        {
            Boek boek = new Boek();
            ViewBag.Title = "Boek toevoegen";
            ViewBag.Categorie = GetCategorieSelectList(boek);
            return View(new BoekViewModel(boek));
        }

        [HttpPost]
        public ActionResult Create(BoekViewModel bvm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Boek boek = new Boek();
                    MapToBoek(bvm, boek);
                    boekRepository.Add(boek);
                    boekRepository.SaveChanges();
                    TempData["Message"] = String.Format("{0} werd gecreëerd.", boek.Naam);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            ViewBag.Categorie = GetCategorieSelectList(bvm.Categorie);
            return View(bvm);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Boek boek = boekRepository.FindById(id);
            if (boek == null)
                return HttpNotFound();
            ViewBag.Categorie = GetCategorieSelectList(boek);
            return View("Create", new BoekViewModel(boek));
        }

        [HttpPost]
        public ActionResult Edit(int id, BoekViewModel bvm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Boek boek = boekRepository.FindById(id);
                    MapToBoek(bvm, boek);
                    boekRepository.SaveChanges();
                    TempData["message"] = String.Format("Boek {0} werd aangepast", boek.Naam);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }
            ViewBag.Categorie = GetCategorieSelectList(bvm.Categorie);
            return View("Create", bvm);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Boek boek = boekRepository.FindById(id);
            if (boek == null)
                return HttpNotFound();
            return View(new BoekViewModel(boek));
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Boek boek = boekRepository.FindById(id);
                if (boek == null)
                    return HttpNotFound();
                boekRepository.Remove(boek);
                boekRepository.SaveChanges();
                TempData["message"] = String.Format("Boek {0} werd verwijderd", boek.Naam);
            }
            catch (Exception ex)
            {
                TempData["error"] = "Verwijderen Boek mislukt. Probeer opnieuw. ";
            }
            return RedirectToAction("Index");
        }

        private void MapToBoek(BoekViewModel bvm, Boek boek)
        {
            boek.Id = bvm.Id;
            boek.Naam = bvm.Naam;
            boek.Omschrijving = bvm.Omschrijving;
            boek.Auteur = bvm.Auteur;
            boek.Uitgeverij = bvm.Uitgeverij;
            boek.Isbn = bvm.Isbn;
            boek.Leeftijd = bvm.Leeftijd;
            boek.Categorie = (String.IsNullOrEmpty(bvm.Categorie) ? null : categorieRepository.FindById(Int32.Parse(bvm.Categorie)));
            boek.Beschikbaar = bvm.Beschikbaar;
        }

        private SelectList GetCategorieSelectList(Boek boek)
        {
            return new SelectList(categorieRepository.FindAll().OrderBy(g => g.Naam),
                "Id", "Naam",
               boek == null || boek.Categorie == null ? "" : boek.Categorie.Naam);
        }

        private SelectList GetCategorieSelectList(string categorie)
        {
            return new SelectList(categorieRepository.FindAll().OrderBy(g => g.Naam),
                "Id", "Naam",
               categorie ?? "");
        }
    }
}