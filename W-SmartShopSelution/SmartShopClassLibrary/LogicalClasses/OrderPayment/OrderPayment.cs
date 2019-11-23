using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public static class OrderPayment
    {

        /// <summary>
        /// Search in all orders to find the OrderPayment Then return the Order
        /// </summary>
        /// <param name="orderPayment"></param>
        /// <returns></returns>
        public static OrderModel GetTheOrder(OrderPaymentModel orderPayment)
        {
            foreach (OrderModel order in PublicVariables.Orders)
            {
                OrderPaymentModel orderPaymentModel;
                orderPaymentModel = order.OrderPayments.Find(x => x == orderPayment);

                if (orderPaymentModel != null)
                {
                    return order;
                }
            }
            return null;
        }
    }
}
