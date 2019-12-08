using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Library
{
    public class SupplierValidator : AbstractValidator<SupplierModel>
    {
        public SupplierValidator()
        {
            RuleFor(p => p.Person)
              .Cascade(CascadeMode.StopOnFirstFailure)
              .NotNull().WithMessage("Choose Person !")
              .NotEmpty().WithMessage("choose person !");
        }
    }
}
