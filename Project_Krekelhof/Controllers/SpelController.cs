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

        private ISpelRepository spelRepository;
        private ICategorieRepository categorieRepository;

        public SpelController(ISpelRepository spelRepository, ICategorieRepository categorieRepository)
        {
            gebruiker = new Gebruiker(null, categorieRepository, null, null, spelRepository, null);
            medewerker = new Medewerker(null, categorieRepository, null, null, spelRepository, null);

            this.spelRepository = spelRepository;
            this.categorieRepository = categorieRepository;
        }

        // GET: Spel
        public ActionResult Index(String zoekstring = null)
        {
            IEnumerable<Spel> spellen;
            if (!String.IsNullOrEmpty(zoekstring))
            {
                spellen = gebruiker.GeefSpellen(zoekstring);
                ViewBag.Selection = "Alle spellen met '" + zoekstring + "'";
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

        [HttpGet]
        public ActionResult Create()
        {
            Spel spel = new Spel();
            ViewBag.Title = "Spel toevoegen";
            ViewBag.Categorie = GetCategorieSelectList(spel);
            return View(new SpelViewModel(spel));
        }

        [HttpPost]
        public ActionResult Create(SpelViewModel svm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Spel spel = new Spel();
                    MapToSpel(svm, spel);
                    spelRepository.Add(spel);
                    spelRepository.SaveChanges();
                    TempData["Message"] = String.Format("{0} werd gecreëerd.", spel.Naam);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            ViewBag.Categorie = GetCategorieSelectList(svm.Categorie);
            return View(svm);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Spel spel = spelRepository.FindById(id);
            if (spel == null)
                return HttpNotFound();
            ViewBag.Categorie = GetCategorieSelectList(spel);
            return View("Create", new SpelViewModel(spel));
        }

        [HttpPost]
        public ActionResult Edit(int id, SpelViewModel svm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Spel spel = spelRepository.FindById(id);
                    MapToSpel(svm, spel);
                    spelRepository.SaveChanges();
                    TempData["message"] = String.Format("Dvd {0} werd aangepast", spel.Naam);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }
            ViewBag.Categorie = GetCategorieSelectList(svm.Categorie);
            return View("Create", svm);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Spel spel = spelRepository.FindById(id);
            if (spel == null)
                return HttpNotFound();
            return View(new SpelViewModel(spel));
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Spel spel = spelRepository.FindById(id);
                if (spel == null)
                    return HttpNotFound();
                spelRepository.Remove(spel);
                spelRepository.SaveChanges();
                TempData["message"] = String.Format("Spel {0} werd verwijderd", spel.Naam);
            }
            catch (Exception ex)
            {
                TempData["error"] = "Verwijderen Spel mislukt. Probeer opnieuw. ";
            }
            return RedirectToAction("Index");
        }

        private void MapToSpel(SpelViewModel svm, Spel spel)
        {
            spel.Id = svm.Id;
            spel.Naam = svm.Naam;
            spel.Omschrijving = svm.Omschrijving;
            spel.Uitgeverij = svm.Uitgeverij;
            spel.Leeftijd = svm.Leeftijd;
            spel.Categorie = (String.IsNullOrEmpty(svm.Categorie) ? null : categorieRepository.FindById(Int32.Parse(svm.Categorie)));
            spel.Beschikbaar = svm.Beschikbaar;
        }

        private SelectList GetCategorieSelectList(Spel spel)
        {
            return new SelectList(categorieRepository.FindAll().OrderBy(g => g.Naam),
                "Id", "Naam",
               spel == null || spel.Categorie == null ? "" : spel.Categorie.Naam);
        }

        private SelectList GetCategorieSelectList(string categorie)
        {
            return new SelectList(categorieRepository.FindAll().OrderBy(g => g.Naam),
                "Id", "Naam",
               categorie ?? "");
        }
    }
}