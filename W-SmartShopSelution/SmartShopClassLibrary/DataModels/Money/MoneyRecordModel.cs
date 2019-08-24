using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public  class MoneyRecordModel
    {
        public int Id { get; set; }

        /// <summary>
        /// The OperationId
        /// </summary>
        public int OperationId { get; set; }

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

    }
}
