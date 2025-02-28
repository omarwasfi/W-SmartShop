﻿using Dapper;
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
        /// Get the total incomeOrdersValue of the store
        /// </summary>
        /// <param name="store"></param>
        /// <returns></returns>
        public static decimal GetTotalIncomeOrdersValue(StoreModel store)
        {
            decimal totalIncomeOrderValue = new decimal();

            foreach(IncomeOrderModel incomeOrder in store.GetIncomeOrders)
            {
                totalIncomeOrderValue += incomeOrder.GetTotalPrice;
            }

            return totalIncomeOrderValue;
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
        /// Get the total shopBills value 
        /// </summary>
        /// <param name="store"></param>
        /// <returns></returns>
        public static decimal GetTotalShopBillsValue(StoreModel store)
        {
            decimal totalShopBills = new decimal();

            foreach(ShopBillModel shopBill in GetShopBills(store))
            {
                totalShopBills += shopBill.TotalMoney;
            }

            return totalShopBills;
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
        /// Get the total staffsalaries value
        /// </summary>
        /// <param name="store"></param>
        /// <returns></returns>
        public static decimal GetStaffSalaryValue(StoreModel store)
        {
            decimal totalStaffSalary = new decimal();

            foreach(StaffSalaryModel staffSalary in store.GetStaffSalaries)
            {
                totalStaffSalary += staffSalary.Salary;
            }

            return totalStaffSalary;
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
        /// Get all products that exist in the stock of the store
        /// </summary>
        /// <param name="store"></param>
        /// <returns></returns>
        public static List<ProductModel>GetExistProducts(StoreModel store)
        {
            List<ProductModel> products = new List<ProductModel>();
            foreach(ProductModel product in PublicVariables.Products)
            {
                if(store.GetStocks.Exists(x=>x.Product == product))
                {
                    products.Add(product);
                }
            }
            return products;
        }

        /// <summary>
        /// Get all categiries that exist in the stocks of the store
        /// </summary>
        /// <param name="store"></param>
        /// <returns></returns>
        public static List<CategoryModel>GetExistCategories(StoreModel store)
        {
            List<CategoryModel> categories = new List<CategoryModel>();
            foreach(CategoryModel category in PublicVariables.Categories)
            {
                if(store.GetStocks.Exists(x=>x.Product.Category == category) || category == PublicVariables.DefaultCategory)
                {
                    categories.Add(category);
                }
            }
            return categories;
        }

        /// <summary>
        /// Get all brands that exist in the stocks of the store
        /// </summary>
        /// <param name="store"></param>
        /// <returns></returns>
        public static List<BrandModel> GetExistBrands(StoreModel store)
        {
            List<BrandModel> brands = new List<BrandModel>();
            foreach (BrandModel brand in PublicVariables.Brands)
            {
                if (store.GetStocks.Exists(x => x.Product.Brand == brand) || brand == PublicVariables.DefaultBrand)
                {
                    brands.Add(brand);
                }
            }
            return brands;
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
        /// Get the total sells value of all the orders
        /// </summary>
        /// <param name="store"></param>
        /// <returns></returns>
        public static decimal GetTotalSellsValue(StoreModel store)
        {
            decimal totalSells = new decimal();

            foreach(OrderModel order in store.GetOrders)
            {
                totalSells += order.GetTotalPrice;
            }

            return totalSells;
        }

        /// <summary>
        /// Get total paid orders of this store
        /// </summary>
        /// <param name="store"></param>
        /// <returns></returns>
        public static decimal GetTotalPaidOrdersValue(StoreModel store)
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
        /// Filter the store orders by the time Period between the two dateTime
        /// </summary>
        /// <param name="store">the store model that we need it's orders to be filted</param>
        /// <param name="from">the start date</param>
        /// <param name="to"> the end date</param>
        /// <returns></returns>
        public static List<OrderModel>FilterOrders(StoreModel store,DateTime from , DateTime to)
        {
            return store.GetOrders.FindAll(x => x.DateTimeOfTheOrder > from && x.DateTimeOfTheOrder < to);
        }

        /// <summary>
        /// Get the count of orders in specific period
        /// </summary>
        /// <param name="store"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        public static int GetTheOrdersCount(StoreModel store, DateTime from , DateTime to)
        {
           return FilterOrders(store,from,to).Count;
        }

        /// <summary>
        ///  The actual profit that the customer paid means( if the totalPaid more than the incomePrice -> actual profit = totalPaid - incomePrice)
        /// </summary>
        /// <param name="store"></param>
        /// <returns></returns>
        public static decimal GetTotalReceivedProfit(StoreModel store)
        {
            decimal totalReceivedProfit = new decimal();

            foreach(OrderModel order in store.GetOrders)
            {
                totalReceivedProfit += order.GetReceivedProfit;
            }

            return totalReceivedProfit;
        }

        /// <summary>
        /// if the total received profits more than 0
        /// return the GetTotalPaidOrdersValue - total recievedProfits
        /// else return the GetTotalPaidOrdersValue
        /// </summary>
        /// <param name="store"></param>
        /// <returns></returns>
        public static decimal GetSellsWihtoutProfits(StoreModel store)
        {
            if(GetTotalReceivedProfit(store) > 0)
            {
                return GetTotalPaidOrdersValue(store) - GetTotalReceivedProfit(store);
            }
            else
            {
                return GetTotalPaidOrdersValue(store);
            }
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
