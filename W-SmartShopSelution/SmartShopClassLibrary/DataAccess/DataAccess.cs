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

        #region Categoty Functions


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
        /// Get list of categories , if the category name in the database return false
        /// </summary>
        /// <param name="categories"> list of category model </param>
        /// <param name="newName"> the new name of the category to check  </param>
        /// <returns></returns>
        public  bool CheckIfTheCategoryNameUnique(List<CategoryModel> categories, string newName)
        {
            return Category.CheckIfTheCategoryNameUnique(categories, newName);
        }

        /// <summary>
        /// Add the category to the database , return the category with the new Id
        /// </summary>
        /// <param name="newCategory"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public  CategoryModel AddCategoryToTheDatabase(CategoryModel newCategory)
        {
            return Category.AddCategoryToTheDatabase(newCategory, db);
        }

        #endregion

        #region Brand Functions


        /// <summary>
        /// Get All brands from the databse
        /// </summary>
        /// <returns></returns>
        public List<BrandModel> GetBrands()
        {
            List<BrandModel> brands = Brand.GetBrands(db);
            return brands;
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

        /// <summary>
        /// Save new brand to the database , return the new brand with new Id
        /// </summary>
        /// <param name="newBrand"> the new brand model </param>
        /// <param name="db"></param>
        /// <returns></returns>
        public BrandModel AddBrandToTheDatabase(BrandModel newBrand)
        {
            return Brand.AddBrandToTheDatabase(newBrand, db);
        }

        #endregion

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
        /// Insert product to the database that Has all the information,
        /// return product model with the new Id
        /// </summary>
        /// <param name="newProduct"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public ProductModel AddProductToTheDatabase(ProductModel newProduct)
        {

            return Product.AddProductToTheDatabase(newProduct, db);
        }


        /// <summary>
        /// Update the   ProductName ,SerialNumber ,IncomePrice,SalePrice ,BrandId ,CategoryId Values with the database
        /// </summary>
        /// <param name="updatedProduct"></param>
        /// <param name="db"></param>
        public void UpdateProdcutData(ProductModel updatedProduct)
        {
            Product.UpdateProdcutData(updatedProduct, db);
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
        /// <param name="products"> all the product in the database </param>
        /// <returns></returns>
        public string CreateBarCode(ProductModel product, List<ProductModel> products)
        {
            return Product.CreateBarCode(product, products);

        }

        /// <summary>
        /// Check if the product barCode is Unique In the list of products
        /// </summary>
        /// <param name="BarCode"> The barcode that we need to check </param>
        /// <returns> 
        /// true if unique
        /// flase if Exist
        /// </returns>
        public bool CheckIfTheProductBarCodeUnique(List<ProductModel> products, string BarCode)
        {
            return Product.CheckIfTheProductBarCodeUnique(products, BarCode);
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
            OrderProduct.RemoveOrderProduct(orderProduct, db);
        }


        /// <summary>
        /// Loop throw each OrderProduct in the order
        /// save each one in the orderProdcut table with tha Id of the order
        /// </summary>
        /// <param name="order"> Order Model Has An Id From Order.GetEmptyOrder </param>
        /// <param name="db"> Database Connection Name </param>
        public void SaveOrderProductListToTheDatabase(OrderModel order)
        {
            OrderProduct.SaveOrderProductListToTheDatabase(order, db);
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

        /// <summary>
        /// Create Customer in the database and no return value Use CreateCustomer To get the new customerModel
        /// </summary>
        public void CreateCustomer_NoReturn(CustomerModel customer)
        {
            Customer.CreateCustomer_NoReturn(customer, db);
        }

        #endregion

        #region Person

        /// <summary>
        /// Check if the national number used before If It is return false
        /// If it is unique return true
        /// </summary>
        /// <param name="people"></param>
        /// <param name="nationalNumber"></param>
        /// <returns></returns>
        public  bool CheckIfTheNationalNumberUnique(string nationalNumber)
        {

            return Person.CheckIfTheNationalNumberUnique(Person.GetAllPeople(db), nationalNumber);

        }

        /// <summary>
        /// Update person data with the database
        /// </summary>
        /// <param name="person"></param>
        /// <param name="db"></param>
        public void UpdatePersonData(PersonModel person)
        {
            Person.UpdatePersonData(person, db);
        }

        /// <summary>
        /// Get person model 
        /// Add to the person table in the database 
        /// Get the Id of this Person
        /// </summary>
        public PersonModel CreatePerson(PersonModel person)
        {

            return Person.CreatePerson(person, db); ;
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
            return Order.GetEmptyOrderFromTheDatabase(order, db);


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
            return Order.GetOrders(db);
                 
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
            return Order.UpdateOrderData(order, db);
        }


        /// <summary>
        /// Delete Order from the database
        /// </summary>
        /// <param name="orderProduct"></param>
        /// <param name="db"></param>
        public void RemoveOrder(OrderModel order)
        {
            Order.RemoveOrder(order, db);
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
        /// - set the list of stores that he works in 
        /// - set the permission 
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
            Staff.UpdateStaffData(staff, db);
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
            List<StockModel> stocks = Stock.GetStocks(db,GetProducts(),GetAllStores());
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
        public void ReduseStock(StockModel stock, int quantity)
        {
            Stock.ReduseStock(stock, quantity, db);

        }

        /// <summary>
        /// Increace the quantity of stock in the database
        /// </summary>
        /// <param name="stock"></param>
        /// <param name="quantity"> the number that u want to increase </param>
        /// <param name="db"></param>
        public void IncreaseStock(StockModel stock, int quantity)
        {
            Stock.IncreaseStock(stock, quantity, db);
        }

        /// <summary>
        /// Insert new stock to the stock table in the database
        /// return stock with the new id
        /// </summary>
        /// <param name="NewStock">stock has product , quantity and store</param>
        /// <returns></returns>
        public  StockModel AddStockToTheDatabase(StockModel NewStock)
        {
            return Stock.AddStockToTheDatabase(NewStock, db);
        }

        /// <summary>
        /// Update the stock quantity If the stock exist
        /// </summary>
        /// <param name="updatedStock"></param>
        /// <param name="db"></param>
        public void UpdateStockData(StockModel updatedStock)
        {
            Stock.UpdateStockData(updatedStock,db);
        }

        public void RemoveStockFromTheDatabase(StockModel stock)
        {
            Stock.RemoveStockFromTheDatabase(stock, db);
        }
        #endregion

        #region Income Order

        /// <summary>
        /// get all the The incomeOrders from the database
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
            return IncomeOrder.GetIncomeOrders(db);
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
            return IncomeOrder.GetEmptyIncomeOrderFromTheDatabase(incomeOrder, db);
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
            IncomeOrderProduct.SaveIncomeOrderProductListToTheDatabase(incomeOrder, db);
        }

        #endregion

        #region Supplier

        /// <summary>
        /// Get the all the suppliers in the database And set the personModel for each one
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        public List<SupplierModel> GetSuppliers()
        {

            return Supplier.GetSuppliers(db);
            
        }

        /// <summary>
        /// Add a new supplier to the database
        /// </summary>
        /// <param name="supplier"></param>
        /// <param name="db"></param>
        public void CreateSupplier(SupplierModel supplier)
        {
            Supplier.CreateSupplier(supplier, db);
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

        /// <summary>
        /// Get all the operations from the database
        /// - Set the Order of installment , incomeOrder , shopBill , staffSalary
        /// </summary>
        /// <returns></returns>
        public List<OperationModel> GetOperations()
        {
            return Operation.GetOperations(db);
        }

        /// <summary>
        /// Add Operation to tha database , set the amountOfMoney and any Propity 
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public OperationModel AddOperationToDatabase(OperationModel operation)
        {
            return Operation.AddOperationToDatabase(operation, db);
        }

        /// <summary>
        /// Filter the opration by StartDate and EndDate in the operation.Date exist add to the fOperation list
        /// </summary>
        /// <param name="operations"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public List<OperationModel> FilterOperationsByDate(List<OperationModel> operations, DateTime startDate, DateTime endDate)
        {
            return Operation.FilterOperationsByDate(operations, startDate, endDate);
        }

        #endregion

        #region CashFlow

        /// <summary>
        /// Calculate all the money records And fint the ShopeeWallet
        /// </summary>
        /// <param name="operationModel"></param>
        /// <returns></returns>
        public decimal GetTheShopeeWallet(List<OperationModel> operationModel)
        {
            return CashFlow.GetTheShopeeWallet(operationModel);
        }

        /// <summary>
        /// Return the total of totalPrice of any Order in a operation
        /// </summary>
        /// <param name="operations"></param>
        /// <returns></returns>
        public decimal TotalSellsIncome(List<OperationModel> operations)
        {
           return CashFlow.TotalSellsIncome(operations);
        }

        /// <summary>
        /// Return the TotalProfit of any Order in a operation
        /// </summary>
        /// <param name="operations"></param>
        /// <returns></returns>
        public decimal TotalSellsProfit(List<OperationModel> operations)
        {
            
            return CashFlow.TotalSellsProfit(operations);
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

            return ShopBill.AddShopBillToTheDatabase(shopBill, db);
        }

        /// <summary>
        /// Get all shopBills from the database
        /// - set the storeModel
        /// - set the staffModel
        /// </summary>
        /// <returns></returns>
        public List<ShopBillModel> GetShopBills()
        {
            return ShopBill.GetShopBills(db);
        }

        /// <summary>
        /// Get all the shopBill Happend on the given date -day-
        /// </summary>
        /// <param name="shopBills"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public  List<ShopBillModel> FilterShopBillsByDate(List<ShopBillModel> shopBills, DateTime date)
        {
            return ShopBill.FilterShopBillsByDate(shopBills, date);
        }


        #endregion

    }
}
