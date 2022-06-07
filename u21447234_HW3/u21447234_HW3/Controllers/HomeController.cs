using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace u21447234_HW3.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Home()
        {
            return View();
        }

        public ActionResult Files()
        {
            return View();
        }

        public ActionResult Images()
        {
            return View();
        }

        public ActionResult Videos()
        {
            return View();
        }



        public ActionResult AboutMe()
        {
            ViewBag.Message = "I'm Mitchell this is my About page, let's get started.";

            return View();
        }
    }
}