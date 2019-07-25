using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace Library
{
    public static class Brand
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
        /// Get list of brands , if the brand name in the database return false
        /// </summary>
        /// <param name="brands"> list of brand model </param>
        /// <param name="newName"> the new name of the brand to check  </param>
        /// <returns></returns>
        public static bool CheckIfTheBrandNameUnique(List<BrandModel> brands, string newName)
        {

            foreach(BrandModel brand in brands)
            {
                if(brand.Name == newName)
                {
                    return false;
                }
            }

            return true;
        }


        /// <summary>
        /// Save new brand to the database , return the new brand with new Id
        /// </summary>
        /// <param name="newBrand"> the new brand model </param>
        /// <param name="db"></param>
        /// <returns></returns>
        public static BrandModel AddBrandToTheDatabase(BrandModel newBrand,string db)
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
