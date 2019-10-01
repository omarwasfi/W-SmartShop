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
                    totalSells += operation.Order.TotalPrice;
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
    }
}
