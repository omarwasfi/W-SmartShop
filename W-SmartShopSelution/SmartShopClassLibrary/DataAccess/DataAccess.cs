﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Library;
//using Excel = Microsoft.Office.Interop.Excel;

namespace Library
{

    public class DataAccess
    {
        /// <summary>
        /// Database name
        /// </summary>
        private const string db = "SmartShopConnection";



         

        
        #region GetTheData and set the public variables

        /// <summary>
        /// Set all the public variables from the database
        /// </summary>
        public void SetThePublicVariables()
        {
            // 1- Set the Permissions
            PublicVariables.Permissions = null;
            PublicVariables.Permissions = GetAllPermissionsFromTheDatabase();

            // 2- Set the Person models
            PublicVariables.People = null;
            PublicVariables.People = GetPeopleFromTheDatabase();
           

            // 3- set the store models
            PublicVariables.Stores = null;
            PublicVariables.Stores = GetStoresFromTheDatabase();

            // 4- Set the staff models
            PublicVariables.Staffs = null;
            PublicVariables.Staffs = GetStaffsFromTheDatabase(PublicVariables.People,PublicVariables.Stores,PublicVariables.Permissions);

            // 5- Set the Customer models
            PublicVariables.Customers = null;
            PublicVariables.Customers = GetCustomersFromTheDatabase(PublicVariables.People);
      
            // 6- Set The Supplier Models
            PublicVariables.Suppliers = null;
            PublicVariables.Suppliers = GetSuppliersFromTheDatabase(PublicVariables.People);


            // 7- Set the Revenue
            PublicVariables.Revenues = null;
            PublicVariables.Revenues = GetRevenuesFromThaDatbase(PublicVariables.Staffs, PublicVariables.Stores);

            // 8- Set the Investment
            PublicVariables.Investments = null;
            PublicVariables.Investments = GetInvestmentsFromTheDatabase(PublicVariables.Staffs, PublicVariables.Stores);

            // 9- Set the Owner Models
            PublicVariables.Owners = null;
            PublicVariables.Owners = GetOwnersFromTheDatabase(PublicVariables.People,PublicVariables.Investments,PublicVariables.Revenues);

            // 10- Set the Transform
            PublicVariables.Transforms = null;
            PublicVariables.Transforms = GetTransformsFromTheDatabase(PublicVariables.Staffs, PublicVariables.Stores);

            // 11- set the DeTransform
            PublicVariables.DeTransforms = null;
            PublicVariables.DeTransforms = GetDeTransformsFromTheDatabase(PublicVariables.Staffs, PublicVariables.Stores);

            // 12- Set the StaffSalary
            PublicVariables.StaffSalaries = null;
            PublicVariables.StaffSalaries = GetStaffSalariesFromTheDatabase(PublicVariables.Stores, PublicVariables.Staffs);

            // 13- Set the Brands
            PublicVariables.Brands = null;
            PublicVariables.Brands = GetBrandsFromTheDatabase();

            // 14- Set the categories
            PublicVariables.Categories = null;
            PublicVariables.Categories = GetCategoriesFromTheDatabase();


            // 15- Set the Products
            PublicVariables.Products = null;
            PublicVariables.Products = GetProductsFromTheDatabase(PublicVariables.Categories,PublicVariables.Brands);

            // 16- Set the stocks
            PublicVariables.Stocks = null;
            PublicVariables.Stocks = GetStocksFromTheDatabase(PublicVariables.Stores, PublicVariables.Products);

            // 17-Set the orderProducts
            PublicVariables.OrderProducts = null;
            PublicVariables.OrderProducts = GetOrderProductsFromTheDatabase(PublicVariables.Products);

            // 18- Set the IncomeOrderProduct
            PublicVariables.IncomeOrderProducts = null;
            PublicVariables.IncomeOrderProducts = GetIncomeOrderProductsFromTheDatabase(PublicVariables.Products);

            //19- Set the OrderPayment Models
            PublicVariables.OrderPayments = null;
            PublicVariables.OrderPayments = GetOrderPaymentsFromTheDatabase(PublicVariables.Staffs,PublicVariables.Stores);

            // 20- Set the IncomeOrderPayment Models
            PublicVariables.IncomeOrderPayments = null;
            PublicVariables.IncomeOrderPayments = GetIncomeOrderPaymentsFromTheDatabase(PublicVariables.Staffs, PublicVariables.Stores);

            // 21- Set the Orders
            PublicVariables.Orders = null;
            PublicVariables.Orders = GetOrdersFromTheDatabase(PublicVariables.Customers, PublicVariables.Stores, PublicVariables.Staffs, PublicVariables.OrderProducts,PublicVariables.OrderPayments);

            // 22- set the IncomeOrder Models
            PublicVariables.IncomeOrders = null;
            PublicVariables.IncomeOrders = GetIncomeOrdersFromTheDatabase(PublicVariables.Suppliers, PublicVariables.Stores, PublicVariables.Staffs, PublicVariables.IncomeOrderPayments, PublicVariables.IncomeOrderProducts);

            // 23- set the ShopBills
            PublicVariables.ShopBills = null;
            PublicVariables.ShopBills = GetShopBillsFromTheDatabase(PublicVariables.Stores, PublicVariables.Staffs);
            
            // 24- Set the Operations
            PublicVariables.Operations = null;
            PublicVariables.Operations = CreateTheOperations(PublicVariables.Transforms, PublicVariables.DeTransforms, PublicVariables.OrderPayments, PublicVariables.IncomeOrderPayments, PublicVariables.ShopBills, PublicVariables.StaffSalaries);

            // 24- Set the Organization
            PublicVariables.Organization = null;
            PublicVariables.Organization = new OrganizationModel
            {
                Name = "",
                Address = "Egypt,Ismailia",
                PhoneNumber = "01555707375",
                Investments = PublicVariables.Investments,
                Revenues = PublicVariables.Revenues
            };

            //25- Initial the Recently added products
            PublicVariables.RecentlyAddProducts = new List<ProductModel>();

            //26- Set the Defaults
            PublicVariables.DefaultBrand = null;
            PublicVariables.DefaultBrand = PublicVariables.Brands.Find(x => x.Id == 10000);
            PublicVariables.DefaultCategory = null;
            PublicVariables.DefaultCategory = PublicVariables.Categories.Find(x=>x.Id == 11000);
            PublicVariables.DefaultPerson = null;
            PublicVariables.DefaultPerson = PublicVariables.People.Find(x => x.Id == 1000000);
        }

        /// <summary>
        /// Gets all the Permissions From the database
        /// </summary>
        /// <returns></returns>
        private List<PermissionModel> GetAllPermissionsFromTheDatabase()
        {
            return Permission_Access.GetAllPermissionsFromTheDatabase(db);
        }

        /// <summary>
        /// Get people from the database
        /// </summary>
        /// <returns></returns>
        private List<PersonModel> GetPeopleFromTheDatabase()
        {
            return PersonAccess.GetPeopleFromTheDatabase(db);
        }

        /// <summary>
        /// Get all stores From the database
        /// </summary>
        /// <returns></returns>
        private List<StoreModel> GetStoresFromTheDatabase()
        {
            return Store_Access.GetAllStores(db);
        }

        /// <summary>
        /// Gets all staff table from the database
        /// - set the person model for each staff
        /// - set the list of stores that he work in
        /// - set the permission model 
        /// </summary>
        /// <param name="people"> All the people in the database </param>
        /// <param name="stores"> all the stores</param>
        /// <param name="permissions"> all the permissions </param>
        /// <returns></returns>
        private List<StaffModel> GetStaffsFromTheDatabase(List<PersonModel> people , List<StoreModel> stores , List<PermissionModel> permissions)
        {
            List<StaffModel> staffs = new List<StaffModel>();

            staffs = StaffAccess.GetStaffsFromTheDabase(db);

            staffs =  StaffAccess.SetThePersonModelForEachStaffFromTheDatabase(staffs, people, db);

            staffs = StaffAccess.SetTheStorsForEachStaffFromTheDatabase(staffs, stores, db);

            staffs = StaffAccess.SetThePermissonModelForEachStaffFromTheDatabase(staffs, permissions, db);

            return staffs;
        }

        /// <summary>
        /// Get all Customers from the database
        /// - set the person model foreach one of them
        /// </summary>
        /// <param name="people"></param>
        /// <returns></returns>
        private List<CustomerModel> GetCustomersFromTheDatabase(List<PersonModel> people)
        {
            List<CustomerModel> customers = new List<CustomerModel>();

            customers = CustomerAccess.GetCustomersFromTheDatabae(db);
            customers = CustomerAccess.SetThePersonModelForEachCustomerFromTheDatabase(customers, people, db);

            return customers;
        }

        /// <summary>
        /// Get all the suppliers from the database
        /// - set the person model foreach one of them
        /// </summary>
        /// <param name="people"></param>
        /// <returns></returns>
        private List<SupplierModel> GetSuppliersFromTheDatabase(List<PersonModel> people)
        {
            List<SupplierModel> suppliers = new List<SupplierModel>();
            suppliers = SupplierAccess.GetSuppliersFromTheDatabase(db);
            suppliers = SupplierAccess.SetThePersonModelForEachSupplierFromTheDatabase(suppliers, people, db);
            return suppliers;
        }

        /// <summary>
        /// Get all revenues from the Database Set the staffModels and the storeModel Foreach one
        /// </summary>
        /// <param name="staffs"></param>
        /// <param name="stores"></param>
        /// <returns></returns>
        private List<RevenueModel> GetRevenuesFromThaDatbase(List<StaffModel> staffs , List<StoreModel> stores)
        {
            List<RevenueModel> revenues = new List<RevenueModel>();
            revenues = RevenueAccess.GetRevenuesFromTheDatabae(db);
            revenues = RevenueAccess.SetTheStaffModelForEachRevenueFromTheDatabase(revenues, staffs, db);
            revenues = RevenueAccess.SetTheStoreModelForEachRevenueFromTheDatabase(revenues, stores, db);

            return revenues;
        }
        
