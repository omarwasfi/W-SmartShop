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
        /// used Just to hold the stock during the selling operation
        /// </summary>
        public StockModel Stock { get; set; }

        /// <summary>
        /// The Product Model
        /// </summary>
        public ProductModel Product { get; set; }

        /// <summary>
        /// The quantity that the customer will buy
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// The SalePrice
        /// </summary>
        public decimal SalePrice { get; set; }

        /// <summary>
        /// The Discount 
        /// </summary>
        public decimal Discount { get; set; }

        

        /// <summary>
        /// The salePrice - IncomePrice of the product
        /// </summary>
        public decimal Profit { get; set; }


        // TODO - Remove It if we don't use !
        /// <summary>
        /// The total price after discount 
        /// </summary>
        public decimal TotalProductPrice { get; set; }

        /// <summary>
        /// Get only : the total price of the order product
        /// </summary>
        public decimal GetTotalPrice
        {
            get
            {
                decimal total = Quantity * SalePrice;
                decimal discount = Quantity * Discount;

                total -= discount;

                return total ;
            }
        }


        /// <summary>
        /// GetThe Profit (  salePrice - IncomePrice of the product )
        /// </summary>
        public decimal GetProfit
        {
            get
            {
                return SalePrice - Product.IncomePrice;
            }
        }

        /// <summary>
        /// get the total profit , GetProfit * Quantity
        /// </summary>
        public decimal GetTotalProfit
        {
            get
            {
                return GetProfit * Quantity;
            }
        }

       

    }
}
