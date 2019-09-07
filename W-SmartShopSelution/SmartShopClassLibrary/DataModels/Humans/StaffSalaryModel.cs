using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class StaffSalaryModel
    {
        /// <summary>
        /// The Id of this Payment
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The staff memeber
        /// </summary>
        public StaffModel Staff { get; set; }

        /// <summary>
        /// The date of the payment
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// The Amount of money Payed at this time
        /// </summary>
        public decimal Salary { get; set; }
    }
}
