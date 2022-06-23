using BusinessLayes.Concreate;
using DataAccessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Web;
using System.Web.Mvc;

namespace MVCProje.Controllers
{
    public class ContentController : Controller
    {
        // GET: Content
        ContentManager Cm = new ContentManager(new EFContentDal());
        public ActionResult Index()
        {
            return View();
        }
        
        public ActionResult GetAllContent(string p="")
        {
            var values = Cm.GetList(p);
            return View(values);
        }
        public ActionResult ContentByHeading(int id)
        {
            var contentvalues = Cm.GetListByHeadingID(id);
            return View(contentvalues);
        }
    }
}