        /// <summary>
        /// Get all investments from the Database Set the staffModels and the storeModel Foreach one
        /// </summary>
        /// <param name="staffs"></param>
        /// <param name="stores"></param>
        /// <returns></returns>
        private List<InvestmentModel> GetInvestmentsFromTheDatabase(List<StaffModel>staffs , List<StoreModel> stores)
        {
            List<InvestmentModel> investments = new List<InvestmentModel>();
            investments = InvestmentAccess.GetInvestmentsFromTheDatabae(db);
            investments = InvestmentAccess.SetTheStaffModelForEachInvestmentFromTheDatabase(investments, staffs, db);
            investments = InvestmentAccess.SetTheStoreModelForEachInvestmentFromTheDatabase(investments, stores, db);

            return investments;
        }

        /// <summary>
        /// Get owners from the database
        /// - set the personModel ForEach owner
        /// - set the investments ForEach owner
        /// - set the revenues ForEach owner
        /// </summary>
        /// <param name="people"></param>
        /// <param name="investments"></param>
        /// <param name="revenues"></param>
        /// <returns></returns>
        private List<OwnerModel> GetOwnersFromTheDatabase(List<PersonModel> people, List<InvestmentModel> investments, List<RevenueModel> revenues)
        {
            List<OwnerModel> owners = new List<OwnerModel>();
            owners = OwnerAccess.GetOwnersFromTheDatabae(db);
            owners = OwnerAccess.SetThePersonModelForEachOwnerFromTheDatabase(owners, people, db);
            owners = OwnerAccess.SetTheInvestmentsForEachOwnerFromTheDatabase(owners, investments, db);
            owners = OwnerAccess.SetTheRevenuesForEachOwnerFromTheDatabase(owners, revenues, db);
            return owners;
        }

        /// <summary>
        /// Get transforms From the database
        /// - Set the staffModel, storeModel , ToStoreModel
        /// </summary>
        /// <param name="staffs"></param>
        /// <param name="stores"></param>
        /// <returns></returns>
        private List<TransformModel> GetTransformsFromTheDatabase(List<StaffModel> staffs, List<StoreModel> stores)
        {
            List<TransformModel> transforms = new List<TransformModel>();
            transforms = TransformAccess.GetTrasformsFromTheDatabase(db);
            transforms = TransformAccess.SetTheStaffForEachTransformFromTheDatabase(transforms, staffs, db);
            transforms = TransformAccess.SetTheStoreForEachTransformFromTheDatabase(transforms, stores, db);
            transforms = TransformAccess.SetTheToStoreForEachTransformFromTheDatabase(transforms, stores, db);
            return transforms;
        }

        /// <summary>
        /// Get DeTransforms From the database 
        /// - Set the StoreModel , StaffModel , FromStoreModel
        /// </summary>
        /// <param name="staffs"></param>
        /// <param name="stores"></param>
        /// <returns></returns>
        private List<DeTransformModel> GetDeTransformsFromTheDatabase(List<StaffModel> staffs, List<StoreModel> stores)
        {
            List<DeTransformModel> deTransforms = new List<DeTransformModel>();
            deTransforms = DeTransformAccess.GetDeTrasformsFromTheDatabase(db);
            deTransforms = DeTransformAccess.SetTheStoreForEachDeTransformFromTheDatabase(deTransforms, stores, db);
            deTransforms = DeTransformAccess.SetTheStaffForEachDeTransformFromTheDatabase(deTransforms, staffs, db);
            deTransforms = DeTransformAccess.SetTheFromStoreForEachDeTransformFromTheDatabase(deTransforms, stores, db);
            return deTransforms;
        }

        /// <summary>
        /// Get all staffSalaries from the database -
        /// set the storeModel , staffModel , ToStaffModel
        /// </summary>
        /// <param name="stores"></param>
        /// <param name="staffs"></param>
        /// <returns></returns>
        private List<StaffSalaryModel> GetStaffSalariesFromTheDatabase(List<StoreModel> stores, List<StaffModel> staffs)
        {
            List<StaffSalaryModel> staffSalaries = new List<StaffSalaryModel>();
            staffSalaries = StaffSalaryAccess.GetStaffSalariesFromTheDatabase(db);
            staffSalaries = StaffSalaryAccess.SetTheStaffForEachStaffSalaryFromTheDatabase(staffSalaries, staffs, db);
            staffSalaries = StaffSalaryAccess.SetTheStoreForEachStaffSalaryFromTheDatabase(staffSalaries, stores, db);
            staffSalaries = StaffSalaryAccess.SetTheToStaffForEachStaffSalaryFromTheDatabase(staffSalaries, staffs, db);
            return staffSalaries;
        }

        /// <summary>
        /// Get all the categories from the database
        /// </summary>
        /// <returns></returns>
        private List<CategoryModel> GetCategoriesFromTheDatabase()
        {
            return CategoryAccess.GetCategories(db);
        }

        /// <summary>
        /// Get all Brands From the database
        /// </summary>
        /// <returns></returns>
        private List<BrandModel> GetBrandsFromTheDatabase()
        {
            return BrandAccess.GetBrands(db);
        }

        /// <summary>
        /// Get all the products 
        /// - set the categoryModel foreach one
        /// - set the brandModel foreach one
        /// </summary>
        /// <param name="categories"></param>
        /// <param name="brands"></param>
        /// <returns></returns>
        private List<ProductModel> GetProductsFromTheDatabase(List<CategoryModel>categories,List<BrandModel>brands)
        {
            List<ProductModel> products = new List<ProductModel>();
            products = ProductAccess.GetProductsFromTheDabase(db);
            products = ProductAccess.SetTheCategoryModelForEachProductFromTheDatabase(products, categories,db);
            products = ProductAccess.SetTheBrandModelForEachProductFromTheDatabase(products, brands, db);
            return products;
        }

        /// <summary>
        /// Get all stocks from the database 
        /// - set the storemodel and the product model foreach stock
        /// </summary>
        /// <param name="stores"></param>
        /// <param name="products"></param>
        /// <returns></returns>
        private List<StockModel> GetStocksFromTheDatabase(List<StoreModel>stores,List<ProductModel>products)
        {
            List<StockModel> stocks = new List<StockModel>();
            stocks = StockAccess.GetAllStocksFromTheDatabase(db);
            stocks = StockAccess.SetTheProductForEachStockFromTheDatabase(stocks, products, db);
            stocks = StockAccess.SetTheStoreForEachStockFromTheDatabase(stocks, stores, db);
            return stocks;
        }

        /// <summary>
        /// Get all OrderProducts from the database
        /// - set the productModel Foreach one of them
        /// </summary>
        /// <param name="products"></param>
        /// <returns></returns>
        private List<OrderProductModel> GetOrderProductsFromTheDatabase(List<ProductModel>products)
        {
            List<OrderProductModel> orderProductModels = new List<OrderProductModel>();
            orderProductModels = OrderProductAccess.GetOrderProductsFromTheDatabase(db);
            orderProductModels = OrderProductAccess.SetTheProductModelForEachOrderProductFromTheDatabase(orderProductModels, products, db);
            return orderProductModels;
        }

        /// <summary>
        /// Get all IncomeOrderProducts From the database
        /// - set the ProductModel foreach one of them
        /// </summary>
        /// <param name="products"></param>
        /// <returns></returns>
        private List<IncomeOrderProductModel> GetIncomeOrderProductsFromTheDatabase(List<ProductModel>products)
        {
            List<IncomeOrderProductModel> incomeOrderProducts = new List<IncomeOrderProductModel>();
            incomeOrderProducts = IncomeOrderProductAccess.GetIncomeOrderProductsFromTheDatabase(db);
            incomeOrderProducts = IncomeOrderProductAccess.SetTheProductModelForEachIncomeProductFromTheDatabase(incomeOrderProducts, products, db);
            return incomeOrderProducts;
        }

        /// <summary>
        /// Get all OrderPayments From the database
        /// -Set the StaffModel , StoreModel
        /// </summary>
        /// <returns></returns>
        private List<OrderPaymentModel> GetOrderPaymentsFromTheDatabase(List<StaffModel>staffs,List<StoreModel>stores)
        {
            List<OrderPaymentModel> orderPayments = new List<OrderPaymentModel>();
            orderPayments = OrderPaymentAccess.GetOrderPaymentsFromTheDatabase(db);
            orderPayments = OrderPaymentAccess.SetStaffForEachOrderPaymentFromTheDatabase(orderPayments, staffs, db);
            orderPayments = OrderPaymentAccess.SetStoreForEachOrderPaymentFromTheDatabase(orderPayments, stores, db);
            return orderPayments;
        }

        /// <summary>
        /// Get all IncomeOrderPayment From the database
        /// - Set the staffModel , storeModel forEach IncomeOrderPayment
        /// </summary>
        /// <returns></returns>
        private List<IncomeOrderPaymentModel> GetIncomeOrderPaymentsFromTheDatabase(List<StaffModel>staffs,List<StoreModel>stores)
        {
            List<IncomeOrderPaymentModel> incomeOrderPayments = new List<IncomeOrderPaymentModel>();
            incomeOrderPayments = IncomeOrderPaymentAccess.GetIncomeOrderPaymentsFromTheDatabase(db);
            incomeOrderPayments = IncomeOrderPaymentAccess.SetStaffForEachIncomeOrderPaymentFromTheDatabase(incomeOrderPayments, staffs, db);
            incomeOrderPayments = IncomeOrderPaymentAccess.SetStoreForEachIncomeOrderPaymentFromTheDatabase(incomeOrderPayments, stores, db);
            return incomeOrderPayments;
        }

