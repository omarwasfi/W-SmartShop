using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public static class ShopBill
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


        /// <summary>
        /// Get all shopBills from the database
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
        /// Get all the shopBill Happend on the given date -day-
        /// </summary>
        /// <param name="shopBills"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public static List<ShopBillModel> FilterShopBillsByDate(List<ShopBillModel> shopBills , DateTime date)
        {
            List<ShopBillModel> fShopBills = new List<ShopBillModel>();
            foreach(ShopBillModel shopBill in shopBills)
            {
                if(shopBill.Date.Year == date.Year && shopBill.Date.Month == date.Month && shopBill.Date.Day == date.Day)
                {
                    fShopBills.Add(shopBill);
                }
            }
            return fShopBills;
        }


    }
}
