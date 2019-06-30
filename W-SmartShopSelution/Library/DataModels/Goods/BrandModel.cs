using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataModels.Goods
{
    /// <summary>
    /// Brand model of the Products contains
    /// Database Id , Name , List of Product Model
    /// </summary>
    public class BrandModel
    {
        /// <summary>
        /// Database Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name of the brand
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// List of the products of this brand
        /// </summary>
        public List<ProductModel> Products { get; set; }

    }
}