        /// <summary>
        /// Get all orders from the database
        /// - set the customer Model
        /// - set the store model
        /// - set the list of orderProductModels
        /// </summary>
        /// <param name="customers">All The Customers</param>
        /// <param name="stores"> All The Stores </param>
        /// <param name="staffs"> All The staffs </param>
        /// <param name="orderProducts"> All the orderProducts </param>
        /// <returns></returns>
        private List<OrderModel>GetOrdersFromTheDatabase(List<CustomerModel>customers,List<StoreModel>stores,List<StaffModel>staffs, List<OrderProductModel> orderProducts,List<OrderPaymentModel>orderPayments)
        {
            List<OrderModel> orders = new List<OrderModel>();
            orders = OrderAccess.GetOrdersFromTheDatabase(db);
            orders = OrderAccess.SetTheCustomerForEachOrderFromTheDatabase(orders, customers, db);
            orders = OrderAccess.SetTheStoreForEachOrderFromTheDatabase(orders, stores, db);
            orders = OrderAccess.SetTheStaffForEachOrderFromTheDatabase(orders, staffs, db);
            orders = OrderAccess.SetTheOrderProductsForEachOrderFromTheDatabase(orders, orderProducts, db);
            orders = OrderAccess.SetTheOrderPaymentsForEachOrderFromTheDatabase(orders, orderPayments, db);
            return orders;
        }
        
        /// <summary>
        /// Get all IncomeOrders From the data base
        /// - set the supplier , store , staff , IncomeOrderPayments , IncomeOrderProducts
        /// </summary>
        /// <param name="suppliers"></param>
        /// <param name="stores"></param>
        /// <param name="staffs"></param>
        /// <param name="incomeOrderPayments"></param>
        /// <param name="incomeOrderProducts"></param>
        /// <returns></returns>
        private List<IncomeOrderModel> GetIncomeOrdersFromTheDatabase(List<SupplierModel>suppliers,List<StoreModel>stores,List<StaffModel>staffs,List<IncomeOrderPaymentModel>incomeOrderPayments,List<IncomeOrderProductModel>incomeOrderProducts)
        {
            List<IncomeOrderModel> incomeOrders = new List<IncomeOrderModel>();
            incomeOrders = IncomeOrderAccess.GetIncomeOrdersFromTheDatabase(db);
            incomeOrders = IncomeOrderAccess.SetTheSupplierForEachIncomeOrderFromTheDatabase(incomeOrders, suppliers, db);
            incomeOrders = IncomeOrderAccess.SetTheStoreForEachIncomeOrderFromTheDatabase(incomeOrders, stores, db);
            incomeOrders = IncomeOrderAccess.SetTheStaffForEachIncomeOrderFromTheDatabase(incomeOrders, staffs, db);
            incomeOrders = IncomeOrderAccess.SetTheIncomeOrderPaymentsForEachIncomeOrderFromTheDatabase(incomeOrders, incomeOrderPayments, db);
            incomeOrders = IncomeOrderAccess.SetTheIncomeOrderProductsForEachIncomeOrderFromTheDatabase(incomeOrders, incomeOrderProducts, db);
            return incomeOrders;
        }

        /// <summary>
        /// Get all shopBills From the database
        /// - Set the store , staff
        /// </summary>
        /// <param name="stores"></param>
        /// <param name="staffs"></param>
        /// <returns></returns>
        private List<ShopBillModel> GetShopBillsFromTheDatabase(List<StoreModel> stores, List<StaffModel> staffs)
        {
            List<ShopBillModel> shopBills = new List<ShopBillModel>();
            shopBills = ShopBillAccess.GetShopBillsFromTheDatabase(db);
            shopBills = ShopBillAccess.SetTheStaffForEachShopBillFromTheDatabase(shopBills, staffs, db);
            shopBills = ShopBillAccess.SetTheStoreForEachShopBillFromTheDatabase(shopBills, stores, db);
            return shopBills;
        }

        private List<OperationModel> CreateTheOperations(List<TransformModel>transforms,List<DeTransformModel>deTransforms,List<OrderPaymentModel>orderPayments,List<IncomeOrderPaymentModel> incomeOrderPayments, List<ShopBillModel> shopBills,List<StaffSalaryModel>staffSalaries)
        {
            return OperationAccess.CreateTheOperations(transforms, deTransforms, orderPayments, incomeOrderPayments, shopBills, staffSalaries);
        }



        #endregion



        #region Brand Functions


        /// <summary>
        /// Get All brands from the databse
        /// </summary>
        /// <returns></returns>
        public List<BrandModel> GetBrands()
        {
            List<BrandModel> brands = BrandAccess.GetBrands(db);
            return brands;
        }

        /// <summary>
        /// Save new brand to the database , return the new brand with new Id
        /// add the new brand to the publicVariables.Brand
        /// </summary>
        /// <param name="newBrand"> the new brand model </param>
        /// <param name="db"></param>
        /// <returns></returns>
        public BrandModel AddBrandToTheDatabase(BrandModel newBrand)
        {
            newBrand =  BrandAccess.AddBrandToTheDatabase(newBrand, db);
            PublicVariables.Brands.Add(newBrand);
            return newBrand;
        }


        /// <summary>
        /// Get list of brands , if the brand name in the database return false
        /// </summary>
        /// <param name="brands"> list of brand model </param>
        /// <param name="newName"> the new name of the brand to check  </param>
        /// <returns></returns>
        public bool CheckIfTheBrandNameUnique(List<BrandModel> brands, string newName)
        {

            return Brand.CheckIfTheBrandNameUnique(brands, newName);
        }


        #endregion

        #region Categoty Functions


        /// <summary>
        /// Get All categories from the databse
        /// </summary>
        /// <returns></returns>
        public List<CategoryModel> GetCategories()
        {
            List<CategoryModel> categories = CategoryAccess.GetCategories(db);
            return categories;
        }

        /// <summary>
        /// Add the category to the database , return the category with the new Id
        /// add the new category to the database
        /// </summary>
        /// <param name="newCategory"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public CategoryModel AddCategoryToTheDatabase(CategoryModel newCategory)
        {
            newCategory = CategoryAccess.AddCategoryToTheDatabase(newCategory, db);
            PublicVariables.Categories.Add(newCategory);
            return newCategory;
        }


        /// <summary>
        /// Get list of categories , if the category name in the database return false
        /// </summary>
        /// <param name="categories"> list of category model </param>
        /// <param name="newName"> the new name of the category to check  </param>
        /// <returns></returns>
        public bool CheckIfTheCategoryNameUnique(List<CategoryModel> categories, string newName)
        {
            return Category.CheckIfTheCategoryNameUnique(categories, newName);
        }

       
        #endregion

        #region Customer

        /// <summary>
        /// Get all customers and set the person model for each one
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        public  List<CustomerModel> GetCustomers()
        {
            return CustomerAccess.GetCustomers(db);
        }

        /// <summary>
        /// Get the default Customer 
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public  CustomerModel GetDefaultCustomer( )
        {
            return Customer.GetDefaultCustomer();
        }

       

        /// <summary>
        /// Create Customer in the database and no return value Use CreateCustomer To get the new customerModel
        /// </summary>
        public void CreateCustomer_NoReturn(CustomerModel customer)
        {
            CustomerAccess.CreateCustomer_NoReturn(customer, db);
        }

        /// <summary>
        /// Create customer in the database and get the customer model back with the new customerId
        /// - Check if this person in the database or not By Comparing the NationalNumber to all people in the database
        /// - if he in the database The return customer with id of -1
        /// - If Not :
        /// - Create person and get the person model 
        /// - Create customer and set the person model for this customer
        /// </summary>
        /// <returns></returns>
        public CustomerModel CreateCustomer(CustomerModel customer)
        {
            if (Person.IsThisPersonInTheDataBase(customer.Person, PersonAccess.GetPeopleFromTheDatabase(db)) == true)
            {
                customer.Id = -1;
                return customer;
            }
            else
            {
                PersonModel personModel = PersonAccess.AddPersonToTheDatabase(customer.Person, db); ;
                customer.Person = new PersonModel();
                customer.Person = personModel;
                return CustomerAccess.AddCustomerToTheDatabase(customer, db);
            }

        }

        #endregion

        #region Investment Functions

        /// <summary>
        /// Add the investment to the database. 
        ///  Add the investment to the publicVariables.Investments.
        ///  Add the investment to the owner.Investments
        /// </summary>
        /// <param name="investment">The new investment model</param>
        /// <param name="owner">The Owner who Invested the money</param>
        /// <returns></returns>
        public InvestmentModel AddInvestmentToTheDatabase(InvestmentModel investment,OwnerModel owner)
        {
            // Add the investment to the database
            investment =  InvestmentAccess.AddInvestmentToTheDatabase(investment, owner, db);
            // Add the investment to the publicVariables.Investments
            PublicVariables.Investments.Add(investment);
            // add the investment to the owner.Investments
            owner.Investments.Add(investment);

            return investment;
        }

        #endregion

        #region Revenue Functions
        /// <summary>
        /// Add the revenue to the databse
        /// add the revenue to the publicVariables.Revenue
        /// add the revenue to the Owner.Revenues
        /// </summary>
        /// <param name="revenue"></param>
        /// <param name="owner"></param>
        /// <returns></returns>
        public RevenueModel AddRevenueToTheDatabase(RevenueModel revenue,OwnerModel owner)
        {
            revenue = RevenueAccess.AddReveueToTheDatabase(revenue, owner, db);
            PublicVariables.Revenues.Add(revenue);
            owner.Revenues.Add(revenue);
            return revenue;
        }

