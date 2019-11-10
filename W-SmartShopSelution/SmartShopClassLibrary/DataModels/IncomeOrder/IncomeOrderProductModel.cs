using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Library
{
    public class IncomeOrderProductModel
    {
        public int Id { get; set; }

        public  ProductModel Product { get; set;}

        public decimal IncomePrice { get; set; }

        public int Quantity { get; set; }

        /// <summary>
        /// Return the total price of this IncomeOrderProduct
        /// </summary>
        public decimal GetTotalProductPrice { get { return Quantity * IncomePrice; }  }

    }
}
