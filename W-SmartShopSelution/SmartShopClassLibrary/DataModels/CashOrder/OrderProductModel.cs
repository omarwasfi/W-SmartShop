using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class OrderProductModel
    {
        public int Id { get; set; }

        public ProductModel Product { get; set; }

        public int Quantity { get; set; }

        public decimal SalePrice { get; set; }

        public decimal Discount { get; set; }

        public decimal TotalProductPrice { get; set; }

    }
}
