using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    [Serializable]
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
        /// Calculate the IncomePrice for the Single Product
        /// </summary>
        public decimal GetIncomePrice 
        {
            get
            {
                return SalePrice - Profit;
            }
            
        }

        /// <summary>
        /// Calculate the IncomePrice for the OrderProduct  GetIncomePrice * (decimal)Quantity
        /// </summary>
        public decimal GetTotalIncomePrice
        {
            get
            {
              return GetIncomePrice * (decimal)Quantity;
            }
        }


    }
}
