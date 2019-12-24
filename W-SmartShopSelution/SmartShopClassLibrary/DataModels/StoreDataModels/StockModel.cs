using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    /// <summary>
    /// Stock model describe where is the product and the quantity contains:
    /// database Id ,  store model , Product model ,current quantity  in the store 
    /// </summary>
    public class StockModel
    {
        /// <summary>
        /// database Id
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// S barcode is the unique thing about the stock
        /// Starts with the Prodict.Barcode then first litter of the store then a Number
        /// </summary>
        public string SBarCode { get; set; }

        /// <summary>
        /// The Store model
        /// </summary>
        public StoreModel Store { get; set; }

        /// <summary>
        /// The product 
        /// </summary>
        public ProductModel Product { get; set; }

        /// <summary>
        /// The real Incomeprice set in IncomeOrderUC
        /// </summary>
        public decimal IncomePrice { get; set; }

        /// <summary>
        /// The salePrice Set in the IncomeOrderUC
        /// </summary>
        public decimal SalePrice { get; set; }

        /// <summary>
        /// The date of the stock creation
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// The Current Quantity of this product in the store
        /// </summary>
        public float Quantity { get; set; }

        #region Expiration Notifications

        /// <summary>
        /// The date of expiration
        /// </summary>
        public DateTime ExpirationDate { set; get; }
        
        /// <summary>
        /// The time of the expiration 
        /// </summary>
        public TimeSpan GetExpirationPeriod
        {
            get
            {
                return Stock.GetExpirationPeriod(this);
            }
        }

        /// <summary>
        /// Get how much time to be complitly expired
        /// Or is it expited
        /// Or it's not has an expiration period
        /// </summary>
        public string ExpirationState
        {
            get
            {
                return Stock.ExpirationState(this);
            }
        }

        /// <summary>
        /// notification Time in hours
        /// </summary>
        public DateTime NotificationDate { get; set; }

      
        /// <summary>
        /// if it's disabled the user will not get notification about the ExpirationPeriod
        /// </summary>
        public Boolean ExpirationAlarmEnabled { get; set; }

        #endregion

        #region Quantity Notifications



        /// <summary>
        /// The quantity that the user need to be notified at To get more stocks
        /// </summary>
        public int AlarmQuantity { get; set; }

        /// <summary>
        /// if it's disabled the user will not get notification about the AlarmQuantity
        /// </summary>
        public Boolean QuantityAlarmEnabled { get; set; }
        #endregion


    }
}
