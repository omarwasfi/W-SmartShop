using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;


namespace Library
{
    public class IncomeOrderPaymentValidator : AbstractValidator<IncomeOrderPaymentModel>
    {
        public IncomeOrderPaymentValidator()
        {
            RuleFor(p => p.Staff)
            .Cascade(CascadeMode.StopOnFirstFailure)
            .NotNull().WithMessage("unexpected Error From IncomeOrderPaymentValidator : The StaffMode is NUll")
            .NotEmpty().WithMessage("unexpected Error From IncomeOrderPaymentValidator : The StaffModel is NUll");

            RuleFor(p => p.Store)
           .Cascade(CascadeMode.StopOnFirstFailure)
           .NotNull().WithMessage("unexpected Error From IncomeOrderPaymentValidator : The StoreMode is NUll")
           .NotEmpty().WithMessage("unexpected Error From IncomeOrderPaymentValidator : The StoreMode is NUll");

            RuleFor(p => p.Paid)
           .Cascade(CascadeMode.StopOnFirstFailure)
           .NotNull().WithMessage("unexpected Error From IncomeOrderPaymentValidator : The Paid is NUll")
           .NotEmpty().WithMessage("The paid value can't be 0")
           .GreaterThan(0).WithMessage("The paid value has to be more than 0")
           .LessThanOrEqualTo(PublicVariables.Store.GetShopeeWallet).WithMessage("The paid amount is more thant the shoppee wallet !");

            RuleFor(p => p.Date)
           .Cascade(CascadeMode.StopOnFirstFailure)
           .NotNull().WithMessage("unexpected Error From IncomeOrderPaymentValidator : The Date is NUll")
           .NotEmpty().WithMessage("unexpected Error From IncomeOrderPaymentValidator : The Date is NUll");
        }
    }
}
