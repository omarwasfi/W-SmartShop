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
