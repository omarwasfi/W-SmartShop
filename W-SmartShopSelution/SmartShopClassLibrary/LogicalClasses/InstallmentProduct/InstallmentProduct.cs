using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public static class InstallmentProduct
    {
        /// <summary>
        /// Foreach InstallmentProduct in The Installment , save it in the database
        /// </summary>
        /// <param name="installment"></param>
        /// <param name="db"></param>
        public static void SaveInstallmentProductToTheDatabase(InstallmentModel installment , string db)
        {

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnVal(db)))
            {
                foreach(InstallmentProductModel installmentProduct in installment.Products)
                {
                    var o = new DynamicParameters();
                    o.Add("@InstallmentId", installment.Id);
                    o.Add("@ProductId", installmentProduct.Product.Id);
                    o.Add("@Quantity", installmentProduct.Quantity);
                    o.Add("@InstallmentPrice", installmentProduct.InstallmentPrice);
                    o.Add("@Discount", installmentProduct.Discount);
                    connection.Execute("dbo.spInstallmentProduct_Create", o, commandType: CommandType.StoredProcedure);
                }
            }

        }
    }
}
