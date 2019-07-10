using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public static class OrderProduct
    {
        /// <summary>
        /// Get the Price and Quantity to return Total Price
        /// Total Price = Price * Quantity ( Trigers When Product Selected Or Quantity Increased)
        /// </summary>
        /// <param name="price"> Product Price </param>
        /// <param name="quantity"> Quantity </param>
        /// <returns></returns>
        public static decimal GetTotalPriceValue(decimal price, int quantity)
        {
            return price * quantity;
        }

        /// <summary>
        /// Get product model and discount 
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
        // Discount = Old Price - Price (Trigger when Price Change)
    }
}
