using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()
        {
            RuleFor(c => c.CategoryName).NotEmpty().WithMessage("Kategori Adını Boş Geçemezsini");
            RuleFor(c => c.CategoryDescription).NotEmpty().WithMessage("Kategori Açıklamasını Boş Geçemezsiniz");
            RuleFor(c => c.CategoryName).MinimumLength(3).WithMessage("Kategori Adını En Az 3 Karakter Giriniz");
            RuleFor(c => c.CategoryName).MaximumLength(20).WithMessage("Kategori Adını En Fazla 20 Karakter Giriniz");
        }
    }
}
