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
    }
}
