using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library

{
    public class OrderPaymentModel
    {
        /// <summary>
        /// Payement Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Paid in this Payment
        /// </summary>
        public decimal Paid { get; set; }

        /// <summary>
        /// The datetime of the Payment 
        /// </summary>
        public DateTime Date { get; set; }
    }
}