        #endregion

        #region Transform

        /// <summary>
        /// add the Transfrom to the database
        /// add the transform to the publicVariables.Transforms
        /// Create Operation to this Transform
        /// add the operation to publicvariables.Operations
        /// </summary>
        /// <param name="transform"></param>
        /// <returns></returns>
        public TransformModel AddTransformToTheDatase(TransformModel transform)
        {
            transform = TransformAccess.AddTransformToTheDatabase(transform,db);
            PublicVariables.Transforms.Add(transform);
            OperationModel operation = new OperationModel { Transform = transform };
            PublicVariables.Operations.Add(operation);
            return transform;
        }

        #endregion

        #region DeTransform

        /// <summary>
        /// Add the DeTransform to the databse
        /// Add the deTransform to the publicVariables.DeTransforms
        /// Create Operation to this Transform
        /// add the operation to publicvariables.Operations
        /// /// </summary>
        /// <param name="deTransform"></param>
        /// <returns></returns>
        public DeTransformModel AddDeTransformToTheDabase(DeTransformModel deTransform)
        {
            DeTransformAccess.AddDeTransformToTheDatabase(deTransform, db);
            PublicVariables.DeTransforms.Add(deTransform);
            OperationModel operation = new OperationModel { DeTransform = deTransform };
            PublicVariables.Operations.Add(operation);
            return deTransform;
        }

        #endregion

        #region Income Order

        /// <summary>
        /// Create a new incomeOrder Get the new Id
        /// 
        /// </summary>
        /// <param name="incomeOrder"></param>
        /// <param name="newStocks"></param>
        /// <returns></returns>
        public IncomeOrderModel AddIncomeOrderToTheDatabase(IncomeOrderModel incomeOrder,List<StockModel> newStocks)
        {
            foreach(StockModel stock in newStocks)
            {
                StockModel similatStock = Stock.FindSimilarStock(stock);
                if(similatStock != null)
                {
                    similatStock = StockAccess.AddStockToSimilarStockToTheDatabase(similatStock,stock,db);
                }
                else
                {
                    
                    stock.SBarCode = Stock.GenerateNewSBarCode(stock);
                    StockModel FinishStock = StockAccess.AddStockToTheDatabase(stock,db);
                    PublicVariables.Stocks.Add(FinishStock);
                    
                }
                
            }

            incomeOrder = IncomeOrderAccess.AddIncomeOrderToTheDatabase(incomeOrder, db);
            PublicVariables.IncomeOrders.Add(incomeOrder); 

            foreach(IncomeOrderProductModel incomeOrderProduct in incomeOrder.IncomeOrderProducts)
            {
                IncomeOrderProductModel FinishIncomeOrderProduct = IncomeOrderProductAccess.AddIncomeOrderProductToTheDatabase(incomeOrderProduct, incomeOrder, db);
                PublicVariables.IncomeOrderProducts.Add(FinishIncomeOrderProduct);
            }
            foreach (IncomeOrderPaymentModel incomeOrderPayment in incomeOrder.IncomeOrderPayments)
            {
                IncomeOrderPaymentModel FinishIncomeOrderPaymentModel = IncomeOrderPaymentAccess.AddIncomeOrderPaymentToTheDatabase(incomeOrderPayment, incomeOrder, db);
                PublicVariables.IncomeOrderPayments.Add(FinishIncomeOrderPaymentModel);
                OperationModel operation = new OperationModel { IncomeOrderPayment = FinishIncomeOrderPaymentModel };
                PublicVariables.Operations.Add(operation);

            }

            return incomeOrder;
        }

       

        /// <summary>
        /// -OLD-get all the The incomeOrders from the database
        /// - set the supplier
        ///     - set the personModel To the Supplier
        /// - set the store
        /// - set the staff
        ///     - set the personModel for the staff
        /// - set the list of products - incomeOrderProducts - 
        ///     - set the product foreach incomeOrderProduct
        /// </summary>
        /// <returns></returns>
        public List<IncomeOrderModel> GetIncomeOrders()
        {
            return IncomeOrderAccess.GetIncomeOrders(db);
        }

        /// <summary>
        /// Get incomeOrder with a new Id
        /// The IncomeOrder should Have The main info of thist variables:
        /// SupplierId , DataTimeOfTheOrder, StoreId, StaffId,TotalPrice
        /// </summary>
        /// <param name="incomeOrder"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public IncomeOrderModel GetEmptyIncomeOrderFromTheDatabase(IncomeOrderModel incomeOrder)
        {
            return IncomeOrderAccess.GetEmptyIncomeOrderFromTheDatabase(incomeOrder, db);
        }

        /// <summary>
        /// If the bill number used before return false
        /// In not return true
        /// </summary>
        /// <param name="incomeOrders"> list of IncomeOrderModels </param>
        /// <param name="billNumber"> the bill number to check </param>
        /// <returns></returns>
        public bool IsBillNumberUnique(List<IncomeOrderModel> incomeOrders, string billNumber)
        {
            return IncomeOrder.IsBillNumberUnique(incomeOrders , billNumber);
        }


        #endregion

        #region IncomeOrderPayment

        /// <summary>
        /// Add IncomeOrderPayment To the database
        /// Add to the public variables
        /// add to the IncomeOrder
        /// return the  IncomeOrderpayment
        /// </summary>
        /// <param name="incomeOrder"></param>
        /// <param name="incomeOrderPayment"></param>
        /// <returns></returns>
        public IncomeOrderPaymentModel AddIncomeOrderPaymentToTheDatabase(IncomeOrderModel incomeOrder, IncomeOrderPaymentModel incomeOrderPayment)
        {
            // Save the orderPayment to the database
            IncomeOrderPaymentAccess.AddIncomeOrderPaymentToTheDatabase(incomeOrderPayment, incomeOrder, db);
            PublicVariables.IncomeOrderPayments.Add(incomeOrderPayment);
            incomeOrder.IncomeOrderPayments.Add(incomeOrderPayment);
            OperationModel operation = new OperationModel
            {
                IncomeOrderPayment = incomeOrderPayment
            };
            PublicVariables.Operations.Add(operation);

            return incomeOrderPayment;
        }

        /// <summary>
        /// If the store should receive money we will reduce the total paid value by Update or remove the incomeOrder.IncomeOrderPayments
        /// </summary>
        /// <param name="incomeOrder"></param>
        /// <returns></returns>
        public IncomeOrderModel SupplierPayment(IncomeOrderModel incomeOrder, decimal supplierPaid)
        {
            // Get the last OrderPayment
            IncomeOrderPaymentModel incomeOrderPaymentModel = new IncomeOrderPaymentModel();
            if (incomeOrder.IncomeOrderPayments.Count > 0)
            {
                incomeOrderPaymentModel = incomeOrder.IncomeOrderPayments.Last();
            }
            foreach (IncomeOrderPaymentModel incomeOrderPayment in incomeOrder.IncomeOrderPayments)
            {
                if (incomeOrderPaymentModel.Date < incomeOrderPayment.Date)
                {
                    incomeOrderPaymentModel = incomeOrderPayment;
                }
            }


            while (supplierPaid > 0)
            {
                if (incomeOrderPaymentModel.Paid <= supplierPaid)
                {
                    supplierPaid -= incomeOrderPaymentModel.Paid;

                    // Remove the orderProducts From the database 
                    IncomeOrderPaymentAccess.RemoveIncomeOrderPayment(incomeOrderPaymentModel, db);

                    // remove the orderpayment from the Order 
                    incomeOrder.IncomeOrderPayments.Remove(incomeOrderPaymentModel);

                    // remove the orderpayment from the publicVariables 
                    PublicVariables.IncomeOrderPayments.Remove(incomeOrderPaymentModel);

                    // remove the orderpayment from the operation of this orderPayment
                    OperationModel operation = PublicVariables.Operations.Find(x => x.IncomeOrderPayment == incomeOrderPaymentModel);
                    PublicVariables.Operations.Remove(operation);

                    if (incomeOrder.IncomeOrderPayments.Count > 0)
                    {
                        incomeOrderPaymentModel = incomeOrder.IncomeOrderPayments.Last();
                    }
                    foreach (IncomeOrderPaymentModel incomeOrderPayment in incomeOrder.IncomeOrderPayments)
                    {
                        if (incomeOrderPaymentModel.Date < incomeOrderPayment.Date)
                        {
                            incomeOrderPaymentModel = incomeOrderPayment;
                        }
                    }

                }
                else
                {
                    incomeOrderPaymentModel.Paid -= supplierPaid;
                    IncomeOrderPaymentAccess.UpdateIncomeOrderPayment(incomeOrderPaymentModel, db);
                    supplierPaid = 0;
                }
            }

            return incomeOrder;
        }


        #endregion

        #region Product Functions

        /// <summary>
        /// Add the product to the datbase
        /// get the new product add to puvlicVariables.Products
        /// add this product to the publicVariables.recentlyAddProducts
        /// </summary>
        /// <param name="product"></param>
        /// <returns>the new product with the new database ID</returns>
        public ProductModel AddProductToTheDatabase(ProductModel product ) 
        {
            product = ProductAccess.AddProductToTheDatabase(product, db);
            PublicVariables.Products.Add(product);
            PublicVariables.RecentlyAddProducts.Add(product);
            return product;
        }

        public ProductModel UpdateProductDataWithTheDatabase(ProductModel product)
        {

            return ProductAccess.UpdateProdcutData(product, db); 
        }

