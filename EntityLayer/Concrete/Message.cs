using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Message
    {
        [Key]
        public int MessageId { get; set; }

        [StringLength(50)]
        public string SenderMail { get; set; } //gönderen

        [StringLength(50)]
        public string ReciverMail { get; set; } //alıcı

        [StringLength(100)]
        public string Subject { get; set; } //Konu başlığı

        [StringLength(500)]
        public string MessageContent { get; set; } //içerik
        public DateTime MessageDate { get; set; }
    }
}
