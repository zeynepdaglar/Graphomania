using BusinessLayer.Concrete;
using DataAccessLayer.Contcrete;
using DataAccessLayer.EntityFreamwork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.Web;
using System.Web.Mvc;

namespace MvcProject.Controllers
{

    public class ContentController : Controller
    {
        ContentManager contentManager = new ContentManager(new EFContentDAL());
       
        // GET: Content
        public ActionResult Index()
        {
            return View();
        }

        
        public ActionResult GetAllContent(string parameter)
        {
            var values = contentManager.GetList(parameter);
            return View(values);
        }

        public ActionResult ContentByHeading(int id)
        {
            var contentvalues = contentManager.GetListByHeadingId(id);
            return View(contentvalues);
        }
    }
}