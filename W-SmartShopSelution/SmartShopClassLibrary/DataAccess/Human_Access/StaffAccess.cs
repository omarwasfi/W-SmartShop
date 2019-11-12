using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;

namespace Library
{
    public static class StaffAccess
    {

        /// <summary>
        /// Get the staff Models
        /// - without PersonModel , ListOf stores , Permissions
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        public static List<StaffModel> GetStaffsFromTheDabase(string db)
        {
            List<StaffModel> staffs = new List<StaffModel>();
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnVal(db)))
            {
                staffs = connection.Query<StaffModel>("dbo.spStaff_GetAll").ToList();
            }
            foreach(StaffModel staff in staffs)
            {
                staff.Person = new PersonModel();
                staff.Permission = new PermissionModel();
                staff.Stores = new List<StoreModel>();
            }
            return staffs;
        }

        /// <summary>
        /// Sets The Person Model for each staff in the list
        ///   -Open the connection
        ///   -set the id of the person foreach staff
        ///   -Close the connection
        ///   -match the IDs to the publicVariables.People AND set the person model for each staffModel
        /// </summary>
        /// <param name="staffs"></param>
        /// <param name="people"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public static List<StaffModel> SetThePersonModelForEachStaffFromTheDatabase(List<StaffModel> staffs,List<PersonModel> people ,string db)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnVal(db)))
            {
                foreach(StaffModel staff in staffs)
                {
                    var p = new DynamicParameters();
                    p.Add("@StaffId", staff.Id);
                    staff.Person.Id = connection.QuerySingle<int>("spStaff_GetPersonIdByStaffId", p, commandType: CommandType.StoredProcedure);

                }
            }

            foreach(StaffModel staffModel in staffs)
            {
                staffModel.Person = people.Find(x => x.Id == staffModel.Person.Id);
            }

            return staffs;
        }


        /// <summary>
        /// Sets The store Models for each staff in the list
        ///   -Open the connection
        ///   - get the IDs of a staff Foreach ID Add store to the staff with this id
        ///   -Close the connection
        ///   -match the IDs to the publicVariables.Stores AND set the Store models for each staffModel
        /// </summary>
        /// <param name="staffs"></param>
        /// <param name="stores"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public static List<StaffModel> SetTheStorsForEachStaffFromTheDatabase(List<StaffModel> staffs, List<StoreModel> stores, string db)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnVal(db)))
            {
                foreach (StaffModel staff in staffs)
                {
                    List<int> storesId = new List<int>();
                    var o = new DynamicParameters();
                    o.Add("@StaffId", staff.Id);
                    storesId = connection.Query<int>("dbo.spStaffStore_GetStoreIdByStaffId", o, commandType: CommandType.StoredProcedure).ToList();

                    foreach (int id in storesId)
                    {
                        staff.Stores.Add(new StoreModel { Id = id });
                    }
                }
            }

            foreach (StaffModel staffModel in staffs)
            {
                // Get the Staff's Stores IDs
                List<int> staffStoreIds = new List<int>();
                foreach(StoreModel store in staffModel.Stores)
                {
                    staffStoreIds.Add(store.Id);
                }

                staffModel.Stores = new List<StoreModel>();

                foreach(int id in staffStoreIds)
                {
                    staffModel.Stores.Add(stores.Find(x => x.Id == id));
                }

            }

            return staffs;
        }

        /// <summary>
        /// Sets The Permission for each staff in the list
        ///   -Open the connection
        ///   - get the Ids of the permission and set it to Staff.Permission.Id
        ///   -Close the connection
        ///   -match the IDs to the publicVariables.Permission AND set the PermissionModel for each staffModel
        /// </summary>
        /// <param name="staffs"></param>
        /// <param name="permissions"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public static List<StaffModel>SetThePermissonModelForEachStaffFromTheDatabase(List<StaffModel> staffs , List<PermissionModel> permissions , string db)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnVal(db)))
            {
                foreach(StaffModel staff in staffs)
                {
                    var p = new DynamicParameters();
                    p.Add("@StaffId", staff.Id);
                    staff.Permission.Id = connection.QuerySingle<int>("spStaff_GetPermissionIdByStaffId", p, commandType: CommandType.StoredProcedure);

                }
            }

            foreach(StaffModel staffModel in staffs)
            {
                staffModel.Permission = permissions.Find(x => x.Id == staffModel.Permission.Id);
            }

            return staffs;
        }


        /// <summary>
        /// -OLD- Gets all staff table from the database
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
                    storesId = connection.Query<int>("dbo.spStaffStore_GetStoreIdByStaffId", o, commandType: CommandType.StoredProcedure).ToList();
                    foreach (int storeId in storesId)
                    {
                        var s = new DynamicParameters();
                        s.Add("StoreId", storeId);

                        s.Add("@StoreName", "", dbType: DbType.String, direction: ParameterDirection.Output);
                        s.Add("@StorePhoneNumber", "", dbType: DbType.String, direction: ParameterDirection.Output);
                        s.Add("@StoreAddress", "", dbType: DbType.String, direction: ParameterDirection.Output);
                        s.Add("@StoreCity", "", dbType: DbType.String, direction: ParameterDirection.Output);
                        s.Add("@StoreCountry", "", dbType: DbType.String, direction: ParameterDirection.Output);

                        connection.Execute("dbo.spStore_GetStoreInfoByStoreId", s, commandType: CommandType.StoredProcedure);
                        // add store model to the staff 


                        staff.Stores.Add(new StoreModel
                        {
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
        /// -OLD- Update staff member data From username , password and permissionId
        /// </summary>
        /// <param name="staff"></param>
        /// <param name="db"></param>
        public static void UpdateStaffData(StaffModel staff, string db)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnVal(db)))
            {
                var p = new DynamicParameters();
                p.Add("@StaffId", staff.Id);
                p.Add("@StaffUsername", staff.Username);
                p.Add("@StaffPassword", staff.Password);
                p.Add("@StaffPermissionId", staff.Permission.Id);
                p.Add("@StaffSalary", staff.Salary);
                connection.Execute("dbo.spStaff_Update", p, commandType: CommandType.StoredProcedure);
            }
        }

    }
}
