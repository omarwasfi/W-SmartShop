using Library.DataModels.Goods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;

namespace Library.LogicalClasses.Category
{
    public static class Category
    {
        public static List<CategoryModel> GetCategories(string db)
        {
            List<CategoryModel> categories;
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnVal(db)))
            {
                categories = connection.Query<CategoryModel>("dbo.spCategory_GetAll").ToList();
            }
            return categories;
        }
    }
}
