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

        // TODO - Remove this probity "Are u kidding me !!"
        /// <summary>
        /// -OLD- used Just to hold the stock during the selling operation
        /// </summary>
        public StockModel Stock { get; set; }

        /// <summary>
        /// The Product Model
        /// </summary>
        public ProductModel Product { get; set; }

        /// <summary>
        /// The quantity that the customer will buy
        /// </summary>
        public float Quantity { get; set; }

        /// <summary>
        /// The SalePrice Of single
        /// </summary>
        public decimal SalePrice { get; set; }

        /// <summary>
        /// The Discount 
        /// </summary>
        public decimal Discount { get; set; }

        

        /// <summary>
        /// The Profit of single  salePrice - IncomePrice of the Stock
        /// </summary>
        public decimal Profit { get; set; }




        /// <summary>
        /// Get only : the total price of the order product
        /// </summary>
        public decimal GetTotalPrice
        {
            get
            {
                decimal total = (decimal)Quantity * SalePrice;
                decimal discount = (decimal)Quantity * Discount;

                total -= discount;

                return total ;
            }
        }

        /// <summary>
        /// get the total profit , GetProfit * Quantity
        /// </summary>
        public decimal GetTotalProfit
        {
            get
            {
                return Profit * (decimal)Quantity;
            }
        }


         // TODO - Remove It if we don't use !
        /// <summary>
        /// -OLD- The total price after discount 
        /// </summary>
        public decimal TotalProductPrice { get; set; }

        /// <summary>
        /// -OLD- GetThe Profit (  salePrice - IncomePrice of the product )
        /// </summary>
        public decimal GetProfit
        {
            get
            {
                return SalePrice - Product.IncomePrice;
            }
        }



    }
}
