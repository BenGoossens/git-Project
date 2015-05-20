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
        private IItemRepository itemRepository;
        private ILeerlingRepository leerlingRepository;

        public UitleningController(Gebruiker gebruiker, IUitleningRepository uitleningRepository, IItemRepository itemRepository, ILeerlingRepository leerlingRepository)
        {
            this.gebruiker = gebruiker;

            this.uitleningRepository = uitleningRepository;
            this.itemRepository = itemRepository;
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

        [HttpGet]
        public ActionResult Create()
        {
            Uitlening uitlening = new Uitlening();
            ViewBag.Title = "Uitlening toevoegen";
            ViewBag.Item = GetItemSelectList(uitlening);
            ViewBag.Leerling = GetLeerlingSelectList(uitlening);
            return View(new UitleningViewModel(uitlening));
        }

        [HttpPost]
        public ActionResult Create(UitleningViewModel uvm)
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
            ViewBag.Item = GetItemSelectList(uvm.Item);
            ViewBag.Leerling = GetLeerlingSelectList(uvm.volledigeNaam);
            return View(uvm);
        }

        [HttpGet]
        public ActionResult Verlengen(int id)
        {
            Uitlening uitlening = uitleningRepository.FindById(id);
            if (uitlening == null)
                return HttpNotFound();
            ViewBag.Item = GetItemSelectList(uitlening);
            ViewBag.Leerling = GetLeerlingSelectList(uitlening);
            return View(new UitleningViewModel(uitlening));
        }

        [HttpPost, ActionName("Verlengen")]
        public ActionResult VerlengenComfirmed(int id, UitleningViewModel uvm)
        {
            try
            {
                //Uitlening uitlening = uitleningRepository.FindById(id);
                //if (uitlening == null)
                //    return HttpNotFound();
                //MapToUitlening(uvm, uitlening);
                //uitleningRepository.Add(uitlening);
                //uitleningRepository.SaveChanges();
                //TempData["message"] = String.Format("Uitlening {0} werd verlengd", uitlening.Id);

                Uitlening uitlening = uitleningRepository.FindById(id);
                MapToUitlening(uvm, uitlening);
                uitleningRepository.SaveChanges();
                TempData["message"] = String.Format("Uitlening {0} werd verlengd", uitlening.Id);
                return RedirectToAction("Index");

                //Boek boek = boekRepository.FindById(id);
                //MapToBoek(bvm, boek);
                //boekRepository.SaveChanges();
                //TempData["message"] = String.Format("Boek {0} werd aangepast", boek.Naam);
                //return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["error"] = "Verwijderen uitlening mislukt. Probeer opnieuw. ";
            }
            ViewBag.Item = GetItemSelectList(uvm.Item);
            ViewBag.Leerling = GetLeerlingSelectList(uvm.volledigeNaam);
            return View(uvm);
        }

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

        private void MapToUitlening(UitleningViewModel uvm, Uitlening uitlening)
        {
            uitlening.Id = uvm.Id;
            uitlening.EindDatum = uvm.EindeUitlening;
            uitlening.BeginDatumUitlening = uvm.StartUitlening;
            uitlening.IsTerug = uvm.IsTerug;
            uitlening.Item = (String.IsNullOrEmpty(uvm.Item)
                ? null
                : itemRepository.FindById(Int32.Parse(uvm.Item)));
            uitlening.Leerling = (String.IsNullOrEmpty(uvm.volledigeNaam)
                ? null
                : leerlingRepository.FindById(Int32.Parse(uvm.volledigeNaam)));
        }

        private SelectList GetItemSelectList(Uitlening uitlening)
        {
            return new SelectList(itemRepository.FindAll().OrderBy(g => g.Naam),
                "Id", "Naam",
               uitlening == null || uitlening.Item == null ? "" : uitlening.Item.Naam);
        }

        private SelectList GetItemSelectList(string item)
        {
            return new SelectList(itemRepository.FindAll().OrderBy(g => g.Naam),
                "Id", "Naam",
               item ?? "");
        }

        private SelectList GetLeerlingSelectList(Uitlening uitlening)
        {
            return new SelectList(leerlingRepository.FindAll().OrderBy(g => g.Voornaam),
                "Id", "LeerlingVoornaam",
               uitlening == null || uitlening.Leerling == null ? "" : uitlening.Leerling.ToString());
        }

        private SelectList GetLeerlingSelectList(string leerling)
        {
            return new SelectList(leerlingRepository.FindAll().OrderBy(g => g.Voornaam),
                "Id", "LeerlingVoornaam",
               leerling ?? "");
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