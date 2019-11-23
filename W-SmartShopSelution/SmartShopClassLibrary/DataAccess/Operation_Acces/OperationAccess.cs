using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public static class OperationAccess
    {
        public static List<OperationModel> CreateTheOperations(List<TransformModel> transforms, List<DeTransformModel> deTransforms, List<OrderPaymentModel> orderPayments, List<IncomeOrderPaymentModel> incomeOrderPayments, List<ShopBillModel> shopBills,List<StaffSalaryModel>staffSalaries)
        {
            List<OperationModel> operations = new List<OperationModel>();
            foreach (TransformModel transformModel in transforms)
            {
                operations.Add(new OperationModel { Transform = transformModel });
            }

            foreach (DeTransformModel deTransformModel in deTransforms)
            {
                operations.Add(new OperationModel { DeTransform = deTransformModel });
            }

            foreach (OrderPaymentModel orderPayment in orderPayments)
            {
                operations.Add(new OperationModel { OrderPayment = orderPayment });
            }

            foreach (IncomeOrderPaymentModel incomeOrderPayment in incomeOrderPayments)
            {
                operations.Add(new OperationModel { IncomeOrderPayment = incomeOrderPayment });
            }

            foreach (ShopBillModel shopBill in shopBills)
            {
                operations.Add(new OperationModel { ShopBill = shopBill });
            }

            foreach (StaffSalaryModel staffSalary in staffSalaries)
            {
                operations.Add(new OperationModel { StaffSalary = staffSalary });
            }

            return operations;
        }
    }
}
