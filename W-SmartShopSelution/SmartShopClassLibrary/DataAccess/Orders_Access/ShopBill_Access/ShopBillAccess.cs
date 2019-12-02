using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public static class ShopBillAccess
    {
        /// <summary>
        /// Add shopBill to the database
        /// </summary>
        /// <param name="shopBill"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public static ShopBillModel AddShopBillToTheDatabase(ShopBillModel shopBill, string db)
        {

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnVal(db)))
            {
                var p = new DynamicParameters();
                p.Add("@StoreId", shopBill.Store.Id);
                p.Add("@StaffId", shopBill.Staff.Id);
                p.Add("@Date", shopBill.Date);
                p.Add("@Details", shopBill.Details);
                p.Add("@TotalMoney", shopBill.TotalMoney);
                p.Add("@Id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
                connection.Execute("dbo.spShopBill_Create", p, commandType: CommandType.StoredProcedure);
                shopBill.Id = p.Get<int>("@Id");

            }

            return shopBill;
        }


        public static List<ShopBillModel>GetShopBillsFromTheDatabase(string db)
        {
            List<ShopBillModel> shopBills = new List<ShopBillModel>();
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnVal(db)))
            {
                shopBills = connection.Query<ShopBillModel>("dbo.spShopBill_GetAll").ToList();

            }
            foreach (ShopBillModel shopBill in shopBills)
            {
                shopBill.Store = new StoreModel();
                shopBill.Staff = new StaffModel();
            }


            return shopBills;
        }

        /// <summary>
        /// Match stores with each shopBill from the database
        /// </summary>
        /// <param name="shopBills"></param>
        /// <param name="stores"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public static List<ShopBillModel> SetTheStoreForEachShopBillFromTheDatabase(List<ShopBillModel> shopBills, List<StoreModel> stores, string db)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnVal(db)))
            {
                foreach (ShopBillModel shopBill in shopBills)
                {
                    var p = new DynamicParameters();
                    p.Add("@ShopBillId", shopBill.Id);

                    shopBill.Store.Id = connection.QuerySingle<int>("spShopBill_GetStoreIdByShopBillId", p, commandType: CommandType.StoredProcedure);
                } 
            }

            foreach (ShopBillModel shopBillModel in shopBills)
            {
                shopBillModel.Store = stores.Find(x => x.Id == shopBillModel.Store.Id);
            }

            return shopBills;
        }

        /// <summary>
        /// Match staffs with each shopBill from the database
        /// </summary>
        /// <param name="shopBills"></param>
        /// <param name="staffs"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public static List<ShopBillModel> SetTheStaffForEachShopBillFromTheDatabase(List<ShopBillModel> shopBills, List<StaffModel> staffs, string db)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnVal(db)))
            {
                foreach (ShopBillModel shopBill in shopBills)
                {
                    var p = new DynamicParameters();
                    p.Add("@ShopBillId", shopBill.Id);

                    shopBill.Staff.Id = connection.QuerySingle<int>("spShopBill_GetStaffIdByShopBillId", p, commandType: CommandType.StoredProcedure);
                }
            }

            foreach (ShopBillModel shopBillModel in shopBills)
            {
                shopBillModel.Staff = staffs.Find(x => x.Id == shopBillModel.Staff.Id);
            }

            return shopBills;
        }




       

        /// <summary>
        /// -OLD-Get all shopBills from the database
        /// - set the storeModel
        /// - set the staffModel
        ///     -- set the personModel
        ///     -- Set the permissions
        /// </summary>
        /// <returns></returns>
        public static List<ShopBillModel> GetShopBills(string db)
        {
            List<ShopBillModel> shopBills = new List<ShopBillModel>();

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnVal(db)))
            {
                shopBills = connection.Query<ShopBillModel>("dbo.spShopBill_GetAll").ToList();
                foreach (ShopBillModel shopBill in shopBills)
                {
                    var p = new DynamicParameters();
                    p.Add("@ShopBillId", shopBill.Id);

                    // Set the store model 
                    shopBill.Store = connection.QuerySingle<StoreModel>("spShopBill_GetStoreByShopBillId", p, commandType: CommandType.StoredProcedure);
                    shopBill.Store.Name = connection.QuerySingle<string>("select Neme from Store where Id = " + shopBill.Store.Id + ";");


                    // set the staffModel
                    shopBill.Staff = connection.QuerySingle<StaffModel>("spShopBill_GetStaffByShopBillId", p, commandType: CommandType.StoredProcedure);
                    var ss = new DynamicParameters();
                    ss.Add("@StaffId", shopBill.Staff.Id);
                    shopBill.Staff.Person = connection.QuerySingle<PersonModel>("spStaff_GetPersonByStaffId", ss, commandType: CommandType.StoredProcedure);
                    shopBill.Staff.Permission = connection.QuerySingle<PermissionModel>("spStaff_GetPermissionByStaffId", ss, commandType: CommandType.StoredProcedure);
                }
            }

            return shopBills;
        }

        /// <summary>
        /// -OLD-Get all the shopBill Happend on the given date -day-
        /// </summary>
        /// <param name="shopBills"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public static List<ShopBillModel> FilterShopBillsByDate(List<ShopBillModel> shopBills, DateTime date)
        {
            List<ShopBillModel> fShopBills = new List<ShopBillModel>();
            foreach (ShopBillModel shopBill in shopBills)
            {
                if (shopBill.Date.Year == date.Year && shopBill.Date.Month == date.Month && shopBill.Date.Day == date.Day)
                {
                    fShopBills.Add(shopBill);
                }
            }
            return fShopBills;
        }


        /// <summary>
        /// -OLD-Add shopBill to the database
        /// </summary>
        /// <param name="shopBill"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public static ShopBillModel UpdateShopBillData(ShopBillModel shopBill, string db)
        {

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnVal(db)))
            {
                var p = new DynamicParameters();
                p.Add("@Id", shopBill.Id);
                p.Add("@Date", shopBill.Date);
                p.Add("@Details", shopBill.Details);
                p.Add("@TotalMoney", shopBill.TotalMoney);
                connection.Execute("dbo.spShopBill_Update", p, commandType: CommandType.StoredProcedure);

            }

            return shopBill;
        }


        /// <summary>
        /// -OLD-Delete ShopBill from the database
        /// </summary>
        /// <param name="orderProduct"></param>
        /// <param name="db"></param>
        public static void RemoveShopBill(ShopBillModel shopBill, string db)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnVal(db)))
            {
                var p = new DynamicParameters();
                p.Add("@Id", shopBill.Id);
                connection.Execute("dbo.spShopBill_Delete", p, commandType: CommandType.StoredProcedure);

            }
        }
    }
}
