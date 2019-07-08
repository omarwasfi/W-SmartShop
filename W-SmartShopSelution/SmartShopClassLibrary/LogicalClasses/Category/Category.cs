using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data;

namespace Library
{
    public static class Category
    {
        /// <summary>
        /// Get all categories from the database
        /// </summary>
        /// <param name="db"> Name OF the database connection </param>
        /// <returns> List of categories </returns>
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
