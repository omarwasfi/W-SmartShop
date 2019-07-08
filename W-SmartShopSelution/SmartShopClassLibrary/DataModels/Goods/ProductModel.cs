using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    /// <summary>
    /// Product model cotains:
    /// Database Id , Name , CategoryModel , BrandModel ,current sale price, Current Income Price
    /// </summary>
    public class ProductModel
    {
        /// <summary>
        /// database Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Product Name ( Has to be Unique )
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Current Sale Price of the product
        /// </summary>
        public decimal SalePrice { get; set;}

        /// <summary>
        /// Current Income price of the product
        /// </summary>
        public decimal IncomePrice { get; set; }

        /// <summary>
        /// Category Model of this product
        /// </summary>
        public CategoryModel Category { get; set;}

        /// <summary>
        /// brand model of this Product
        /// </summary>
        public BrandModel Brand { get; set; }
    }
}
