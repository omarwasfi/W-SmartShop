using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class InstallmentModel
    {
        public int Id { get; set; }

        public CustomerModel Customer { get; set; }

        /// <summary>
        /// The Date Of the Order
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// The Number of monthes
        /// </summary>
        public int NumberOfMonths { get; set; }

        /// <summary>
        /// The date Of first poyment
        /// </summary>
        public DateTime PaymentsStartDate { get; set; }

        /// <summary>
        /// The amount of money customer pay each time
        /// </summary>
        public decimal EMI { get; set; }

        /// <summary>
        /// the rate of Interest * (total price before installment - deposit) = TotalInstallmentPrice
        /// </summary>
        public double RateOfInterest { get; set; }

        /// <summary>
        /// The Loan Amount = TotaInstallmentPrice - Deposit
        /// </summary>
        public decimal LoanAmount { get; set; }

        public decimal Deposit { get; set; }

        /// <summary>
        /// The total price of the installment
        /// </summary>
        public decimal TotaInstallmentPrice { get; set; }

        public StoreModel Store { get; set; }

        public StaffModel Staff { get; set; }

        public List<InstallmentProductModel> Products { get; set; }

        /// <summary>
        /// List of installmentDetails
        /// </summary>
        public List<InstallmentDetailsModel> InstallmentDetails { get; set; }

       
    }
}
