using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
   
    public static class Brand_Access
    {

        /// <summary>
        /// Get all brands from the database
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        public static List<BrandModel> GetBrands(string db)
        {
            List<BrandModel> brands;
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnVal(db)))
            {
                brands = connection.Query<BrandModel>("dbo.spBrand_GetAll").ToList();
            }
            return brands;
        }

        /// <summary>
        /// Save new brand to the database , return the new brand with new Id
        /// </summary>
        /// <param name="newBrand"> the new brand model </param>
        /// <param name="db"></param>
        /// <returns></returns>
        public static BrandModel AddBrandToTheDatabase(BrandModel newBrand, string db)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnVal(db)))
            {
                var p = new DynamicParameters();
                p.Add("@BrandName", newBrand.Name);



                p.Add("@Id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
                connection.Execute("dbo.spBrand_Create", p, commandType: CommandType.StoredProcedure);
                newBrand.Id = p.Get<int>("@Id");
            }
            return newBrand;
        }

    }
}
