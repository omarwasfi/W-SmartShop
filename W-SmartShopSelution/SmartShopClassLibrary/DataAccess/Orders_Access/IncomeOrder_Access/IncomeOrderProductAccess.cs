using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;

namespace Library
{
    public static class IncomeOrderProductAccess
    {
        /// <summary>
        /// Add the new incomeOrderProduct to the database
        /// return the incomeOrderProduct with the new id
        /// </summary>
        /// <param name="incomeOrderProduct"></param>
        /// <param name="incomeOrder"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public static IncomeOrderProductModel AddIncomeOrderProductToTheDatabase(IncomeOrderProductModel incomeOrderProduct, IncomeOrderModel incomeOrder , string db)
        {

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnVal(db)))
            {
                var p = new DynamicParameters();
                p.Add("@IncomeOrderId", incomeOrder.Id);
                p.Add("@ProductId", incomeOrderProduct.Product.Id);
                p.Add("@IncomePrice", incomeOrderProduct.IncomePrice);
                p.Add("@Quantity", incomeOrderProduct.Quantity);
                p.Add("@Id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
                connection.Execute("dbo.spIncomeOrderProduct_Create", p, commandType: CommandType.StoredProcedure);
                incomeOrderProduct.Id = p.Get<int>("@Id");
            }
           
            return incomeOrderProduct;
        }
      
        /// <summary>
        /// Get all IncomeOrderProductModels without ProductModel
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        public static List<IncomeOrderProductModel> GetIncomeOrderProductsFromTheDatabase(string db)
        {
            List<IncomeOrderProductModel> incomeOrderProducts = new List<IncomeOrderProductModel>();
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnVal(db)))
            {
                incomeOrderProducts = connection.Query<IncomeOrderProductModel>("dbo.spIncomeOrderProduct_GetAll").ToList();
            }
            foreach(IncomeOrderProductModel incomeOrderProduct in incomeOrderProducts)
            {
                incomeOrderProduct.Product = new ProductModel();
            }

            return incomeOrderProducts;

        }

        /// <summary>
        /// Set the productModel foreach IncomeOrderProduct by matching the products to each IncomeOrderProduct
        /// </summary>
        /// <param name="incomeOrderProducts"></param>
        /// <param name="products"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public static List<IncomeOrderProductModel>SetTheProductModelForEachIncomeProductFromTheDatabase(List<IncomeOrderProductModel>incomeOrderProducts,List<ProductModel>products , string db)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnVal(db)))
            {
                foreach (IncomeOrderProductModel incomeOrderProduct in incomeOrderProducts)
                {
                    var p = new DynamicParameters();
                    p.Add("@IncomeOrderProductId", incomeOrderProduct.Id);
                    incomeOrderProduct.Product.Id = connection.QuerySingle<int>("spIncomeOrderProduct_GetProductIdByIncomeOrderProductId", p, commandType: CommandType.StoredProcedure);
                }
            }

            foreach (IncomeOrderProductModel incomeOrderProductModel in incomeOrderProducts)
            {
                incomeOrderProductModel.Product = products.Find(x => x.Id == incomeOrderProductModel.Product.Id);
            }
            return incomeOrderProducts;
        }


        /// <summary>
        /// -OLD- Loop throw each IncomeOrderProduct in the IncomeOrder
        /// save each one in the IncomeOrderProdcut table with tha Id of the IncomeOrder
        /// </summary>
        /// <param name="order"> IncomeOrder Model Has An Id From IncomeOrder.GetEmptyIncomeOrder </param>
        /// <param name="db"> Database Connection Name </param>
        public static void SaveIncomeOrderProductListToTheDatabase(IncomeOrderModel incomeOrder, string db)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnVal(db)))
            {
                foreach (IncomeOrderProductModel incomeOrderProduct in incomeOrder.IncomeOrderProducts)
                {
                    var o = new DynamicParameters();
                    o.Add("@IncomeOrderId", incomeOrder.Id);
                    o.Add("@ProductId", incomeOrderProduct.Product.Id);
                    o.Add("@IncomePrice", incomeOrderProduct.IncomePrice);
                    o.Add("@Quantity", incomeOrderProduct.Quantity);
                    connection.Execute("dbo.spIncomeOrderProduct_Create", o, commandType: CommandType.StoredProcedure);

                }
            }
        }

    }
}
