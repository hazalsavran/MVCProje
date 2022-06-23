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
    public class AuthorizationController : Controller
    {
        // GET: Authorization
        AdminManager am = new AdminManager(new EFAdminDal());
        public ActionResult Index()
        {
            var adminvalues = am.GetList();

            return View(adminvalues);
        }
        [HttpGet]
        public ActionResult AddAdmin()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddAdmin(Admin p)
        {
            am.AdminAdd(p);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditAdmin(int id)
        {
            List<SelectListItem> adminrole= (from x in am.GetList()
                                                  select new SelectListItem
                                                  { Text = x.AdminRole, Value = x.AdminID.ToString() }).ToList();
            // başka bir tablodan adminin rolünü ve ıd sini linq ile getirdik
            ViewBag.admin = adminrole;
            var adminvalue = am.GetByID(id);
            return View(adminvalue);
        }
        [HttpPost]
        public ActionResult EditAdmin(Admin p)
        {
            am.AdminUpdate(p);
            return RedirectToAction("Index");
        }
    }
}