using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using u21447234_HW3.Models;

namespace u21447234_HW3.Controllers
{
    public class VideoController : Controller
    {
        public ActionResult Index()
        {
            string[] videoPaths = Directory.GetFiles(Server.MapPath("~/App_Data/video/"));

            List<FileModel> videos = new List<FileModel>();

            foreach (string videoPath in videoPaths)
            {
                videos.Add(new FileModel { FileName = Path.GetFileName(videoPath) });
            }
            return View(videos);
        }

        public FileResult DownloadVideo(string fileName)
        {
            string path = Server.MapPath("~/App_Data/video/") + fileName;
            byte[] bytes = System.IO.File.ReadAllBytes(path);

            return File(bytes, "application/octet-stream", fileName);
        }

        public ActionResult DeleteVideo(string fileName)
        {
            string path = Server.MapPath("~/App_Data/video/") + fileName;

            System.IO.File.Delete(path);

            return RedirectToAction("Index");
        }
    }
}