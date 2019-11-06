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
        /// Get list of categories , if the category name in the database return false
        /// </summary>
        /// <param name="categories"> list of category model </param>
        /// <param name="newName"> the new name of the category to check  </param>
        /// <returns></returns>
        public static bool CheckIfTheCategoryNameUnique(List<CategoryModel> categories , string newName)
        {
            foreach(CategoryModel category in categories)
            {
                if(category.Name == newName)
                {
                    return false;
                }
            }
            return true;
        }



    }
}
