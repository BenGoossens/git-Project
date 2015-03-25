using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project_Krekelhof.Models.Domain;
using Project_Krekelhof.ViewModels;

namespace Project_Krekelhof.Controllers
{
    public class BoekController : Controller
    {

        private IBoekRepository BoekRepository;
        private ICategorieRepository CategorieRepository;

       public BoekController(IBoekRepository boekRepository, ICategorieRepository categorieRepository)
        {
            BoekRepository = boekRepository;
            CategorieRepository = categorieRepository;
        }
        
        // GET: Boek
        public ActionResult Index()
        {
            //return View(new BoeksIndexViewModel(BoekRepository.FindAll().OrderBy(p => p.Id).ToList()));
            IEnumerable<Boek> boeken = BoekRepository.FindAll().OrderBy(b => b.Id).ToList();
            IEnumerable<BoekIndexViewModel> bvm = boeken.Select(b => new BoekIndexViewModel(b)).ToList();
            return View(bvm);
        }
    }
}