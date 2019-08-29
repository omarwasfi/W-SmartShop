using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class InstallmentProductModel
    {
        public int Id { get; set; }

        public ProductModel Product { get; set; }

        public int Quantity { get; set; }

        /// <summary>
        /// The price of one peace after Discount
        /// </summary>
        public decimal InstallmentPrice { get; set; }

        public decimal Discount { get; set; }

        /// <summary>
        /// Get the total Installment Price
        /// </summary>
        public decimal GetTotalInstallmentPrice { get { return InstallmentPrice * Quantity; } }

        /// <summary>
        /// Get the total price before installment 
        /// </summary>
        public decimal GetTotalPriceBeforeInstallment { get { return Product.SalePrice * Quantity; } }
    }
}
