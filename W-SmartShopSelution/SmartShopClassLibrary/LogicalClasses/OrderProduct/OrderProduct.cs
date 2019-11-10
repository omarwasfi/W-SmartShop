using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public static class OrderProduct
    {

        /// <summary>
        /// Get the profit of single of this OrderProduct 
        /// </summary>
        /// <param name="stock">The stock</param>
        /// <param name="salePrice"> The sale price that the customer will pay for a single</param>
        /// <returns></returns>
        public static decimal GetProfit(StockModel stock , decimal salePrice)
        {
            decimal profit = new decimal();
            profit = salePrice - stock.IncomePrice;
            return profit;
        }

        /// <summary>
        /// Get the Price and Quantity to return Total Price
        /// Total Price = Price * Quantity ( Trigers When Product Selected Or Quantity Increased)
        /// </summary>
        /// <param name="price"> Product Price </param>
        /// <param name="quantity"> Quantity </param>
        /// <returns></returns>
        public static decimal GetTotalPriceValue(decimal price, float quantity)
        {
            return price * (decimal)quantity;
        }

        /// <summary>
        /// -OLD- Get product model and discount 
        /// to calculate the price If discount > sale price it will return -1
        /// // Price = OldPrice - Discount (Trigger When Discount change)
        /// </summary>
        /// <param name="discount"></param>
        /// <param name="product"></param>
        /// <returns></returns>
        public static decimal GetPriceValue(decimal discount, ProductModel product)
        {
            if (discount > product.SalePrice)
            {
                return -1;
            }
            else {return product.SalePrice - discount; }

        }



        /// <summary>
        /// Get discount when price value changes
        /// // Discount = Old Price - Price (Trigger when Price Change)
        /// </summary>
        /// <param name="price"></param>
        /// <param name="product"></param>
        /// <returns>
        /// -1 if price < 0
        /// 0 if there is no discount
        /// discount value
        /// </returns>
        public static decimal GetDiscountValue(decimal price,ProductModel product)
        {
            decimal discount;
            if(price > product.SalePrice)
            {
                return 0;

            }
            else if (price < 0)
            {
                return -1;
            }
            else
            {
                discount = product.SalePrice - price;
                return discount;
            }

        }


    }
}
