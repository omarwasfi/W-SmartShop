using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;
using System.Text.RegularExpressions;

namespace Library
{
    public static class Staff
    {
        
        /// <summary>
        /// Gets all staff table from the database
        /// - set the person model for each staff
        /// - set the list of stores that he work in
        /// - set the permission model 
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

        /// <summary>
        /// Get the Staffs whoes works in store
        /// get list of all staffs and store model
        /// return the staffs that works in the store model
        /// </summary>
        /// <param name="staffs"></param>
        /// <param name="store"></param>
        /// <returns></returns>
        public static List<StaffModel> FilterStaffsByStore(List<StaffModel> staffs , StoreModel store)
        {
            List<StaffModel> FStaffs = new List<StaffModel>();
            foreach (StaffModel staff in staffs)
            {
                foreach(StoreModel storeModel in staff.Stores)
                {
                    if(storeModel.Id == store.Id)
                    {
                        FStaffs.Add(staff);
                        break;
                    }
                }
            }
            return FStaffs;
        }
        

        /// <summary>
        /// Filter staffs by person name 
        /// get list of staffs and fullName 
        /// return list of staffs if the personName matches
        /// </summary>
        /// <param name="staffs"></param>
        /// <param name="username"></param>
        /// <returns></returns>
        public static List<StaffModel> FilterSatffsByPersonFullName(List<StaffModel> staffs , string fullName)
        {
            List<StaffModel> FStaffs = new List<StaffModel>();
            foreach(StaffModel staff in staffs)
            {
                if (Regex.IsMatch(staff.Person.FullName, Regex.Escape(fullName), RegexOptions.IgnoreCase))
                {
                    FStaffs.Add(staff);
                }
            }
            return FStaffs;
        }

        /// <summary>
        /// Filter staffs by username 
        /// get list of staffs and userName 
        /// return list of staffs if the personName matches
        /// </summary>
        /// <param name="staffs"></param>
        /// <param name="username"></param>
        /// <returns></returns>
        public static List<StaffModel> FilterSatffsByUsername(List<StaffModel> staffs, string username)
        {
            List<StaffModel> FStaffs = new List<StaffModel>();
            foreach (StaffModel staff in staffs)
            {
                if (Regex.IsMatch(staff.Username, Regex.Escape(username), RegexOptions.IgnoreCase))
                {
                    FStaffs.Add(staff);
                }
            }
            return FStaffs;
        }


        /// <summary>
        /// Check if the user name unique 
        /// If unique return true
        /// if NOT return false
        /// </summary>
        /// <param name="staffs"></param>
        /// <param name="newUsername"></param>
        /// <returns></returns>
        public static bool CheckIfTheUsernameUnique(List<StaffModel> staffs , string newUsername)
        {
            foreach(StaffModel staff in staffs)
            {
                if(staff.Username == newUsername)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Update staff member data From username , password and permissionId
        /// </summary>
        /// <param name="staff"></param>
        /// <param name="db"></param>
        public static void UpdateStaffData(StaffModel staff , string db)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnVal(db)))
            {
                var p = new DynamicParameters();
                p.Add("@StaffId", staff.Id);
                p.Add("@StaffUsername", staff.Username);
                p.Add("@StaffPassword", staff.Password);
                p.Add("@StaffPermissionId", staff.Permission.Id);

                connection.Execute("dbo.spStaff_Update", p, commandType: CommandType.StoredProcedure);
            }
        }



    }
}
