using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public static class Category_Access
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


        /// <summary>
        /// Add the category to the database , return the category with the new Id
        /// </summary>
        /// <param name="newCategory"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public static CategoryModel AddCategoryToTheDatabase(CategoryModel newCategory, string db)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnVal(db)))
            {
                var p = new DynamicParameters();
                p.Add("CategoryName", newCategory.Name);



                p.Add("@Id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
                connection.Execute("dbo.spCategory_Create", p, commandType: CommandType.StoredProcedure);
                newCategory.Id = p.Get<int>("@Id");
            }
            return newCategory;
        }

    }
}
