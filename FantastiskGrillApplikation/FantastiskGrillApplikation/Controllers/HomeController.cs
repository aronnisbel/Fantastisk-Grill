using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FantastiskGrillApplikation.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Menu()
        {
            
            ViewBag.trans = translateAPI.parseApi("Hej");

            return View();
        }

    }
}