using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Library.DataModels.Goods;
using Library.LogicalClasses.Category;

namespace Library.DataAccess
{
    public class DataAccess
    {
        /// <summary>
        /// Database name
        /// </summary>
        private const string db = "SmartShopConnection";

        public List<CategoryModel> GetCategories()
        {
            return Category.GetCategories(db);
        }
    }
}
