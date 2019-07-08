using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    /// <summary>
    /// the supplier Model is a person that supplie the product to the store
    /// Database Id, person model
    /// </summary>
    public class SupplierModel
    {
        /// <summary>
        /// Supplier Database Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// person Model describe everything everything about the supplier person
        /// </summary>
        public PersonModel Person { get; set; }
    }
}
