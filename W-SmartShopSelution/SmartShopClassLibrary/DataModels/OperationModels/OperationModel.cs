using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    /// <summary>
    /// Any money Record (Transform , DeTransform , OrderPayment , IncomeOrderPayment , ShopBill , StaffSalary)
    /// </summary>
    public class OperationModel
    {

        public TransformModel Transform { get; set; }

        public DeTransformModel DeTransform { get; set; }

        public OrderPaymentModel OrderPayment { get; set; }

        public IncomeOrderPaymentModel IncomeOrderPayment { get; set; }

        public  ShopBillModel ShopBill { get; set; }

        public StaffSalaryModel StaffSalary { get; set; }

        /// <summary>
        /// Retun the operation Type Enum {"DeTransform","Transform","OrderPayment","IncomeOrderPayment","ShopBill",StaffSalary"}
        /// </summary>
        public OperationType Type
        {
            get
            {
                if (DeTransform != null)
                {
                    return OperationType.DeTransform;
                }
                else if (Transform != null)
                {
                    return OperationType.Transform;
                }
                else if (OrderPayment != null)
                {
                    return OperationType.OrderPayment;
                }
                else if (IncomeOrderPayment != null)
                {
                    return OperationType.IncomeOrderPayment;
                }
                else if (ShopBill != null)
                {
                    return OperationType.ShopBill;
                }
                else 
                {
                    return OperationType.StaffSalary;
                }
            }
        }

        /// <summary>
        /// The date of the {"DeTransform","Transform","OrderPayment","IncomeOrderPayment","ShopBill",StaffSalary}
        /// </summary>
        public DateTime GetDate 
        { 
            get 
            {
                if(Type == OperationType.DeTransform)
                {
                    return DeTransform.Date;
                }
                else if (Type == OperationType.Transform)
                {
                    return Transform.Date;
                }
                else if (Type == OperationType.OrderPayment)
                {
                    return OrderPayment.Date;
                }
                else if (Type == OperationType.IncomeOrderPayment)
                {
                    return IncomeOrderPayment.Date;
                }
               else if (Type == OperationType.ShopBill)
                {
                    return ShopBill.Date;
                }
                else
                {
                    return StaffSalary.Date;
                }

            } 
        }

        /// <summary>
        /// Get the store affected by this Operation
        /// </summary>
        public StoreModel GetTheAffactedStore 
        {
            get
            {
                if (Type == OperationType.DeTransform)
                {
                    return DeTransform.FromStore;
                }
                else if (Type == OperationType.Transform)
                {
                    return Transform.ToStore;
                }
                else if (Type == OperationType.OrderPayment)
                {
                    return OrderPayment.GetOrder.Store;
                }
                else if (Type == OperationType.IncomeOrderPayment)
                {
                    return IncomeOrderPayment.GetIncomeOrder.Store;
                }
                else if (Type == OperationType.ShopBill)
                {
                    return ShopBill.Store;
                }
                else
                {
                    return StaffSalary.Store;
                }
            }
        }

        /// <summary>
        /// Get the id of any of {"DeTransform","Transform","OrderPayment","IncomeOrderPayment","ShopBill",StaffSalary}
        /// </summary>
        public int GetTheId
        { 
            get
            {
                if (Type == OperationType.DeTransform)
                {
                    return DeTransform.Id;
                }
                else if (Type == OperationType.Transform)
                {
                    return Transform.Id;
                }
                else if (Type == OperationType.OrderPayment)
                {
                    return OrderPayment.Id;
                }
                else if (Type == OperationType.IncomeOrderPayment)
                {
                    return IncomeOrderPayment.Id;
                }
                else if (Type == OperationType.ShopBill)
                {
                    return ShopBill.Id;
                }
                else if(Type == OperationType.StaffSalary)
                {
                    return StaffSalary.Id;
                }
                else
                {
                    return 0;
                }
               
            }
        }


        /// <summary>
        /// return the Name of the operation to the user {"DeTransform","Transform","OrderPayment","IncomeOrderPayment","ShopBill",StaffSalary} , if all null return "Empty"
        /// </summary>
        public string GetTheOperationName
        {
            get
            {

                if (Type == OperationType.DeTransform)
                {
                    return "Detransform";
                }
                else if (Type == OperationType.Transform)
                {
                    return "Transform";
                }
                else if (Type == OperationType.OrderPayment)
                {
                    return "Order Payment";
                }
                else if (Type == OperationType.IncomeOrderPayment)
                {
                    return "Income Order Payment";
                }
                else if (Type == OperationType.ShopBill)
                {
                    return "Shop bill";
                }
                else if (Type == OperationType.StaffSalary)
                {
                    return "Staff Salary";
                }
                else
                {
                    return "";
                }




            }
        }

        /// <summary>
        /// Get the Actual Value of the money {Store.ShopeeWallet increased the value in positive , Store.ShopeeWallet Decreased The Value in negtive}
        /// </summary>
        public decimal GetTheValueOfTheMoney 
        {
            get
            {
                if (Type == OperationType.DeTransform)
                {
                    return DeTransform.TotalMoney * -1;
                }
                else if (Type == OperationType.Transform)
                {
                    return Transform.TotalMoney;
                }
                else if (Type == OperationType.OrderPayment)
                {
                    return OrderPayment.Paid;
                }
                else if (Type == OperationType.IncomeOrderPayment)
                {
                    return IncomeOrderPayment.Paid * -1;
                }
                else if (Type == OperationType.ShopBill)
                {
                    return ShopBill.TotalMoney * -1;
                }
                else if (Type == OperationType.StaffSalary)
                {
                    return StaffSalary.Salary * -1 ;
                }
                else
                {
                    return 0;
                }
            }
        }



    }
}
