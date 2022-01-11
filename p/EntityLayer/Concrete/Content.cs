using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Content //içerik
    {
        [Key]
        public int ContentId { get; set; }

        [StringLength(1000)]
        public string ContentText { get; set; } //içerik metni

        public DateTime ContentDate { get; set; }

        //Content başlığı
        public int HeadingId { get; set; }
        public virtual Heading Heading { get; set; }

        //Content(ierik) yazarı
        public int? WriterId { get; set; }
        public virtual Writer Writer { get; set; }
    }
}
