using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class InstallmentDetailsModel
    {
        public int Id { get; set; }

        /// <summary>
        /// The date of payment
        /// </summary>
        public DateTime DueToPay { get; set; }

        /// <summary>
        /// Equals 1/1/1755 if it not payed
        /// </summary>
        public DateTime PaymentDate { get; set; }
    }
}
