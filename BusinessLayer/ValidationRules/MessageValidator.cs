using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class MessageValidator : AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(x => x.SenderMail).NotEmpty().WithMessage("Gönderici adını boş geçemezsiniz");
            RuleFor(x => x.SenderMail).NotEmpty().MinimumLength(11);
            RuleFor(x => x.SenderMail).MaximumLength(50);


            RuleFor(x => x.ReciverMail).NotEmpty().WithMessage("Alıcı adını boş geçemezsiniz");
            RuleFor(x => x.ReciverMail).MinimumLength(11); //x@gmail.com
            RuleFor(x => x.ReciverMail).MaximumLength(50);

            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu başlığını boş geçemezsiniz");
            RuleFor(x => x.Subject).MinimumLength(3);
            RuleFor(x => x.Subject).MaximumLength(100);


            RuleFor(x => x.MessageContent).NotEmpty().WithMessage("Mesaj içeriğini boş geçemezsiniz");
            RuleFor(x => x.MessageContent).MinimumLength(3);
            RuleFor(x => x.MessageContent).MaximumLength(500);
        }
    }
}
