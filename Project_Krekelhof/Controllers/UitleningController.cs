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