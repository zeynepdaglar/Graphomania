using BusinessLayer.Concrete;
using DataAccessLayer.Contcrete;
using DataAccessLayer.EntityFreamwork;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProject.Controllers
{
    public class WriterPanelContentController : Controller
    {
        AdminManager contentManager = new AdminManager(new EFAdminDAL());
        Context context = new Context();
        // GET: WriterPanelContent
        public ActionResult MyContent(string p)
        {
            p = (string)Session["WriterMail"];
            //TODO: mimariye göre yap
            var writeridinfo = context.Writers.Where(x => x.WriterEmail == p).Select(y=>y.WriterId).FirstOrDefault(); 
            var contentvalues = contentManager.GetListByWriter(writeridinfo);
            return View(contentvalues);
        }

        [HttpGet]
        public ActionResult AddContent(int id)
        {
            ViewBag.d = id;
            return View();
        }

        [HttpPost]
        public ActionResult AddContent(Content content)
        {
            string mail = (string)Session["WriterMail"];
            //mimariye taşı
            var writeridinfo = context.Writers.Where(x => x.WriterEmail == mail).Select(y => y.WriterId).FirstOrDefault();
           
            //ContentDate için o anki tarih değerini veriyoruz
            content.ContentDate = DateTime.Parse(DateTime.Now.ToShortDateString());

            content.WriterId = writeridinfo; //sesiondan gelen değeri verdik

            content.ContentStatus = true;

            contentManager.ContentAdd(content);
            return RedirectToAction("MyContent"); 
        }

        public ActionResult ToDoList()
        {
            return View();
        }
    }
}