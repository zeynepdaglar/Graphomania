using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IAdminServices
    {
        List<Admin> GetList();
        void AdminAdd(Admin admin);
        Category GetByID(int id);

        void AdminDelete(Admin admin);
        void AdminUpdate(Admin admin);
    }
}