        /// <summary>
        /// Get All Products from the databse
        /// </summary>
        /// <returns></returns>
        public List<ProductModel> GetProducts()
        {
            List<ProductModel> products = ProductAccess.GetProducts(db);
            return products;
        }

        /// <summary>
        /// Filter List of products by category
        /// </summary>
        /// <param name="category"> Category Model </param>
        /// <returns> list of filtered products </returns>
        public  List<ProductModel> GetProductsByCategory(List<ProductModel> products, CategoryModel category)
        {
            List<ProductModel> FProducts = Product.GetProductsByCategory(products,category,db);
            return FProducts;
        }

        /// <summary>
        /// Filter List of products by category,
        /// All cases:
        /// - brand != null OR brand != default && category != null OR category != default (Filter by Brand and category)
        /// - brand == null OR brand == default && category == null OR category == default ( No Filtering)
        /// - brand != null OR brand != default && category == null OR category == default ( Filter by brand Only)
        /// - brand == null OR brand == default && category != null OR category != default ( Filter by category Only)
        /// </summary>
        /// <param name="products">List of product to filter</param>
        /// <param name="category"> category model </param>
        /// <param name="brand"> Brand model </param>
        /// <returns></returns>
        public  List<ProductModel> GetProductsByCategoryAndBrand(List<ProductModel> products, CategoryModel category, BrandModel brand)
        {
            List<ProductModel> FProducts = Product.FilterProductsByCategoryAndBrand(category, brand);
            return FProducts;
        }

        /// <summary>
        /// Check if the product with this serial number exist
        /// </summary>
        /// <param name="products"> List Of products </param>
        /// <param name="SerialNumber"> serial number </param>
        /// <returns></returns>
        public ProductModel GetProductBySerialNumber(List<ProductModel> products, string SerialNumber)
        {
            ProductModel product = Product.GetProductBySerialNumber(products, SerialNumber);

            return product;
        }

        /// <summary>
        /// return list of filterd Products if the product name Contains String name
        /// </summary>
        /// <param name="products"> list of Product model </param>
        /// <param name="name"> name that we search for </param>
        /// <returns></returns>
        public  List<ProductModel> FilterProductsByName(List<ProductModel> products, string name)
        {
           
            return Product.FilterProductsByName(products,name);
        }

        /// <summary>
        ///  return list of filterd products if the product serial number  Contains SerialNumber  
        /// </summary>
        /// <param name="products"> list of Product model  </param>
        /// <param name="serialNumber"></param>
        /// <returns></returns>
        public  List<ProductModel> FilterProductsBySerialNumber(List<ProductModel> products, string serialNumber)
        {

            return Product.FilterProductsBySerialNumber(products, serialNumber);
        }

        /// <summary>
        /// Check if the product name is Unique In the list of products
        /// </summary>
        /// <param name="name"></param>
        /// <returns> 
        /// true if unique
        /// flase if Exist
        /// </returns>
        public bool CheckIfTheProductNameUnique(List<ProductModel> products, string name)
        {
            return Product.CheckIfTheProductNameUnique(products, name);
        }

        /// <summary>
        /// Check if the product SerialNumber is Unique In the list of products
        /// </summary>
        /// <param name="serialNumber"></param>
        /// <returns> 
        /// true if unique
        /// flase if Exist
        /// </returns>
        public bool CheckIfTheProductSerialNumberUnique(List<ProductModel> products,string serialNumber)
        {
            return Product.CheckIfTheProductSerialNumberUnique(products, serialNumber);
        }


        /// <summary>
        /// Update the   ProductName ,SerialNumber ,IncomePrice,SalePrice ,BrandId ,CategoryId Values with the database
        /// </summary>
        /// <param name="updatedProduct"></param>
        /// <param name="db"></param>
        public void UpdateProdcutData(ProductModel updatedProduct)
        {
            ProductAccess.UpdateProdcutData(updatedProduct, db);
        }

        /// <summary>
        /// Get list of Products , List of stocks 
        /// Return list of products not in the stocks
        /// </summary>
        /// <returns>list of products not in the stocks</returns>
        public List<ProductModel> GetTheProductsNotInTheStocks(List<ProductModel> products, List<StockModel> stocks)
        {
            return Product.GetTheProductsNotInTheStocks(products, stocks);

        }

        /// <summary>
        /// Get product by barCode
        /// if the barCode is not exist return Null
        /// </summary>
        /// <param name="products"></param>
        /// <param name="barCode"></param>
        /// <returns></returns>
        public ProductModel GetTheProductByTheBarCode(List<ProductModel> products, string barCode)
        {

            return Product.GetTheProductByTheBarCode(products, barCode);
        }

        /// <summary>
        /// return list of filterd Products if the product BarCOde Contains String name
        /// source of the search way: https://stackoverflow.com/a/3355561/6421951
        /// </summary>
        /// <param name="products"> list of Product model  </param>
        /// <param name="BarCode"> BarCode that we search for </param>
        /// <returns></returns>
        public  List<ProductModel> FilterProductsByBarCode(List<ProductModel> products, string BarCode)
        {
            return Product.FilterProductsByBarCode(products, BarCode);
        }

        /// <summary>
        /// Create a unique BarCode
        /// </summary>
        /// <param name="product"> the new product that we need to create the barCode to it </param>
        /// <returns></returns>
        public string CreateBarCode(ProductModel product)
        {
            return Product.CreateBarCode(product);

        }

        /// <summary>
        /// Check if the product barCode is Unique In the list of products
        /// </summary>
        /// <param name="BarCode"> The barcode that we need to check </param>
        /// <returns> 
        /// true if unique
        /// flase if Exist
        /// </returns>
        public bool CheckIfTheProductBarCodeUnique(string BarCode)
        {
            return Product.CheckIfTheProductBarCodeUnique( BarCode);
        }

        #endregion

        #region Order Product

        /// <summary>
        /// Get the Price and Quantity to return Total Price
        /// Total Price = Price * Quantity ( Trigers When Product Selected Or Quantity Increased)
        /// </summary>
        /// <param name="price"> Product Price </param>
        /// <param name="quantity"> Quantity </param>
        /// <returns></returns>
        public  decimal GetTotalPriceValue(decimal price, int quantity)
        {
            return OrderProduct.GetTotalPriceValue(price,quantity);
        }

        /// <summary>
        /// Get product model and discount 
        /// to calculate the price 
        /// // Price = OldPrice - Discount (Trigger When Discount change)
        /// </summary>
        /// <param name="discount"></param>
        /// <param name="product"></param>
        /// <returns></returns>
        public  decimal GetPriceValue(decimal discount, ProductModel product)
        {
            return OrderProduct.GetPriceValue(discount, product);
        }

        /// <summary>
        /// Get discount when price value changes
        /// // Discount = Old Price - Price (Trigger when Price Change)
        /// </summary>
        /// <param name="price"></param>
        /// <param name="product"></param>
        /// <returns> 
        /// -1 if price < 0
        /// 0 if there is no discount
        /// discount value
        /// </returns>
        public  decimal GetDiscountValue(decimal price, ProductModel product)
        {
            return OrderProduct.GetDiscountValue(price, product);

        }

        /// <summary>
        /// Delete OrderProduct from the database
        /// </summary>
        /// <param name="orderProduct"></param>
        /// <param name="db"></param>
        public void RemoveOrderProduct(OrderProductModel orderProduct)
        {
            OrderProductAccess.RemoveOrderProduct(orderProduct, db);
        }


        /// <summary>
        /// Loop throw each OrderProduct in the order
        /// save each one in the orderProdcut table with tha Id of the order
        /// </summary>
        /// <param name="order"> Order Model Has An Id From Order.GetEmptyOrder </param>
        /// <param name="db"> Database Connection Name </param>
        public void SaveOrderProductListToTheDatabase(OrderModel order)
        {
            OrderProductAccess.SaveOrderProductListToTheDatabase(order, db);
        }

        #endregion

        #region OrderPayment

        /// <summary>
        /// Add OrderPayment To the database
        /// Add to the public variables
        /// add to the order
        /// return the  orderpayment
        /// </summary>
        /// <param name="order"></param>
        /// <param name="orderPayment"></param>
        /// <returns></returns>
        public OrderPaymentModel AddOrderPaymentToTheDatabase(OrderModel order , OrderPaymentModel orderPayment)
        {
            // Save the orderPayment to the database
            OrderPaymentAccess.AddOrderPaymentToTheDatabase(orderPayment, order, db);
            PublicVariables.OrderPayments.Add(orderPayment);
            order.OrderPayments.Add(orderPayment);
            OperationModel operation = new OperationModel
            {
                OrderPayment = orderPayment
            };
            PublicVariables.Operations.Add(operation);

            return orderPayment;
        }

