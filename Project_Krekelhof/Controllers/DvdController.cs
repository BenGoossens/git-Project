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

        private IDvdRepository dvdRepository;
        private ICategorieRepository categorieRepository;

        public DvdController(IDvdRepository dvdRepository, ICategorieRepository categorieRepository)
        {
            gebruiker = new Gebruiker(null, categorieRepository, null, dvdRepository, null, null);
            medewerker = new Medewerker(null, categorieRepository, null, dvdRepository, null, null);

            this.dvdRepository = dvdRepository;
            this.categorieRepository = categorieRepository;
        }
        // GET: Dvd
        public ActionResult Index(String zoekstring = null)
        {
            IEnumerable<Dvd> dvds;
            if (!String.IsNullOrEmpty(zoekstring))
            {
                dvds = gebruiker.GeefDvds(zoekstring);
                ViewBag.Selection = "Alle dvd's met '" + zoekstring + "'";
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

        [HttpGet]
        public ActionResult Create()
        {
            Dvd dvd = new Dvd();
            ViewBag.Title = "Dvd toevoegen";
            ViewBag.Categorie = GetCategorieSelectList(dvd);
            return View(new DvdViewModel(dvd));
        }

        [HttpPost]
        public ActionResult Create(DvdViewModel dvm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Dvd dvd = new Dvd();
                    MapToDvd(dvm, dvd);
                    dvdRepository.Add(dvd);
                    dvdRepository.SaveChanges();
                    TempData["Message"] = String.Format("{0} werd gecreëerd.", dvd.Naam);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            ViewBag.Categorie = GetCategorieSelectList(dvm.Categorie);
            return View(dvm);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Dvd dvd = dvdRepository.FindById(id);
            if (dvd == null)
                return HttpNotFound();
            ViewBag.Categorie = GetCategorieSelectList(dvd);
            return View("Create", new DvdViewModel(dvd));
        }

        [HttpPost]
        public ActionResult Edit(int id, DvdViewModel dvm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Dvd dvd = dvdRepository.FindById(id);
                    MapToDvd(dvm, dvd);
                    dvdRepository.SaveChanges();
                    TempData["message"] = String.Format("Dvd {0} werd aangepast", dvd.Naam);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }
            ViewBag.Categorie = GetCategorieSelectList(dvm.Categorie);
            return View("Create", dvm);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Dvd dvd = dvdRepository.FindById(id);
            if (dvd == null)
                return HttpNotFound();
            return View(new DvdViewModel(dvd));
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Dvd dvd = dvdRepository.FindById(id);
                if (dvd == null)
                    return HttpNotFound();
                dvdRepository.Remove(dvd);
                dvdRepository.SaveChanges();
                TempData["message"] = String.Format("Dvd {0} werd verwijderd", dvd.Naam);
            }
            catch (Exception ex)
            {
                TempData["error"] = "Verwijderen Dvd mislukt. Probeer opnieuw. ";
            }
            return RedirectToAction("Index");
        }

        private void MapToDvd(DvdViewModel dvm, Dvd dvd)
        {
            dvd.Id = dvm.Id;
            dvd.Naam = dvm.Naam;
            dvd.Omschrijving = dvm.Omschrijving;
            dvd.Regisseur = dvm.Regisseur;
            dvd.Categorie = (String.IsNullOrEmpty(dvm.Categorie) ? null : categorieRepository.FindById(Int32.Parse(dvm.Categorie)));
            dvd.Beschikbaar = dvm.Beschikbaar;
        }

        private SelectList GetCategorieSelectList(Dvd dvd)
        {
            return new SelectList(categorieRepository.FindAll().OrderBy(g => g.Naam),
                "Id", "Naam",
               dvd == null || dvd.Categorie == null ? "" : dvd.Categorie.Naam);
        }

        private SelectList GetCategorieSelectList(string categorie)
        {
            return new SelectList(categorieRepository.FindAll().OrderBy(g => g.Naam),
                "Id", "Naam",
               categorie ?? "");
        }
    }
}