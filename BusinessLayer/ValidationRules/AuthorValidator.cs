using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class AuthorValidator : AbstractValidator<Author>
    {
        public AuthorValidator()
        {
            RuleFor(x => x.AuthorName).NotEmpty().WithMessage("Bu kısım boş geçilemez");
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Bu kısım boş geçilemez");
            RuleFor(x => x.Password).NotEmpty().WithMessage("Bu kısım boş geçilemez");
            RuleFor(x => x.AuthorName).MinimumLength(2).WithMessage("Lütfen en az 2 karakter giriniz"); 
        }
    }
}
