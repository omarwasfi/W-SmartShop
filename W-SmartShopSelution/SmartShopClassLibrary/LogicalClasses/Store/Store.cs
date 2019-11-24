using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Library;

namespace Library
{
    public static class Store
    {

      
        /// <summary>
        /// Check if this store exist in the list of the stores By Name
        /// </summary>
        /// <param name="store"></param>
        /// <param name="stores"></param>
        /// <returns></returns>
        public static StoreModel IsThisStoreExist(StoreModel store , List<StoreModel> stores)
        {
            foreach(StoreModel s in stores)
            {
                if(store.Name == s.Name)
                {
                    return s;
                }
            }
            return new StoreModel { Id = -1 };
        }

        /// <summary>
        /// Get all the transforms of the this store
        /// </summary>
        /// <param name="store"></param>
        /// <returns></returns>
        public static List<TransformModel> GetTransforms(StoreModel store)
        {
            return PublicVariables.Transforms.FindAll(x => x.Store.Id == store.Id);
        }

        /// <summary>
        /// Get all Transforms Value (all the money that the store recivef from the owners)
        /// </summary>
        /// <param name="store"></param>
        /// <returns></returns>
        public static decimal GetTransformsValue(StoreModel store)
        {
            decimal transformsValue = new decimal();
            foreach(TransformModel transform in store.GetTransforms)
            {
                transformsValue += transform.TotalMoney;
            }
            return transformsValue;
        }

        /// <summary>
        /// Get all the DeTransforms of the this store
        /// </summary>
        /// <param name="store"></param>
        /// <returns></returns>
        public static List<DeTransformModel> GetDeTransforms(StoreModel store)
        {
            return PublicVariables.DeTransforms.FindAll(x => x.Store.Id == store.Id);
        }

        /// <summary>
        /// Get all DETransforms Value (all the money that the owners recived from the store )
        /// </summary>
        /// <param name="store"></param>
        /// <returns></returns>
        public static decimal GetDeTransformsValue(StoreModel store)
        {
            decimal deTransformsValue = new decimal();
            foreach (DeTransformModel deTransform in store.GetDeTransforms)
            {
                deTransformsValue += deTransform.TotalMoney;
            }
            return deTransformsValue;
        }

        /// <summary>
        /// Get all Orders of this store
        /// </summary>
        /// <param name="store"></param>
        /// <returns></returns>
        public static List<OrderModel> GetOrders(StoreModel store)
        {
            return PublicVariables.Orders.FindAll(x => x.Store.Id == store.Id);
        }


        /// <summary>
        /// Get all IncomeOrders of this store
        /// </summary>
        /// <param name="store"></param>
        /// <returns></returns>
        public static List<IncomeOrderModel> GetIncomeOrders(StoreModel store)
        {
            return PublicVariables.IncomeOrders.FindAll(x => x.Store.Id == store.Id);
        }

        /// <summary>
        /// Get all ShopBills of this store
        /// </summary>
        /// <param name="store"></param>
        /// <returns></returns>
        public static List<ShopBillModel> GetShopBills(StoreModel store)
        {
            return PublicVariables.ShopBills.FindAll(x => x.Store.Id == store.Id);
        }

        /// <summary>
        /// Get all staffSalaries of this store
        /// </summary>
        /// <param name="store"></param>
        /// <returns></returns>
        public static List<StaffSalaryModel> GetStaffSalaries(StoreModel store)
        {
            return PublicVariables.StaffSalaries.FindAll(x => x.Store.Id == store.Id);
        }

        /// <summary>
        /// Get all the Operations that effect this store
        /// </summary>
        /// <param name="store"></param>
        /// <returns></returns>
        public static List<OperationModel> GetOperations(StoreModel store)
        {
            return PublicVariables.Operations.FindAll(x => x.GetTheAffactedStore == store);
        }

        /// <summary>
        /// Go on each Operation and GetTheValueOfTheMoney
        /// </summary>
        /// <param name="store"></param>
        /// <returns></returns>
        public static decimal GetShopeeWallet(StoreModel store)
        {
            decimal shopeeWallet = new decimal();

            foreach(OperationModel operation in store.GetOperations)
            {
                shopeeWallet += operation.GetTheValueOfTheMoney;
            }

            return shopeeWallet;
        }

        /// <summary>
        /// Get all The Stocks in this store
        /// </summary>
        /// <param name="store"></param>
        /// <returns></returns>
        public static List<StockModel>GetStocks(StoreModel store)
        {
            return PublicVariables.Stocks.FindAll(x => x.Store == store);
        }

        /// <summary>
        ///  The Stocks IncomeValue in this store
        /// </summary>
        /// <param name="store"></param>
        /// <returns></returns>
        public static decimal GetStocksIncomeValue(StoreModel store)
        {
            decimal incomeValue = new decimal();

            foreach(StockModel stockModel in store.GetStocks)
            {
                incomeValue += stockModel.IncomePrice * (decimal)stockModel.Quantity;
            }

            return incomeValue;
        }

        /// <summary>
        ///  The Stocks SaleValue in this store
        /// </summary>
        /// <param name="store"></param>
        /// <returns></returns>
        public static decimal GetStocksSaleValue(StoreModel store)
        {
            decimal saleValue = new decimal();

            foreach (StockModel stockModel in store.GetStocks)
            {
                saleValue += stockModel.SalePrice;
            }

            return saleValue;
        }

        /// <summary>
        /// Get total paid orders of this store
        /// </summary>
        /// <param name="store"></param>
        /// <returns></returns>
        public static decimal GetTotalPaidOrders(StoreModel store)
        {
            decimal totalPaid = new decimal();
            foreach(OrderModel order in store.GetOrders)
            {
                totalPaid += order.GetTotalPaid;
            }
            return totalPaid;
        }

        /// <summary>
        /// Calculate the value of the not paid orders of this store
        /// </summary>
        /// <param name="store"></param>
        /// <returns></returns>
        public static decimal GetNotPaidOrdersValue(StoreModel store)
        {
            decimal totalNotPaid = new decimal();
            foreach(OrderModel order in store.GetOrders)
            {
                totalNotPaid += order.GetTotalNotPaid;
            }
            return totalNotPaid;
        }


        /// <summary>
        /// Calculate All the paid amount of money in the incomeOrder
        /// </summary>
        /// <param name="store"></param>
        /// <returns></returns>
        public static decimal GetTotalPaidIncomeOrdersValue(StoreModel store)
        {
            decimal TotalPaidIncomeOrders = new decimal();
            foreach(IncomeOrderModel incomeOrder in store.GetIncomeOrders)
            {
                TotalPaidIncomeOrders += incomeOrder.GetTotalPaid;
            }
            return TotalPaidIncomeOrders;
        }

        /// <summary>
        ///  The Total Loans on this store the IncomeOrders that's not fully paid yet(the amount of money not paid)
        /// </summary>
        /// <param name="store"></param>
        /// <returns></returns>
        public static decimal GetLoans(StoreModel store)
        {
            decimal totalLoans = new decimal();
            foreach(IncomeOrderModel incomeOrder in store.GetIncomeOrders)
            {
                totalLoans += incomeOrder.GetTotalNotPaid;
            }
            return totalLoans;
        }
    }
}
