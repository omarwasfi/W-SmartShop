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
