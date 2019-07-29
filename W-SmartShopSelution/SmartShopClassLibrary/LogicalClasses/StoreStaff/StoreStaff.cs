using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public static class StoreStaff
    {
        /// <summary>
        /// Add store staff in the database
        /// </summary>
        /// <param name="store"> store model</param>
        /// <param name="staff">staff model </param>
        public static void AddStoreStaffToTheDatabase(StoreModel store , StaffModel staff , string db)
        {

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnVal(db)))
            {
                var p = new DynamicParameters();
                p.Add("StaffId", staff.Id);
                p.Add("StoreId", store.Id);
                connection.Execute("dbo.spStaffStore_Create", p, commandType: CommandType.StoredProcedure);

            }

        }

        /// <summary>
        /// Remove store staff in the database
        /// </summary>
        /// <param name="store"> store model</param>
        /// <param name="staff">staff model </param>
        public static void RemoveStoreStaffToTheDatabase(StoreModel store, StaffModel staff , string db)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnVal(db)))
            {
                var p = new DynamicParameters();
                p.Add("StaffId", staff.Id);
                p.Add("StoreId", store.Id);

                connection.Execute("dbo.spStaffStore_Delete", p, commandType: CommandType.StoredProcedure);

            }
        }
    }
}
