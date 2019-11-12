using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    /// <summary>
    /// The relation between the Owners Capital and the Stores
    /// Transfare money from the Store to Capital
    /// </summary>
    public class DeTransformModel
    {

        /// <summary>
        /// The id if the DeTransformation in the database
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The staff who made this DeTransformation
        /// </summary>
        public StaffModel Staff { get; set; }

        /// <summary>
        /// The Store that this DeTransformation done in (The LogedIn store)
        /// </summary>
        public StoreModel Store { get; set; }

        /// <summary>
        /// The datatime of the DeTransformation
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// The total amount of money of this DeTransformation
        /// </summary>
        public decimal TotalMoney { get; set; }

        /// <summary>
        /// The store that Paid this DeTrancformation
        /// </summary>
        public StoreModel FromStore { get; set; }
    }
}
