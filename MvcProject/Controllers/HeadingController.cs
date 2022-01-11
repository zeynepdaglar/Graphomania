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
    
    public class HeadingController : Controller
    {
        HeadingManager headingManager = new HeadingManager(new EFHeadingDAL());
        CategoryManager categoryManager = new CategoryManager(new EFCategoryDAL());
        WriterManager writerManager = new WriterManager(new EFWriterDAL());
        // GET: Heading
        public ActionResult Index()
        {
            var headingvalue = headingManager.GetList();
            return View(headingvalue);
        }

        public ActionResult HeadingReport()
        {
            var headingvalue = headingManager.GetList();
            return View(headingvalue);
        }

        [HttpGet]
        public ActionResult AddHeading()
        {
            //dropdownın iki parametresi vardır:
            //valuemember: secmiş olduğumuz değerin idsi -->controller tarafındaki karşılığı  value
            //displaymember: secmiş olduğumuz değerin görünümü yani kendisi -->text

            //valuecategory değişkeni category sınıfındaki değerleri id, name değerlerini tutucak
            List<SelectListItem> valuecategory = (from x in categoryManager.GetCategoryList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryId.ToString()
                                                  }
                                                 ).ToList();


            List<SelectListItem> valuewriter = (from x in writerManager.GetList() 
                                                select new SelectListItem
                                                {
                                                    Text=x.WriterName + " " + x.WriterSurname,
                                                    Value=x.WriterId.ToString()
                                                }
                                                ).ToList();

            ViewBag.vlc = valuecategory; //controller üzerinde bir viewbag yardımıyla bunları view tarafına taşıyabilicez
            ViewBag.vlw = valuewriter;
            return View();
        }

        [HttpGet]
        public ActionResult AddHeading(Heading p)
        {
            p.HeadingTime = DateTime.Parse(DateTime.Now.ToShortDateString());
            headingManager.HeadingAdd(p);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditHeading(int id)
        {
            List<SelectListItem> valuecategory = (from x in categoryManager.GetCategoryList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryId.ToString()
                                                  }
                                             ).ToList();

            ViewBag.vlc = valuecategory;
            var headingvalue = headingManager.GetByID(id);
            return View(headingvalue);
        }

        [HttpPost]
        public ActionResult EditHeading(Heading p)
        {
            headingManager.HeadingUpdate(p);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteHeading(int id)
        {
            var headingvalue = headingManager.GetByID(id);
            headingvalue.HeadingStatus = false;
            headingManager.HeadingDelete(headingvalue);
            return RedirectToAction("index");
        }

      
    }
}