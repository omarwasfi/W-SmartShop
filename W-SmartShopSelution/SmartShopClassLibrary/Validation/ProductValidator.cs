using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
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
                .NotEmpty().WithMessage("The Product {PropertyName} Should not be Empty !")
                .NotNull().WithMessage("Enter the product {PropertyName} !");

            RuleFor(p => p.SalePrice )
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("The Product {PropertyName} Should not be Empty !")
                .NotNull().WithMessage("Enter the product {PropertyName} !");
            RuleFor(p => p.BarCode)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty().WithMessage("The Product {PropertyName} Should not be Empty !")
                .NotNull().WithMessage("Enter the product {PropertyName} !");

            RuleFor(p => p)
               .Cascade(CascadeMode.StopOnFirstFailure)
               .Must(SalePriceIsMoreThanTheIncomePrice).WithMessage("The Sale price has to be more than the income price !");
        }
        
        /// <summary>
        /// Check if the Sale Price of the product is greater than the Income Product of the product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        protected bool SalePriceIsMoreThanTheIncomePrice(ProductModel product)
        {
            if(product.SalePrice > product.IncomePrice)
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
