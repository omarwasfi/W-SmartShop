using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class OperationModel
    {
        public  int Id { get; set; }

        public  OrderModel Order { get; set; }

        public  InstallmentModel Installment { get; set; }

        public  IncomeOrderModel IncomeOrder { get; set; }

        public  ShopBillModel ShopBill { get; set; }

        public StaffSalaryModel StaffSalary { get; set; }

        /// <summary>
        /// The amount of money of the operation
        /// </summary>
        public decimal AmountOfMoney { get; set; }

        /// <summary>
        /// Set and return The OperationName {"Order","Installment","IncomeOrder","ShopBill",StaffSalary} , if all null return "Empty"
        /// </summary>
        public string GetOperationName
        {
            get
            {

                if (Installment != null)
                {
                    return "Installment";
                }
                else if (IncomeOrder != null)
                {
                    return "IncomeOrder";
                }
                else if (Order != null)
                {
                    return "Order";
                }
                else if (ShopBill != null)
                {
                    return "ShopBill";
                }
                else if (StaffSalary != null)
                {
                    return "StaffSalary";
                }
                else
                {
                    return "Empty";
                }

                

            }
        }

        /// <summary>
        /// The type of Opertation (In , out), if true => In -> money Payment , false => out -> money income
        /// </summary>
        public Boolean GetTheOperationType
        {
            get
            {
                if(GetOperationName == "Installment" || GetOperationName == "Order")
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

    }
}
