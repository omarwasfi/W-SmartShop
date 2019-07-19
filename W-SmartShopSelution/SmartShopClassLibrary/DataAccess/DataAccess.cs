using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Library;

namespace Library
{
    public class DataAccess
    {
        /// <summary>
        /// Database name
        /// </summary>
        private const string db = "SmartShopConnection";

        /// <summary>
        /// The Default Id in the category table in the database
        /// </summary>
        private const int DefaultCategoryId = 11000 ;

        /// <summary>
        /// The Default Id in the brand table in the database
        /// </summary>
        private const int DefaultBrandId = 10000;

        /// <summary>
        /// The Default Id in the Perosn table in the database
        /// </summary>
        private const int DefaultPerson = 1000000;

        /// <summary>
        /// Get All categories from the databse
        /// </summary>
        /// <returns></returns>
        public List<CategoryModel> GetCategories()
        {
            List<CategoryModel> categories = Category.GetCategories(db);
            return categories ;
        }

        

        /// <summary>
        /// Get All brands from the databse
        /// </summary>
        /// <returns></returns>
        public List<BrandModel> GetBrands()
        {
            List<BrandModel> brands = Brand.GetBrands(db);
            return brands;
        }

        #region Product Functions

        /// <summary>
        /// Get All Products from the databse
        /// </summary>
        /// <returns></returns>
        public List<ProductModel> GetProducts()
        {
            List<ProductModel> products = Product.GetProducts(db);
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
            List<ProductModel> FProducts = Product.GetProductsByCategoryAndBrand(products, category, DefaultCategoryId, brand, DefaultBrandId);
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

        #endregion

        #region Customer

        /// <summary>
        /// Get all customers and set the person model for each one
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        public  List<CustomerModel> GetCustomers()
        {
            return Customer.GetCustomers(db);
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
            if( Person.IsThisPersonInTheDataBase(customer.Person, Person.GetAllPeople(db)) == true)
            {
                customer.Id = -1;
                return customer;
            }
            else
            {
                PersonModel personModel = Person.CreatePerson(customer.Person, db); ;
                customer.Person = new PersonModel();
                customer.Person = personModel;
                return Customer.CreateCustomer(customer, db);
            }
           
        }
        #endregion

        #region order

        /// <summary>
        /// save the order to the database by :
        /// Calling order.getemptyorder to get Id for the order
        /// then save each orderProdcut alone in the database throw func. OrderProduct.saveOrderProductListToTheDataBase
        /// each orderproduct will be add to the orderproduct table in the database
        /// </summary>
        /// <param name="order">order model</param>
        /// <param name="db"></param>
        public  void SaveOrderToDatabase(OrderModel order)
        {
            OrderProduct.SaveOrderProductListToTheDatabase(Order.GetEmptyOrderFromTheDatabase(order, db), db);
        }

        #endregion

        #region store

        /// <summary>
        /// get all stores from the database
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        public  List<StoreModel> GetAllStores()
        {
            return Store.GetAllStores(db);
        }

        /// <summary>
        /// Check if this store exist in the list of the stores By Name
        /// gets StoreNameEnum Compare to each StoreName case IF exist:
        /// check if is exist in the database
        /// </summary>
        /// <param name="store"></param>
        /// <param name="stores"></param>
        /// <returns></returns>
        public StoreModel CheckByEnumIsThisStoreExist(StoreName storeName_Enum )
        {
            List<StoreModel> stores = GetAllStores();
            if(storeName_Enum == StoreName.CairoStore)
            {
                StoreModel store = new StoreModel { Name = "CairoStore" };
                if(Store.IsThisStoreExist(store, stores))
                {
                    return store;
                }
            }
            if(storeName_Enum == StoreName.FayedStore)
            {
                StoreModel store = new StoreModel { Name = "FayedStore" };
                if (Store.IsThisStoreExist(store, stores))
                {
                    return store;
                }
            }
            if (storeName_Enum == StoreName.Ma3adiStore)
            {
                StoreModel store = new StoreModel { Name = "Ma3adiStore" };
                if (Store.IsThisStoreExist(store, stores))
                {
                    return store;
                }
            }
            
                
            return new StoreModel { Id = -1} ;
            
        }
        #endregion

        #region Staff

        /// <summary>
        /// Gets all staff table from the database
        /// - set the person model for each staff
        /// </summary>
        /// <returns></returns>
        public List<StaffModel> GetStaffs()
        {
           return Staff.GetStaffs(db);
        }

        /// <summary>
        /// Check if the staff username and password in the database
        /// check if the staff can login from this sore
        /// return staff model if he can,
        /// if not return staff model with id of -1
        /// </summary>
        /// <param name="staff"></param>
        /// <param name="store"></param>
        /// <returns></returns>
        public StaffModel CheckIfStaffValid(StaffModel staff , StoreModel store)
        {
            List<StaffModel> staffs = GetStaffs();
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


        #endregion

        #region Stock

        // TODO - filter stockes by product to know What store has this product



        /// <summary>
        /// Get all stocks from the database 
        /// - set the product for each stock
        /// - set store for each stock
        /// </summary>
        /// <returns></returns>
        public List<StockModel> GetStocks()
        {
            List<StockModel> stocks = Stock.GetStocks(db,GetProducts(),GetAllStores());
            return stocks;
        }


        /// <summary>
        /// Filter all stock list by store
        /// </summary>
        /// <param name="stocks"> list of stocks foom the database</param>
        /// <param name="store"> store model </param>
        /// <returns></returns>
        public  List<StockModel> FilterStocksByStore( StoreModel store)
        {
            return Stock.FilterStocksByStore(GetStocks(), store);
        }

        /// <summary>
        /// Filter list of stocks by category and brand of the products in the stock list
        /// </summary>
        /// <param name="stocks"> list of stock model </param>
        /// <param name="category"> category model </param>
        /// <param name="brand">Brand model</param>
        /// <returns> list of filterd stocks by category and brand</returns>
        public List<StockModel> FilterStocksByCategoryAndBrand(List<StockModel> stocks , CategoryModel category,BrandModel brand)
        {
            return Stock.FilterStocksByCategoryAndBrand(stocks, category, DefaultCategoryId, brand, DefaultBrandId);
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


        #endregion
    }
}
