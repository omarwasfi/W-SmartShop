using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public static class OrderProductRecord
    {
        /// <summary>
        /// Calculates the discount and the profit Then set then to the OrderProduct
        /// </summary>
        /// <param name="orderProductRecord"></param>
        /// <returns></returns>
        public static OrderProductRecordModel DiscountAndProfitCalculations(OrderProductRecordModel orderProductRecord)
        {
            decimal discount = orderProductRecord.Stock.SalePrice - orderProductRecord.OrderProduct.SalePrice;
            if(discount < 0)
            {
                discount = 0;
                orderProductRecord.OrderProduct.Discount = discount;
            }
            else
            {
                orderProductRecord.OrderProduct.Discount = discount;
            }
            decimal profit = orderProductRecord.OrderProduct.SalePrice - orderProductRecord.Stock.IncomePrice;
            orderProductRecord.OrderProduct.Profit = profit;
           
            return orderProductRecord;
        }
    }
}
