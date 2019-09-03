using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class MoneyRecordModel
    {
        public int Id { get; set; }

        /// <summary>
        /// The OperationId
        /// </summary>
        public OperationModel Operation { get; set; }


        /// <summary>
        /// The type of Opertation (In , out)
        /// if true => In
        /// false => out
        /// </summary>
        public Boolean OperationType { get; set; }

        /// <summary>
        /// The amount of money of the operation
        /// </summary>
        public decimal AmountOfMoney { get; set; }

        /// <summary>
        /// Check every thing in the operation and return the date of the order that not null
        /// </summary>
        public DateTime GetDate
        {
            get
            {
                if (Operation.Installment != null)
                {
                    return Operation.Installment.Date;
                }
                else if (Operation.IncomeOrder != null)
                {
                    return Operation.IncomeOrder.Date;
                }
                else if (Operation.Order != null)
                {
                    return Operation.Order.DateTimeOfTheOrder;
                }
                else
                {
                    return Operation.ShopBill.Date;
                }
                
            }
        }

    }

}
