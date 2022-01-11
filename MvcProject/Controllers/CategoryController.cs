
using BusinessLayer.Concrete;
using BusinessLayer.ValidationRules;
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
    public class CategoryController : Controller
    {
        //business layerde oluşturduğumuz sınıfı çağırmamız gerekiyor bunun için bir nesne oluşturmalıyız
        //cm nesnesini kullanarak artık o sınıfa erişebiliriz
        CategoryManager cm = new CategoryManager(new EFCategoryDAL());



        public ActionResult Index() //listeleme sayfası
        {
            return View();
        }

        public ActionResult GetCategoryList()
        {
            var categoryvalues = cm.GetCategoryList(); //categoryvalues değişkeninin içerisine category tablosunda yer alan veriler gelicek
            return View(categoryvalues); //categoryvalues değişkenindeki değerler viewe aktarılıcak
        }

        [HttpGet] //sayfa yüklendiğinde
        public ActionResult AddCategory()
        {
            return View(); //sayfayı geriye döndür.
        }

        //Yeni kategory ekleme(hatalı yol)
        [HttpPost]
        public ActionResult AddCategory(Category categoryP) //category sınıfından bir p parametresi türettik
        {
            //cm.CategoryAddBL(categoryP);
            //validate: geçerliliğini kontrol etme vb.
            CategoryValidatior categoryValidator = new CategoryValidatior();
            ValidationResult results = categoryValidator.Validate(categoryP);

            if (results.IsValid) //Category Validatordaki kurallar doğruysa
            {
                cm.CategoryAddBL(categoryP);
                //RedirectToAction: bizi bir aksiyona yönlendirir
                return RedirectToAction("GetCategoryList");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
            
        }
    }
} 