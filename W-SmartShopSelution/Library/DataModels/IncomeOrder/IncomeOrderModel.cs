using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataModels.IncomeOrder
{
    public class IncomeOrderModel
    {
        public int Id { get; set; }

        public SupplierModel Supplier { get; set; }

        public string BillNumber { get; set; }

        public DateTime DateTime { get; set; }

        public StoreModel Store { get; set; }

        public StaffModel Staff { get; set; }

        public List<IncomeOrderProduct> Products { get; set; }

    }
}
