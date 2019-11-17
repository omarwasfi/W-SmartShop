using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class InvestmentModel
    {
        /// <summary>
        /// The id of the Investment record
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The Staff Member who made this Investment record (The Loged in staff)
        /// </summary>
        public StaffModel Staff { get; set; }

        /// <summary>
        /// The store that this investment done in(the loged in store)
        /// </summary>
        public StoreModel Store { get; set; }

        /// <summary>
        /// The dataTime of the investment
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// The money Owner paid at this investment
        /// </summary>
        public decimal TotalMoney { get; set; }

        

    }
}
