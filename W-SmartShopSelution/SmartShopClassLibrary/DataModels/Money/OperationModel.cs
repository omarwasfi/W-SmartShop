using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
     class OperationModel
    {
        public  int Id { get; set; }

        public  OrderModel Order { get; set; }

        public  InstallmentModel Installment { get; set; }

        public  IncomeOrderModel IncomeOrder { get; set; }

        public  ShopBillModel ShopBill { get; set; }

    }
}
