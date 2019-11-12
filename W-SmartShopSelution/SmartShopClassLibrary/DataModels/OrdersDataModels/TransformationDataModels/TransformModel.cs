using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{

    /// <summary>
    /// The relation between the Owners Capital and the Stores
    /// Transfare money from the Capital to Store
    /// </summary>
    public class TransformModel
    {
        /// <summary>
        /// The id if the transformation in the database
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The staff who made this transformation
        /// </summary>
        public StaffModel Staff { get; set; }

        /// <summary>
        /// The Store that this transformation done in (The LogedIn store)
        /// </summary>
        public StoreModel Store { get; set; }

        /// <summary>
        /// The datatime of the transformation
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// The total amount of money of this transformation
        /// </summary>
        public decimal TotalMoney { get; set; }

        /// <summary>
        /// The store that recived this trancformation
        /// </summary>
        public StoreModel ToStore { get; set; }
    }
}
