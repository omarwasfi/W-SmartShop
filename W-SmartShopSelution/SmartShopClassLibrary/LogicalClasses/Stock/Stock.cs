using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Dapper;

namespace Library
{
    public static class Stock
    {

        /// <summary>
        /// ExpirationAlarmEnabeled = ture , return Null
        /// if  x.ExpirationAlarmEnabled == false && x.Store == stock.Store && x.Product == stock.Product && x.IncomePrice == stock.IncomePrice && x.SalePrice == stock.SalePrice
        /// Return the stockModel
        /// </summary>
        /// <returns></returns>
        public static StockModel FindSimilarStock(StockModel stock)
        {
            if(stock.ExpirationAlarmEnabled == true)
            {
                return null ;
            }
            StockModel stockModel = PublicVariables.Stocks.Find(x => x.ExpirationAlarmEnabled == false && x.Store == stock.Store && x.Product == stock.Product && x.IncomePrice == stock.IncomePrice && x.SalePrice == stock.SalePrice);
            if(stockModel != null)
            {
                return stockModel;
            }
            return null;
        }

        /// <summary>
        /// Generate a unique SBarcode for the stock
        /// Based on StoreID + First char of the productName + Number
        /// </summary>
        /// <param name="stock"></param>
        /// <returns></returns>
        public static string GenerateNewSBarCode(StockModel stock)
        {
            
            string startOfTheSBarCode = stock.Product.Name.Substring(0, 1) + stock.Store.Id.ToString();
            startOfTheSBarCode = startOfTheSBarCode.ToUpper();
            int number = 1;

            while (CheckIfTheSBarCodeUnique(startOfTheSBarCode + number) == false)
            {
                number++;
            }

            

            return startOfTheSBarCode + number;
        }

        public static bool CheckIfTheSBarCodeUnique(string startOfTheSBarCode)
        {

            if (PublicVariables.Stocks.Exists(x => x.SBarCode == startOfTheSBarCode))
            {
                return false;

            }
            else
            {
                return true;
            }
           
        }

        /// <summary>
        /// Get The Expiration period by Expiration Date
        /// </summary>
        /// <param name="stock"></param>
        /// <returns></returns>
        public static TimeSpan GetExpirationPeriod(StockModel stock)
        {
            TimeSpan expirationPeriod = stock.ExpirationDate - DateTime.Now;
            return expirationPeriod;
        }


        /// <summary>
        /// Get the Expiration state (The days and hours left OR expired !! OR Don't Expire )
        /// </summary>
        /// <param name="stock"></param>
        /// <returns></returns>
        public static string ExpirationState(StockModel stock)
        {
            if(stock.ExpirationAlarmEnabled == true)
            {
                if(stock.GetExpirationPeriod > new TimeSpan(0, 0, 0, 0))
                {
                    return "Days: " + stock.GetExpirationPeriod.Days + " ,Hours: " + stock.GetExpirationPeriod.Hours;
                }
                else
                {
                    return "Expired !!";
                }
            }
            else
            {
                return "Don't Expire";
            }
        }

        /// <summary>
        /// Filter all stock list by store
        /// </summary>
        /// <param name="stocks"> list of stocks foom the database</param>
        /// <param name="store"> store model </param>
        /// <returns></returns>
        public static List<StockModel> FilterStocksByStore(List<StockModel> stocks, StoreModel store)
        {
            List<StockModel> FStocks = new List<StockModel>();

            foreach (StockModel stock in stocks)
            {
                if (stock.Store.Id == store.Id)
                {
                    FStocks.Add(stock);
                }
            }

            return FStocks;
        }


