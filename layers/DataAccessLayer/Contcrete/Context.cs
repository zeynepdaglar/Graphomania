using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Contcrete
{
    public class Context : DbContext
    {
        //başka bir katmandaki propertyleri yada sınıfları kullanmak istiyorsak o katmanı referans olarak eklemeliyiz
        //Context sınıfı buraya yazılmış olan DbSet türündeki propertyleri sqle birer tablo olarak yansıtıcak
        public Context(): base("Context")
        {

        }

        //About --> bizim projemizin içinde yer alan sınıfın ismi 
        //Abouts --> sqlde veritabanına yansıycak tablomuzun ismi
        public DbSet<About> Abouts { get; set; }
        public DbSet<Category> Categorys { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Heading> Headings { get; set; }
        public DbSet<Writer> Writers { get; set; }
    }
}
