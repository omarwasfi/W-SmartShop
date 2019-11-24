using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public static class RevenueAccess
    {
        /// <summary>
        /// Add the investment to the database. 
        ///  Add the investment to the publicVariables.Investments.
        ///  Add the investment to the owner.Investments
        /// </summary>
        /// <param name="revenue"></param>
        /// <param name="owner"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public static RevenueModel AddReveueToTheDatabase(RevenueModel revenue, OwnerModel owner,string db)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnVal(db)))
            {
                var p = new DynamicParameters();
                p.Add("@OwnerId", owner.Id);
                p.Add("@Date", revenue.Date);
                p.Add("@TotalMoney", revenue.TotalMoney);
                p.Add("@StoreId", revenue.Store.Id);
                p.Add("@StaffId", revenue.Staff.Id);
                p.Add("@Id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
                connection.Execute("dbo.spRevenue_Create", p, commandType: CommandType.StoredProcedure);
                revenue.Id = p.Get<int>("@Id");
            }
            return revenue;
        }

        /// <summary>
        /// Get all revenues from the database without the staffModel , storeModel
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        public static List<RevenueModel> GetRevenuesFromTheDatabae(string db)
        {
            List<RevenueModel> revenues = new List<RevenueModel>();
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnVal(db)))
            {
                revenues = connection.Query<RevenueModel>("dbo.spRevenue_GetAll").ToList();
            }

            foreach (RevenueModel revenue in revenues)
            {
                revenue.Staff = new StaffModel();
                revenue.Store = new StoreModel();
            }
            return revenues;
        }

        /// <summary>
        /// Match the staffModels woth the revenues from the database
        /// </summary>
        /// <param name="revenues"></param>
        /// <param name="staffs"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public static List<RevenueModel> SetTheStaffModelForEachRevenueFromTheDatabase(List<RevenueModel> revenues, List<StaffModel>staffs,string db)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnVal(db)))
            {
                foreach (RevenueModel revenue in revenues)
                {
                    var p = new DynamicParameters();
                    p.Add("@RevenueId", revenue.Id);
                    revenue.Staff.Id = connection.QuerySingle<int>("spRevenue_GetStaffIdByRevenueId", p, commandType: CommandType.StoredProcedure);
                }
            }

            foreach (RevenueModel revenueModel in revenues)
            {
                revenueModel.Staff = staffs.Find(x => x.Id == revenueModel.Staff.Id);
            }

            return revenues;
        }


        /// <summary>
        /// Match the storeModels woth the revenues from the database
        /// </summary>
        /// <param name="revenues"></param>
        /// <param name="stores"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public static List<RevenueModel> SetTheStoreModelForEachRevenueFromTheDatabase(List<RevenueModel> revenues, List<StoreModel> stores, string db)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnVal(db)))
            {
                foreach (RevenueModel revenue in revenues)
                {
                    var p = new DynamicParameters();
                    p.Add("@RevenueId", revenue.Id);
                    revenue.Store.Id = connection.QuerySingle<int>("spRevenue_GetStoreIdByRevenueId", p, commandType: CommandType.StoredProcedure);
                }
            }

            foreach (RevenueModel revenueModel in revenues)
            {
                revenueModel.Store = stores.Find(x => x.Id == revenueModel.Store.Id);
            }

            return revenues;
        }

    }
}
