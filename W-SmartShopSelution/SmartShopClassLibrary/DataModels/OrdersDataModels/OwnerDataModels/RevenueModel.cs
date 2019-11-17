using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class RevenueModel
    {
        /// <summary>
        /// The Id of the Revenue in the database
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The Staff Member who made this Revenue record (The Loged in staff)
        /// </summary>
        public StaffModel Staff { get; set; }

        /// <summary>
        /// The store that this Revenue done in(the loged in store)
        /// </summary>
        public StoreModel Store { get; set; }

        /// <summary>
        /// The Datetime of the revenue
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// The Total Money that the owner take
        /// </summary>
        public decimal TotalMoney { get; set; }
    }
}
