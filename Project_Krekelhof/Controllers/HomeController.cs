using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Project_Krekelhof.Models.DAL;

namespace Project_Krekelhof.Controllers
{
    public class HomeController : Controller
    {
        private KrekelschoolContext context = new KrekelschoolContext();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
    }
}