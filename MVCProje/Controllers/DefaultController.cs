using BusinessLayes.Concreate;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProje.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        // GET: Default
        HeadingManager Hm = new HeadingManager(new EFHeadingDal());
        ContentManager Cm = new ContentManager(new EFContentDal());
        public ActionResult Headings()
        {
            var headinglist = Hm.GetList();
            return View(headinglist);
        }
        public PartialViewResult Index(int id)
        {
            var contentlist = Cm.GetListByHeadingID(id);
            return PartialView(contentlist);
        }
    }
}