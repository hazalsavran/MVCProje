using BusinessLayes.Concreate;
using BusinessLayes.ValidationRules;
using DataAccessLayer.EntityFramework;
using EntityLayer.Concreate;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCProje.Controllers
{
    public class WriterController : Controller
    {
        WriterManager Wm = new WriterManager(new EFWriterDal());
        WriterValidator writervalidator = new WriterValidator();
        public ActionResult Index()
        {
            var writervalues = Wm.GetList();

            return View(writervalues);
        }
        [HttpGet]
        public ActionResult AddWriter()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddWriter(Writer p)
        {
           
            ValidationResult result = writervalidator.Validate(p);
            if (result.IsValid)
            {
                Wm.WriterAdd(p);
                return RedirectToAction("Index");
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
        [HttpGet]
        public ActionResult EditWriter(int id)
        {
            var writervalues = Wm.GetById(id);
            return View(writervalues);
        }

        [HttpPost]
        public ActionResult EditWriter(Writer  writer)
        {
            ValidationResult result = writervalidator.Validate(writer);
            if (result.IsValid)
            {
                Wm.WriterUpdate(writer);
                return RedirectToAction("Index");
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

    }
}