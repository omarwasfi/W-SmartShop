using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public static class CashFlow
    {

      

        #region ShopBills


        /// <summary>
        /// Return the total of the totalPrice of any ShopBills in a operation
        /// </summary>
        /// <param name="operations"></param>
        /// <returns></returns>
        public static decimal TotalShopBillsPrice(List<OperationModel> operations)
        {
            decimal totalShopBills = new decimal();

            foreach (OperationModel operation in operations)
            {
                if (operation.ShopBill != null)
                {
                    totalShopBills += operation.ShopBill.TotalMoney;
                }

            }

            return totalShopBills;
        }


        #endregion

    }
}
