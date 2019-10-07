using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class IncomeOrderModel
    {
        public int Id { get; set; }

        public SupplierModel Supplier { get; set; }

        /// <summary>
        /// The billNumber not unique , could be null
        /// </summary>
        public string BillNumber { get; set; }

        public DateTime Date { get; set; }

        public StoreModel Store { get; set; }

        public StaffModel Staff { get; set; }

        public decimal TotalPrice { get; set; }

        /// <summary>
        /// The details of the IncomeOrder
        /// </summary>
        public string Details { get; set; }

        /// <summary>
        /// List of OncomeOrderProdcutModel
        /// </summary>
        public List<IncomeOrderProductModel> Products { get; set; }

        /// <summary>
        /// Get the total price payed to the supplier
        /// </summary>
        public decimal GetTotalPrice
        {
            get
            {
                decimal totalPrice = new decimal();
                foreach(IncomeOrderProductModel incomeOrderProduct in Products)
                {
                    totalPrice += incomeOrderProduct.GetTotalProductPrice;
                }

                return totalPrice;
            }
        }
    }
}
