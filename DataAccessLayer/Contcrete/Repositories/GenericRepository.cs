using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Contcrete.Repositories
{
    //bir şart koyduk gelicek T değeri class olmalı 
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        //generic: bütün bileşenlerin tamamını kapsar

        Context c = new Context(); //contextde bizim contextdekilere erişmemiz için 
        DbSet<T> _object; //_object bizim T değerimize karşılık gelen sınıfı tutuyor

        //T değerine karşılık olarak gelicek sınıfı nasıl tutucaz
        //constructor
        public GenericRepository()
        {
            _object = c.Set<T>(); //burada _object değerinin c den gelen (entity) T değeri olduğunu belirttik
        }


        public void Delete(T p)
        {
            var deletedEntiy = c.Entry(p);
            deletedEntiy.State = EntityState.Deleted; 
            //_object.Remove(p);
            c.SaveChanges();
        }

        public T Get(Expression<Func<T, bool>> filter)
        {
            //singleordefault: bir dizide veya listede sadece bir tane değer döndürmek için kullanılan ef linq methodudur
            return _object.SingleOrDefault(filter);
        }

        public void Insert(T p)
        {
            //entry: giriş
            //state: durum
            var addedEntity = c.Entry(p);
            addedEntity.State = EntityState.Added; //yapı olarak add methoduyla aynı görevi görür
            //_object.Add(p);
            c.SaveChanges(); //değişiklikleri kaydeder
        }

        public List<T> List()
        {
            return _object.ToList();

        }

        public List<T> List(Expression<Func<T, bool>> filter)
        {
            return _object.Where(filter).ToList();

        }

        public void Update(T p)
        {
            var updateEntity = c.Entry(p);
            updateEntity.State = EntityState.Modified;
            c.SaveChanges();
        }
    }
}
