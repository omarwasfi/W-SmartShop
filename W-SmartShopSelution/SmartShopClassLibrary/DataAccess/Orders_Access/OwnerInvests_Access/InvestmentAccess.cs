using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public static class InvestmentAccess
    {

        /// <summary>
        /// Add the investment to the database 
        /// </summary>
        /// <param name="investment">The new investment model</param>
        /// <param name="owner">The Owner who Invested the money</param>
        /// <param name="db"></param>
        /// <returns>The New investment with the new Id</returns>
        public static InvestmentModel AddInvestmentToTheDatabase(InvestmentModel investment, OwnerModel owner, string db)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnVal(db)))
            {
                var p = new DynamicParameters();
                p.Add("@OwnerId", owner.Id);
                p.Add("@Date", investment.Date);
                p.Add("@TotalMoney", investment.TotalMoney);
                p.Add("@StoreId", investment.Store.Id);
                p.Add("@StaffId", investment.Staff.Id);
                p.Add("@Id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
                connection.Execute("dbo.spInvestment_Create", p, commandType: CommandType.StoredProcedure);
                investment.Id = p.Get<int>("@Id");
            }

            return investment;
        }

        /// <summary>
        /// Get all investments from the database without the StaffModel and the storeModel
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        public static List<InvestmentModel> GetInvestmentsFromTheDatabae(string db)
        {
            List<InvestmentModel> investments = new List<InvestmentModel>();
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnVal(db)))
            {
                investments = connection.Query<InvestmentModel>("dbo.spInvestments_GetAll").ToList();
            }

            foreach (InvestmentModel investment in investments)
            {
                investment.Staff = new StaffModel();
                investment.Store = new StoreModel();
            }
            return investments;
        }

        /// <summary>
        /// Match the staffModels foreach Investment From the database
        /// </summary>
        /// <param name="investments"></param>
        /// <param name="staffs"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public static List<InvestmentModel> SetTheStaffModelForEachInvestmentFromTheDatabase(List<InvestmentModel> investments, List<StaffModel> staffs, string db)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnVal(db)))
            {
                foreach (InvestmentModel investment in investments)
                {
                    var p = new DynamicParameters();
                    p.Add("@InvestmentId", investment.Id);
                    investment.Staff.Id = connection.QuerySingle<int>("dbo.spInvestment_GetStaffIdByInvestmentId", p, commandType: CommandType.StoredProcedure);
                }
            }

            foreach (InvestmentModel investmentModel in investments)
            {
                investmentModel.Staff = staffs.Find(x => x.Id == investmentModel.Staff.Id);
            }

            return investments;
        }

        /// <summary>
        /// Match the stroreModels foreach Investment From the database
        /// </summary>
        /// <param name="investments"></param>
        /// <param name="stores"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public static List<InvestmentModel> SetTheStoreModelForEachInvestmentFromTheDatabase(List<InvestmentModel> investments, List<StoreModel> stores, string db)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnVal(db)))
            {
                foreach (InvestmentModel investment in investments)
                {
                    var p = new DynamicParameters();
                    p.Add("@InvestmentId", investment.Id);
                    investment.Store.Id = connection.QuerySingle<int>("spInvestment_GetStoreIdByInvestmentId", p, commandType: CommandType.StoredProcedure);
                }
            }

            foreach (InvestmentModel investmentModel in investments)
            {
                investmentModel.Store = stores.Find(x => x.Id == investmentModel.Store.Id);
            }

            return investments;
        }
    }
}
