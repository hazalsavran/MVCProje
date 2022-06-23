using EntityLayer.Concreate;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayes.ValidationRules
{
   public class WriterValidator: AbstractValidator<Writer>
    {
            public WriterValidator()
            {
                RuleFor(x => x.WriterName).NotEmpty().WithMessage("Yazar Adını Boş Geçemezsiniz");
                RuleFor(x => x.WriterSurname).NotEmpty().WithMessage("Yazar Soydını Boş Geçemezsiniz");
                RuleFor(x => x.WriterAbouth).MinimumLength(3).WithMessage("Lütfen en az 3 karakter giriniz");
                RuleFor(x => x.WriterSurname).MinimumLength(3).WithMessage("Lütfen en az 3 karakter giriniz");
                
            //RuleFor(x => x.WriterMail).Must(x => x != null && x.ToUpper().Contains("@gmail.com") ).WithMessage("Lütfen geçerli bir mail adresi giriniz");
        }
        
    }
}
