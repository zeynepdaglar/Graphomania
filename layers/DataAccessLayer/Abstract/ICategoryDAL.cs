using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface ICategoryDAL  : IRepository<Category>
    {
        //CRUD işlemleri metotları
        //tüm tablolar için tek tek interface oluşturup yapamayız bu yanlış bir yöntem
        //type name();
        //ToList, Add,Find-bulma işlemi için, Remove metotları
        //listeleme
        //List<Category> List();

        ////ekleme işlemi
        //void Insert(Category p);

        ////güncelleme
        //void Update(Category p);

        ////silme işlemi
        //void Delete(Category p);
    }
}
