using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;


namespace Library
{
    public class IncomeOrderProductValidator : AbstractValidator<IncomeOrderProductModel>
    {
        public IncomeOrderProductValidator()
        {

            RuleFor(p => p.Product)
              .Cascade(CascadeMode.StopOnFirstFailure)
              .NotNull().WithMessage("Choose The  {PropertyName}")
              .NotEmpty().WithMessage("Choose The  {PropertyName}");

            RuleFor(p => p.IncomePrice)
            .Cascade(CascadeMode.StopOnFirstFailure)
            .NotNull().WithMessage("Enter The  {PropertyName}")
            .GreaterThanOrEqualTo(0).WithMessage(" The  {PropertyName} can't be less than 0");

            RuleFor(p => p.Quantity)
              .Cascade(CascadeMode.StopOnFirstFailure)
              .NotNull().WithMessage("Enter The  {PropertyName}")
              .NotEmpty().WithMessage("Enter The  {PropertyName}")
              .NotEqual(0).WithMessage("The {PropertyName} should be more than 0")
              .GreaterThan(0).WithMessage("The {PropertyName} should be more than 0");

            RuleFor(p => p)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull().WithMessage("unexpected Error From IncomeOrderProductValidator : The IncomeOrderProduct is NUll  ");

        }
    }
}
