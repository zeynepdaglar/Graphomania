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
    public class ContentManager : IContentServices
    {
        IContentDAL _contentDAL;

        public ContentManager(IContentDAL contentDAL)
        {
            _contentDAL = contentDAL;
        }

        public void ContentAdd(Content content)
        {
            _contentDAL.Insert(content);
        }

        public void ContentDelete(Content content)
        {
            throw new NotImplementedException();
        }

        public void ContentUpdate(Content content)
        {
            throw new NotImplementedException();
        }

        public Content GetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<Content> GetList(string parameter)
        {
            return _contentDAL.List(x=>x.ContentText.Contains(parameter));
        }

        public List<Content> GetList()
        {
            throw new NotImplementedException();
        }

        public List<Content> GetListByHeadingId(int id)
        {
            return _contentDAL.List(x=> x.HeadingId == id);
        }

        public List<Content> GetListByWriter(int id)
        {
            return _contentDAL.List(x=>x.WriterId == id);
        }
    }
}
