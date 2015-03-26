using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project_Krekelhof.Models.Domain;
using Project_Krekelhof.ViewModels;

namespace Project_Krekelhof.Controllers
{
    public class LeerlingController : Controller
    {
        private ILeerlingRepository LeerlingRepository;
        private IUitleningRepository UitleningRepository;

        public LeerlingController(ILeerlingRepository leerlingRepository, IUitleningRepository uitleningRepository)
        {
            LeerlingRepository = leerlingRepository;
            UitleningRepository = uitleningRepository;
        }

        // GET: Leerling
        public ActionResult Index()
        {
            IEnumerable<Leerling> leerlingen = LeerlingRepository.FindAll().OrderBy(l => l.Id).ToList();
            IEnumerable<LeerlingIndexViewModel> lvm = leerlingen.Select(l => new LeerlingIndexViewModel(l)).ToList();
            return View(lvm);
        }
    }
}