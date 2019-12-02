using System.Collections.Generic;

namespace Library
{
    public static class PublicVariables
    {


        /// <summary>
        /// All the permissions in the database
        /// </summary>
        public static List<PermissionModel> Permissions { get; set; }

        /// <summary>
        /// all The people in the datbase (List of person models)
        /// </summary>
        public static List<PersonModel> People { get; set; }

        /// <summary>
        /// All Stores in the database
        /// </summary>
        public static List<StoreModel> Stores { get; set; }

        /// <summary>
        /// All Staffs of all stors
        /// </summary>
        public static List<StaffModel> Staffs { get; set; }

        /// <summary>
        /// All Customer in the database
        /// </summary>
        public static List<CustomerModel> Customers { get; set; }

        /// <summary>
        /// All The Suppliers
        /// </summary>
        public static List<SupplierModel> Suppliers { get; set; }

        /// <summary>
        /// All the Revenues
        /// </summary>
        public static List<RevenueModel> Revenues { get; set; }

        /// <summary>
        /// All The Investments
        /// </summary>
        public static List<InvestmentModel>Investments { get; set;}

        /// <summary>
        /// All Owners
        /// </summary>
        public static List<OwnerModel> Owners { get; set; }

        /// <summary>
        /// All The Transforms
        /// </summary>
        public static List<TransformModel> Transforms { get; set; }

        /// <summary>
        /// All DeTransforms
        /// </summary>
        public static List<DeTransformModel> DeTransforms { get; set; }

        /// <summary>
        /// All staffSalaries
        /// </summary>
        public static List<StaffSalaryModel> StaffSalaries { get; set; }

        /// <summary>
        /// All the categories in the database
        /// </summary>
        public static List<CategoryModel> Categories { get; set; }

        /// <summary>
        /// All the brands in the database
        /// </summary>
        public static List<BrandModel> Brands { get; set; }

        /// <summary>
        /// All Products list
        /// </summary>
        public static List<ProductModel> Products { get; set; }

        /// <summary>
        /// All Stocks For all stores
        /// </summary>
        public static List<StockModel> Stocks { get; set; }

        /// <summary>
        /// All the orderProducts in the database
        /// </summary>
        public static List<OrderProductModel> OrderProducts { get; set; }

        /// <summary>
        /// All the IncomeOrderProducts in the database
        /// </summary>
        public static List<IncomeOrderProductModel> IncomeOrderProducts { get; set; }

        /// <summary>
        /// All OrderPayments
        /// </summary>
        public static List<OrderPaymentModel> OrderPayments { get; set; }

        /// <summary>
        /// All IncomeOrderPayments
        /// </summary>
        public static List<IncomeOrderPaymentModel> IncomeOrderPayments { get; set; }

        /// <summary>
        /// All Orders
        /// </summary>
        public static List<OrderModel> Orders { get; set; }

        /// <summary>
        /// All the IncomeOrders 
        /// </summary>
        public static List<IncomeOrderModel> IncomeOrders { get; set; }

        /// <summary>
        /// All shopBills
        /// </summary>
        public static List<ShopBillModel> ShopBills { get; set; }

        /// <summary>
        /// The Organization Model
        /// </summary>
        public static OrganizationModel Organization { get; set; }

        /// <summary>
        /// All the operations in the database
        /// </summary>
        public static List<OperationModel> Operations { get; set; }

        /// <summary>
        /// The last added products
        /// </summary>
        public static List<ProductModel> RecentlyAddProducts { get; set; }

        /// <summary>
        /// The Current Staff member that use the program
        /// </summary>
        public static StaffModel Staff { get; set; }

        /// <summary>
        /// Get the store that the program works on
        /// </summary>
        public static StoreModel Store { get; set; }

        /// <summary>
        /// The Default personModel
        /// </summary>
        public static PersonModel DefaultPerson { get; set; }
        
        /// <summary>
        /// The Default Category
        /// </summary>
        public static CategoryModel DefaultCategory { get; set; }

        /// <summary>
        /// The Default Brand
        /// </summary>
        public static BrandModel DefaultBrand { get; set; }

        /// <summary>
        /// The Stocks in the store
        /// {Set} call each time you update the stocks
        /// {get} call each time you need the stocks
        /// </summary>
        public static List<StockModel> LoginStoreStocks { get; set; }



        

    }
}