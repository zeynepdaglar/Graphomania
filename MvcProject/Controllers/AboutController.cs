using BusinessLayer.Concrete;
using DataAccessLayer.EntityFreamwork;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProject.Controllers
{
    public class AboutController : Controller
    {
        AboutManager aboutManager = new AboutManager(new EFAboutDAL());

        // GET: About
        public ActionResult Index()
        {
            var aboutvalues = aboutManager.GetList();
            return View(aboutvalues);
        }

        [HttpGet]
        public ActionResult AddAbout()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAbout(About p)
        {
            aboutManager.AboutAdd(p);
            return RedirectToAction("index");
        }

        public PartialViewResult AboutPartial()
        {
            return PartialView();
        }

    }
}