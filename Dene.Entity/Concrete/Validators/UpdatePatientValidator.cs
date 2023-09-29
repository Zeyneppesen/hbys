using Dene.Entity.Concrete.DTO;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dene.Entity.Concrete.Validators
{
    public class UpdatePatientValidator: AbstractValidator<UpdatePatientRequest>
    {
        //public UpdatePatientValidator()
        //{
        //    RuleFor(s => s.Id).NotEmpty().WithMessage("mesajjjjjj");
        //}
    }
}
