using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;



namespace Library
{
    public class TransformValidator : AbstractValidator<TransformModel>
    {
        public TransformValidator()
        {
            RuleFor(p => p.Staff)
              .Cascade(CascadeMode.StopOnFirstFailure)
              .NotNull().WithMessage("unexpected Error From TransformValidator : The StaffModel is NUll  ");
            RuleFor(p => p.Store)
                    .Cascade(CascadeMode.StopOnFirstFailure)
                    .NotNull().WithMessage("unexpected Error From TransformValidator : The StoreModel is NUll  ");
            RuleFor(p => p.Date)
                   .Cascade(CascadeMode.StopOnFirstFailure)
                   .NotNull().WithMessage("unexpected Error From TransformValidator : The Date is NUll  ");
            RuleFor(p => p.ToStore)
                 .Cascade(CascadeMode.StopOnFirstFailure)
                   .NotNull().WithMessage("unexpected Error From TransformValidator : The ToStore is NUll  ")
                   .NotEmpty().WithMessage("Choose the store that you want to transform the money for !");
            RuleFor(p => p.TotalMoney)
                   .Cascade(CascadeMode.StopOnFirstFailure)
                   .NotNull().WithMessage("unexpected Error From TransformValidator : The TotalMoney is NUll  ")
                   .NotEmpty().WithMessage("Enter The amount of money of the Transform")
                   .GreaterThan(0).WithMessage("The transform can't be less than 0")
                   .LessThanOrEqualTo(PublicVariables.Organization.GetFreeMoney).WithMessage("The Amount of money can't be more the FreeMoney");
        }
    }
}
