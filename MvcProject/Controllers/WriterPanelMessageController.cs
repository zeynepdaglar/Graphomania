using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
using DataAccessLayer.Contcrete;
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
    public class WriterPanelMessageController : Controller
    {

        MessageManager messageManager = new MessageManager(new EFMessageDAL());
        MessageValidator messageValidator = new MessageValidator();
        public ActionResult Inbox()
        {
            string p = (string)Session["WriterEmail"];
            var messageList = messageManager.GetListInbox(p); //p ye session degeri vermemiz gerekli
            return View(messageList);
        }
        public ActionResult Sendbox()
        {
            string p = (string)Session["WriterEmail"];
            var messagelist = messageManager.GetListSendbox(p);
            return View(messagelist);
        }

        public PartialViewResult MessageListMenu()
        {
            return PartialView();
        }

        public ActionResult GetInboxMessageDetails(int id)
        {
            var values = messageManager.GetById(id);
            return View(values);
        }

        public ActionResult GetSendBoxMessageDetails(int id)
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
            string sender = (string)Session["WriterEmail"];
            ValidationResult result = messageValidator.Validate(message);

            if (result.IsValid)
            {
                message.SenderMail = sender; //sonra değiştir
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