        /// <summary>
        /// If the customer should receive money we will reduce the total paid value by Update or remove the order.OrderPayments
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        public OrderModel StorePayment(OrderModel order,decimal storePaid)
        {
            // Get the last OrderPayment
            OrderPaymentModel orderPaymentModel = new OrderPaymentModel();
            if (order.OrderPayments.Count > 0)
            {
                orderPaymentModel = order.OrderPayments.Last();
            }
            foreach (OrderPaymentModel orderPayment in order.OrderPayments)
            {
                if(orderPaymentModel.Date < orderPayment.Date)
                {
                    orderPaymentModel = orderPayment;
                }
            }

            
            while(storePaid > 0)
            {
                if(orderPaymentModel.Paid <= storePaid)
                { 
                    storePaid -= orderPaymentModel.Paid;

                    // Remove the orderProducts From the database 
                    OrderPaymentAccess.RemoveOrderPayment(orderPaymentModel,db);

                    // remove the orderpayment from the Order 
                    order.OrderPayments.Remove(orderPaymentModel);

                    // remove the orderpayment from the publicVariables 
                    PublicVariables.OrderPayments.Remove(orderPaymentModel);

                    // remove the orderpayment from the operation of this orderPayment
                    OperationModel operation = PublicVariables.Operations.Find(x => x.OrderPayment == orderPaymentModel);
                    PublicVariables.Operations.Remove(operation);

                    if (order.OrderPayments.Count > 0)
                    {
                        orderPaymentModel = order.OrderPayments.Last();
                    }
                    foreach (OrderPaymentModel orderPayment in order.OrderPayments)
                    {
                        if (orderPaymentModel.Date < orderPayment.Date)
                        {
                            orderPaymentModel = orderPayment;
                        }
                    }

                }
                else
                {
                    orderPaymentModel.Paid -= storePaid;
                    OrderPaymentAccess.UpdateOrderPayment(orderPaymentModel,db);
                    storePaid = 0;
                }
            }

            return order;
        }

        #endregion

        #region Person

        /// <summary>
        /// Get Person model after adding to the database
        /// - Add this person to the customers
        /// - Add to the publicVariables.person , publicVariables.Customer
        /// </summary>
        /// <param name="person"></param>
        /// <returns></returns>
        public PersonModel AddPersonToTheDatabase(PersonModel person)
        {
            person = PersonAccess.AddPersonToTheDatabase(person, db);
            PublicVariables.People.Add(person);
            CustomerModel customer = new CustomerModel();
            customer.Person = person;
            customer = CustomerAccess.AddCustomerToTheDatabase(customer, db);
            PublicVariables.Customers.Add(customer);
            return person;
        }

        /// <summary>
        /// Check if the national number used before If It is return false
        /// If it is unique return true
        /// </summary>
        /// <param name="people"></param>
        /// <param name="nationalNumber"></param>
        /// <returns></returns>
        public  bool CheckIfTheNationalNumberUnique(string nationalNumber)
        {

            return Person.CheckIfTheNationalNumberUnique(PersonAccess.GetPeopleFromTheDatabase(db), nationalNumber);

        }

        /// <summary>
        /// Update person data with the database
        /// </summary>
        /// <param name="person"></param>
        /// <param name="db"></param>
        public void UpdatePersonData(PersonModel person)
        {
            PersonAccess.UpdatePersonData(person, db);
        }

        /// <summary>
        /// Get person model 
        /// Add to the person table in the database 
        /// Get the Id of this Person
        /// </summary>
        public PersonModel CreatePerson(PersonModel person)
        {

            return PersonAccess.AddPersonToTheDatabase(person, db); ;
        }


        #endregion

        #region order

        /// <summary>
        /// Add the order to the database
        /// add to the publicVariables
        /// add the orderProducts to the database
        /// add to the publicVariables
        /// add the orderPaymens to the database
        /// add to the publicVariables
        /// Reduce the stocks or remove it
        /// </summary>
        /// <param name="order">The new Order</param>
        /// <param name="orderProductRecords">The orderProductRecords list</param>
        /// <returns></returns>
        public OrderModel AddOrderToTheDatabase(OrderModel order,List<OrderProductRecordModel> orderProductRecords)
        {
            order = OrderAccess.AddOrderToTheDatabase(order,db);
            PublicVariables.Orders.Add(order);

            foreach(OrderProductModel orderProduct in order.OrderProducts)
            {
                OrderProductAccess.AddOrderProductToTheDatabase(orderProduct, order, db);
                PublicVariables.OrderProducts.Add(orderProduct);
            }

            foreach(OrderPaymentModel orderPayment in order.OrderPayments)
            {
                OrderPaymentAccess.AddOrderPaymentToTheDatabase(orderPayment, order, db);
                PublicVariables.OrderPayments.Add(orderPayment);
                OperationModel operation = new OperationModel { OrderPayment = orderPayment };
                PublicVariables.Operations.Add(operation);
            }

            foreach(OrderProductRecordModel orderProductRecord in orderProductRecords)
            {
                StockAccess.ReduseStock(orderProductRecord.Stock, orderProductRecord.OrderProduct.Quantity, db);
            }

            

            return order;
        }

        /// <summary>
        /// Update the Orignal Order Data after remove the RemovedOrderProducts list
        /// Create the new stocks
        /// add the new stocks to the database and the publicVariables
        /// </summary>
        /// <param name="OrignalOrder"></param>
        /// <param name="RemovedOrderProducts"></param>
        /// <returns></returns>
        public OrderModel UpdateOrder(OrderModel OrignalOrder , List<OrderProductModel> RemovedOrderProducts)
        {
            
            foreach(OrderProductModel removedOrderProduct in RemovedOrderProducts)
            {
                // Update the order
                OrderProductModel orderProduct = OrignalOrder.OrderProducts.Find(x => x.Id == removedOrderProduct.Id);
                if (orderProduct != null)
                {
                    orderProduct.Quantity -= removedOrderProduct.Quantity;
                    
                    if(orderProduct.Quantity == 0)
                    {
                        OrderProductAccess.RemoveOrderProduct(orderProduct,db);
                        OrignalOrder.OrderProducts.Remove(orderProduct);
                        PublicVariables.OrderProducts.Remove(orderProduct);
                    }
                    else
                    {
                        OrderProductAccess.UpdateOrderProduct(orderProduct, db);
                    }
                }

                // Create the Stock
                StockModel stock = new StockModel();
                stock.Store = PublicVariables.Store;
                stock.Product = PublicVariables.Products.Find(x => x.Id == removedOrderProduct.Product.Id);
                stock.IncomePrice = removedOrderProduct.GetIncomePrice;
                stock.SalePrice = stock.Product.SalePrice;
                stock.Date = DateTime.Now;
                stock.ExpirationAlarmEnabled = false;
                stock.QuantityAlarmEnabled = false;
                stock.Quantity = removedOrderProduct.Quantity;

                StockModel similatStock = Stock.FindSimilarStock(stock);
                if (similatStock != null)
                {
                    similatStock = StockAccess.AddStockToSimilarStockToTheDatabase(similatStock, stock, db);
                }
                else
                {

                    stock.SBarCode = Stock.GenerateNewSBarCode(stock);
                    StockModel FinishStock = StockAccess.AddStockToTheDatabase(stock, db);
                    PublicVariables.Stocks.Add(FinishStock);

                }


            }

            if(OrignalOrder.OrderProducts.Count == 0 && OrignalOrder.OrderPayments.Count == 0)
            {
                // Delete the order from the database
                OrderAccess.RemoveOrder(OrignalOrder, db);
                // remove from the publicVariables
                PublicVariables.Orders.Remove(OrignalOrder);
            }

            return OrignalOrder;
        }

        /// <summary>
        /// save the order to the database by :
        /// Calling order.getemptyorder to get Id for the order
        /// then save each orderProdcut alone in the database throw func. OrderProduct.saveOrderProductListToTheDataBase
        /// each orderproduct will be add to the orderproduct table in the database
        /// </summary>
        /// <param name="order">order model</param>
        /// <param name="db"></param>
       /* public void SaveOrderToDatabase(OrderModel order)
        {
            OrderProduct.SaveOrderProductListToTheDatabase(Order.GetEmptyOrderFromTheDatabase(order, db), db);
        }*/

        /// <summary>
        /// Gets Empty Order that have Id  , 
        /// The order should Have The main info of thist variables:
        /// CustomerId, DataTimeOfTheOrder, StoreId, StaffId,TotalPrice
        /// </summary>
        /// <param name="order">order model</param>
        /// <param name="db"> Database Connection Name </param>
        public OrderModel GetEmptyOrderFromTheDatabase(OrderModel order)
        {
            return OrderAccess.AddOrderToTheDatabase(order, db);


        }

        /// <summary>
        /// get all the orders from the database , 
        /// - set the customerModel foreach order
        /// - set the storemodel foreach order,
        /// - set the staffModel foreach order,
        /// - set the list OrderProdcut for each order
        /// - set the prodcut foreach OrderProdcut 
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        public  List<OrderModel> GetOrders()
        {
            return OrderAccess.GetOrders(db);
                 
        }

        /// <summary>
        /// Filter list of orders by Customer
        /// </summary>
        /// <param name="orders"></param>
        /// <param name="customer"></param>
        /// <returns></returns>
        public List<OrderModel> FilterOrdersByCustomer(List<OrderModel> orders, CustomerModel customer)
        {
            return Order.FilterOrdersByCustomer(orders, customer);

        }


        /// <summary>
        /// Filter orders by order id
        /// </summary>
        /// <param name="orders"></param>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public List<OrderModel> FilterOrdersByOrderId(List<OrderModel> orders, string orderId)
        {
            
            return Order.FilterOrdersByOrderId(orders,orderId);

        }


        /// <summary>
        /// Filter orders by Customer name
        /// </summary>
        /// <param name="orders"></param>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public List<OrderModel> FilterOrdersByCustomerName(List<OrderModel> orders, string customerName)
        {
            return Order.FilterOrdersByCustomerName(orders, customerName);

        }

        /// <summary>
        /// Filter orders by Date
        /// </summary>
        /// <param name="orders"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public List<OrderModel> FilterOrdersByDate(List<OrderModel> orders, DateTime date)
        {
            return Order.FilterOrdersByDate(orders,date);

        }

        /// <summary>
        /// update the order data , Total Price , details
        /// </summary>
        /// <param name="order"></param>
        /// <param name="db"></param>
        public OrderModel UpdateOrderData(OrderModel order)
        {
            return OrderAccess.UpdateOrderData(order, db);
        }


