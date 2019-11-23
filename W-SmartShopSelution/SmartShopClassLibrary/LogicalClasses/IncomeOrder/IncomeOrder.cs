using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    /// <summary>
    /// Get all incomeOrders
    /// check if the bill number unique
    /// create incomeOrder and save it in the database
    /// </summary>
    public static class IncomeOrder
    {

      
        /// <summary>
        /// Calculate the Total Paid Value if this IncomeOrder
        /// </summary>
        /// <param name="incomeOrder"></param>
        /// <returns></returns>
       public static decimal GetTotalPaid(IncomeOrderModel incomeOrder)
        {
            decimal paid = new decimal();

            foreach(IncomeOrderPaymentModel incomeOrderPayment in incomeOrder.IncomeOrderPayments)
            {
                paid += incomeOrderPayment.Paid;
            }

            return paid;
        }

        /// <summary>
        /// Calculate the to total not paid price that the supplier of the IncomeORder should take
        /// </summary>
        /// <param name="incomeOrder"></param>
        /// <returns></returns>
        public static decimal GetTotalNotPaid(IncomeOrderModel incomeOrder)
        {
            return incomeOrder.GetTotalPrice - incomeOrder.GetTotalPaid;
        }

        /// <summary>
        /// If the bill number used before return false
        /// In not return true
        /// </summary>
        /// <param name="incomeOrders"> list of IncomeOrderModels </param>
        /// <param name="billNumber"> the bill number to check </param>
        /// <returns></returns>
        public static bool IsBillNumberUnique(List<IncomeOrderModel> incomeOrders , string billNumber)
        {
            foreach(IncomeOrderModel incomeOrder in incomeOrders)
            {
                if(billNumber == incomeOrder.BillNumber)
                {
                    return false;
                }
            }

            return true;
        }



    }
}
