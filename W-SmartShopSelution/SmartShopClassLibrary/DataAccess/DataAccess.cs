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

    }
}
