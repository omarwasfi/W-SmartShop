using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public static class ProductAccess
    {
        /// <summary>
        /// Get all products from the database - without settiong category and brand models
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        public static List<ProductModel> GetProductsFromTheDabase(string db)
        {
            List<ProductModel> products;
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnVal(db)))
            {
                products = connection.Query<ProductModel>("dbo.spProduct_GetAll").ToList();
            }
            foreach(ProductModel product in products)
            {
                product.Category = new CategoryModel();
                product.Brand = new BrandModel();
            }
            return products;
        }

        /// <summary>
        ///   Sets The Category Model for each product in the list
        ///   -Open the connection
        ///   -set the id of the category foreach product
        ///   -Close the connection
        ///   -match the IDs to the publicVariables.Category AND set the Category model for each product Model
        /// </summary>
        /// <param name="products"></param>
        /// <param name="categories"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public static List<ProductModel>SetTheCategoryModelForEachProductFromTheDatabase(List<ProductModel>products , List<CategoryModel>categories,string db)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnVal(db)))
            {
                foreach (ProductModel product in products)
                {
                    var p = new DynamicParameters();
                    p.Add("@ProductId", product.Id);
                    product.Category.Id = connection.QuerySingle<int>("spProduct_GetCategoryIdByProductId", p, commandType: CommandType.StoredProcedure);
                }
            }

            foreach(ProductModel productModel in products)
            {
                productModel.Category = categories.Find(x => x.Id == productModel.Category.Id);
            }

            return products;
        }

        /// <summary>
        ///  Sets The Brand Model for each product in the list
        ///   -Open the connection
        ///   -set the id of the Brand foreach product
        ///   -Close the connection
        ///   -match the IDs to the publicVariables.Brand AND set the Brand model for each product Model
        /// </summary>
        /// <param name="products"></param>
        /// <param name="brands"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public static List<ProductModel>SetTheBrandModelForEachProductFromTheDatabase(List<ProductModel>products,List<BrandModel>brands,string db)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnVal(db)))
            {
                foreach (ProductModel product in products)
                {
                    var p = new DynamicParameters();
                    p.Add("@ProductId", product.Id);
                    product.Brand.Id = connection.QuerySingle<int>("spProduct_GetBrandIdByProductId", p, commandType: CommandType.StoredProcedure);
                }
            }

            foreach (ProductModel productModel in products)
            {
                productModel.Brand = brands.Find(x => x.Id == productModel.Brand.Id);
            }

            return products;
        }

        /// <summary>
        /// -OLD- Get the products from the database 
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
                foreach (ProductModel product in products)
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
        /// Insert product to the database that Has all the information,
        /// return product model with the new Id
        /// </summary>
        /// <param name="newProduct"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public static ProductModel AddProductToTheDatabase(ProductModel newProduct, string db)
        {

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnVal(db)))
            {
                var p = new DynamicParameters();
                p.Add("@ProductName", newProduct.Name);
                p.Add("@BarCode", newProduct.BarCode);
                p.Add("@SerialNumber", newProduct.SerialNumber);
                p.Add("@SerialNumber2", newProduct.SerialNumber2);
                p.Add("@Size", newProduct.Size);
                p.Add("@Details", newProduct.Details);
                p.Add("@SalePrice", newProduct.SalePrice);
                p.Add("@IncomePrice", newProduct.IncomePrice);
                p.Add("@BrandId", newProduct.Brand.Id);
                p.Add("@CategoryId", newProduct.Category.Id);
                p.Add("@Id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
                connection.Execute("dbo.spProduct_Create", p, commandType: CommandType.StoredProcedure);
                newProduct.Id = p.Get<int>("@Id");
            }
            return newProduct;
        }

        /// <summary>
        /// Update the   ProductName ,SerialNumber ,IncomePrice,SalePrice ,BrandId ,CategoryId Values with the database
        /// </summary>
        /// <param name="updatedProduct"></param>
        /// <param name="db"></param>
        public static void UpdateProdcutData(ProductModel updatedProduct, string db)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnVal(db)))
            {
                var p = new DynamicParameters();
                p.Add("@Id", updatedProduct.Id);
                p.Add("@ProductName", updatedProduct.Name);
                p.Add("@BarCode", updatedProduct.BarCode);
                p.Add("@SerialNumber", updatedProduct.SerialNumber);
                p.Add("@SerialNumber2", updatedProduct.SerialNumber2);
                p.Add("@Size", updatedProduct.Size);
                p.Add("@Details", updatedProduct.Details);
                p.Add("@SalePrice", updatedProduct.SalePrice);
                p.Add("@IncomePrice", updatedProduct.IncomePrice);
                p.Add("@BrandId", updatedProduct.Brand.Id);
                p.Add("@CategoryId", updatedProduct.Category.Id);
                connection.Execute("dbo.spProduct_Update", p, commandType: CommandType.StoredProcedure);

            }
        }

    }
}
