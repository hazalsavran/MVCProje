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
    public class MessageController : Controller
    {
        // GET: Message
        MessageManager Mm = new MessageManager(new EFMessageDal());
        MessageValidator messagevalidator = new MessageValidator();

        [Authorize]
        public ActionResult Inbox()
        {
            string receiver = (string)Session["WriterMail"];
            var messageList = Mm.GetListInbox(receiver);
            return View(messageList);
        }
        public ActionResult SendBox()
        {
            string sender = (string)Session["WriterMail"];
            
            var messagelist = Mm.GetListSendbox(sender);
            return View(messagelist);
        }
        public ActionResult GetInboxDetails(int id)
        {
            var messagevalues = Mm.GetByID(id);
            return View(messagevalues); 
        }
        public ActionResult GetSendBoxDetails(int id)
        {
            var messagevalues = Mm.GetByID(id);
            return View(messagevalues);
        }
        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult NewMessage(Message message)
        {
            string sender = (string)Session["WriterMail"];
            ValidationResult result = messagevalidator.Validate(message);
            if (result.IsValid)
            {
                message.SenderMail = sender;
                message.MessageDate = DateTime.Parse( DateTime.Now.ToShortDateString());
                Mm.MessageAdd(message);
                return RedirectToAction("SendBox");
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