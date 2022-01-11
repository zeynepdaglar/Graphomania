using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Abstract;
using DataAccessLayer.EntityFreamwork;
using EntityLayer.Concrete;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProject.Controllers
{
    public class MessageController : Controller
    {

        MessageManager messageManager = new MessageManager(new EFMessageDAL());
        MessageValidator messageValidator = new MessageValidator();

        // GET: Message
        public ActionResult Inbox(string p)
        {
            var messagelist = messageManager.GetListInbox(p);
            return View(messagelist);
        }


        public ActionResult Sendbox(string p)
        {
            var messagelist = messageManager.GetListSendbox(p);
            return View(messagelist);
        }

        public ActionResult GetInboxMesageDetails(int id)
        {
            var values = messageManager.GetById(id);
            return View(values);
        }

        public ActionResult GetSendMesageDetails(int id)
        {
            var values = messageManager.GetById(id);
            return View(values);
        }

       
        [HttpGet]
        public ActionResult NewMessage()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewMessage(Message message)
        {
            ValidationResult result = messageValidator.Validate(message);

            if (result.IsValid)
            {
                message.MessageDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                messageManager.MessageAdd(message);
                return RedirectToAction("Sendbox");
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