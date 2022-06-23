using EntityLayer.Concreate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayes.ValidationRules
{
  public  class MessageValidator: AbstractValidator<Message>
    {
        public MessageValidator()
        {
            RuleFor(x => x.ReceiverMail).NotEmpty().WithMessage("Alıcı alanı boş geçilemez");
            RuleFor(x => x.Subject).NotEmpty().WithMessage("Konu alanı boş geçilemez");
            RuleFor(x => x.MessageContent).NotEmpty().WithMessage("İçerik boş geçilemez");
            RuleFor(x => x.ReceiverMail).EmailAddress().WithMessage("Geçerli bir email adresi giriniz.");
            RuleFor(x => x.Subject).MinimumLength(3).WithMessage("Lütfen en az 3 karakter giriniz");
            RuleFor(x => x.Subject).MaximumLength(50).WithMessage("Konu en fazla 50 karakter olabilir");

        }
    }
}
