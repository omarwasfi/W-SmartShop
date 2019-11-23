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
        /// The Staff who did this Payment (The LogedIn Staff member)
        /// </summary>
        public StaffModel Staff { get; set; }

        /// <summary>
        /// The Store who recived the money (The LoggedIn Store)
        /// </summary>
        public StoreModel Store { get; set; }
        /// <summary>
        /// Paid in this Payment
        /// </summary>
        public decimal Paid { get; set; }

        /// <summary>
        /// The datetime of the Payment 
        /// </summary>
        public DateTime Date { get; set; }

        #region Not Database Related

        /// <summary>
        /// Get the Order Of this Payment
        /// </summary>
        public OrderModel GetOrder 
        {
            get 
            {
               return OrderPayment.GetTheOrder(this);
            }
        }

        #endregion
    }
}
