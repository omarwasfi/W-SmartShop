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
        /// The product 
        /// </summary>
        public ProductModel Product { get; set; }

        /// <summary>
        /// The Store model
        /// </summary>
        public StoreModel Store { get; set; }

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
        /// The time of the expiration in days
        /// </summary>
        public int ExpirationPeriod { get; set; }

        /// <summary>
        /// The Current Quantity of this product in the store
        /// </summary>
        public int Quantity { get; set; }
    }
}
