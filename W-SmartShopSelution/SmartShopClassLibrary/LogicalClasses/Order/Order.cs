﻿using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Library
{
    public static class Order
    {

        /// <summary>
        /// Calculate all Payments to get the total paid
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public static decimal GetTotalPaid(OrderModel order)
        {
            decimal paid = new decimal();
            foreach(OrderPaymentModel orderPayment in order.OrderPayments)
            {
                paid += orderPayment.Paid;
            }
            return paid;
        }

        /// <summary>
        /// Calculate the rest of the money not Paid
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public static decimal GetTotalNotPaid(OrderModel order)
        {
            decimal notPaid = new decimal();
            notPaid = order.GetTotalPrice - order.GetTotalPaid;
            return notPaid;
        }

        /// <summary>
        /// The actual profit that the customer paid means( if the totalPaid more than the incomePrice -> actual profit = totalPaid - incomePrice)
        /// </summary>
        public static decimal GetReceivedProfit(OrderModel order)
        {
            decimal receivedProfit = new decimal();
            decimal totalIncomePrice = new decimal();

            foreach(OrderProductModel orderProduct in order.OrderProducts)
            {
                totalIncomePrice += orderProduct.GetTotalIncomePrice;
            }

            if(order.GetTotalPaid > totalIncomePrice)
            {
                receivedProfit = order.GetTotalPaid - totalIncomePrice;
            }

            return receivedProfit;
        }

        /// <summary>
        /// Filter list of orders by Customer
        /// </summary>
        /// <param name="orders"></param>
        /// <param name="customer"></param>
        /// <returns></returns>
        public static List<OrderModel> FilterOrdersByCustomer(List<OrderModel> orders , CustomerModel customer )
        {
            List<OrderModel> FOrders = new List<OrderModel>();

            foreach(OrderModel order in orders)
            {
                if (order.Customer.Id == customer.Id)
                {
                    FOrders.Add(order);
                }
            }

            return FOrders;

        }

        /// <summary>
        /// Filter orders by order id
        /// </summary>
        /// <param name="orders"></param>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public static List<OrderModel>FilterOrdersByOrderId(List<OrderModel> orders , string orderId)
        {
            List<OrderModel> fOrders = new List<OrderModel>();
            foreach(OrderModel order in orders)
            {
                if(Regex.IsMatch(order.Id.ToString(), Regex.Escape(orderId), RegexOptions.IgnoreCase))
                {
                    fOrders.Add(order);
                }
            }

            return fOrders;

        }


        /// <summary>
        /// Filter orders by Customer name
        /// </summary>
        /// <param name="orders"></param>
        /// <param name="customerName"></param>
        /// <returns></returns>
        public static List<OrderModel> FilterOrdersByCustomerName(List<OrderModel> orders, string customerName)
        {
            List<OrderModel> fOrders = new List<OrderModel>();
            foreach (OrderModel order in orders)
            {
                if (Regex.IsMatch(order.Customer.Person.FullName, Regex.Escape(customerName), RegexOptions.IgnoreCase))
                {
                    fOrders.Add(order);
                }
            }

            return fOrders;

        }


        /// <summary>
        /// Filter orders by Date
        /// </summary>
        /// <param name="orders"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public static List<OrderModel> FilterOrdersByDate(List<OrderModel> orders, DateTime date)
        {
            List<OrderModel> fOrders = new List<OrderModel>();
            foreach (OrderModel order in orders)
            {

                if(order.DateTimeOfTheOrder.Year == date.Year && order.DateTimeOfTheOrder.Month == date.Month && order.DateTimeOfTheOrder.Day == date.Day)
                {
                    fOrders.Add(order);
                }

            }

            return fOrders;

        }

       


       

    }
}
