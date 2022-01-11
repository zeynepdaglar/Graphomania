using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Heading //diğer katmanlardan diğer sınıflardan erişebilmek için herkese açık yaptık
    {
        //id, heading name, date, writer
        //propertyler yapı olarak değişkenlere benzer ama farklılıklları vardır

        [Key]
        public int HeadingId { get; set; }

        [StringLength(500)]
        public string HeadingName { get; set; }

        public DateTime HeadingTime { get; set; }

        public bool HeadingStatus { get; set; }

        //ilişkili sütunun ıd kısmında yazan ismi aynen yazmalıyız yoksa hata oluşur
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public int WriterId { get; set; }
        public virtual Writer Writer { get; set; }


        public ICollection<Content> Contents { get; set; } //content sınıfı ile ilişki kurduk




    }
}
