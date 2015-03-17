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


        private IUitleningRepository uitleningRepository;
        private IItemRepository itemRepository;
        private ILeerlingRepository leerlingRepository;

        public UitleningController()
        {

        }
        public UitleningController(IUitleningRepository uitleningRepository, IItemRepository itemRepository,ILeerlingRepository leerlingRepository)
        {
            this.uitleningRepository = uitleningRepository;
            this.itemRepository = itemRepository;
            this.leerlingRepository = leerlingRepository;
        }

        public IEnumerable<Uitlening> GetUitleningen()
        {
            return uitleningRepository.FindAll().ToList();
        }

        //public ActionResult Index()
        //{
        //    //Ophalen uitleningen, gesorteerd op startuitlening.
        //    IEnumerable<Uitlening> uitleningen =
        //        uitleningRepository.FindAll().Include(u => u.Item).OrderByDescending(u => u.StartUitlening);
        //    //Aanmaken van ViewModel.  ToList zorgt voor het uitvoeren van de query
        //    if (uitleningen != null)
        //    {
        //        IEnumerable<UitleningIndexViewModel> vms =
        //        uitleningen.Select(u => new UitleningIndexViewModel(u)).ToList();
        //        return View(vms);
        //    }
            
        //    //ViewBag.TotaleOmzet = uitleningen.Sum(b => b.Id);
        //    return null;
        //}
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