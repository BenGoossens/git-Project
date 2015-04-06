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

        private ICdRepository cdRepository;
        private ICategorieRepository categorieRepository;

        public CdController(ICdRepository cdRepository, ICategorieRepository categorieRepository)
        {
            gebruiker = new Gebruiker(null, categorieRepository, cdRepository, null, null, null);
            medewerker = new Medewerker(null, categorieRepository, cdRepository, null, null, null);

            this.cdRepository = cdRepository;
            this.categorieRepository = categorieRepository;
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

        [HttpGet]
        public ActionResult Create()
        {
            Cd cd = new Cd();
            ViewBag.Title = "Cd toevoegen";
            ViewBag.Categorie = GetCategorieSelectList(cd);
            return View(new CdViewModel(cd));
        }

        [HttpPost]
        public ActionResult Create(CdViewModel cvm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Cd cd = new Cd();
                    MapToCd(cvm, cd);
                    cdRepository.Add(cd);
                    cdRepository.SaveChanges();
                    TempData["Message"] = String.Format("{0} werd gecreëerd.", cd.Naam);
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
            }
            ViewBag.Categorie = GetCategorieSelectList(cvm.Categorie);
            return View(cvm);
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            Cd cd = cdRepository.FindById(id);
            if (cd == null)
                return HttpNotFound();
            ViewBag.Postcode = GetCategorieSelectList(cd);
            return View("Create", new CdViewModel(cd));
        }

        [HttpPost]
        public ActionResult Edit(int id, CdViewModel cvm)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Cd cd = cdRepository.FindById(id);
                    MapToCd(cvm, cd);
                    cdRepository.SaveChanges();
                    TempData["message"] = String.Format("Cd {0} werd aangepast", cd.Naam);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                }
            }
            ViewBag.Categorie = GetCategorieSelectList(cvm.Categorie);
            return View("Create", cvm);
        }

        public ActionResult Delete(int id)
        {
            Cd cd = cdRepository.FindById(id);
            if (cd == null)
                return HttpNotFound();
            return View(new CdViewModel(cd));
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Cd cd = cdRepository.FindById(id);
                if (cd == null)
                    return HttpNotFound();
                cdRepository.Remove(cd);
                cdRepository.SaveChanges();
                TempData["message"] = String.Format("Cd {0} werd verwijderd", cd.Naam);
            }
            catch (Exception ex)
            {
                TempData["error"] = "Verwijderen Cd mislukt. Probeer opnieuw. ";
            }
            return RedirectToAction("Index");
        }
        
        private void MapToCd(CdViewModel cvm, Cd cd)
        {
            cd.Id = cvm.Id;
            cd.Naam = cvm.Naam;
            cd.Omschrijving = cvm.Omschrijving;
            cd.ArtiestNaam = cvm.ArtiestNaam;
            cd.Categorie = (String.IsNullOrEmpty(cvm.Categorie) ? null : categorieRepository.FindById(Int32.Parse(cvm.Categorie)));
            cd.Beschikbaar = cvm.Beschikbaar;
        }

        private SelectList GetCategorieSelectList(Cd cd)
        {
            return new SelectList(categorieRepository.FindAll().OrderBy(g => g.Naam),
                "Id", "Naam",
               cd == null || cd.Categorie == null ? "" : cd.Categorie.Naam);
        }

        private SelectList GetCategorieSelectList(string categorie)
        {
            return new SelectList(categorieRepository.FindAll().OrderBy(g => g.Naam),
                "Id", "Naam",
               categorie ?? "");
        }
    }
}