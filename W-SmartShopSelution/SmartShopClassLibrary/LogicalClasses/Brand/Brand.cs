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
        /// Get list of brands , if the brand name in the database return false
        /// </summary>
        /// <param name="brands"> list of brand model </param>
        /// <param name="newName"> the new name of the brand to check  </param>
        /// <returns></returns>
        public static bool CheckIfTheBrandNameUnique(List<BrandModel> brands, string newName)
        {

            foreach (BrandModel brand in brands)
            {
                if (brand.Name == newName)
                {
                    return false;
                }
            }

            return true;
        }


    }
}
