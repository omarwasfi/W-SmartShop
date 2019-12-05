using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;


namespace Library
{
    public class OrderProductRecordValidator : AbstractValidator<OrderProductRecordModel>
    {
        public OrderProductRecordValidator()
        {
            RuleFor(p => p)
             .Cascade(CascadeMode.StopOnFirstFailure)
             .NotNull().WithMessage("unexpected Error From OrderProductRecordValidator : The OrderProductRecordModel is NUll  ");

            RuleFor(p => p.Stock)
            .Cascade(CascadeMode.StopOnFirstFailure)
            .NotNull().WithMessage("Choose Stock !")
            .NotEmpty().WithMessage("Choose Stock !");
           

            RuleFor(p => p.OrderProduct)
           .Cascade(CascadeMode.StopOnFirstFailure)
           .NotNull().WithMessage("unexpected Error From OrderProductRecordValidator : The OrderProductModel is NUll  ");

            RuleFor(p => p.OrderProduct.Product)
          .Cascade(CascadeMode.StopOnFirstFailure)
          .NotNull().WithMessage("Choose a product and Stock Please")
           .NotEmpty().WithMessage("Choose a product and Stock Please");

            RuleFor(p => p.OrderProduct.Quantity)
          .Cascade(CascadeMode.StopOnFirstFailure)
          .NotNull().WithMessage("Enter the Quantity !")
           .NotEmpty().WithMessage("The Quantity can't be 0")
           .GreaterThan(0).WithMessage("The Quantity Should be more than 0");

            RuleFor(p => p.OrderProduct.SalePrice)
          .Cascade(CascadeMode.StopOnFirstFailure)
          .NotNull().WithMessage("unexpected Error From OrderProductRecordValidator : The SalePrice is NUll");

            RuleFor(p => p)
       .Cascade(CascadeMode.StopOnFirstFailure)
       .Must(IsDiscountLessThanOrEqualsSalePrice).WithMessage("The discount is more than the stock SalePrice ! reduce it ")
        .Must(IsTheOrderQuantityLessOfEquanlsTheInStock).WithMessage("There isn't enough of this stock in the inventory , reduce the quantity !");

        }

        protected bool IsDiscountLessThanOrEqualsSalePrice(OrderProductRecordModel orderProductRecord)
        {
            if(orderProductRecord.OrderProduct.Discount > orderProductRecord.Stock.SalePrice)
            {
                return false;
            }
            return true;
        }

        protected bool IsTheOrderQuantityLessOfEquanlsTheInStock(OrderProductRecordModel orderProductRecord)
        {
            if (orderProductRecord.OrderProduct.Quantity > orderProductRecord.Stock.Quantity)
            {
                return false;
            }
            return true;
        }
    }
}
