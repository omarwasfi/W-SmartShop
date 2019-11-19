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
