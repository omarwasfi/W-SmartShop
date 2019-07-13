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
        /// Gets Empty Order that have Id  , 
        /// The order should Have The main info of thist variables:
        /// CustomerId, DataTimeOfTheOrder, StoreId, StaffId,TotalPrice
        /// </summary>
        /// <param name="order">order model</param>
        /// <param name="db"> Database Connection Name </param>
        public static OrderModel GetEmptyOrderFromTheDatabase(OrderModel order, string db)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnVal(db)))
            {

                var p = new DynamicParameters();
                p.Add("@CustomerId", order.Customer.Id);
                p.Add("@DateTimeOfTheOrder", order.DateTimeOfTheOrder);
                p.Add("@StoreId", order.Store.Id);
                p.Add("@StaffId", order.Staff.Id);
                p.Add("@TotalPrice", order.TotalPrice);
                p.Add("@Id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
                connection.Execute("dbo.spOrders_CreateOrder", p, commandType: CommandType.StoredProcedure);
                order.Id = p.Get<int>("@Id");
            }
            return order;
                
            
        }

    }
}
