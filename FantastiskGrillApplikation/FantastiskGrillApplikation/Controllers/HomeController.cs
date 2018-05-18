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

        public ActionResult Menu(string lang = "sv")
        {
            List<Tbl_Menu> menuList = db.Tbl_Menu.ToList();

            if (lang == "sv")
            {
                ViewBag.menuList = menuList;

                ViewBag.listSize = menuList.Count();
            }
            else
            {
                List<Tbl_Menu> transList = new List<Tbl_Menu>();

                foreach (Tbl_Menu m in menuList)
                {
                    Tbl_Menu transMen = new Tbl_Menu();
                    transMen.Me_Id = m.Me_Id;
                    transMen.Me_IsSpecialPrice = m.Me_IsSpecialPrice;
                    transMen.Me_Name = translateAPI.parseApi(m.Me_Name,lang);
                    transMen.Me_Price = m.Me_Price;
                    transMen.Me_Type = m.Me_Type;
                    transList.Add(transMen);
                }

                ViewBag.menuList = transList;

                ViewBag.listSize = transList.Count();

            }

            return View();
        }
        
        public ActionResult EnglishMenu()
        {

            List<Tbl_Menu> menuList = db.Tbl_Menu.ToList();
           
            return View();
        }
    }
}