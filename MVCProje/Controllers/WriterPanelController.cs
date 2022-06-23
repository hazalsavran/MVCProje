using BusinessLayes.Concreate;
using DataAccessLayer.Concreate;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using BusinessLayes.ValidationRules;
using FluentValidation.Results;

namespace MVCProje.Controllers
{
    public class WriterPanelController : Controller
    {
        // GET: WriterPanel
        HeadingManager Hm = new HeadingManager(new EFHeadingDal());
        CategoryManager cm = new CategoryManager(new EFCategoryDal());
        Context c = new Context();
        WriterManager wm = new WriterManager(new EFWriterDal());
        WriterValidator writervalidator = new WriterValidator();

        [HttpGet]
        public ActionResult WriterProfile(int id=0)
        {
            string p = (string)Session["WriterMail"];
            var writeradinfo = c.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterName).FirstOrDefault();
            ViewBag.d = writeradinfo;
            
            id = c.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterID).FirstOrDefault();
            var writervalue = wm.GetById(id);       
            return View(writervalue);
        }
        [HttpPost]
        public ActionResult WriterProfile(Writer writer)
        {
           string p = (string)Session["WriterMail"];
            var writeradinfo = c.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterName).FirstOrDefault();
            ViewBag.d = writeradinfo;
            ValidationResult result = writervalidator.Validate(writer);
            if (result.IsValid)
            {
                wm.WriterUpdate(writer);
                return RedirectToAction("AllHeading", "WriterPanel");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }

            return View();


        }

        public ActionResult MyHeading(string p)
        {
           
            p = (string)Session["WriterMail"];
            var writeridinfo = c.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterID).FirstOrDefault();
            var writeradinfo = c.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterName).FirstOrDefault();
            ViewBag.d = writeradinfo;
            ViewBag.i = writeridinfo;
            var values = Hm.GetListByWriter(writeridinfo);
                //.Where(x => x.HeadingStatus == true);
            return View(values);
        }
        [HttpGet]
        public ActionResult NewHeading()
        {
            string p = (string)Session["WriterMail"];
            var writeradinfo = c.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterName).FirstOrDefault();
            ViewBag.d = writeradinfo;
            List<SelectListItem> valuecategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  { Text = x.CategoryName, Value = x.CategoryID.ToString() }).ToList();
            ViewBag.vlc = valuecategory;
            return View();
        }
        [HttpPost]
        public ActionResult NewHeading(Heading p)
        {
            string deger = (string)Session["WriterMail"];
            var writeridinfo = c.Writers.Where(x => x.WriterMail == deger).Select(y => y.WriterID).FirstOrDefault();
            p.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            p.WriterID = writeridinfo;
            p.HeadingStatus = true;
            Hm.HeadingAdd(p);
            return RedirectToAction("MyHeading");
        }
        [HttpGet]
        public ActionResult EditHeading(int id)
        {

            List<SelectListItem> valuecategory = (from x in cm.GetList()
                                                  select new SelectListItem
                                                  { Text = x.CategoryName, Value = x.CategoryID.ToString() }).ToList();
            ViewBag.vlc = valuecategory;
            var Headingvalue = Hm.GetByID(id);
            return View(Headingvalue);
        }
        [HttpPost]
        public ActionResult EditHeading(Heading p)
        {
            Hm.HeadingUpdate(p);
            return RedirectToAction("MyHeading");
        }
        public ActionResult DeleteHeading(int id)
        {
            var headingdelete = Hm.GetByID(id);
           
            Hm.HeadingDelete(headingdelete);
            return RedirectToAction("MyHeading");
        }

        public ActionResult AllHeading(int sayfa=1)
        {
            string p = (string)Session["WriterMail"];
            var writeradinfo = c.Writers.Where(x => x.WriterMail == p).Select(y => y.WriterName).FirstOrDefault();
            ViewBag.d = writeradinfo;
            var headings = Hm.GetList().ToPagedList(sayfa,7);

            return View(headings);
        }
        

        
    }
}