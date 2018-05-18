using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc;
using FantastiskGrillApplikation.Models;


namespace FantastiskGrillApplikation.Controllers
{
    public class HomeController : Controller
    {

        FantastiskDatabasEntities db = new FantastiskDatabasEntities();

        public ActionResult Index()
        {
            WeatherClient wc = new WeatherClient();
            ViewBag.temp = wc.getData();

            return View();
        }

        public ActionResult Menu()
        {
            
            ViewBag.trans = translateAPI.parseApi("Hej");

            List<Tbl_Menu> menuList = db.Tbl_Menu.ToList();

            ViewBag.menuList = menuList;

            ViewBag.listSize = menuList.Count();

            return View();
        }
    }
}