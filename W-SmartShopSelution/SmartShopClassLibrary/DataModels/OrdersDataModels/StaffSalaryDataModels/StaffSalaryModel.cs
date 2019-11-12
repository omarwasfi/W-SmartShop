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
        /// The store model that this StaffSalary Happend in The salary Money From this store
        /// </summary>
        public StoreModel Store { get; set; }

        /// <summary>
        /// The staff who made this StaffSalary(the logged in store)
        /// </summary>
        public StaffModel Staff { get; set; }
        /// <summary>
        /// The date of the payment
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// The Amount of money Paid at this time
        /// </summary>
        public decimal Salary { get; set; }

        /// <summary>
        /// The staff who took the salary
        /// </summary>
        public StaffModel ToStaff { get; set; }
    }
}
