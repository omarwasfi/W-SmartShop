using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    /// <summary>
    /// add incomeOrderProduct
    /// </summary>
    public static class IncomeOrderProduct
    {

        /// <summary>
        /// Loop throw each IncomeOrderProduct in the IncomeOrder
        /// save each one in the IncomeOrderProdcut table with tha Id of the IncomeOrder
        /// </summary>
        /// <param name="order"> IncomeOrder Model Has An Id From IncomeOrder.GetEmptyIncomeOrder </param>
        /// <param name="db"> Database Connection Name </param>
        public static void SaveIncomeOrderProductListToTheDatabase(IncomeOrderModel incomeOrder, string db)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnVal(db)))
            {
               foreach(IncomeOrderProductModel incomeOrderProduct in incomeOrder.Products)
                {
                    var o = new DynamicParameters();
                    o.Add("@IncomeOrderId", incomeOrder.Id);
                    o.Add("@ProductId", incomeOrderProduct.Product.Id);
                    o.Add("@IncomePrice", incomeOrderProduct.IncomePrice);
                    o.Add("@Quantity", incomeOrderProduct.Quantity);
                    connection.Execute("dbo.spIncomeOrderProduct_Create", o, commandType: CommandType.StoredProcedure);

                }
            }
        }

    }
}
