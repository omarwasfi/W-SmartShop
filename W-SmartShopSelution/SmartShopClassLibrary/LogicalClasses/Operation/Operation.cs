using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public static class Operation
    {
        /// <summary>
        /// Add Operation to tha database , set the amountOfMoney and any Propity 
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public static OperationModel AddOperationToDatabase(OperationModel operation,string db)
        {
            if(operation.GetOperationName == "Order")
            {
                using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnVal(db)))
                {
                    var p = new DynamicParameters();
                    p.Add("@AmountOfMoney", operation.AmountOfMoney);
                    p.Add("@Type", operation.GetTheOperationType);
                    p.Add("@OrderId", operation.Order.Id);
                    p.Add("@InstallmentId", null);
                    p.Add("@IncomeOrderId", null);
                    p.Add("@ShopBillId", null);
                    p.Add("@StaffSalaryId", null);
                    p.Add("@Id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
                    connection.Execute("dbo.spOperation_Create", p, commandType: CommandType.StoredProcedure);
                    operation.Id = p.Get<int>("@Id");
                }
            }
            else if (operation.GetOperationName == "Installment")
            {
                using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnVal(db)))
                {
                    var p = new DynamicParameters();
                    p.Add("@AmountOfMoney", operation.AmountOfMoney);
                    p.Add("@Type", operation.GetTheOperationType);
                    p.Add("@InstallmentId", operation.Installment.Id);
                    p.Add("@Id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
                    connection.Execute("dbo.spOperation_Create", p, commandType: CommandType.StoredProcedure);
                    operation.Id = p.Get<int>("@Id");
                }
            }
            else if (operation.GetOperationName == "IncomeOrder")
            {
                using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnVal(db)))
                {
                    var p = new DynamicParameters();
                    p.Add("@AmountOfMoney", operation.AmountOfMoney);
                    p.Add("@Type", operation.GetTheOperationType);
                    p.Add("@IncomeOrderId", operation.IncomeOrder.Id);
                    p.Add("@Id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
                    connection.Execute("dbo.spOperation_Create", p, commandType: CommandType.StoredProcedure);
                    operation.Id = p.Get<int>("@Id");
                }
            }
            else if (operation.GetOperationName == "ShopBill")
            {
                using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnVal(db)))
                {
                    var p = new DynamicParameters();
                    p.Add("@AmountOfMoney", operation.AmountOfMoney);
                    p.Add("@Type", operation.GetTheOperationType);
                    p.Add("@ShopBillId", operation.ShopBill.Id);
                    p.Add("@Id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
                    connection.Execute("dbo.spOperation_Create", p, commandType: CommandType.StoredProcedure);
                    operation.Id = p.Get<int>("@Id");
                }
            }
            else if (operation.GetOperationName == "StaffSalary")
            {
                using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnVal(db)))
                {
                    var p = new DynamicParameters();
                    p.Add("@AmountOfMoney", operation.AmountOfMoney);
                    p.Add("@Type", operation.GetTheOperationType);
                    p.Add("@StaffSalaryId", operation.StaffSalary.Id);
                    p.Add("@Id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
                    connection.Execute("dbo.spOperation_Create", p, commandType: CommandType.StoredProcedure);
                    operation.Id = p.Get<int>("@Id");
                }
            }
            else
            {

            }

            return operation;
        }

    }
}
