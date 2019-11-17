using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public static class CashFlow
    {

        /// <summary>
        /// Calculate all the money records And fint the ShopeeWallet
        /// </summary>
        /// <param name="moneyRecords"></param>
        /// <returns></returns>
        public static decimal GetTheShopeeWallet(List<OperationModel> operations )
        {
            decimal shopeeWallet = new decimal();

            foreach(OperationModel operation in operations)
            {
                if(operation.GetTheOperationType == false)
                {
                    shopeeWallet += operation.AmountOfMoney;
                }
                else
                {
                    shopeeWallet -= operation.AmountOfMoney;
                }
            }

            return shopeeWallet;
        }

        #region Orders

        /// <summary>
        /// Return the total of totalPrice of any Order in a operation
        /// </summary>
        /// <param name="operations"></param>
        /// <returns></returns>
        public static decimal TotalSellsIncome(List<OperationModel> operations)
        {
            decimal totalSells = new decimal();

            foreach(OperationModel operation in operations)
            {
                if (operation.Order != null)
                {
                    totalSells += operation.Order.GetTotalPrice;
                }
                
            }

            return totalSells;
        }


        /// <summary>
        /// Return the TotalProfit of any Order in a operation
        /// </summary>
        /// <param name="operations"></param>
        /// <returns></returns>
        public static decimal TotalSellsProfit(List<OperationModel> operations)
        {
            decimal totalProfit = new decimal();

            foreach(OperationModel operation in operations)
            {
                if (operation.Order != null)
                {
                    totalProfit += operation.Order.GetTotalProfit;
                }
                    
            }

            return totalProfit;
        }


        #endregion

        #region IncomeOrder


        /// <summary>
        /// Return the total of totalPrice of any IncomeOrder in a operation
        /// </summary>
        /// <param name="operations"></param>
        /// <returns></returns>
        public static decimal TotalIncomeOrderPrice(List<OperationModel> operations)
        {
            decimal totalIncomeOrders = new decimal();

            foreach (OperationModel operation in operations)
            {
                if (operation.IncomeOrder != null)
                {
                    totalIncomeOrders += operation.IncomeOrder.GetTotalPrice;
                }

            }

            return totalIncomeOrders;
        }


        #endregion


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
