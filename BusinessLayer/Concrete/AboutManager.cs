using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{

    public class AboutManager : IAboutServices
    {
        IAboutDAL _aboutDAL;

        public AboutManager(IAboutDAL aboutDAL)
        {
            _aboutDAL = aboutDAL;
        }

        public void AboutDelete(About about)
        {
            _aboutDAL.Delete(about);
        }

        public void AboutUpdate(About about)
        {
            _aboutDAL.Update(about);
        }

        public void AboutAdd(About about)
        {
            _aboutDAL.Insert(about);
        }

        public About GetById(int id)
        {
            return _aboutDAL.Get(x=> x.AboutId == id);
        }

        public List<About> GetList()
        {
            return _aboutDAL.List();
        }
    }
}
