using BusinessLayes.Concreate;
using DataAccessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProje.Controllers
{
    public class WriterPanelContentController : Controller
    {
        // GET: WriterPanelContent
        ContentManager Cm = new ContentManager(new EFContentDal());
        Context c = new Context();
        public ActionResult MyContent(string p)
        {
            
            p = (string)Session["WriterMail"];
     
            var writeridinfo = c.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterID).FirstOrDefault();
            var writername = c.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterName).FirstOrDefault();
            ViewBag.d = writername;
            var contentvalues = Cm.GetListByWriter(writeridinfo);
            return View(contentvalues);
        }
        [HttpGet]
        public ActionResult AddContent(int id)
        {
            
            ViewBag.d = id;
            return View();
        }
        [HttpPost]
        public ActionResult AddContent(Content p)
        {
           string mail = (string)Session["WriterMail"];

            var writeridinfo = c.Writers.Where(x => x.WriterMail == mail).Select(y => y.WriterID).FirstOrDefault();
            p.ContentDate = DateTime.Parse( DateTime.Now.ToShortDateString());           
            p.WriterID = writeridinfo;
            Cm.ContentAdd(p);

            return RedirectToAction("MyContent");
        }

    }
}