        /// <summary>
        /// Delete Order from the database
        /// </summary>
        /// <param name="orderProduct"></param>
        /// <param name="db"></param>
        public void RemoveOrder(OrderModel order)
        {
            OrderAccess.RemoveOrder(order, db);
        }


        #endregion

        #region store

        /// <summary>
        /// get all stores from the database
        /// each store model contain ID , Name
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        public List<StoreModel> GetAllStores()
        {
            return Store_Access.GetAllStores(db);
        }

        /// <summary>
        /// Check if this store exist in the list of the stores By Name
        /// gets StoreNameEnum Compare to each StoreName case IF exist:
        /// check if is exist in the database
        /// </summary>
        /// <param name="store"></param>
        /// <param name="stores">All the stores</param>
        /// <returns></returns>
        public StoreModel CheckByEnumIsThisStoreExist(StoreName storeName_Enum , List<StoreModel>stores )
        {
            if (storeName_Enum == StoreName.EMG)
            {
                StoreModel store = new StoreModel { Name = "EMG" };
                return Store.IsThisStoreExist(store, stores);
            }

            return new StoreModel { Id = -1 };



        }
        #endregion

        #region Staff

        /// <summary>
        /// Gets all staff table from the database
        /// - set the person model for each staff
        /// - set the list of stores that he works in 
        /// - set the permission 
        /// </summary>
        /// <returns></returns>
        public List<StaffModel> GetStaffs()
        {
           return StaffAccess.GetStaffs(db);
        }

        /// <summary>
        /// Check if the staff username and password in the database
        /// check if the staff can login from this sore
        /// return staff model if he can,
        /// if not return staff model with id of -1
        /// </summary>
        /// <param name="staff"></param>
        /// <param name="store"></param>
        /// <param name="staffs">All staffs</param>
        /// <returns></returns>
        public StaffModel CheckIfStaffValid(StaffModel staff,List<StaffModel>staffs , StoreModel store)
        {
            foreach(StaffModel s in staffs)
            {
                if(s.Username == staff.Username)
                {
                    if (s.Password == staff.Password)
                    {
                        staff = s;
                        foreach (StoreModel WorkingStores in staff.Stores)
                        {
                            if (store.Id == WorkingStores.Id)
                            {
                                return s;
                            }
                        }
                    }
                }
                
            }

            return new StaffModel { Id = -1 };

        }

        /// <summary>
        /// Get the Staffs whoes works in store
        /// get list of all staffs and store model
        /// return the staffs that works in the store model
        /// </summary>
        /// <param name="staffs"></param>
        /// <param name="store"></param>
        /// <returns></returns>
        public List<StaffModel> FilterStaffsByStore(List<StaffModel> staffs , StoreModel store)
        {
            return Staff.FilterStaffsByStore(staffs, store);
        }

        /// <summary>
        /// Filter staffs by person name 
        /// get list of staffs and fullName 
        /// return list of staffs if the personName matches
        /// </summary>
        /// <param name="staffs"></param>
        /// <param name="fullName"></param>
        /// <returns></returns>
        public List<StaffModel> FilterSatffsByPersonFullName(List<StaffModel> staffs, string fullName)
        {
            return Staff.FilterSatffsByPersonFullName(staffs, fullName);
        }

        /// <summary>
        /// Filter staffs by username 
        /// get list of staffs and userName 
        /// return list of staffs if the personName matches
        /// </summary>
        /// <param name="staffs"></param>
        /// <param name="username"></param>
        /// <returns></returns>
        public List<StaffModel> FilterSatffsByUsername(List<StaffModel> staffs, string username)
        {
            return Staff.FilterSatffsByUsername(staffs, username);
        }


        /// <summary>
        /// Check if the user name unique 
        /// If unique return true
        /// if NOT return false
        /// </summary>
        /// <param name="staffs"></param>
        /// <param name="newUsername"></param>
        /// <returns></returns>
        public  bool CheckIfTheUsernameUnique(List<StaffModel> staffs, string newUsername)
        {
            return Staff.CheckIfTheUsernameUnique(staffs, newUsername);
        }

        /// <summary>
        /// Update staff member data From username , password and permissionId
        /// </summary>
        /// <param name="staff"></param>
        /// <param name="db"></param>
        public  void UpdateStaffData(StaffModel staff)
        {
            StaffAccess.UpdateStaffData(staff, db);
        }

        #endregion

        #region StaffSalary


        /// <summary>
        /// add the staffSalary to the database
        /// add to the publicvariables.StaffSalary
        /// create the operation of the staffSalary
        /// add the operation to the publicVariables.Operations
        /// </summary>
        /// <param name="staffSalary"></param>
        /// <returns></returns>
        public StaffSalaryModel AddStaffSalaryToTheDatabase(StaffSalaryModel staffSalary)
        {
            staffSalary = StaffSalaryAccess.AddStaffSalaryToDatabase(staffSalary, db);
            PublicVariables.StaffSalaries.Add(staffSalary);
            OperationModel operation = new OperationModel();
            operation.StaffSalary = staffSalary;
            PublicVariables.Operations.Add(operation);
            return staffSalary;
        }

        #endregion

        #region StoreStaff 

        /// <summary>
        /// Add store staff in the database
        /// </summary>
        /// <param name="store"> store model</param>
        /// <param name="staff">staff model </param>
        public void AddStoreStaffToTheDatabase(StoreModel store, StaffModel staff)
        {
            StoreStaff.AddStoreStaffToTheDatabase(store, staff,db);
        }

        /// <summary>
        /// Remove store staff in the database
        /// </summary>
        /// <param name="store"> store model</param>
        /// <param name="staff">staff model </param>
        public void RemoveStoreStaffToTheDatabase(StoreModel store, StaffModel staff)
        {
            StoreStaff.RemoveStoreStaffToTheDatabase(store, staff,db);
        }


        #endregion

        #region Stock

        /// <summary>
        /// Return the prodcut's stocks
        /// </summary>
        /// <param name="stocks"> list of stock </param>
        /// <param name="product"> product model </param>
        /// <returns></returns>
        public List<StockModel> GetStocksByProduct(List<StockModel> stocks , ProductModel product)
        {
            return Stock.GetStocksByProduct(stocks,product);
        }

        

        /// <summary>
        /// Get all stocks from the database 
        /// - set the product for each stock
        /// - set store for each stock
        /// </summary>
        /// <returns></returns>
        public List<StockModel> GetStocks()
        {
            List<StockModel> stocks = StockAccess.GetStocks(db,GetProducts(),GetAllStores());
            return stocks;
        }



        /// <summary>
        /// Get stocks in This store only From the database 
        /// </summary>
        /// <param name="stocks"> list of stocks foom the database</param>
        /// <param name="store"> store model </param>
        /// <returns></returns>
        public  List<StockModel> FilterStocksByStore( StoreModel store)
        {
            return Stock.FilterStocksByStore(GetStocks(), store);
        }

        /// <summary>
        /// Filter list of Stocks by store 
        /// </summary>
        /// <param name="store"></param>
        /// <returns></returns>
        public List<StockModel> FilterStocksListByStore(List<StockModel> stocks , StoreModel store)
        {
            return Stock.FilterStocksByStore(stocks, store);
        }


        /// <summary>
        /// -OLD-Filter list of stocks by category and brand of the products in the stock list
        /// </summary>
        /// <param name="stocks"> list of stock model </param>
        /// <param name="category"> category model </param>
        /// <param name="brand">Brand model</param>
        /// <returns> list of filterd stocks by category and brand</returns>
        public List<StockModel> FilterStocksByCategoryAndBrand(List<StockModel> stocks , CategoryModel category,BrandModel brand)
        {
            //return Stock.FilterStocksByCategoryAndBrand(stocks, category, DefaultCategoryId, brand, DefaultBrandId);
            return new List<StockModel>();
        }


        /// <summary>
        /// return list of filterd stocks if the product name foreach one Contains String name
        /// </summary>
        /// <param name="stocks"> list of stock model </param>
        /// <param name="name"> name that we search for </param>
        /// <returns></returns>
        public List<StockModel> FilterStocksByName(List<StockModel> stocks , string name)
        {
            return Stock.FilterStocksByName(stocks,name);
        }

        /// <summary>
        ///  return list of filterd stocks if the product name foreach one Contains SerialNumber
        ///  source of the search way: https://stackoverflow.com/a/3355561/6421951
        /// </summary>
        /// <param name="stocks">  list of stock model  </param>
        /// <param name="serialNumber"> serialNumber that we search for </param>
        /// <returns></returns>
        public  List<StockModel> FilterStocksBySerialNumber(List<StockModel> stocks, string serialNumber)
        {
            
            return Stock.FilterStocksBySerialNumber(stocks,serialNumber);
        }

        /// <summary>
        /// Return list of filtered stocks if the product barcorde foreach one cotains barCode
        /// </summary>
        /// <param name="stocks"></param>
        /// <param name="barCode"></param>
        /// <returns></returns>
        public List<StockModel> FilterStocksByBarCode(List<StockModel> stocks, string barCode)
        {
            return Stock.FilterStocksByBarCode(stocks, barCode);
        }

        /// <summary>
        /// Get stock by serialNumber If exist
        /// If Not : return null
        /// </summary>
        /// <param name="stocks"></param>
        /// <param name="SerialNumber"></param>
        /// <returns></returns>
        public StockModel GetStockBySerialNumber(List<StockModel> stocks, string SerialNumber)
        {

            return Stock.GetStockBySerialNumber(stocks, SerialNumber);
        }



