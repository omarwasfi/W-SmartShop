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
        /// <param name="category"> category model </param>
        /// <param name="brand"> Brand model </param>
        /// <returns></returns>
        public static List<ProductModel> FilterProductsByCategoryAndBrand(CategoryModel category,BrandModel brand)
        {
            List<ProductModel> FProducts = new List<ProductModel>();
            bool FilterByBrand = true;
            bool FilterByCategory = true;

            if (brand == null || brand == PublicVariables.DefaultBrand)
                FilterByBrand = false;

            if (category == null || category == PublicVariables.DefaultCategory)
                FilterByCategory = false;



            // Filter by Brand and category
            if (FilterByBrand == true && FilterByCategory == true)
            {
               return FProducts = PublicVariables.Products.FindAll(x => x.Brand == brand && x.Category == category);
            }

            // Filter by category Only
            else if (FilterByBrand == false && FilterByCategory == true)
            {
                return FProducts = PublicVariables.Products.FindAll(x => x.Category == category);
            }

            // Filter by brand Only
            else if (FilterByBrand == true && FilterByCategory == false)
            {

                return FProducts = PublicVariables.Products.FindAll(x => x.Brand == brand);
            }

            // No Filtering
            else
            {
                return PublicVariables.Products;
            }

        }

        /// <summary>
        /// Filter The given products with the categories and brands
        /// </summary>
        /// <param name="products"></param>
        /// <param name="category"></param>
        /// <param name="brand"></param>
        /// <returns></returns>
        public static List<ProductModel> FilterProductsByCategoryAndBrand(List<ProductModel> products,CategoryModel category, BrandModel brand)
        {
            List<ProductModel> FProducts = new List<ProductModel>();
            bool FilterByBrand = true;
            bool FilterByCategory = true;

            if (brand == null || brand == PublicVariables.DefaultBrand)
                FilterByBrand = false;

            if (category == null || category == PublicVariables.DefaultCategory)
                FilterByCategory = false;



            // Filter by Brand and category
            if (FilterByBrand == true && FilterByCategory == true)
            {
                return FProducts = products.FindAll(x => x.Brand == brand && x.Category == category);
            }

            // Filter by category Only
            else if (FilterByBrand == false && FilterByCategory == true)
            {
                return FProducts = products.FindAll(x => x.Category == category);
            }

            // Filter by brand Only
            else if (FilterByBrand == true && FilterByCategory == false)
            {

                return FProducts = products.FindAll(x => x.Brand == brand);
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
        public static bool CheckIfTheProductBarCodeUnique(string BarCode)
        {
            if(string.IsNullOrWhiteSpace(BarCode))
            {
                return false;

            }

            foreach (ProductModel product in PublicVariables.Products)
            {
                if (product.BarCode == BarCode)
                {
                    return false;
                }
            }
            return true;
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
       public static string CreateBarCode(ProductModel product )
        {
            string barCode = product.GetFirstThreeLitterBarCode;
            int number = 1;
            
            while(CheckIfTheProductBarCodeUnique(barCode + number) == false)
            {
                number++;
            }

            return barCode + number;
            
        }

        

    }
}
