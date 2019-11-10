using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;


namespace Library
{
    public class OrderProductValidator : AbstractValidator<OrderProductModel>
    {

        public OrderProductValidator()
        {
            RuleFor(p => p.Product)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull().WithMessage("unexpected Error From OrderProductValidator : The ProductModel is NUll  ");

            RuleFor(p => p.Quantity)
               .Cascade(CascadeMode.StopOnFirstFailure)
               .NotNull().WithMessage("Enter The  {PropertyName}")
               .NotEmpty().WithMessage("Enter The  {PropertyName}")
               .NotEqual(0).WithMessage("The {PropertyName} should be more than 0")
               .LessThan(0).WithMessage("The {PropertyName} can't be less than 0");

            RuleFor(p => p.SalePrice)
               .Cascade(CascadeMode.StopOnFirstFailure)
               .NotNull().WithMessage("Enter The  {PropertyName}")
               .NotEmpty().WithMessage("Enter The  {PropertyName}")
               .LessThan(0).WithMessage("The {PropertyName} can't be less than 0");

            RuleFor( p => p.Profit)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull().WithMessage("unexpected Error From OrderProductValidator : The Profit is NUll  ");
        }
    }
}
