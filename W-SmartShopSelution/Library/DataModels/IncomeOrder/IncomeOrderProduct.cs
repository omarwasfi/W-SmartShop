using Library.DataModels.Goods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataModels.IncomeOrder
{
    public class IncomeOrderProduct
    {
        public int Id { get; set; }

        public ProductModel Product { get; set; }

        public int Quantity { get; set; }

        public decimal IncomePrice { get; set; }
    }
}
