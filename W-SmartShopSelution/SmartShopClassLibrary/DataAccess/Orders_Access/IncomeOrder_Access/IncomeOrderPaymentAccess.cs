using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public static class IncomeOrderPaymentAccess
    {
        /// <summary>
        /// Add incomeorderPayment To the database
        /// return the incomeOrderPayment with the new id
        /// </summary>
        /// <param name="incomeOrderPayment"></param>
        /// <param name="incomeOrder"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public static IncomeOrderPaymentModel AddIncomeOrderPaymentToTheDatabase(IncomeOrderPaymentModel incomeOrderPayment, IncomeOrderModel incomeOrder, string  db)
        {

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnVal(db)))
            {
                var p = new DynamicParameters();
                p.Add("@IncomeOrderId", incomeOrder.Id);
                p.Add("@StaffId", incomeOrderPayment.Staff.Id);
                p.Add("@StoreId", incomeOrderPayment.Store.Id);
                p.Add("@Paid", incomeOrderPayment.Paid);
                p.Add("@Date", incomeOrderPayment.Date);
                p.Add("@Id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
                connection.Execute("dbo.spIncomeOrderPayment_Create", p, commandType: CommandType.StoredProcedure);
                incomeOrderPayment.Id = p.Get<int>("@Id");
            }
                return incomeOrderPayment;
        }

        /// <summary>
        /// Get IncomeOrderPayments From the database
        /// - without setting StaffModel , StoreModel
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        public static List<IncomeOrderPaymentModel>GetIncomeOrderPaymentsFromTheDatabase(string db)
        {
            List<IncomeOrderPaymentModel> incomeOrderPayments = new List<IncomeOrderPaymentModel>();
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnVal(db)))
            {
                incomeOrderPayments = connection.Query<IncomeOrderPaymentModel>("dbo.spIncomeOrderPayment_GetAll").ToList();
            }
            foreach(IncomeOrderPaymentModel incomeOrderPayment in incomeOrderPayments)
            {
                incomeOrderPayment.Staff = new StaffModel();
                incomeOrderPayment.Store = new StoreModel();
            }
            return incomeOrderPayments;
        }

        /// <summary>
        /// Match the staffs With the IncomeOrderPayments from the database
        /// </summary>
        /// <param name="incomeOrderPayments"></param>
        /// <param name="staffs"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public static List<IncomeOrderPaymentModel> SetStaffForEachIncomeOrderPaymentFromTheDatabase(List<IncomeOrderPaymentModel>incomeOrderPayments,List<StaffModel>staffs,string db)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnVal(db)))
            {
                foreach(IncomeOrderPaymentModel incomeOrderPayment in incomeOrderPayments)
                {
                    var p = new DynamicParameters();
                    p.Add("@IncomeOrderPaymentId", incomeOrderPayment.Id);
                    incomeOrderPayment.Staff.Id = connection.QuerySingle<int>("spIncomeOrderPayment_GetStaffIdByIncomeOrderPayment", p, commandType: CommandType.StoredProcedure);
                }
            }
            foreach (IncomeOrderPaymentModel incomeOrderPaymentModel in incomeOrderPayments)
            {

                incomeOrderPaymentModel.Staff = staffs.Find(x => x.Id == incomeOrderPaymentModel.Staff.Id);
            }
            return incomeOrderPayments;
        }

        /// <summary>
        /// Match the stores With the IncomeOrderPayments from the database
        /// </summary>
        /// <param name="incomeOrderPayments"></param>
        /// <param name="stores"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public static List<IncomeOrderPaymentModel>SetStoreForEachIncomeOrderPaymentFromTheDatabase(List<IncomeOrderPaymentModel>incomeOrderPayments,List<StoreModel>stores,string db)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnVal(db)))
            {
                foreach (IncomeOrderPaymentModel incomeOrderPayment in incomeOrderPayments)
                {
                    var p = new DynamicParameters();
                    p.Add("@IncomeOrderPaymentId", incomeOrderPayment.Id);
                    incomeOrderPayment.Store.Id = connection.QuerySingle<int>("spIncomeOrderPayment_GetStoreIdByIncomeOrderPaymentId", p, commandType: CommandType.StoredProcedure);
                }
            }
            foreach (IncomeOrderPaymentModel incomeOrderPaymentModel in incomeOrderPayments)
            {

                incomeOrderPaymentModel.Store = stores.Find(x => x.Id == incomeOrderPaymentModel.Staff.Id);
            }
            return incomeOrderPayments;
        }
        
        
    }
}
