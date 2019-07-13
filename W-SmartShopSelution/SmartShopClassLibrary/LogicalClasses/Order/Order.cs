using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public static class Order
    {

        /// <summary>
        /// save the order to the database, 
        /// each orderproduct will be add to the orderproduct table in the database
        /// </summary>
        /// <param name="order">order model</param>
        /// <param name="db"></param>
        public static void SaveOrderToDatabase(OrderModel order, string db)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnVal(db)))
            {
                
                var p = new DynamicParameters();
                p.Add("@CustomerId" , order.Customer.Id);
                p.Add("@DateTimeOfTheOrder", order.DateTimeOfTheOrder);
                p.Add("@StoreId", order.Store.Id);
                p.Add("@StaffId", order.Staff.Id);
                p.Add("@TotalPrice", order.TotalPrice);
                p.Add("@Id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
                connection.Execute("dbo.spOrders_CreateOrder", p, commandType: CommandType.StoredProcedure);
                order.Id = p.Get<int>("@Id");

                
                foreach (OrderProductModel orderProduct in order.Products)
                {
                    var o = new DynamicParameters();
                    o.Add("@OrderId", order.Id);
                    o.Add("@ProductId", orderProduct.Product.Id);
                    o.Add("@SalePrice", orderProduct.SalePrice);
                    o.Add("@Discount", orderProduct.Discount);
                    o.Add("@Quantity", orderProduct.Quantity);
                  connection.Execute("dbo.spOrderProduct_Create", o, commandType: CommandType.StoredProcedure);

                }

            }
        }

    }
}
