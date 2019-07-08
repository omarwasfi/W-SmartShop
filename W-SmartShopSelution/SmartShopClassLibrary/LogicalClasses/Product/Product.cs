using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Library
{
    public static class Product
    {
        /// <summary>
        /// Get the products from the database 
        /// set the category and brand for each productModel
        /// </summary>
        /// <param name="db"> Database connection Name </param>
        /// <returns></returns>
        public static List<ProductModel> GetProducts(string db)
        {
            List<ProductModel> products;
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnVal(db)))
            {
                products = connection.Query<ProductModel>("dbo.spProduct_GetAll").ToList();
                foreach(ProductModel product in products)
                {
                    var p = new DynamicParameters();
                    p.Add("@ProductId", product.Id);
                    product.Category = connection.QuerySingle<CategoryModel>("spProduct_GetCategoryByProductId", p, commandType: CommandType.StoredProcedure);
                    product.Brand = connection.QuerySingle<BrandModel>("spProduct_GetBrandByProductId", p, commandType: CommandType.StoredProcedure);

                }
            }
            return products;
        }

        /// <summary>
        /// Filter List of products by category
        /// </summary>
        /// <param name="category"> Category Model </param>
        /// <returns> list of filtered products </returns>
        public static List<ProductModel> GetProductsByCategory(List<ProductModel> products , CategoryModel category , string db)
        {
            List<ProductModel> FProducts = new List<ProductModel>();
            foreach (ProductModel product in products)
            {
                if (product.Category.Id == category.Id)
                {
                    FProducts.Add(product);
                }
            }

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
        /// <param name="defaultBrandId" > the default product id const value signed in the database</param>
        /// <param name="defaultCategoryId"> the default brand id const value signed in the database </param>
        /// <returns></returns>
        public static List<ProductModel> GetProductsByCategoryAndBrand(List<ProductModel> products, CategoryModel category, int defaultCategoryId ,BrandModel brand, int defaultBrandId)
        {
            List<ProductModel> FProducts = new List<ProductModel>();
            bool FilterByBrand = true;
            bool FilterByCategory = true;

            if (brand == null || brand.Id == defaultBrandId)
                FilterByBrand = false;

            if (category == null || category.Id == defaultCategoryId)
                FilterByCategory = false;

            // Filter by Brand and category
            if (FilterByBrand == true && FilterByCategory == true )
            {
                foreach (ProductModel product in products)
                {
                    if (product.Category.Id == category.Id && product.Brand.Id == brand.Id)
                    {
                        FProducts.Add(product);
                    }
                }
                return FProducts;
            }

            // Filter by category Only
            else if (FilterByBrand == false && FilterByCategory == true)
            {
                foreach(ProductModel product in products)
                {
                    if(product.Category.Id == category.Id)
                    {
                        FProducts.Add(product);
                    }
                }
                return FProducts;
            }

            // Filter by brand Only
            else if (FilterByBrand == true && FilterByCategory == false)
            {
                foreach (ProductModel product in products)
                {
                    if (product.Brand.Id == brand.Id)
                    {
                        FProducts.Add(product);
                    }
                }
                return FProducts;
            }

            // No Filtering
            else
            {
                return products;
            }

        }
    }
}