        /// <summary>
        /// Resuce the quantity of stock in the database
        /// If the quantity  = stock.quantity => remove the stock from the database
        /// </summary>
        /// <param name="stock"></param>
        /// <param name="quantity"> the number that u want to decreace </param>
        /// <param name="db"></param>
        public void ReduseStock(StockModel stock, float quantity)
        {
            StockAccess.ReduseStock(stock, quantity, db);

        }

        /// <summary>
        /// Increace the quantity of stock in the database
        /// </summary>
        /// <param name="stock"></param>
        /// <param name="quantity"> the number that u want to increase </param>
        /// <param name="db"></param>
        public void IncreaseStock(StockModel stock, float quantity)
        {
            StockAccess.IncreaseStock(stock, quantity, db);
        }

        /// <summary>
        /// Insert new stock to the stock table in the database
        /// return stock with the new id
        /// </summary>
        /// <param name="NewStock">stock has product , quantity and store</param>
        /// <returns></returns>
        public  StockModel AddStockToTheDatabase(StockModel NewStock)
        {
            return StockAccess.AddStockToTheDatabase(NewStock, db);
        }

        /// <summary>
        /// Update the stock quantity If the stock exist
        /// </summary>
        /// <param name="updatedStock"></param>
        /// <param name="db"></param>
        public void UpdateStockData(StockModel updatedStock)
        {
            StockAccess.UpdateStockData(updatedStock,db);
        }

        public void RemoveStockFromTheDatabase(StockModel stock)
        {
            StockAccess.RemoveStockFromTheDatabase(stock, db);
        }
        #endregion

        #region IncomeOrderProduct

        /// <summary>
        /// Loop throw each IncomeOrderProduct in the IncomeOrder
        /// save each one in the IncomeOrderProdcut table with tha Id of the IncomeOrder
        /// </summary>
        /// <param name="order"> IncomeOrder Model Has An Id From IncomeOrder.GetEmptyIncomeOrder </param>
        /// <param name="db"> Database Connection Name </param>
        public void SaveIncomeOrderProductListToTheDatabase(IncomeOrderModel incomeOrder)
        {
            IncomeOrderProductAccess.SaveIncomeOrderProductListToTheDatabase(incomeOrder, db);
        }

        #endregion

        #region Supplier

        /// <summary>
        /// Add the Supplier to the database
        /// add the supplier to the publicVariables
        /// </summary>
        /// <returns></returns>
        public SupplierModel AddSupplierWithOldPersonToTheDatabase(SupplierModel supplier)
        {
            SupplierAccess.AddSupplierToTheDatabase(supplier, db);
            PublicVariables.Suppliers.Add(supplier);
            return supplier;
        }

        /// <summary>
        /// Get the all the suppliers in the database And set the personModel for each one
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        public List<SupplierModel> GetSuppliers()
        {

            return SupplierAccess.GetSuppliers(db);
            
        }

        /// <summary>
        /// Add a new supplier to the database
        /// </summary>
        /// <param name="supplier"></param>
        /// <param name="db"></param>
        public void CreateSupplier(SupplierModel supplier)
        {
            SupplierAccess.AddSupplierToTheDatabase(supplier, db);
        }

        #endregion

        #region Installment

        /// <summary>
        /// Calculate the EMI of loan When create the installment order
        /// </summary>
        /// <param name="loanAmount"> The Amount of money </param>
        /// <param name="rateOfInterest"> rate Of Interest per year </param>
        /// <param name="numberOfMonths"> Number Of months or PaymentPeriods  </param>
        /// <returns></returns>
        public decimal CalculateTheEMI_RateOfInterestByYear(decimal loanAmount, double rateOfInterest, int numberOfMonths)
        {
            return Installment.CalculateTheEMI_RateOfInterestByYear(loanAmount,rateOfInterest,numberOfMonths);
        }

        /// <summary>
        /// Create installment to the database
        /// requires : CustomerModel,Date,NumberOfMonths,PaymentsStartDate,EMI,RateOfInterest,LoanAmount,Deposit,TotalInstallmentPrice,StoreModel,StaffModel
        /// </summary>
        /// <param name="installment"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public InstallmentModel GetEmptyInstallmentFromTheDatabase(InstallmentModel installment)
        {
            return Installment.GetEmptyInstallmentFromTheDatabase(installment, db);
        }


        #endregion

        #region InstallmentProduct

        /// <summary>
        /// Foreach InstallmentProduct in The Installment , save it in the database
        /// </summary>
        /// <param name="installment"></param>
        /// <param name="db"></param>
        public void SaveInstallmentProductToTheDatabase(InstallmentModel installment)
        {

            InstallmentProduct.SaveInstallmentProductToTheDatabase(installment, db);

        }

        #endregion

        #region InstallmentDetails

        /// <summary>
        /// Get Installment
        /// Create the InstallmentDetails:
        ///     - initial the InstallmentDetail Lists countOf(numberOfMonths)
        ///     - Fill the DueToPay each InstallmentDetail
        ///     - Fill the PaymentDate to 1/1/1 date as they not payed
        ///     - Save To the database
        /// </summary>
        public void CreateAndSaveInstallmentDetailsToTheDatabase(InstallmentModel installment)
        {
            InstallmentDetails.CreateAndSaveInstallmentDetailsToTheDatabase(installment, db);

        }

        #endregion

        #region Operation

      

        #endregion

        #region CashFlow

        
        /// <summary>
        /// Return the total of the totalPrice of any ShopBills in a operation
        /// </summary>
        /// <param name="operations"></param>
        /// <returns></returns>
        public  decimal TotalShopBillsPrice(List<OperationModel> operations)
        {
            return CashFlow.TotalShopBillsPrice(operations);
        }


        #endregion

        #region ShopBill

        
        /// <summary>
        /// Add shopBill to the database
        /// </summary>
        /// <param name="shopBill"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public ShopBillModel AddShopBillToTheDatabase(ShopBillModel shopBill)
        {
            shopBill = ShopBillAccess.AddShopBillToTheDatabase(shopBill, db);
            PublicVariables.ShopBills.Add(shopBill);
            OperationModel operation = new OperationModel { ShopBill = shopBill };
            PublicVariables.Operations.Add(operation);
            return shopBill;
        }

        /// <summary>
        /// Get all shopBills from the database
        /// - set the storeModel
        /// - set the staffModel
        /// </summary>
        /// <returns></returns>
        public List<ShopBillModel> GetShopBills()
        {
            return ShopBillAccess.GetShopBills(db);
        }

        /// <summary>
        /// Get all the shopBill Happend on the given date -day-
        /// </summary>
        /// <param name="shopBills"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public  List<ShopBillModel> FilterShopBillsByDate(List<ShopBillModel> shopBills, DateTime date)
        {
            return ShopBillAccess.FilterShopBillsByDate(shopBills, date);
        }


        /// <summary>
        /// Add shopBill to the database
        /// </summary>
        /// <param name="shopBill"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public ShopBillModel UpdateShopBillData(ShopBillModel shopBill)
        {

            return ShopBillAccess.UpdateShopBillData(shopBill, db);
        }


        /// <summary>
        /// Delete ShopBill from the database
        /// </summary>
        /// <param name="orderProduct"></param>
        /// <param name="db"></param>
        public  void RemoveShopBill(ShopBillModel shopBill)
        {
            ShopBillAccess.RemoveShopBill(shopBill,db);
        }


        #endregion

        #region Get Products From Exel
        /*
        /// <summary>
        /// 1- productName
        /// 2- incomePrice
        /// 3- salePrice
        /// 4- QuantityType
        /// 5- BarCode
        /// 6- Size
        /// 7- CategoryId
        /// 8- BrandId
        /// </summary>
        public void GetProductsFromExelFileAndAddToTheDatabase()
        {
            //Create COM Objects. Create a COM object for everything that is referenced
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkbook = xlApp.Workbooks.Open(@"C:\Users\omerw\Documents\GitHub\W-SmartShop\W-SmartShopSelution\WPF GUI\bin\Debug\Products.xlsx");
            Excel._Worksheet xlWorksheet = xlWorkbook.Sheets[1];
            Excel.Range xlRange = xlWorksheet.UsedRange;

            for (int i = 1; i <= 615; i++)
            {
                ProductModel product = new ProductModel();

                for (int j = 1; j <= 8; j++)
                {
                    if(j == 1)
                    {
                        product.Name = xlRange.Cells[i, j].Value2.ToString();
                    }
                    else if(j == 2)
                    {
                        product.IncomePrice = decimal.Parse(xlRange.Cells[i, j].Value2.ToString());
                    }
                    else if (j == 3)
                    {
                        product.SalePrice = decimal.Parse(xlRange.Cells[i, j].Value2.ToString());
                    }
                    else if (j == 4)
                    {
                        product.QuantityType = xlRange.Cells[i, j].Value2.ToString();
                    }
                    else if (j == 5)
                    {
                        product.SerialNumber = xlRange.Cells[i, j].Value2.ToString();
                    }
                    else if (j == 6)
                    {
                        if(xlRange.Cells[i, j].Value2.ToString() != "NULL")
                        {
                            product.Size = xlRange.Cells[i, j].Value2.ToString();
                        }
                    }
                    else if (j == 7)
                    {
                        product.Category = PublicVariables.Categories.Find(x=>x.Id == int.Parse(xlRange.Cells[i, j].Value2.ToString()));
                    }
                    else if (j == 8)
                    {
                        product.Brand = PublicVariables.Brands.Find(x => x.Id == int.Parse(xlRange.Cells[i, j].Value2.ToString()));
                    }
                }
                product.BarCode = CreateBarCode(product);
                // Save the Product to the database
                AddProductToTheDatabase(product);
            }
           
        }
        */
        #endregion

    }
}
