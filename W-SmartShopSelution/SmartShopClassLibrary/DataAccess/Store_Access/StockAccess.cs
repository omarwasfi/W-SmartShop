using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;

namespace Library
{
    public static class StockAccess
    {

        /// <summary>
        /// Update a SimilarStock With new stock 
        /// </summary>
        /// <param name="similarStock"></param>
        /// <param name="newStock"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public static StockModel AddStockToSimilarStockToTheDatabase(StockModel similarStock,StockModel newStock , string db)
        {
            similarStock.Quantity += newStock.Quantity;
            similarStock.Date = newStock.Date;
            similarStock.AlarmQuantity = newStock.AlarmQuantity;
            similarStock.QuantityAlarmEnabled = newStock.QuantityAlarmEnabled;
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnVal(db)))
            {
                var p = new DynamicParameters();
                p.Add("@Id", similarStock.Id);
                p.Add("@Date", similarStock.Date);
                p.Add("@AlarmQuantity", similarStock.AlarmQuantity);
                p.Add("@QuantityAlarmEnabled", similarStock.QuantityAlarmEnabled);
                p.Add("@Quantity", similarStock.Quantity);

                connection.Execute("dbo.spStock_Update", p, commandType: CommandType.StoredProcedure);
            }

                return similarStock;
        }
       
        /// <summary>
        /// Add stock to the database Get the new stock with the new stock Id
        /// </summary>
        /// <param name="stock"></param>
        /// <returns></returns>
        public static StockModel AddStockToTheDatabase(StockModel stock,string db)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnVal(db)))
            {
                var p = new DynamicParameters();
                p.Add("@SBarCode", stock.SBarCode);
                p.Add("@StoreId", stock.Store.Id);
                p.Add("@ProductId", stock.Product.Id);
                p.Add("@IncomePrice", stock.IncomePrice);
                p.Add("@SalePrice", stock.SalePrice);
                p.Add("@Date", stock.Date);
                p.Add("@ExpirationPeriodHours", stock.ExpirationPeriodHours);
                p.Add("@ExpirationAlarmEnabled", stock.ExpirationAlarmEnabled);
                p.Add("@Quantity", stock.Quantity);
                p.Add("@AlarmQuantity", stock.AlarmQuantity);
                p.Add("@QuantityAlarmEnabled", stock.QuantityAlarmEnabled);            
                p.Add("@Id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
                connection.Execute("dbo.spStock_Create", p, commandType: CommandType.StoredProcedure);
                stock.Id = p.Get<int>("@Id");
            }
                return stock;
        }

        /// <summary>
        /// Get all stocks from the database without setting the StoreModel And the ProductModel
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        public static List<StockModel> GetAllStocksFromTheDatabase(string db)
        {
            List<StockModel> stocks = new List<StockModel>();
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnVal(db)))
            {
                stocks = connection.Query<StockModel>("dbo.spStock_GetAll").ToList();
            }

            foreach(StockModel stock in stocks)
            {
                stock.Store = new StoreModel();
                stock.Product = new ProductModel();
            }
            return stocks;
        }

        /// <summary>
        ///  Sets The Store Model for each stock in the list
        ///   -Open the connection
        ///   -set the id of the store foreach stock
        ///   -Close the connection
        ///   -match the IDs to the publicVariables.stores AND set the store model for each stockModel
        /// </summary>
        /// <param name="stocks"></param>
        /// <param name="stores"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public static List<StockModel> SetTheStoreForEachStockFromTheDatabase(List<StockModel>stocks,List<StoreModel>stores , string db)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnVal(db)))
            {
                foreach (StockModel stock in stocks)
                {
                    var p = new DynamicParameters();
                    p.Add("@StockId", stock.Id);
                    stock.Store.Id = connection.QuerySingle<int>("spStock_GetStoreIdByStockId", p, commandType: CommandType.StoredProcedure);
                }
            }

            foreach(StockModel stockModel in stocks)
            {
                stockModel.Store = stores.Find(x => x.Id == stockModel.Store.Id);
            }
            return stocks;
        }

        /// <summary>
        /// Sets The product Model for each stock in the list
        ///   -Open the connection
        ///   -set the id of the product foreach stock
        ///   -Close the connection
        ///   -match the IDs to the publicVariables.products AND set the product model for each stockModel
        /// </summary>
        /// <param name="stocks"></param>
        /// <param name="products"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public static List<StockModel>SetTheProductForEachStockFromTheDatabase(List<StockModel>stocks,List<ProductModel>products,string db)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnVal(db)))
            {
                foreach(StockModel stock in stocks)
                {
                    var p = new DynamicParameters();
                    p.Add("@StockId", stock.Id);
                    stock.Product.Id = connection.QuerySingle<int>("spStock_GetProductIdByStockId", p, commandType: CommandType.StoredProcedure);

                }
            }

            foreach(StockModel stockModel in stocks)
            {
                stockModel.Product = products.Find(x => x.Id == stockModel.Product.Id);
            }

            return stocks;
        }




        /// <summary>
        /// Resuce the quantity of stock in the database
        /// If the quantity  = stock.quantity => remove the stock from the database
        /// </summary>
        /// <param name="stock"></param>
        /// <param name="quantity"> the number that u want to decreace </param>
        /// <param name="db"></param>
        public static void ReduseStock(StockModel stock, float quantity, string db)
        {
            if (stock.Quantity > quantity)
            {
                using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnVal(db)))
                {
                    var p = new DynamicParameters();
                    p.Add("@StockId", stock.Id);
                    p.Add("@Quantity", quantity);
                    connection.Execute("dbo.spStock_ReduseStock", p, commandType: CommandType.StoredProcedure);

                }
            }
            else
            {
                using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnVal(db)))
                {
                    var p = new DynamicParameters();
                    p.Add("@Id", stock.Id);

                    connection.Execute("dbo.spStock_Delete", p, commandType: CommandType.StoredProcedure);

                }
            }


        }

        /// <summary>
        /// Increace the quantity of stock in the database
        /// </summary>
        /// <param name="stock"></param>
        /// <param name="quantity"> the number that u want to increase </param>
        /// <param name="db"></param>
        public static void IncreaseStock(StockModel stock, float quantity, string db)
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
        /// -OLD-Update the stock Date If the stock exist
        /// </summary>
        /// <param name="updatedStock"></param>
        /// <param name="db"></param>
        public static void UpdateStockData(StockModel updatedStock, string db)
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
        public static void RemoveStockFromTheDatabase(StockModel stock, string db)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnVal(db)))
            {
                var p = new DynamicParameters();
                p.Add("@Id", stock.Id);

                connection.Execute("dbo.spStock_Delete", p, commandType: CommandType.StoredProcedure);

            }
        }

        /// <summary>
        /// -OLD- get all stockes from the database 
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
    }
}
