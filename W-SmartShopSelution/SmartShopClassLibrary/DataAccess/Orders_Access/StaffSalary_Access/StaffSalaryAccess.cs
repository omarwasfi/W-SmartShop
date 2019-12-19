using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public static class StaffSalaryAccess
    {
        /// <summary>
        /// Get all StaffSalaries from the database without set the StoreModel,StaffModel , ToStaffModel
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        public static List<StaffSalaryModel>GetStaffSalariesFromTheDatabase(string db)
        {
            List<StaffSalaryModel> staffSalaries = new List<StaffSalaryModel>();
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnVal(db)))
            {
                staffSalaries = connection.Query<StaffSalaryModel>("dbo.spStaffSalary_GetAll").ToList();
            }
            foreach(StaffSalaryModel staffSalary in staffSalaries)
            {
                staffSalary.Store = new StoreModel();
                staffSalary.Staff = new StaffModel();
                staffSalary.ToStaff = new StaffModel();
            }
            return staffSalaries;
        }


        /// <summary>
        /// Match the Stores with Each StaffSalaryModel From the database
        /// </summary>
        /// <param name="staffSalaries"></param>
        /// <param name="stores"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public static List<StaffSalaryModel> SetTheStoreForEachStaffSalaryFromTheDatabase(List<StaffSalaryModel>staffSalaries,List<StoreModel>stores,string db)
        {
            
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnVal(db)))
            {
                foreach (StaffSalaryModel staffSalaryModel in staffSalaries)
                {
                    var p = new DynamicParameters();
                    p.Add("@StaffSalaryId", staffSalaryModel.Id);

                    staffSalaryModel.Store.Id = connection.QuerySingle<int>("spStaffSalary_GetStoreIdByStaffSalaryId", p, commandType: CommandType.StoredProcedure);
                }
            }

            foreach (StaffSalaryModel staffSalary in staffSalaries)
            {
                staffSalary.Store = stores.Find(x => x.Id == staffSalary.Store.Id);
            }
            return staffSalaries;
        }


        /// <summary>
        /// Match the staffs with Each StaffSalaryModel.Staff From the database
        /// </summary>
        /// <param name="staffSalaries"></param>
        /// <param name="staffs"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public static List<StaffSalaryModel> SetTheStaffForEachStaffSalaryFromTheDatabase(List<StaffSalaryModel> staffSalaries, List<StaffModel> staffs, string db)
        {

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnVal(db)))
            {
                foreach (StaffSalaryModel staffSalaryModel in staffSalaries)
                {
                    var p = new DynamicParameters();
                    p.Add("@StaffSalaryId", staffSalaryModel.Id);

                    staffSalaryModel.Staff.Id = connection.QuerySingle<int>("spStaffSalary_GetStaffIdByStaffSalaryId", p, commandType: CommandType.StoredProcedure);
                }
            }

            foreach (StaffSalaryModel staffSalary in staffSalaries)
            {
                staffSalary.Staff = staffs.Find(x => x.Id == staffSalary.Staff.Id);
            }
            return staffSalaries;
        }

        /// <summary>
        /// Match the Staffs with Each StaffSalaryModel.ToStaff From the database
        /// </summary>
        /// <param name="staffSalaries"></param>
        /// <param name="staffs"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public static List<StaffSalaryModel> SetTheToStaffForEachStaffSalaryFromTheDatabase(List<StaffSalaryModel> staffSalaries, List<StaffModel> staffs, string db)
        {

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnVal(db)))
            {
                foreach (StaffSalaryModel staffSalaryModel in staffSalaries)
                {
                    var p = new DynamicParameters();
                    p.Add("@StaffSalaryId", staffSalaryModel.Id);

                    staffSalaryModel.ToStaff.Id = connection.QuerySingle<int>("spStaffSalary_GetToStaffIdByStaffSalaryId", p, commandType: CommandType.StoredProcedure);
                }
            }

            foreach (StaffSalaryModel staffSalary in staffSalaries)
            {
                staffSalary.ToStaff = staffs.Find(x => x.Id == staffSalary.ToStaff.Id);
            }
            return staffSalaries;
        }

        /// <summary>
        /// Add Staff Salary to the database
        /// </summary>
        /// <param name="staffSalary"></param>
        /// <returns></returns>
        public static StaffSalaryModel AddStaffSalaryToDatabase(StaffSalaryModel staffSalary,string db)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnVal(db)))
            {
                var p = new DynamicParameters();
                p.Add("@StoreId", staffSalary.Store.Id);
                p.Add("@StaffId", staffSalary.Staff.Id);
                p.Add("@Date", staffSalary.Date);
                p.Add("@Salary", staffSalary.Salary);
                p.Add("@Details", staffSalary.Details);
                p.Add("@ToStaffId", staffSalary.ToStaff.Id);
                p.Add("@Id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
                connection.Execute("dbo.spStaffSalary_Create", p, commandType: CommandType.StoredProcedure);
                staffSalary.Id = p.Get<int>("@Id");

            }
            return staffSalary;
        }

    }
}
