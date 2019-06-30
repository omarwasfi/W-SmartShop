using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DataModels.CashOrder
{
    /// <summary>
    /// Cash order contain:
    /// Database Id , Customer model ,  date and time , Store model , staff model , List of the Products
    /// </summary>
    public class OrderModel
    {
        /// <summary>
        /// database Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Customer model
        /// </summary>
        public CustomerModel Customer { get; set; }

        /// <summary>
        /// The Date and the time of this order
        /// </summary>
        public DateTime DateTime { get; set; }

        /// <summary>
        /// store model
        /// </summary>
        public StoreModel Store { get; set; }

        /// <summary>
        /// staff member
        /// </summary>
        public StaffModel Staff { get; set; }

        /// <summary>
        /// Total Price of this order
        /// </summary>
        public decimal TotalPrice { get; set; }

        /// <summary>
        /// List of order product model describe 
        /// what products we have , the quantity , the price of each one , if there is a discount or not
        /// </summary>
        public List<OrderProductModel> Products { get; set; }
    }
}
