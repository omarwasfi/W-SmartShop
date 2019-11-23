using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public static class IncomeOrderPayment
    {

        /// <summary>
        /// Search in all IncomeOrder to find the IncomeOrderPayment Then return the IncomeOrder
        /// </summary>
        /// <param name="incomeOrderPayment"></param>
        /// <returns></returns>
        public static IncomeOrderModel GetTheIncomeOrder(IncomeOrderPaymentModel incomeOrderPayment)
        {
            foreach (IncomeOrderModel incomeOrder in PublicVariables.IncomeOrders)
            {
                IncomeOrderPaymentModel incomeOrderPaymentModel;
                incomeOrderPaymentModel = incomeOrder.IncomeOrderPayments.Find(x => x == incomeOrderPayment);

                if (incomeOrderPaymentModel != null)
                {
                    return incomeOrder;
                }
            }
            return null;
        }
    }
}
