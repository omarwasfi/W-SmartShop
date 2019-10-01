using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public static class PublicVariables
    {

        public static string OrganizationName { get; set; }

        public static string OrganizationAddress { get; set; }

        public static string OrganizationPhoneNumber { get; set; }

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
        /// - Set in the LoginUC
        /// </summary>
        public static  List<ProductModel> Products { get; set; }

        /// <summary>
        /// All Stocks
        /// set when modifyProductUC fired
        ///  - Set in the LoginUC
        /// </summary>
        public static List<StockModel> Stocks { get; set; }

        /// <summary>
        /// All Staffs of all stors
        /// set when staffs manager UC fires
        /// </summary>
        public static List<StaffModel> Staffs { get; set; }

        /// <summary>
        /// All Stores 
        /// - set when StaffManagerUC Fires
        /// - Set In the loginU
        /// </summary>
        public static List<StoreModel> Stores { get; set; }

        /// <summary>
        /// All Store Orders
        /// - Set In the loginUC
        /// </summary>
        public static List<OrderModel> Orders { get; set; }

        /// <summary>
        /// All the IncomeOrders
        /// - Set in the loginUC
        /// </summary>
        public static List<IncomeOrderModel> IncomeOrders { get; set; }

        /// <summary>
        /// All The Suppliers
        /// Set in the LoginUC
        /// </summary>
        public static List<SupplierModel> Suppliers { get; set; }

        /// <summary>
        /// All the operations in the database
        /// </summary>
        public static List<OperationModel> Operations { get; set; }
    }
}
