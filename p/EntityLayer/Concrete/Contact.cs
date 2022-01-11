using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Contact //iletişim
    {
        [Key]
        public int ContactId { get; set; }

        [StringLength(50)]
        public string Username { get; set; }

        [StringLength(50)]
        public string UserEmail { get; set; }

        [StringLength(50)]
        public string Subject { get; set; } //konu

        [StringLength(1000)]
        public string Message { get; set; }

    }
}
