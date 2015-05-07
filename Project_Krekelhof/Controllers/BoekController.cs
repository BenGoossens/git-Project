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

        private IUitleningRepository uitleningRepository;
        private ILeerlingRepository leerlingRepository;

        public BoekController(IBoekRepository boekRepository, ICategorieRepository categorieRepository, IUitleningRepository uitleningRepository, ILeerlingRepository leerlingRepository)
        {
            gebruiker = new Gebruiker(boekRepository, categorieRepository, null, null, null, null, null);
            medewerker = new Medewerker(boekRepository, categorieRepository, null, null, null, null, null);

            this.boekRepository = boekRepository;
            this.categorieRepository = categorieRepository;
            this.uitleningRepository = uitleningRepository;
            this.leerlingRepository = leerlingRepository;
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

        [HttpGet]
        public ActionResult CreateUitlening()
        {
            Uitlening uitlening = new Uitlening();
            ViewBag.Title = "Uitlening toevoegen";
            ViewBag.Leerling = GetLeerlingSelectList(uitlening);
            return View(new UitleningViewModel(uitlening));
        }

        [HttpPost, ActionName("Uitlenen")]
        public ActionResult CreateUitlening(UitleningViewModel uvm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Uitlening uitlening = new Uitlening();
                    MapToUitlening(uvm, uitlening);
                    uitleningRepository.Add(uitlening);
                    uitleningRepository.SaveChanges();
                    TempData["Message"] = String.Format("{0} werd gecreëerd.", uitlening.Id);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            //ViewBag.Item = GetItemSelectList(uvm.Item);
            ViewBag.Leerling = GetLeerlingSelectList(uvm.volledigeNaam);
            return View(uvm);
        }

        private void MapToUitlening(UitleningViewModel uvm, Uitlening uitlening)
        {
            uitlening.Id = uvm.Id;
            uitlening.EindDatum = uvm.EindeUitlening.AddDays(7);
            uitlening.BeginDatumUitlening = uvm.StartUitlening;
            uitlening.IsTerug = uvm.IsTerug;
            //uitlening.Item = (String.IsNullOrEmpty(uvm.Item)
            //    ? null
            //    : itemRepository.FindById(Int32.Parse(uvm.Item)));
            uitlening.Leerling = (String.IsNullOrEmpty(uvm.volledigeNaam)
                ? null
                : leerlingRepository.FindById(Int32.Parse(uvm.volledigeNaam)));
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

        private SelectList GetLeerlingSelectList(Uitlening uitlening)
        {
            return new SelectList(leerlingRepository.FindAll().OrderBy(g => g.Voornaam),
                "Id", "volledigeNaam",
               uitlening == null || uitlening.Leerling == null ? "" : uitlening.Leerling.ToString());
        }

        private SelectList GetLeerlingSelectList(string leerling)
        {
            return new SelectList(leerlingRepository.FindAll().OrderBy(g => g.Voornaam),
                "Id", "volledigeNaam",
               leerling ?? "");
        }

    }

    

}