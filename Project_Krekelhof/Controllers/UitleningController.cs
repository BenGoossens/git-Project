using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Services.Description;
using Project_Krekelhof.Models.Domain;
using Project_Krekelhof.ViewModels;
namespace Project_Krekelhof.Controllers
{
    public class UitleningController : Controller
    {
        private Gebruiker gebruiker;

        private IUitleningRepository uitleningRepository;
        private IBoekRepository boekRepository;
        private ICdRepository cdRepository;
        private IDvdRepository dvdRepository;
        private ISpelRepository spelRepository;
        private ILeerlingRepository leerlingRepository;

        public UitleningController(Gebruiker gebruiker, IUitleningRepository uitleningRepository, IBoekRepository boekRepository, ICdRepository cdRepository, IDvdRepository dvdRepository, ISpelRepository spelRepository, ILeerlingRepository leerlingRepository)
        {
            this.gebruiker = gebruiker;

            this.uitleningRepository = uitleningRepository;
            this.boekRepository = boekRepository;
            this.cdRepository = cdRepository;
            this.dvdRepository = dvdRepository;
            this.spelRepository = spelRepository;
            this.leerlingRepository = leerlingRepository;
        }
        
        public ActionResult Index(string zoekstring)
        {
            IEnumerable<Uitlening> uitleningen;
            if (!String.IsNullOrEmpty(zoekstring))
            {
                uitleningen = gebruiker.GeefUitleningen(zoekstring);
                ViewBag.Selection = "Alle uitleningen met '" + zoekstring + "'";
            }
            else
            {
                uitleningen = gebruiker.GeefUitleningen(zoekstring);
                ViewBag.Selection = "Alle Uitleningen";
            }
            if (Request.IsAjaxRequest())
                return PartialView("Lijst", new UitleningIndexViewModel(uitleningen));

            return View(new UitleningIndexViewModel(uitleningen));
        }

        //[HttpGet]
        //public ActionResult Create()
        //{
        //    Uitlening uitlening = new Uitlening();
        //    ViewBag.Title = "Uitlening toevoegen";
        //    ViewBag.Categorie = GetCategorieSelectList(uitlening);
        //    return View(new UitleningViewModel(uitlening));
        //}

        //[HttpPost]
        //public ActionResult Create(BoekViewModel bvm)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            Boek boek = new Boek();
        //            MapToBoek(bvm, boek);
        //            boekRepository.Add(boek);
        //            boekRepository.SaveChanges();
        //            TempData["Message"] = String.Format("{0} werd gecreëerd.", boek.Naam);
        //            return RedirectToAction("Index");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        ModelState.AddModelError("", ex.Message);
        //    }
        //    ViewBag.Categorie = GetCategorieSelectList(bvm.Categorie);
        //    return View(bvm);
        //}

        [HttpGet]
        public ActionResult Delete(int id)
        {
            Uitlening uitlening = uitleningRepository.FindById(id);
            if (uitlening == null)
                return HttpNotFound();
            return View(new UitleningViewModel(uitlening));
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            try
            {
                Uitlening uitlening = uitleningRepository.FindById(id);
                if (uitlening == null)
                    return HttpNotFound();
                uitleningRepository.Delete(uitlening);
                uitleningRepository.SaveChanges();
                TempData["message"] = String.Format("Uitlening {0} werd verwijderd", uitlening.Id);
            }
            catch (Exception ex)
            {
                TempData["error"] = "Verwijderen uitlening mislukt. Probeer opnieuw. ";
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Verlengen(int id)
        {
            Uitlening uitlening = uitleningRepository.FindById(id);
            if (uitlening == null)
                return HttpNotFound();
            //uitlening.EindDatum = uitlening.EindDatum.AddDays(7);
            return View("Verlengen", new UitleningViewModel(uitlening));
        }

        [HttpPost, ActionName("Verlengen")]
        public ActionResult VerlengenComfirmed(int id, UitleningViewModel uvm)
        {
            try
            {
                Uitlening uitlening = uitleningRepository.FindById(id);
                if (uitlening == null)
                    return HttpNotFound();
                MapToUitlening(uvm, uitlening);
                uitleningRepository.Add(uitlening);
                uitleningRepository.SaveChanges();
                TempData["message"] = String.Format("Uitlening {0} werd verlengd", uitlening.Id);
            }
            catch (Exception ex)
            {
                TempData["error"] = "Verwijderen uitlening mislukt. Probeer opnieuw. ";
            }
            return RedirectToAction("Index");
        }

        private void MapToUitlening(UitleningViewModel uvm, Uitlening uitlening)
        {
            uitlening.Id = uvm.Id;
            uitlening.EindDatum = uvm.EindeUitlening.AddDays(7);
            uitlening.BeginDatumUitlening = uvm.StartUitlening;
            uitlening.IsTerug = uvm.IsTerug;
           //// uitlening.Leerling = (String.IsNullOrEmpty(uvm.LeerlingVoornaam) ? null : uitleningRepository.FindById(Int32.Parse(uvm.LeerlingVoornaam)));
           // uitlening.Isbn = uvm.Isbn;
           // uitlening.Leeftijd = uvm.Leeftijd;
           // uitlening.Categorie = (String.IsNullOrEmpty(uvm.Categorie) ? null : categorieRepository.FindById(Int32.Parse(uvm.Categorie)));
           // uitlening.Beschikbaar = uvm.Beschikbaar;
        }



    }
}































//private IUitleningenRepository repos;

//        public UitleningController(KrekelSchoolContext context)
//        {
//            repos = new UitleningRepository(context);
//        }
//        public Collection<Uitlening> Uitleningen
//        {
//            get
//            {
//                throw new System.NotImplementedException();
//            }
//            set
//            {
//            }
//        }

//        public void EditUitlening(Uitlening uitlening)
//        {
//            // Remove add = edit?
//            // removeUitlening(uitlening);
           
//        }

//        public void RemoveUitlening(Uitlening uitlening)
//        {
//            repos.Delete(uitlening);
//        }

//        public Uitlening GetUitlening()
//        {
//            throw new System.NotImplementedException();
//        }

//        public Collection<Uitlening> GetUitleningen()
//        {
//            throw new System.NotImplementedException();
//        }

//        public void CheckOutUitlening(Uitlening uitlening)
//        {
//            // uitleningeinddatum < huidigeDatum => Boete 
//            // schade Claim => Boete (laag, hoge claim)
//            // Item schade op geclaimde schade.
//            // UitleningeindDatum > huidige datum => No problem check that shit out
//            // beschikbaar van item op true
//            // 
//            throw new System.NotImplementedException();
//        }

//        public void AddUitlening(Lener leerling, DateTime uitlendatum, Collection<Item> items)
//        {
//            //Kinderboeken 1 week , andere 2 weken (Kijken op leeftijd)
//            //item beschikbaar false 
            
//            throw new System.NotImplementedException();
//        }