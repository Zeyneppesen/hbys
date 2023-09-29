using Dene.Entity.Concrete.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dene.Entity.Concrete.Validators
{
    public class ChangePasswordValidator: AbstractValidator<ChangePasswordRequest>
 {   
    //    public ChangePasswordValidator()
    //{

    //    RuleFor(x => x.OldPassword)
    //        .NotEmpty().WithMessage("Şifre boş olamaz.")
    //        .Length(6, 50).WithMessage("Şifre uzunluğu minimum 6 maksimum 50 karakter olmalıdır.");
    //    RuleFor(x => x.NewPassword)
    //        .NotEmpty().WithMessage("Şifre boş olamaz.")
    //        .Length(6, 50).WithMessage("Şifre uzunluğu minimum 6 maksimum 50 karakter olmalıdır.");
    //    RuleFor(x => x.ConfirmPassword)
    //        .NotEmpty().WithMessage("Şifre boş olamaz.")
    //        .Length(6, 50).WithMessage("Şifre uzunluğu minimum 6 maksimum 50 karakter olmalıdır.");
    //}
    
    
}
}