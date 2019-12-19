using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;


namespace Library
{
    public class StaffSalaryValidator : AbstractValidator<StaffSalaryModel>
    {
        public StaffSalaryValidator()
        {
            RuleFor(p => p.Store)
            .Cascade(CascadeMode.StopOnFirstFailure)
            .NotNull().WithMessage("unexpected Error From StaffSalaryValidator : The StaffMode is NUll")
            .NotEmpty().WithMessage("unexpected Error From StaffSalaryValidator : The StaffModel is NUll");

            RuleFor(p => p.Staff)
           .Cascade(CascadeMode.StopOnFirstFailure)
           .NotNull().WithMessage("unexpected Error From StaffSalaryValidator : The StoreMode is NUll")
           .NotEmpty().WithMessage("unexpected Error From StaffSalaryValidator : The StoreMode is NUll");

            RuleFor(p => p.Date)
           .Cascade(CascadeMode.StopOnFirstFailure)
           .NotNull().WithMessage("unexpected Error From StaffSalaryValidator : The Date is NUll")
           .NotEmpty().WithMessage("unexpected Error From StaffSalaryValidator : The Date is NUll");
            
            RuleFor(p => p.Salary)
          .Cascade(CascadeMode.StopOnFirstFailure)
          .NotNull().WithMessage("unexpected Error From StaffSalaryValidator : The Salary is NUll")
          .NotEmpty().WithMessage("The Salary value can't be 0")
          .GreaterThan(0).WithMessage("The Salary value has to be more than 0")
          .LessThan(PublicVariables.Store.GetShopeeWallet).WithMessage("The Salary amount is more thant the shoppee wallet !");

           RuleFor(p => p.ToStaff)
        .Cascade(CascadeMode.StopOnFirstFailure)
        .NotNull().WithMessage("unexpected Error From StaffSalaryValidator : The ToStaff is NUll")
        .NotEmpty().WithMessage("unexpected Error From StaffSalaryValidator : The ToStaff is NUll");


        }
    }
}
