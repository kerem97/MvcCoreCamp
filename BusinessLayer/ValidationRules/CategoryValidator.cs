﻿using EntityLayer.Concrete;
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
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Kategori Adı Boş Geçilemez");
            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("Açıklama Alanı Boş Geçilemez");
            RuleFor(x => x.CategoryName).MaximumLength(50).WithMessage("Lütfen En Fazla 50 Karakter Girişi Yapınız");
            RuleFor(x => x.CategoryName).MinimumLength(2).WithMessage("Lütfen En Az 2 Karakter Girişi Yapınız");
        }
    }
}
