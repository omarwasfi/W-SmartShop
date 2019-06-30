using Library.DataModels.Goods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataModels.Installment
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
