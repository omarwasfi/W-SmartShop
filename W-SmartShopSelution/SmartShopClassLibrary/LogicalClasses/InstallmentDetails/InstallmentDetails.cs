using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    
    public static class InstallmentDetails
    {

        /// <summary>
        /// Get Installment
        /// Create the InstallmentDetails:
        ///     - initial the InstallmentDetail Lists countOf(numberOfMonths)
        ///     - Fill the DueToPay each InstallmentDetail
        ///     - Fill the PaymentDate to 1/1/1755 date as they not payed
        ///     - Save To the database
        /// </summary>
        public static void CreateAndSaveInstallmentDetailsToTheDatabase(InstallmentModel installment,string db)
        {
            installment.InstallmentDetails = new List<InstallmentDetailsModel>();
            DateTime paymentDate = new DateTime();
            paymentDate = installment.PaymentsStartDate;

            for(int i = 1; i <= installment.NumberOfMonths; i++)
            {
                InstallmentDetailsModel installmentDetails = new InstallmentDetailsModel();
                installmentDetails.DueToPay = paymentDate;
                installmentDetails.PaymentDate = new DateTime(1755,1,1);
                installment.InstallmentDetails.Add(installmentDetails);
                paymentDate = paymentDate.AddMonths(1);
            }


            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnVal(db)))
            {
                foreach (InstallmentDetailsModel installmentDetailsModel in installment.InstallmentDetails)
                {
                    var o = new DynamicParameters();
                    o.Add("@InstallmentId", installment.Id);
                    o.Add("@DuoToPay", installmentDetailsModel.DueToPay);
                    o.Add("@PaymentDate", installmentDetailsModel.PaymentDate);
                    connection.Execute("dbo.spInstallmentDetails_Create", o, commandType: CommandType.StoredProcedure);

                }
            }

        }

    }
}
