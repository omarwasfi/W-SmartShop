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
        public static List<BrandModel> GetBrands(string db)
        {
            List<BrandModel> brands;
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnVal(db)))
            {
                brands = connection.Query<BrandModel>("dbo.spBrand_GetAll").ToList();
            }
            return brands;
        }
    }
}
