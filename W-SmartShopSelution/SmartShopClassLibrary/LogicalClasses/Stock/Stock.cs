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
        /// get all stockes from the database 
        /// - set the product for each store
        /// - set the store for each sotre
        /// </summary>
        /// <param name="db"></param>
        /// <param name="allProducts"> get the product list from the database </param>
        /// <param name="allStores"> get the stores list from the database </param>
        /// <returns></returns>
        public static List<StockModel> GetStocks(string db, List<ProductModel> allProducts, List<StoreModel> allStores)
        {
            List<StockModel> stocks = new List<StockModel>();

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnVal(db)))
            {
                stocks = connection.Query<StockModel>("dbo.spStock_GetAll").ToList();
                // set the product and the store foreach stock
                foreach (StockModel stock in stocks)
                {
                    // set the product id 
                    var p = new DynamicParameters();
                    p.Add("@StockId", stock.Id);
                    stock.Product = connection.QuerySingle<ProductModel>("spStock_GetProductIdByStockId", p, commandType: CommandType.StoredProcedure);
                    // set the product from the product list
                    foreach (ProductModel product in allProducts)
                    {
                        if (product.Id == stock.Product.Id)
                        {
                            stock.Product = product;
                            break;
                        }
                    }

                    stock.Store = connection.QuerySingle<StoreModel>("spStock_GetStoreIdByStockId", p, commandType: CommandType.StoredProcedure);

                    // set the store from the store list
                    foreach (StoreModel store in allStores)
                    {
                        if (store.Id == stock.Store.Id)
                        {
                            stock.Store = store;
                            break;
                        }
                    }

                }
            }
            return stocks;
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

                    if (Regex.IsMatch(stock.Product.SerialNumber, Regex.Escape(serialNumber), RegexOptions.IgnoreCase))
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
                if (s.Product.SerialNumber == SerialNumber)
                {
                    stock = s;
                    return stock;
                }
            }

            return null;
        }



        /// <summary>
        /// Resuce the quantity of stock in the database
        /// </summary>
        /// <param name="stock"></param>
        /// <param name="quantity"> the number that u want to decreace </param>
        /// <param name="db"></param>
        public static void ReduseStock(StockModel stock , int quantity , string db)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnVal(db)))
            {
                var p = new DynamicParameters();
                p.Add("@StockId", stock.Id);
                p.Add("@Quantity", quantity);
                connection.Execute("dbo.spStock_ReduseStock", p, commandType: CommandType.StoredProcedure);

            }

        }

        /// <summary>
        /// Increace the quantity of stock in the database
        /// </summary>
        /// <param name="stock"></param>
        /// <param name="quantity"> the number that u want to increase </param>
        /// <param name="db"></param>
        public static void IncreaseStock(StockModel stock , int quantity , string db)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnVal(db)))
            {
                var p = new DynamicParameters();
                p.Add("@StockId", stock.Id);
                p.Add("@Quantity", quantity);
                connection.Execute("dbo.spStock_IncreaseStock", p, commandType: CommandType.StoredProcedure);
            }

        }

        /// <summary>
        /// Insert new stock to the stock table in the database
        /// return stock with the new id
        /// </summary>
        /// <param name="NewStock">stock has product , quantity and store</param>
        /// <returns></returns>
        public static StockModel AddStockToTheDatabase(StockModel NewStock, string db)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnVal(db)))
            {
                var p = new DynamicParameters();
                p.Add("@StoreId", NewStock.Store.Id);
                p.Add("@ProductId", NewStock.Product.Id);
                p.Add("@Quantity", NewStock.Quantity);


                p.Add("@Id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
                connection.Execute("dbo.spStock_Create", p, commandType: CommandType.StoredProcedure);
                NewStock.Id = p.Get<int>("@Id");
            }
            return NewStock;
        }

        /// <summary>
        /// Return the prodcut's stocks
        /// </summary>
        /// <param name="stocks"> list of stock </param>
        /// <param name="product"> product model </param>
        /// <returns></returns>
        public static List<StockModel> GetStocksByProduct(List<StockModel> stocks , ProductModel product)
        {
            List<StockModel> FStocks = new List<StockModel>();

            foreach(StockModel stock in stocks)
            {
                if(stock.Product.Id == product.Id)
                {
                    FStocks.Add(stock);
                }
            }

            return FStocks;
        }
        

        /// <summary>
        /// Update the stock quantity If the stock exist
        /// </summary>
        /// <param name="updatedStock"></param>
        /// <param name="db"></param>
        public static void UpdateStockData(StockModel updatedStock , string db)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnVal(db)))
            {
                var p = new DynamicParameters();
                p.Add("@Id", updatedStock.Id);
                p.Add("Quantity", updatedStock.Quantity);

                connection.Execute("dbo.spStock_Update", p, commandType: CommandType.StoredProcedure);

            }
        }

        /// <summary>
        /// Remove stock from the database
        /// </summary>
        /// <param name="stock"></param>
        /// <param name="db"></param>
        public static void RemoveStockFromTheDatabase(StockModel stock , string db)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnVal(db)))
            {
                var p = new DynamicParameters();
                p.Add("@Id", stock.Id);

                connection.Execute("dbo.spStock_Delete", p, commandType: CommandType.StoredProcedure);

            }
        }


    }
}
