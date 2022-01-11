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
    public class ImageFileManager : IImageFileServices
    {
        IImageFileDAL _ImageFileDal;

        public ImageFileManager(IImageFileDAL ımageFile)
        {
            _ImageFileDal = ımageFile;
        }

        public List<ImageFile> GetList()
        {
           return _ImageFileDal.List();
        }
    }
}
