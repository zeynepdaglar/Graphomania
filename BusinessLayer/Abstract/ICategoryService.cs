using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    interface ICategoryService
    {
        List<Category> GetCategoryList();
        void CategoryAddBL(Category category);
        Category GetByID(int id);

        void CategoryDelete(Category category);
        void CategoryUpdate(Category category);
        void CatoryUpdate(Category category);
    }
}
