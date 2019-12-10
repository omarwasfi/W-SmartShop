using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public static class Operation
    {
        /// <summary>
        /// Get the staff who did the operation
        /// </summary>
        /// <param name="operation"></param>
        /// <returns></returns>
        public static StaffModel GetStaff(OperationModel operation)
        {
            if (operation.Type == OperationType.DeTransform)
            {
                return operation.DeTransform.Staff;
            }
            else if (operation.Type == OperationType.Transform)
            {
                return operation.Transform.Staff;
            }
            else if (operation.Type == OperationType.OrderPayment)
            {
                return operation.OrderPayment.GetOrder.Staff;
            }
            else if (operation.Type == OperationType.IncomeOrderPayment)
            {
                return operation.IncomeOrderPayment.GetIncomeOrder.Staff;
            }
            else if (operation.Type == OperationType.ShopBill)
            {
                return operation.ShopBill.Staff;
            }
            else
            {
                return operation.StaffSalary.Staff;
            }
        }

    }
}
