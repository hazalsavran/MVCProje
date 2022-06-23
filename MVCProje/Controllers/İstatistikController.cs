using BusinessLayes.Concreate;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProje.Controllers
{
    public class İstatistikController : Controller
    {
        // GET: İstatistik
        HeadingManager Hm = new HeadingManager(new EFHeadingDal());
        CategoryManager cm = new CategoryManager(new EFCategoryDal());
        WriterManager wm = new WriterManager(new EFWriterDal());
        public ActionResult İstatistikView()
        {
           

            var kategorisayısı = cm.GetList().Count().ToString();
            ViewBag.ktgr = kategorisayısı;
            var tiyatro = (from x in Hm.GetList() select new { x.HeadingName, x.Category.CategoryName } ).Where(x=>x.CategoryName=="Tiyatro").Count().ToString();
            ViewBag.tiyatro = tiyatro;
            var yazar = (from x in wm.GetList() select new { x.WriterName }).Where(x => x.WriterName.ToUpper().Contains("A") ).Count().ToString();
            ViewBag.yazar = yazar;
            var kategoritrue = (from x in cm.GetList() select new { x.CategoryStatus }).Where(x => x.CategoryStatus == true).Count();
            var kategorifalse = (from x in cm.GetList() select new { x.CategoryStatus }).Where(x => x.CategoryStatus == false).Count();
            ViewBag.Fark = kategoritrue - kategorifalse;
            var baslık = (from x in Hm.GetList() select new { x.Category.CategoryName }).ToList();
            
          

            return View();
        }
        
    }
}