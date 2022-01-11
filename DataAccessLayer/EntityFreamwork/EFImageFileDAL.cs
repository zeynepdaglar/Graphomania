using DataAccessLayer.Abstract;
using DataAccessLayer.Contcrete.Repositories;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFreamwork
{
    public class EFImageFileDAL : GenericRepository<ImageFile>, IImageFileDAL
    {
    }
}
