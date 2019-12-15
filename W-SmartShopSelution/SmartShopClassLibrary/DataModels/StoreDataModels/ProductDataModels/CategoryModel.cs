using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    [Serializable]
    /// <summary>
    /// Category model catain:
    /// Database Id , Name , List of products of this category
    /// </summary>
    public class CategoryModel
    {
        /// <summary>
        /// category Database Id 
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Category Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// List of the products of this category
        /// </summary>
        //public List<ProductModel> Products { get; set; }
    }
}
