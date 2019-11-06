using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;


namespace Library
{
    public static class Store_Access
    {

        /// <summary>
        /// get all stores from the database ,
        /// each store model contain ID , Name
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        public static List<StoreModel> GetAllStores(string db)
        {
            List<StoreModel> stores = new List<StoreModel>();
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnVal(db)))
            {

                stores = connection.Query<StoreModel>("select * from Store").ToList();
                foreach (StoreModel s in stores)
                {
                    s.Name = connection.QuerySingle<string>("select Neme from Store where Id = " + s.Id + ";");
                }
            }
            return stores;
        }




    }
}
