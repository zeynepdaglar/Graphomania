using BusinessLayer.Concrete;
using DataAccessLayer.Contcrete;
using DataAccessLayer.EntityFreamwork;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using PagedList.Mvc;
using FluentValidation.Results;
using BusinessLayer.ValidationRules;

namespace MvcProject.Controllers
{
    
    public class WriterPanelController : Controller
    {
        HeadingManager headingManager = new HeadingManager(new EFHeadingDAL());
        CategoryManager categoryManager = new CategoryManager(new EFCategoryDAL());
        WriterManager writerManager = new WriterManager(new EFWriterDAL());
        Context context = new Context();

        [HttpGet]
        public ActionResult WriterProfile(int id=0)
        {
            string p = (string)Session["WriterEmail"];
            ViewBag.d = p;
            id = context.Writers.Where(x => x.WriterEmail == p).Select(y => y.WriterId).FirstOrDefault();
            var writervalue = writerManager.GetByID(id);
            return View(writervalue);
        }

        [HttpPost]
        public ActionResult WriterProfile(Writer writer)
        {
            WriterValidator WriterValidator = new WriterValidator();
            ValidationResult result = WriterValidator.Validate(writer);

            if (result.IsValid)
            {
                writerManager.WriterUpdate(writer);
                return RedirectToAction("AllHeading", "WriterPanel");
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
        public ActionResult MyHeading(string p)
        {
            //solid eziliyor mu?neden?
            p = (string)Session["WriterEmail"];
            var writeridinfo = context.Writers.Where(x => x.WriterEmail == p).Select(y => y.WriterId).FirstOrDefault();
            var values = headingManager.GetListByWriter(writeridinfo);
            return View(values);
        }

        [HttpGet]
        public ActionResult NewHeading()
        {

            List<SelectListItem> valuecategory = (from x in categoryManager.GetCategoryList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryId.ToString()
                                                  }

                                                  ).ToList();

            ViewBag.vlc = valuecategory;
            return View();
        }

        [HttpPost]
        public ActionResult NewHeading(Heading heading)
        {
            Context context = new Context();
            string writermailinfo = (string)Session["WriterEmail"];
            var writeridinfo = context.Writers.Where(x => x.WriterEmail == writermailinfo).Select(y => y.WriterId).FirstOrDefault();
            ViewBag.d = writeridinfo;
            heading.HeadingTime = DateTime.Parse(DateTime.Now.ToShortDateString());
            heading.WriterId = writeridinfo;
            heading.HeadingStatus = true;
            headingManager.HeadingAdd(heading);
            return RedirectToAction("MyHeading");
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
            return RedirectToAction("MyHeading");
        }

        
        public ActionResult AllHeading(int page =1) 
        {
            //ToPagedList(başlangiç sayfa numarası, sayfada kaç veri bulunacağı)
            var headings = headingManager.GetList().ToPagedList(page,2);
            return View(headings);
        }
    }
}