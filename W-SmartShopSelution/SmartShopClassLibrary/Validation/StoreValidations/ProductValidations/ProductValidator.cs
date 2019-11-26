using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    /// <summary>
    /// The Barcode Has to be Unique
    /// The SerialNumbers not has to be unique
    /// </summary>
    public class ProductValidator : AbstractValidator<ProductModel>
    {
        public ProductValidator()
        {
            RuleFor(p => p.Name)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("The Product {PropertyName} Should not be Empty !")
                .NotNull().WithMessage("Enter the product {PropertyName} !");

            RuleFor(p => p.IncomePrice)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .GreaterThanOrEqualTo(0).WithMessage("The Product {PropertyName} can't be less than 0");

            RuleFor(p => p.SalePrice )
                .Cascade(CascadeMode.StopOnFirstFailure)
                .GreaterThanOrEqualTo(0).WithMessage("The Product {PropertyName} can't be less than 0");
            
            RuleFor(p => p.BarCode)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("The Product {PropertyName} Should not be Empty. Generate a new one !")
                .NotNull().WithMessage("Enter the product {PropertyName}. Generate a new one !")
                .Must(IsTheBarCodeUnique).WithMessage("This {PropertyName} is used before");
            RuleFor(p => p.Category)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull().WithMessage("unexpected Error From ProductValidator: The {PropertyName} is NUll !")
                .NotEmpty().WithMessage("unexpected Error From ProductValidator : The {PropertyName} is NUll !");
            
            RuleFor(p => p.Brand)
               .Cascade(CascadeMode.StopOnFirstFailure)
               .NotNull().WithMessage("unexpected Error From ProductValidator: The {PropertyName} is NUll !")
               .NotEmpty().WithMessage("unexpected Error From ProductValidator : The {PropertyName} is NUll !");

        }

        /// <summary>
        /// Check if the barcode unique 
        /// </summary>
        /// <param name="barcode"></param>
        /// <returns>true if the barcode unique</returns>
        protected bool IsTheBarCodeUnique(string barcode)
        {
            return Product.CheckIfTheProductBarCodeUnique(barcode);
        }

       

        
        
    }
}
