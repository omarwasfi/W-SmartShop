using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;


namespace Library
{
    public class OrderValidator : AbstractValidator<OrderModel>
    {
        public OrderValidator()
        {
            RuleFor(p => p.Customer)
             .Cascade(CascadeMode.StopOnFirstFailure)
             .NotNull().WithMessage("Choose The  {PropertyName}")
             .NotEmpty().WithMessage("Choose The  {PropertyName}");

            RuleFor(p => p.DateTimeOfTheOrder)
            .Cascade(CascadeMode.StopOnFirstFailure)
            .NotNull().WithMessage("unexpected Error From OrderValidator : The DateTimeOfTheOrder is NUll ")
            .NotEmpty().WithMessage("Choose The  {PropertyName} of the incomeOrder");

            RuleFor(p => p.Store)
            .Cascade(CascadeMode.StopOnFirstFailure)
            .NotNull().WithMessage(" unexpected Error From OrderValidator : The StoreModel is NUll  ")
            .NotEmpty().WithMessage("unexpected Error From OrderValidator : The StoreModel is Empty ");

            RuleFor(p => p.Staff)
           .Cascade(CascadeMode.StopOnFirstFailure)
           .NotNull().WithMessage(" unexpected Error From OrderValidator : The StaffModle is NUll  ")
           .NotEmpty().WithMessage("unexpected Error From OrderValidator : The StaffModle is Empty ");

            RuleFor(p => p.OrderProducts)
           .Cascade(CascadeMode.StopOnFirstFailure)
           .NotNull().WithMessage(" unexpected Error From OrderValidator : The OrderProducts is NUll  ")
           .NotEmpty().WithMessage("Add Products to the Order ! ");

            RuleFor(p => p.GetTotalPaid)
           .Cascade(CascadeMode.StopOnFirstFailure)
           .NotNull().WithMessage(" unexpected Error From OrderValidator : The GetTotalPaid is NUll  ")
           .GreaterThanOrEqualTo(0).WithMessage("unexpected Error From OrderValidator : The GetTotalPaid is Less Than 0");

            RuleFor(p => p)
          .Cascade(CascadeMode.StopOnFirstFailure)
          .Must(IsTheTotalPaidAndNotPaidEquanlsTotalPrice).WithMessage(" unexpected Error From OrderValidator : There is a problem in Calculations !!!");
        }

        protected bool IsTheTotalPaidAndNotPaidEquanlsTotalPrice(OrderModel Order)
        {
            if (Order.GetTotalPaid + Order.GetTotalNotPaid == Order.GetTotalPrice)
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
