using BusinessLayes.Concreate;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProje.Controllers
{
    public class GaleriController : Controller
    {
        // GET: Galeri
        ImageFilesManager im = new ImageFilesManager(new EFImageFilesDal());
        public ActionResult Index()
        {
            var files = im.GetList();
            return View(files);
        }
    }
}