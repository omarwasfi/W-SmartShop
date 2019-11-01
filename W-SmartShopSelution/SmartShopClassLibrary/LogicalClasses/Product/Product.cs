using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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


        /// <summary>
        /// Check if the product with this serial number exist , in the  product's serialNumber , serialNumber2
        /// </summary>
        /// <param name="products"> List Of products </param>
        /// <param name="SerialNumber"> serial number </param>
        /// <returns></returns>
        public static ProductModel GetProductBySerialNumber(List<ProductModel> products ,string SerialNumber )
        {
            ProductModel product;

            foreach(ProductModel p in products)
            {
                if (p.SerialNumber == SerialNumber || p.SerialNumber2 == SerialNumber)
                {
                    product = p;
                    return product;
                }
            }

            return null;
        }

        /// <summary>
        /// Get product by barCode
        /// if the barCode is not exist return Null
        /// </summary>
        /// <param name="products"></param>
        /// <param name="barCode"></param>
        /// <returns></returns>
        public static ProductModel GetTheProductByTheBarCode(List<ProductModel> products , string barCode)
        {
            
            foreach(ProductModel p in products)
            {
                if (p.BarCode == barCode)
                {
                    return p;
                }
            }
            return null;
        }

        /// <summary>
        /// return list of filterd Products if the product BarCOde Contains String name
        /// source of the search way: https://stackoverflow.com/a/3355561/6421951
        /// </summary>
        /// <param name="products"> list of Product model  </param>
        /// <param name="BarCode"> BarCode that we search for </param>
        /// <returns></returns>
        public static List<ProductModel> FilterProductsByBarCode(List<ProductModel> products, string BarCode)
        {
            List<ProductModel> FProducts = new List<ProductModel>();
            foreach (ProductModel product in products)
            {
                if (Regex.IsMatch(product.BarCode, Regex.Escape(BarCode), RegexOptions.IgnoreCase))
                {
                    FProducts.Add(product);
                }
            }
            return FProducts;
        }

        /// <summary>
        /// return list of filterd Products if the product name Contains String name
        /// source of the search way: https://stackoverflow.com/a/3355561/6421951
        /// </summary>
        /// <param name="products"> list of Product model  </param>
        /// <param name="name"> name that we search for </param>
        /// <returns></returns>
        public static List<ProductModel> FilterProductsByName(List<ProductModel> products, string name)
        {
            List<ProductModel> FProducts = new List<ProductModel>();
            foreach (ProductModel product in products)
            {
                if (Regex.IsMatch(product.Name, Regex.Escape(name), RegexOptions.IgnoreCase))
                {
                    FProducts.Add(product);
                }
            }
            return FProducts;
        }

        /// <summary>
        ///  return list of filterd products if the product serialnumber or serialNumber2  Contains SerialNumber
        ///  source of the search way: https://stackoverflow.com/a/3355561/6421951
        /// </summary>
        /// <param name="products"></param>
        /// <param name="serialNumber"></param>
        /// <returns></returns>
        public static List<ProductModel> FilterProductsBySerialNumber(List<ProductModel> products, string serialNumber)
        {
            List<ProductModel> FProducts = new List<ProductModel>();
            foreach (ProductModel product in products)
            {
                if (product.SerialNumber != null || product.SerialNumber2 != null)
                {

                    if (Regex.IsMatch(product.SerialNumber, Regex.Escape(serialNumber), RegexOptions.IgnoreCase) || Regex.IsMatch(product.SerialNumber2, Regex.Escape(serialNumber), RegexOptions.IgnoreCase))
                    {
                        FProducts.Add(product);
                    }
                }
            }
            return FProducts;
        }


        /// <summary>
        /// Check if the product name is Unique In the list of products
        /// </summary>
        /// <param name="name"></param>
        /// <returns> 
        /// true if unique
        /// flase if Exist
        /// </returns>
        public static bool CheckIfTheProductNameUnique(List<ProductModel> products, string name)
        {
            foreach(ProductModel product in products)
            {
                if (product.Name == name )
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Check if the product SerialNumber is Unique In the list of products
        /// </summary>
        /// <param name="serialNumber"></param>
        /// <returns> 
        /// true if unique
        /// flase if Exist
        /// </returns>
        public static bool CheckIfTheProductSerialNumberUnique(List<ProductModel> products, string serialNumber)
        {
            foreach (ProductModel product in products)
            {
                if (product.SerialNumber == serialNumber || product.SerialNumber2 == serialNumber)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Check if the product barCode is Unique In the list of products true if unique , flase if Exist
        /// </summary>
        /// <param name="BarCode"> The barcode that we need to check </param>
        /// <returns> 
        /// true if unique
        /// flase if Exist
        /// </returns>
        public static bool CheckIfTheProductBarCodeUnique(List<ProductModel> products, string BarCode)
        {
            if(string.IsNullOrWhiteSpace(BarCode))
            {
                return false;

            }

            foreach (ProductModel product in products)
            {
                if (product.BarCode == BarCode)
                {
                    return false;
                }
            }
            return true;
        }


        /// <summary>
        /// Insert product to the database that Has all the information,
        /// return product model with the new Id
        /// </summary>
        /// <param name="newProduct"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public static ProductModel AddProductToTheDatabase(ProductModel newProduct , string db)
        {
            
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnVal(db)))
            {
                var p = new DynamicParameters();
                p.Add("@ProductName" , newProduct.Name);
                p.Add("@BarCode", newProduct.BarCode);
                p.Add("@SerialNumber", newProduct.SerialNumber);
                p.Add("@SerialNumber2", newProduct.SerialNumber2);
                p.Add("@Size",newProduct.Size);
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
        public static void UpdateProdcutData(ProductModel updatedProduct , string db)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnVal(db)))
            {
                var p = new DynamicParameters();
                p.Add("@Id",updatedProduct.Id);
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


        /// <summary>
        /// Get list of Products , List of stocks 
        /// Return list of products not in the stocks
        /// </summary>
        /// <returns></returns>
        public static List<ProductModel> GetTheProductsNotInTheStocks(List<ProductModel> products, List<StockModel> stocks)
        {
            List<ProductModel> FProducts = new List<ProductModel>();
            bool exist = false;

            foreach(ProductModel product in products)
            {
                exist = false;
                foreach(StockModel stock in stocks)
                {
                    if(stock.Product.Id == product.Id)
                    {
                        exist = true;
                        break;
                    }
                }
                if(exist == false)
                {
                    FProducts.Add(product);
                }
            }


            return FProducts;

        }

        /// <summary>
        /// Create a unique BarCode
        /// </summary>
        /// <param name="product"> the new product that we need to create the barCode to it </param>
        /// <param name="products"> all the product in the database </param>
        /// <returns></returns>
       public static string CreateBarCode(ProductModel product , List<ProductModel> products)
        {
            string barCode = product.GetFirstThreeLitterBarCode;
            int number = 1;
            
            while(CheckIfTheProductBarCodeUnique(products,barCode + number) == false)
            {
                number++;
            }

            return barCode + number;
            
        }

        

    }
}
