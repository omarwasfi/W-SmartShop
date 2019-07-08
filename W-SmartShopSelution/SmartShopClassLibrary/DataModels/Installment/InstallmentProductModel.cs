using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class InstallmentProductModel
    {
        public int Id { get; set; }

        public ProductModel Product { get; set; }

        public decimal Deposit { get; set; }

        public decimal InstallmentPrice { get; set; }

        public decimal Discount { get; set; }
    }
}
