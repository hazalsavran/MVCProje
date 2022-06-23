using BusinessLayes.Concreate;
using BusinessLayes.ValidationRules;
using DataAccessLayer.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProje.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        ContactManager Cm = new ContactManager(new EFContactDal());
        ContactValidator cv = new ContactValidator();
        MessageManager mm = new MessageManager(new EFMessageDal());
        public ActionResult Index(string p="")
        {
            var contactvalues = Cm.GetList(p);
            return View(contactvalues);
        }

        public ActionResult GetContactDetails(int id)
        {
            var contactvalues = Cm.GetByID(id);
            return View(contactvalues);
        }
        public PartialViewResult MessageListMenu()
        {
            string receiver = (string)Session["WriterMail"];
            var iletisim = Cm.GetListAll().Count().ToString();
            ViewBag.iletisim = iletisim;
            var gelenmsj = mm.GetListInbox(receiver).Count().ToString();
            ViewBag.gelenmsj = gelenmsj;
            var gonderilenmsj = mm.GetListSendbox(receiver).Count().ToString();
            ViewBag.gonderilenmsj = gonderilenmsj;
            return PartialView();
        }
        
    }
}