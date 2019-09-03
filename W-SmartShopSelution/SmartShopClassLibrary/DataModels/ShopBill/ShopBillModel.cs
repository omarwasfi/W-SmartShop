using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class ShopBillModel
    {
        public int Id { get; set; }

        /// <summary>
        /// The date-time of the Bill
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// The descreption of the bill
        /// </summary>
        public string Details { get; set; }

        /// <summary>
        /// The Total money of the bill
        /// </summary>
        public decimal TotalMoney { get; set; }
    }
}
