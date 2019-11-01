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
        // TODO - Do the incomeOrder , installment..... in the addOperationToDatabase
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
                    p.Add("@Date", operation.Date);
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
                    p.Add("@Date", operation.Date);
                    p.Add("@OrderId", null);
                    p.Add("@InstallmentId", null);
                    p.Add("@IncomeOrderId", operation.IncomeOrder.Id);
                    p.Add("@ShopBillId", null);
                    p.Add("@StaffSalaryId", null);
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
                    p.Add("@Date", operation.Date);
                    p.Add("@OrderId", null);
                    p.Add("@InstallmentId", null);
                    p.Add("@IncomeOrderId",null);
                    p.Add("@ShopBillId", operation.ShopBill.Id);
                    p.Add("@StaffSalaryId", null);
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

        /// <summary>
        /// Get all the operations from the database
        /// - Set the Order of installment , incomeOrder , shopBill , staffSalary
        /// </summary>
        /// <returns></returns>
        public static List<OperationModel> GetOperations(string db)
        {
            List<OperationModel> operations = new List<OperationModel>();

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnVal(db)))
            {
                operations = connection.Query<OperationModel>("dbo.spOperation_GetAll").ToList();

                foreach (OperationModel operation in operations)
                {
                    var p = new DynamicParameters();
                    p.Add("@OperationId", operation.Id);

                    //TODO - Set the other Options (installment , incomeorder , ....) to the operation

                    string orderId = connection.QuerySingle<string>("dbo.spOperation_GetOrderIdByOperationId", p, commandType: CommandType.StoredProcedure);
                    string incomeOrderId = connection.QuerySingle<string>("dbo.spOperation_GetIncomeOrderIdByOperationId", p, commandType: CommandType.StoredProcedure);
                    string shopBillId = connection.QuerySingle<string>("dbo.spOperation_GetShopBillIdByOperationId", p, commandType: CommandType.StoredProcedure);

                    /*string installmentId = connection.QuerySingle<string>("dbo.spOperation_GetInstallmentIdByOperationId", p, commandType: CommandType.StoredProcedure);
                    string staffSalaryId = connection.QuerySingle<string>("dbo.spOperation_GetInstallmentIdByOperationId", p, commandType: CommandType.StoredProcedure);*/

                    if (orderId != null)
                    {
                        foreach (OrderModel order in PublicVariables.Orders)
                        {
                            if (order.Id == int.Parse(orderId))
                            {
                                operation.Order = order;
                                break;
                            }
                        }
                    }
                    else if (incomeOrderId != null)
                    {
                        foreach (IncomeOrderModel incomeOrder in PublicVariables.IncomeOrders)
                        {
                            if (incomeOrder.Id == int.Parse(incomeOrderId))
                            {
                                operation.IncomeOrder = incomeOrder;
                                break;
                            }
                        }
                    }
                    else if (shopBillId != null)
                    {
                        foreach (ShopBillModel shopBill in PublicVariables.ShopBills)
                        {
                            if (shopBill.Id == int.Parse(shopBillId))
                            {
                                operation.ShopBill = shopBill;
                                break;
                            }
                        }
                    }
                        /*else if (installmentId != null)
                        {
                            //TODO - Set the installment to the operation
                        }


                        else if (staffSalaryId != null)
                        {
                            //TODO - Set the StaffSalary to the operation
                        }*/

                 }

            }

            return operations;
        }


        /// <summary>
        /// Filter the opration by StartDate and EndDate in the operation.Date exist add to the fOperation list
        /// </summary>
        /// <param name="operations"></param>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns></returns>
        public static List<OperationModel> FilterOperationsByDate(List<OperationModel> operations , DateTime startDate , DateTime endDate)
        {
            List<OperationModel> fOperations = new List<OperationModel>();

            // Here to add the 24 hour
            endDate = endDate.AddDays(1);

            
                foreach (OperationModel operation in operations)
                {
                    if (operation.Date <= endDate && operation.Date >= startDate)
                    {
                        fOperations.Add(operation);
                    }
                }
            

            


            return fOperations;
        }

        /// <summary>
        /// Get all the operations that contain the order
        /// </summary>
        /// <param name="order"></param>
        /// <param name="operations"></param>
        /// <returns></returns>
        public static List<OperationModel> GetOperationsByOrder(OrderModel order , List<OperationModel> operations)
        {
            List<OperationModel> fOperations = new List<OperationModel>();
            foreach(OperationModel operation in operations)
            {
                if(operation.GetOperationName == "Order")
                {
                    if (operation.Order.Id == order.Id)
                    {
                       fOperations.Add(operation);
                    }
                }
               
            }
            return fOperations;

        }

        /// <summary>
        /// Get the opration that contain the ShopBill
        /// </summary>
        /// <param name="order"></param>
        /// <param name="operations"></param>
        /// <returns></returns>
        public static OperationModel GetOperationByShopBill(ShopBillModel shopBill, List<OperationModel> operations)
        {
            OperationModel fOperation = new OperationModel();
            foreach (OperationModel operation in operations)
            {
                if (operation.GetOperationName == "ShopBill")
                {
                    if (operation.ShopBill.Id == shopBill.Id)
                    {
                        fOperation = operation;
                    }
                }

            }
            return fOperation;

        }

        /// <summary>
        /// Update the operation AmountOfMoney
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public static OperationModel UpdateOperationData(OperationModel operation,string db)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnVal(db)))
            {
                var p = new DynamicParameters();
                p.Add("@Id", operation.Id);
                p.Add("@AmountOfMoney", operation.AmountOfMoney);
                connection.Execute("dbo.spOperation_Update", p, commandType: CommandType.StoredProcedure);
            }

            return operation;
        }

        /// <summary>
        /// Delete operation from the database totaly
        /// </summary>
        /// <param name="operation"></param>
        /// <param name="db"></param>
        public static void RemoveOperation(OperationModel  operation, string db)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnVal(db)))
            {
                var p = new DynamicParameters();
                p.Add("@Id", operation.Id);
                connection.Execute("dbo.spOperation_Delete", p, commandType: CommandType.StoredProcedure);

            }
        }

    }
}
