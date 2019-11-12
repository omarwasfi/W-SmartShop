using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class IncomeOrderPaymentModel
    {
        /// <summary>
        /// The Id of the IncomeOrderPayment in the database
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The Total Money paid at this payment
        /// </summary>
        public decimal Paid { get; set; }

        /// <summary>
        /// The datatime of the payment
        /// </summary>
        public DateTime Date { get; set; }
    }
}
