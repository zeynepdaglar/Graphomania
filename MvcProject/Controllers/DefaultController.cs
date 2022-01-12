using BusinessLayer.Concrete;
using DataAccessLayer.EntityFreamwork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcProject.Controllers
{
    [AllowAnonymous] //sisteme giriş yapmadan aşağıdaki sayalara erişebiliriz
    public class DefaultController : Controller
    {
        HeadingManager headingManager = new HeadingManager(new EFHeadingDAL());
        AdminManager contentManager = new AdminManager(new EFAdminDAL());
        // projenin ana sayfası olucak

        public ActionResult Headings()
        {
            var headinglist = headingManager.GetList();
            return View(headinglist);
        }

        //başlangıçta id boş gelicek ve bu yüzden hata fırlatıcak
        //bunu engellemek için geçici olarak 0 değeri verdik
        public PartialViewResult Index(int id=0)
        {
            var contentlist = contentManager.GetListByHeadingId(id);
            return PartialView(contentlist);
        }
    }
}
