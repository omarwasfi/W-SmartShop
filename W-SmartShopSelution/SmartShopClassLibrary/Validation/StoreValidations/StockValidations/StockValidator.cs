using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;


namespace Library 
{
    public class StockValidator : AbstractValidator<StockModel>
    {
        public StockValidator()
        {
            RuleFor(p => p.Store)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull().WithMessage("unexpected Error From StockValidator : The StoreModel is NUll  ");
            
            RuleFor(p => p.Product)
              .Cascade(CascadeMode.StopOnFirstFailure)
              .NotNull().WithMessage("unexpected Error From StockValidator : The ProductModel is NUll  ");

            RuleFor(p => p.IncomePrice)
            .Cascade(CascadeMode.StopOnFirstFailure)
            .NotNull().WithMessage("unexpected Error From StockValidator : The IncomePrice is NUll  ")
            .NotEmpty().WithMessage("unexpected Error From StockValidator : The IncomePrice is Empty")
            .GreaterThanOrEqualTo(0).WithMessage(" unexpected Error From StockValidator : The IncomePrice is Less than 0");

            RuleFor(p => p.Date)
           .Cascade(CascadeMode.StopOnFirstFailure)
           .NotNull().WithMessage("unexpected Error From StockValidator : The Date is NUll  ")
           .NotEmpty().WithMessage("unexpected Error From StockValidator : The Date is Empty");

            RuleFor(p => p.Quantity)
         .Cascade(CascadeMode.StopOnFirstFailure)
         .NotNull().WithMessage("unexpected Error From StockValidator : The Date is NUll  ")
         .NotEmpty().WithMessage("unexpected Error From StockValidator : The Date is Empty")
         .GreaterThan(0).WithMessage(" unexpected Error From StockValidator : The IncomePrice is not greater than 0");

        }
    }
}
