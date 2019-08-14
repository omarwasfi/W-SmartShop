using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class OrderProductModel
    {
        public int Id { get; set; }

        /// <summary>
        /// used Just to hold the stock during the selling operation
        /// </summary>
        public StockModel Stock { get; set; }

        public ProductModel Product { get; set; }

        public int Quantity { get; set; }

        public decimal SalePrice { get; set; }

        public decimal Discount { get; set; }

        public decimal TotalProductPrice { get; set; }

        /// <summary>
        /// Get only : the total price of the order product
        /// </summary>
        public decimal TotalPrice
        {
            get
            {
                decimal total = Quantity * SalePrice;
                decimal discount = Quantity * Discount;

                total -= discount;

                return total ;
            }
        }

    }
}
