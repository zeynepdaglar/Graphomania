using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using DataAccessLayer.Contcrete.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDAL _categoryDAL;

        public CategoryManager(ICategoryDAL categoryDAL)
        {
            _categoryDAL = categoryDAL;
        }

        public void CategoryAddBL(Category category)
        {
            _categoryDAL.Insert(category);
        }

        public void CategoryDelete(Category category)
        {
            _categoryDAL.Delete(category);
        }

        public void CategoryUpdate(Category category)
        {
            _categoryDAL.Update(category);
        }

        public void CatoryUpdate(Category category)
        {
            _categoryDAL.Update(category);
        }

        public Category GetByID(int id)
        {
            return _categoryDAL.Get(x => x.CategoryId == id);
        }

        public List<Category> GetCategoryList()
        {
            return _categoryDAL.List();
        }



    }
}
