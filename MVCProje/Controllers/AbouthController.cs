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
    public class AbouthController : Controller
    {
        // GET: Abouth
        AbouthManager abm = new AbouthManager(new EFAbouthDal());
        public ActionResult Index()
        {
            var abouthvalue = abm.GetList();
            return View(abouthvalue);
        }
        [HttpGet]
        public ActionResult AddAbouth()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAbouth(Abouth abouth )
        {
            abm.AbouthAdd(abouth);
            return RedirectToAction("Index");
        }
        
        public PartialViewResult AbouthPartial()
        {
            return PartialView();
        }
    }
}