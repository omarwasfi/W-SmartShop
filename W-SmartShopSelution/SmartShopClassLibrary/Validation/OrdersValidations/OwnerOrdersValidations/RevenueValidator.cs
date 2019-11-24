using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace Library
{
    public class RevenueValidator : AbstractValidator<RevenueModel>
    {
       public RevenueValidator()
        {
            RuleFor(p => p.Staff)
               .Cascade(CascadeMode.StopOnFirstFailure)
               .NotNull().WithMessage("unexpected Error From InvestmentValidator : The StaffModel is NUll  ");
            RuleFor(p => p.Store)
                    .Cascade(CascadeMode.StopOnFirstFailure)
                    .NotNull().WithMessage("unexpected Error From InvestmentValidator : The StoreModel is NUll  ");
            RuleFor(p => p.Date)
                   .Cascade(CascadeMode.StopOnFirstFailure)
                   .NotNull().WithMessage("unexpected Error From InvestmentValidator : The Date is NUll  ");
            RuleFor(p => p.TotalMoney)
                   .Cascade(CascadeMode.StopOnFirstFailure)
                   .NotNull().WithMessage("unexpected Error From InvestmentValidator : The TotalMoney is NUll  ")
                   .NotEmpty().WithMessage("Enter The amount of money of the Revenue")
                   .LessThan(0).WithMessage("The Revenue can't be less than 0");
        }
    }
}
