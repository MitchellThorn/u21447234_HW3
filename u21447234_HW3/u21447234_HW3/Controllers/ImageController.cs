using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using u21447234_HW3.Models;

namespace u21447234_HW3.Controllers
{
    public class ImageController : Controller
    {
        // GET: Image
        public ActionResult Index()
        {
            string[] imagePaths = Directory.GetFiles(Server.MapPath("~/App_Data/image/"));

            List<FileModel> images = new List<FileModel>();

            foreach (string imagePath in imagePaths)
            {
                images.Add(new FileModel { FileName = Path.GetFileName(imagePath) });
            }
            return View(images);
        }

        public FileResult DownloadImage(string fileName)
        {
            string path = Server.MapPath("~/App_Data/image/") + fileName;
            byte[] bytes = System.IO.File.ReadAllBytes(path);

            return File(bytes, "application/octet-stream", fileName);
        }

        public ActionResult DeleteImage(string fileName)
        {
            string path = Server.MapPath("~/App_Data/image/") + fileName;

            System.IO.File.Delete(path);

            return RedirectToAction("Index");
        }
    }
}