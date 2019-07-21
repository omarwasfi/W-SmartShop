using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;

namespace Library
{
    public static class Staff
    {
        
        /// <summary>
        /// Gets all staff table from the database
        /// - set the person model for each staff
        /// - set the list of stores that he work in
        /// </summary>
        /// <returns></returns>
        public static List<StaffModel> GetStaffs(string db)
        {
            List<StaffModel> staffs = new List<StaffModel>();

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnVal(db)))
            {
                staffs = connection.Query<StaffModel>("dbo.spStaff_GetAll").ToList();
                foreach (StaffModel staff in staffs)
                {
                    var p = new DynamicParameters();
                    p.Add("@StaffId", staff.Id);
                    staff.Person = connection.QuerySingle<PersonModel>("spStaff_GetPersonByStaffId", p, commandType: CommandType.StoredProcedure);
                    staff.Permission = connection.QuerySingle<PermissionModel>("spStaff_GetPermissionByStaffId", p, commandType: CommandType.StoredProcedure);

                    // Add The List of stores that the saff work in
                    staff.Stores = new List<StoreModel>();
                    List<int> storesId = new List<int>();
                    var o = new DynamicParameters();
                    o.Add("@StaffId", staff.Id);
                    storesId = connection.Query<int>("dbo.spStaffStore_GetStoreIdByStaffId",o, commandType: CommandType.StoredProcedure).ToList();
                    foreach(int storeId in storesId)
                    {
                        var s = new DynamicParameters();
                        s.Add("StoreId", storeId);

                        s.Add("@StoreName","", dbType: DbType.String, direction: ParameterDirection.Output);
                        s.Add("@StorePhoneNumber", "", dbType: DbType.String, direction: ParameterDirection.Output);
                        s.Add("@StoreAddress","", dbType: DbType.String, direction: ParameterDirection.Output);
                        s.Add("@StoreCity", "", dbType: DbType.String, direction: ParameterDirection.Output);
                        s.Add("@StoreCountry", "", dbType: DbType.String, direction: ParameterDirection.Output);

                        connection.Execute("dbo.spStore_GetStoreInfoByStoreId", s , commandType: CommandType.StoredProcedure);
                        // add store model to the staff 
                        

                        staff.Stores.Add(new StoreModel {
                            Id = storeId,
                             Name = s.Get<string>("@StoreName"),
                            PhoneNumber = s.Get<string>("@StorePhoneNumber"),
                            Address = s.Get<string>("@StoreAddress"),
                            City = s.Get<string>("@StoreCity"),
                            Country = s.Get<string>("@StoreCountry")
                    });
                       
                    }
                }

                // for each staff create list of stores ,  set staff stores id foreach store get the rest of the info
                


            }
            return staffs;

        }

    }
}
