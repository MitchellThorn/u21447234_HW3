using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace u21447234_HW3.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase files, string rbSelection)
        {
            if (files != null && files.ContentLength > 0)
            {
                var fileName = Path.GetFileName(files.FileName);
                var path = "";

                if (rbSelection == "Doc")
                {
                    path = Path.Combine(Server.MapPath("~/App_Data/document"), fileName);
                }
                else if(rbSelection == "Img")
                {
                    path = Path.Combine(Server.MapPath("~/App_Data/image"), fileName);
                }
                else if(rbSelection == "Vid")
                {
                    path = Path.Combine(Server.MapPath("~/App_Data/video"), fileName);
                }
                files.SaveAs(path);
            }
            return RedirectToAction("Index");
        }

        public ActionResult AboutMe()
        {
            return View();
        }
    }
}