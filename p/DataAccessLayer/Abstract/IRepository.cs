using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IRepository<T>
    {
        //buradaki T biz hangi entityi gönderirsek o olucak
        List<T> List();

        //ekleme
        void Insert(T p);

        //silme
        void Delete(T p);

        //güncelleme
        void Update(T p);

        //şartlı listeleme
        List<T> List(Expression<Func<T, bool>> filter); 
    }
}
