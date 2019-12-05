using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public static class OrderPaymentAccess
    {
        /// <summary>
        /// Add OrderPayment to the database 
        /// Get the orderPayment with the new ID
        /// </summary>
        /// <param name="orderPayment"></param>
        /// <param name="order"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public static OrderPaymentModel AddOrderPaymentToTheDatabase(OrderPaymentModel orderPayment , OrderModel order ,string db)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnVal(db)))
            {
                var p = new DynamicParameters();
                p.Add("@OrderId", order.Id);
                p.Add("@StaffId", orderPayment.Staff.Id);
                p.Add("@StoreId", orderPayment.Store.Id);
                p.Add("@Paid", orderPayment.Paid);
                p.Add("@Date", orderPayment.Date);
                p.Add("@Id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
                connection.Execute("dbo.spOrderPayment_Create", p, commandType: CommandType.StoredProcedure);
                orderPayment.Id = p.Get<int>("@Id");
            }
            return orderPayment;
        }


        /// <summary>
        /// Get all OrderPayments From the database
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        public static List<OrderPaymentModel> GetOrderPaymentsFromTheDatabase(string db)
        {
            List<OrderPaymentModel> orderPayments;
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnVal(db)))
            {
                orderPayments = connection.Query<OrderPaymentModel>("dbo.spOrderPayment_GetAll").ToList();
            }

            foreach(OrderPaymentModel orderPayment in orderPayments)
            {
                orderPayment.Staff = new StaffModel();
                orderPayment.Store = new StoreModel();
            }
            return orderPayments;
        }

        /// <summary>
        /// Match The StaffModel With each OrderPayment From The database
        /// </summary>
        /// <param name="orderPayments"></param>
        /// <param name="staffs"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public static List<OrderPaymentModel> SetStaffForEachOrderPaymentFromTheDatabase(List<OrderPaymentModel>orderPayments , List<StaffModel>staffs,string db)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnVal(db)))
            {
                foreach(OrderPaymentModel orderPayment in orderPayments)
                {
                    var p = new DynamicParameters();
                    p.Add("@OrderPaymentId", orderPayment.Id);

                    orderPayment.Staff.Id = connection.QuerySingle<int>("spOrderPayment_GetStaffIdByOrderPaymentId", p, commandType: CommandType.StoredProcedure);
                }
            }
            foreach(OrderPaymentModel orderPaymentModel in orderPayments)
            {
                orderPaymentModel.Staff = staffs.Find(x => x.Id == orderPaymentModel.Staff.Id);
            }


            return orderPayments;
        }

        /// <summary>
        /// Match The StoreModel With each OrderPayment From The database
        /// </summary>
        /// <param name="orderPayments"></param>
        /// <param name="stores"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public static List<OrderPaymentModel>SetStoreForEachOrderPaymentFromTheDatabase(List<OrderPaymentModel>orderPayments,List<StoreModel>stores,string db)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnVal(db)))
            {
                foreach(OrderPaymentModel orderPayment in orderPayments)
                {
                    var p = new DynamicParameters();
                    p.Add("@OrderPaymentId", orderPayment.Id);
                    orderPayment.Store.Id = connection.QuerySingle<int>("spOrderPayment_GetStoreIdByOrderPaymentId", p, commandType: CommandType.StoredProcedure);
                }
            }

            foreach(OrderPaymentModel orderPaymentModel in orderPayments)
            {
                orderPaymentModel.Store = stores.Find(x => x.Id == orderPaymentModel.Store.Id);
            }

            return orderPayments;
        }

    }
}
