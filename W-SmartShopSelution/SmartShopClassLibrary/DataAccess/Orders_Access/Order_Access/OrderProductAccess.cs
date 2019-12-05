using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Dapper;
namespace Library
{
    public static class OrderProductAccess
    {
        /// <summary>
        /// Add orderProduct to the database
        /// return it with the new Id
        /// </summary>
        /// <param name="OrderProduct"></param>
        /// <param name="Order"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public static OrderProductModel AddOrderProductToTheDatabase(OrderProductModel OrderProduct, OrderModel Order, string db)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnVal(db)))
            {
                var p = new DynamicParameters();
                p.Add("@OrderId", Order.Id);
                p.Add("@ProductId", OrderProduct.Product.Id);
                p.Add("@SalePrice", OrderProduct.SalePrice);
                p.Add("@Quantity", OrderProduct.Quantity);
                p.Add("@Discount", OrderProduct.Discount);
                p.Add("@Profit", OrderProduct.Profit);
                p.Add("@Id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
                connection.Execute("dbo.spOrderProduct_Create", p, commandType: CommandType.StoredProcedure);
                OrderProduct.Id = p.Get<int>("@Id");
            }

            return OrderProduct;
        }

        /// <summary>
        /// Get the Orders from the database Without the ProductModel
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        public static List<OrderProductModel> GetOrderProductsFromTheDatabase(string db)
        {
            List<OrderProductModel> orderProducts = new List<OrderProductModel>();
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnVal(db)))
            {
                orderProducts = connection.Query<OrderProductModel>("dbo.spOrderProduct_GetAll", commandType: CommandType.StoredProcedure).ToList();
            }

            foreach(OrderProductModel orderProduct in orderProducts)
            {
                orderProduct.Product = new ProductModel();

            }
            return orderProducts;
        }

        /// <summary>
        /// Set the Product id foreach productModel 
        /// match the products with each orderProduct
        /// </summary>
        /// <param name="orderProducts"></param>
        /// <param name="products"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public static List<OrderProductModel> SetTheProductModelForEachOrderProductFromTheDatabase(List<OrderProductModel>orderProducts,List<ProductModel>products,string db)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnVal(db)))
            {
                foreach (OrderProductModel orderProduct in orderProducts)
                {
                    var o = new DynamicParameters();
                    o.Add("@OrderProductId", orderProduct.Id);
                    orderProduct.Product.Id = connection.QuerySingle<int>("dbo.spOrderProduct_GetProdcutIdByOrderProductId", o, commandType: CommandType.StoredProcedure);

                }
            }

            foreach(OrderProductModel orderProductModel in orderProducts)
            {
                orderProductModel.Product = products.Find(x => x.Id == orderProductModel.Product.Id);
            }

            return orderProducts;
        }



        /// <summary>
        /// Loop throw each OrderProduct in the order
        /// save each one in the orderProdcut table with tha Id of the order
        /// </summary>
        /// <param name="order"> Order Model Has An Id From Order.GetEmptyOrder </param>
        /// <param name="db"> Database Connection Name </param>
        public static void SaveOrderProductListToTheDatabase(OrderModel order, string db)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnVal(db)))
            {
                foreach (OrderProductModel orderProduct in order.OrderProducts)
                {
                    var o = new DynamicParameters();
                    o.Add("@OrderId", order.Id);
                    o.Add("@ProductId", orderProduct.Product.Id);
                    o.Add("@Quantity", orderProduct.Quantity);
                    o.Add("@SalePrice", orderProduct.SalePrice);
                    o.Add("@Discount", orderProduct.Discount);
                    o.Add("@Profit", orderProduct.Profit);

                    connection.Execute("dbo.spOrderProduct_Create", o, commandType: CommandType.StoredProcedure);

                }
            }
        }


        /// <summary>
        /// Delete OrderProduct from the database
        /// </summary>
        /// <param name="orderProduct"></param>
        /// <param name="db"></param>
        public static void RemoveOrderProduct(OrderProductModel orderProduct, string db)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnVal(db)))
            {
                var p = new DynamicParameters();
                p.Add("@Id", orderProduct.Id);
                connection.Execute("dbo.spOrderProduct_Delete", p, commandType: CommandType.StoredProcedure);

            }
        }


    }
}
