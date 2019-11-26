using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;


namespace Library
{
    public class BrandValidator : AbstractValidator<BrandModel>
    {
        public BrandValidator()
        {
            RuleFor(p => p.Name)
               .Cascade(CascadeMode.StopOnFirstFailure)
               .NotEmpty().WithMessage("The Brand {PropertyName} Should not be Empty !")
               .NotNull().WithMessage("Enter the Brand {PropertyName} !");
        }
    }
}
