using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;


namespace Library
{
    public class IncomeOrderProductRecordValidator : AbstractValidator<IncomeOrderProductRecordModel>
    {
        public IncomeOrderProductRecordValidator()
        {
            RuleFor(p => p)
              .Cascade(CascadeMode.StopOnFirstFailure)
              .NotNull().WithMessage("unexpected Error From IncomeOrderProductRecordValidator : The IncomeOrderProductRecordModel is NUll  ");

            RuleFor(p => p.Stock.Store)
              .Cascade(CascadeMode.StopOnFirstFailure)
              .NotNull().WithMessage("unexpected Error From IncomeOrderProductRecordValidator : The StoreModel is NUll  ");

            RuleFor(p => p.Stock.Product)
             .Cascade(CascadeMode.StopOnFirstFailure)
             .NotNull().WithMessage("Select the product ");

           RuleFor(p => p.Stock.IncomePrice)
          .Cascade(CascadeMode.StopOnFirstFailure)
          .NotNull().WithMessage("unexpected Error From IncomeOrderProductRecordValidator : The IncomePrice is NUll  ")
          .GreaterThanOrEqualTo(0).WithMessage(" The IncomePrice can't be  is Less than 0");

            RuleFor(p => p.Stock.SalePrice)
           .Cascade(CascadeMode.StopOnFirstFailure)
            .NotNull().WithMessage("unexpected Error From IncomeOrderProductRecordValidator : The Sale is NUll  ")
          .GreaterThanOrEqualTo(0).WithMessage(" unexpected Error From IncomeOrderProductRecordValidator : The SalePrice is Less than 0");

            RuleFor(p => p.Stock.Date)
          .Cascade(CascadeMode.StopOnFirstFailure)
          .NotNull().WithMessage("unexpected Error From IncomeOrderProductRecordValidator : The Date is NUll  ")
          .NotEmpty().WithMessage("unexpected Error From IncomeOrderProductRecordValidator : The Date is Empty");

            RuleFor(p => p.Stock.Quantity)
             .Cascade(CascadeMode.StopOnFirstFailure)
         .NotNull().WithMessage("unexpected Error From IncomeOrderProductRecordValidator : The Quantity is NUll  ")
          .NotEmpty().WithMessage("The Quantity should be greater than 0")
          .GreaterThan(0).WithMessage(" The Quantity should be greater than 0");

            RuleFor(p => p.IncomeOrderProduct.Product)
             .Cascade(CascadeMode.StopOnFirstFailure)
             .NotNull().WithMessage("Choose The  {PropertyName}")
             .NotEmpty().WithMessage("Choose The  {PropertyName}");

            RuleFor(p => p.IncomeOrderProduct.IncomePrice)
          .Cascade(CascadeMode.StopOnFirstFailure)
          .NotNull().WithMessage("Enter The  {PropertyName}")
          .GreaterThanOrEqualTo(0).WithMessage(" The  {PropertyName} can't be less than 0");

            RuleFor(p => p.IncomeOrderProduct.Quantity)
              .Cascade(CascadeMode.StopOnFirstFailure)
              .NotNull().WithMessage("Enter The  {PropertyName}")
              .NotEqual(0).WithMessage("The {PropertyName} should be more than 0")
              .GreaterThan(0).WithMessage("The {PropertyName} should be more than 0");

        }
    }
}
