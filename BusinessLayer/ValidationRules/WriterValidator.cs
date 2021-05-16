using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator : AbstractValidator<Writer>
    {
        public WriterValidator()
        {
            RuleFor(w => w.WriterName).NotEmpty().WithMessage("Yazar Adını Boş Geçemezsini");
            RuleFor(w => w.WriterSurname).NotEmpty().WithMessage("Yazar Soyadını Boş Geçemezsiniz");
            RuleFor(w => w.WriterAbout).NotEmpty().WithMessage("Yazar Bilgisini Boş Geçemezsiniz");
            RuleFor(w => w.WriterAbout).Must(ContainsA).WithMessage("Yazar Bilgisi İçerisinde 'A' Harfi Bulunmak Zorundadır");
            RuleFor(w => w.WriterName).MinimumLength(3).WithMessage("Yazar Adını En Az 3 Karakter Giriniz");
            RuleFor(c => c.WriterName).MaximumLength(20).WithMessage("Yazar Adını En Fazla 20 Karakter Giriniz");
            RuleFor(w => w.WriterSurname).MinimumLength(3).WithMessage("Yazar Soyadını En Az 3 Karakter Giriniz");
            RuleFor(c => c.WriterSurname).MaximumLength(20).WithMessage("Yazar Soyadını En Fazla 20 Karakter Giriniz");
            
        }

        private bool ContainsA(string arg)
        {
            if(arg.Contains('a') || arg.Contains('A'))
            {
                return true;
            }
            return false;

        }

    }
}
