using BusinessLayer.Concrete;
using DataAccessLayer.Contcrete;
using DataAccessLayer.EntityFreamwork;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcProject.Controllers
{
    //burada authorizeden muaf tutuyoruz. Bu sayfayı görüntüleyip giriş yapmak için
    [AllowAnonymous]
    public class LoginController : Controller
    {
        WriterLoginManager writerLoginManager = new WriterLoginManager(new EFWriterDAL());
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Admin p)
        {
            Context context = new Context();
            //FirstOrDefault: geriye sadece bir değer döner.
            var AdminUserInfo = context.Admins.FirstOrDefault(x =>x.AdminUsername==p.AdminUsername && x.AdminPassword == p.AdminPassword);

            if (AdminUserInfo != null)
            {
                //yetkilendirme
                //kalıcı cookie olmasını istiyorsak son kısmı true yapabiliriz 
                FormsAuthentication.SetAuthCookie(AdminUserInfo.AdminUsername, false);
                //oturum yönetimi
                Session["AdminUsername"] = AdminUserInfo.AdminUsername;
                return RedirectToAction("Index", "AdminCategory");
            }
            else
            {
                return RedirectToAction("Index");
            }
           
        }

        //TODO: bu kısmı kurumsal mimariye taşı 
        [HttpGet]
        public ActionResult WriterLogin()
        {
            return View(); 
        }

        [HttpPost]
        public ActionResult WriterLogin(Writer writer)
        {
            //Context context = new Context();
            ////FirstOrDefault: geriye sadece bir değer döner.
            //var WriterUserInfo = context.Writers.FirstOrDefault(x => x.WriterEmail == writer.WriterEmail && x.WriterPassword == writer.WriterPassword);

            var WriterUserInfo = writerLoginManager.GetWriter(writer.WriterEmail, writer.WriterPassword);
            if (WriterUserInfo != null)
            {
                //yetkilendirme
                //kalıcı cookie olmasını istiyorsak son kısmı true yapabiliriz 
                FormsAuthentication.SetAuthCookie(WriterUserInfo.WriterEmail, false);
                //oturum yönetimi
                Session["WriterEmail"] = WriterUserInfo.WriterEmail;
                return RedirectToAction("MyContent", "WriterPanelContent");
            }
            else
            {
                return RedirectToAction("WriterLogin");
            }

        }

        public ActionResult LogOut()
        {
            //oturumu sonlandırmak
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Headings", "Default"); 
            //çıkış yapılınca default içindeki headingse yönlendiricek 
        }
    }
}