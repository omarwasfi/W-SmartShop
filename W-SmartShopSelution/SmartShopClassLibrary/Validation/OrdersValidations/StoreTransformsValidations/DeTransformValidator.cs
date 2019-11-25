using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;


namespace Library
{
    public class DeTransformValidator : AbstractValidator<DeTransformModel>
    {
        public DeTransformValidator()
        {
            RuleFor(p => p.Staff)
              .Cascade(CascadeMode.StopOnFirstFailure)
              .NotNull().WithMessage("unexpected Error From DeTransformValidator : The StaffModel is NUll  ");
            RuleFor(p => p.Store)
                    .Cascade(CascadeMode.StopOnFirstFailure)
                    .NotNull().WithMessage("unexpected Error From DeTransformValidator : The StoreModel is NUll  ");
            RuleFor(p => p.Date)
                   .Cascade(CascadeMode.StopOnFirstFailure)
                   .NotNull().WithMessage("unexpected Error From DeTransformValidator : The Date is NUll  ");
            RuleFor(p => p.FromStore)
                 .Cascade(CascadeMode.StopOnFirstFailure)
                   .NotNull().WithMessage("unexpected Error From DeTransformValidator : The FromStore is NUll  ")
                   .NotEmpty().WithMessage("Choose the store that you want to detransform the money from !");
            RuleFor(p => p.TotalMoney)
                   .Cascade(CascadeMode.StopOnFirstFailure)
                   .NotNull().WithMessage("unexpected Error From DeTransformValidator : The TotalMoney is NUll  ")
                   .NotEmpty().WithMessage("Enter The amount of money of the Transform")
                   .GreaterThan(0).WithMessage("The transform can't be less than 0");

            RuleFor(p => p)
           .Cascade(CascadeMode.StopOnFirstFailure)
           .Must(IsTotalMoneyLessOfEqualToStoreShoppeWallet).WithMessage("The Amount of money can't be more the store Shoppe Wallet");



        }

        /// <summary>
        /// Checks if the totalMoney of the detransform is less than or equal to the store.GetShoppeWallet
        /// </summary>
        /// <param name="deTransform"></param>
        /// <returns></returns>
        protected bool IsTotalMoneyLessOfEqualToStoreShoppeWallet(DeTransformModel deTransform)
        {
            if (deTransform.TotalMoney <= deTransform.Store.GetShopeeWallet)
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
