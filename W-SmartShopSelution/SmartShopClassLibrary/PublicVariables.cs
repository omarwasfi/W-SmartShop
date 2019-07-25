using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public static class PublicVariables
    {
        /// <summary>
        /// The Current Staff member that use the program
        /// </summary>
        public static StaffModel Staff { get; set; }

        /// <summary>
        /// Get the store that the program works on
        /// </summary>
        public static StoreModel Store { get; set; }

        /// <summary>
        /// The Stocks in the store
        /// {Set} call each time you update the stocks
        /// {get} call each time you need the stocks
        /// </summary>
        public static List<StockModel> LoginStoreStocks { get; set; }

        /// <summary>
        /// All the categories in the database
        /// set first when the program opens
        /// </summary>
        public static List<CategoryModel> Categories { get; set; }

        /// <summary>
        /// All the brands in the database
        /// set first when the program opens
        /// </summary>
        public static List<BrandModel> Brands { get; set; }

        /// <summary>
        /// All Customer in the database
        /// set first when the program opens
        /// </summary>
        public static List<CustomerModel> Customers { get; set; }

        /// <summary>
        /// All Products list
        /// - Set after create new product
        /// - set when opening produts manager 
        /// </summary>
        public static  List<ProductModel> Products { get; set; }


    }
}