        /// <summary>
        /// Filter list of stocks by category and brand of the products in the stock list
        /// </summary>
        /// <param name="stocks"> list of stock model </param>
        /// <param name="category"> category model </param>
        /// <param name="defaultCategoryId">the default product id const value signed in the database</param>
        /// <param name="brand">brand model</param>
        /// <param name="defaultBrandId">the default product id const value signed in the database</param>
        /// <returns> list of filterd stocks by category and brand</returns>
        public static List<StockModel> FilterStocksByCategoryAndBrand(List<StockModel> stocks, CategoryModel category, int defaultCategoryId, BrandModel brand, int defaultBrandId)
        {
            List<StockModel> FStocks = new List<StockModel>();

            bool FilterByBrand = true;
            bool FilterByCategory = true;

            if (brand == null || brand.Id == defaultBrandId)
                FilterByBrand = false;

            if (category == null || category.Id == defaultCategoryId)
                FilterByCategory = false;

            // Filter by Brand and category
            if (FilterByBrand == true && FilterByCategory == true)
            {
                foreach (StockModel stock in stocks)
                {
                    if (stock.Product.Category.Id == category.Id && stock.Product.Brand.Id == brand.Id)
                    {
                        FStocks.Add(stock);
                    }
                }
                return FStocks;
            }

            // Filter by category Only
            else if (FilterByBrand == false && FilterByCategory == true)
            {
                foreach (StockModel stock in stocks)
                {
                    if (stock.Product.Category.Id == category.Id)
                    {
                        FStocks.Add(stock);
                    }
                }
                return FStocks;
            }

            // Filter by brand Only
            else if (FilterByBrand == true && FilterByCategory == false)
            {
                foreach (StockModel stock in stocks)
                {
                    if (stock.Product.Brand.Id == brand.Id)
                    {
                        FStocks.Add(stock);
                    }

                }
                return FStocks;
            }

            // No Filtering
            else
            {
                return stocks;
            }

        }


        /// <summary>
        /// return list of filterd stocks if the product name foreach one Contains String name
        /// source of the search way: https://stackoverflow.com/a/3355561/6421951
        /// </summary>
        /// <param name="stocks"> list of stock model </param>
        /// <param name="name"> name that we search for </param>
        /// <returns></returns>
        public static List<StockModel> FilterStocksByName(List<StockModel> stocks, string name)
        {
            List<StockModel> FStocks = new List<StockModel>();
            foreach(StockModel stock in stocks)
            {
                if (Regex.IsMatch(stock.Product.Name, Regex.Escape(name), RegexOptions.IgnoreCase))
                {
                    FStocks.Add(stock);
                }
            }
            return FStocks;
        }

        /// <summary>
        ///  return list of filterd stocks if the product serial number foreach one Contains SerialNumber
        ///  source of the search way: https://stackoverflow.com/a/3355561/6421951
        /// </summary>
        /// <param name="stocks"></param>
        /// <param name="serialNumber"></param>
        /// <returns></returns>
        public static List<StockModel> FilterStocksBySerialNumber(List<StockModel> stocks, string serialNumber)
        {
            List<StockModel> FStocks = new List<StockModel>();
            foreach (StockModel stock in stocks)
            {
                if (stock.Product.SerialNumber != null)
                {

                    if (Regex.IsMatch(stock.Product.SerialNumber, Regex.Escape(serialNumber), RegexOptions.IgnoreCase) || Regex.IsMatch(stock.Product.SerialNumber2, Regex.Escape(serialNumber), RegexOptions.IgnoreCase))
                    {
                        FStocks.Add(stock);
                    }
                }
            }
            return FStocks;
        }

        /// <summary>
        /// Return list of filtered stocks if the product barcorde foreach one cotains barCode
        /// </summary>
        /// <param name="stocks"></param>
        /// <param name="barCode"></param>
        /// <returns></returns>
        public static List<StockModel> FilterStocksByBarCode(List<StockModel> stocks, string barCode)
        {
            List<StockModel> FStocks = new List<StockModel>();
            foreach (StockModel stock in stocks)
            {
                if (stock.Product.SerialNumber != null)
                {

                    if (Regex.IsMatch(stock.Product.BarCode, Regex.Escape(barCode), RegexOptions.IgnoreCase))
                    {
                        FStocks.Add(stock);
                    }
                }
            }
            return FStocks;
        }

        /// <summary>
        /// Get stock by serialNumber If exist
        /// If Not : return null
        /// </summary>
        /// <param name="stocks"></param>
        /// <param name="SerialNumber"></param>
        /// <returns></returns>
        public static StockModel GetStockBySerialNumber(List<StockModel> stocks , string SerialNumber)
        {
            StockModel stock;

            foreach (StockModel s in stocks)
            {
                if (s.Product.SerialNumber == SerialNumber || s.Product.SerialNumber2 == SerialNumber)
                {
                    stock = s;
                    return stock;
                }
            }

            return null;
        }



        /// <summary>
        /// Return the prodcut's stocks
        /// </summary>
        /// <param name="stocks"> list of stock </param>
        /// <param name="product"> product model </param>
        /// <returns></returns>
        public static List<StockModel> GetStocksByProduct(List<StockModel> stocks ,ProductModel product)
        {

            return stocks.FindAll(x=>x.Product == product);
        }
        


    }
}
