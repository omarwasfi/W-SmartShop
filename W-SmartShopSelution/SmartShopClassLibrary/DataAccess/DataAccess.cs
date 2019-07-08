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
    }
}
