using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;


namespace Library
{
    public class IncomeOrderValidator : AbstractValidator<IncomeOrderModel>
    {
        public IncomeOrderValidator()
        {
            RuleFor(p => p.Supplier)
             .Cascade(CascadeMode.StopOnFirstFailure)
             .NotNull().WithMessage("Choose The  {PropertyName}")
             .NotEmpty().WithMessage("Choose The  {PropertyName}");

            RuleFor(p => p.Date)
            .Cascade(CascadeMode.StopOnFirstFailure)
            .NotNull().WithMessage(" Choose The  {PropertyName} of the incomeOrder")
            .NotEmpty().WithMessage("Choose The  {PropertyName} of the incomeOrder");

            RuleFor(p => p.Store)
            .Cascade(CascadeMode.StopOnFirstFailure)
            .NotNull().WithMessage(" unexpected Error From IncomeOrderValidator : The StoreModel is NUll  ")
            .NotEmpty().WithMessage("unexpected Error From IncomeOrderValidator : The StoreModel is Empty ");

         RuleFor(p => p.Staff)
        .Cascade(CascadeMode.StopOnFirstFailure)
        .NotNull().WithMessage(" unexpected Error From IncomeOrderValidator : The StaffMolde is NUll  ")
        .NotEmpty().WithMessage("unexpected Error From IncomeOrderValidator : The StaffMolde is Empty ");

          RuleFor(p => p.IncomeOrderProducts)
         .Cascade(CascadeMode.StopOnFirstFailure)
         .NotNull().WithMessage(" unexpected Error From IncomeOrderValidator : The StaffMolde is NUll  ")
         .NotEmpty().WithMessage("Add Products to the IncomeOrder ! ");

          RuleFor(p => p.GetTotalPaid)
         .Cascade(CascadeMode.StopOnFirstFailure)
         .NotNull().WithMessage(" unexpected Error From IncomeOrderValidator : The GetTotalPaid is NUll  ")
         .GreaterThanOrEqualTo(0).WithMessage("unexpected Error From IncomeOrderValidator : The GetTotalPaid is Less Than 0");

            RuleFor(p => p)
          .Cascade(CascadeMode.StopOnFirstFailure)
          .Must(IsTheTotalPaidAndNotPaidEquanlsTotalPrice).WithMessage(" unexpected Error From IncomeOrderValidator : There is a problem in Calculations !!!");
        }

        protected bool IsTheTotalPaidAndNotPaidEquanlsTotalPrice(IncomeOrderModel incomeOrder)
        {
            if(incomeOrder.GetTotalPaid + incomeOrder.GetTotalNotPaid == incomeOrder.GetTotalPrice)
            {
                return true;
            }
            else
            {
                return false;
            }

            
        }

    }
}
