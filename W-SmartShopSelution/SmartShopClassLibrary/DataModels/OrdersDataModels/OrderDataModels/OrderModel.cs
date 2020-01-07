using System;
using System.Collections.Generic;

namespace Library
{
    [Serializable]
    /// <summary>
    /// Cash order contain:
    /// Database Id , Customer model ,  date and time , Store model , staff model , List of the Products
    /// </summary>
    public class OrderModel
    {
        /// <summary>
        /// database Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Customer model
        /// </summary>
        public CustomerModel Customer { get; set; }

        /// <summary>
        /// The Date and the time of this order
        /// </summary>
        public DateTime DateTimeOfTheOrder { get; set; }

        /// <summary>
        /// store model
        /// </summary>
        public StoreModel Store { get; set; }

        /// <summary>
        /// staff member
        /// </summary>
        public StaffModel Staff { get; set; }

        /// <summary>
        /// All the payments of the order
        /// </summary>
        public List<OrderPaymentModel> OrderPayments { get; set; }

        /// <summary>
        /// The details of the order Or any aditional information the user staff want to add
        /// </summary>
        public string Details { get; set; }

        /// <summary>
        /// List of order product model describe
        /// what products we have , the quantity , the price of each one , if there is a discount or not
        /// </summary>
        public List<OrderProductModel> OrderProducts { get; set; }

        /// <summary>
        /// Get the orderState ("DONE" , "Customer Should Receive" , "Customer Should Pay")
        /// </summary>
        public string GetOrderState 
        {
            get
            {
                if(GetTotalPaid == GetTotalPrice)
                {
                    return "DONE";
                }
                else if(GetTotalNotPaid > 0)
                {
                    return "Customer Should Pay";
                }
                else if(GetCustomerShouldReceive > 0)
                {
                    return "Customer Should Receive";
                }
                else
                {
                    return "Something wrong !";
                }
            }
        }

        /// <summary>
        /// Get all the total paid money
        /// </summary>
        public decimal GetTotalPaid
        {
            get
            {
                return Order.GetTotalPaid(this);
            }
        }

        /// <summary>
        /// Get the rest of the money that not paid 
        /// </summary>
        public decimal GetTotalNotPaid 
        {
            get
            {
                return Order.GetTotalNotPaid(this);
            }
        }

        /// <summary>
        /// What customer should receive ( has a value when the customer return a product and the shop didn't pay him hit money)
        /// </summary>
        public decimal GetCustomerShouldReceive 
        { 
            get
            {
                return GetTotalPaid - GetTotalPrice;
            }
        }

        /// <summary>
        /// Get the total Profit of this Order
        /// </summary>
        public decimal GetTotalProfit
        {
            get
            {
                decimal profit = new decimal();
                foreach (OrderProductModel orderProduct in OrderProducts)
                {
                    profit += orderProduct.GetTotalProfit;
                }

                return profit;
            }
        }

        /// <summary>
        /// The actual profit that the customer paid means( if the totalPaid more than the incomePrice -> actual profit = totalPaid - incomePrice)
        /// </summary>
        public decimal GetReceivedProfit
        {
            get
            {
               return Order.GetReceivedProfit(this);
            }
        }

        /// <summary>
        /// Calculate the total Price from each OrderProduct
        /// </summary>
        public decimal GetTotalPrice
        {
            get
            {
                decimal total = new decimal();
                foreach (OrderProductModel orderProduct in OrderProducts)
                {
                    total += orderProduct.GetTotalPrice;
                }
                return total;
            }
        }

        public int GetTheNumberOfOrderProducts
        {
            get
            {
                return OrderProducts.Count;
            }
        }
    }
}