using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public static class IncomeOrderAccess
    {
        /// <summary>
        /// Get all the IncomeOrders From The database without set the the supplierModel , storeModel , staffModel , list of IncomeOrderProducts
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        public static List<IncomeOrderModel> GetIncomeOrdersFromTheDatabase(string db)
        {
            List<IncomeOrderModel> incomeOrders = new List<IncomeOrderModel>();
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnVal(db)))
            {
                incomeOrders = connection.Query<IncomeOrderModel>("dbo.").ToList();

            }
            foreach(IncomeOrderModel incomeOrder in incomeOrders)
            {
                incomeOrder.Supplier = new SupplierModel();
                incomeOrder.Store = new StoreModel();
                incomeOrder.Staff = new StaffModel();
                incomeOrder.IncomeOrderProducts = new List<IncomeOrderProductModel>();
            }

            return incomeOrders;
        }

        /// <summary>
        /// Get incomeOrder with a new Id
        /// The IncomeOrder should Have The main info of thist variables:
        /// SupplierId , DataTimeOfTheOrder, StoreId, StaffId,TotalPrice
        /// </summary>
        /// <param name="incomeOrder"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public static IncomeOrderModel GetEmptyIncomeOrderFromTheDatabase(IncomeOrderModel incomeOrder, string db)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnVal(db)))
            {
                var p = new DynamicParameters();
                p.Add("@SupplierId", incomeOrder.Supplier.Id);
                if (!string.IsNullOrWhiteSpace(incomeOrder.BillNumber))
                {
                    p.Add("@BillNumber", incomeOrder.BillNumber);
                }
                else
                {
                    p.Add("@BillNumber", null);
                }

                p.Add("@TotalPrice", incomeOrder.GetTotalPrice);
                p.Add("@Date", incomeOrder.Date);
                p.Add("@StoreId", incomeOrder.Store.Id);
                p.Add("@StaffId", incomeOrder.Staff.Id);

                if (!string.IsNullOrWhiteSpace(incomeOrder.Details))
                {
                    p.Add("@Details", incomeOrder.Details);
                }
                else
                {
                    p.Add("@Details", null);
                }

                p.Add("@Id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
                connection.Execute("dbo.spIncomeOrder_CreateIncomeOrder", p, commandType: CommandType.StoredProcedure);
                incomeOrder.Id = p.Get<int>("@Id");
            }
            return incomeOrder;
        }


        /// <summary>
        /// -OLD- get all the The incomeOrders from the database
        /// - set the supplier
        ///     - set the personModel To the Supplier
        /// - set the store
        /// - set the staff
        ///     - set the personModel for the staff
        /// - set the list of products - incomeOrderProducts - 
        ///     - set the product foreach incomeOrderProduct
        /// </summary>
        /// <returns></returns>
        public static List<IncomeOrderModel> GetIncomeOrders(string db)
        {
            List<IncomeOrderModel> incomeOrders = new List<IncomeOrderModel>();

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnVal(db)))
            {
                incomeOrders = connection.Query<IncomeOrderModel>("dbo.spIncomeOrder_GetAll").ToList();

                // Is here couse store bugs skip it to the next foreach ->>> this is just to set the store model foreach incomeOrder !!
                List<StoreModel> stores = new List<StoreModel>();
                stores = connection.Query<StoreModel>("select * from Store").ToList();
                foreach (StoreModel s in stores)
                {
                    s.Name = connection.QuerySingle<string>("select Neme from Store where Id = " + s.Id + ";");
                }

                foreach (IncomeOrderModel incomeOrder in incomeOrders)
                {
                    var p = new DynamicParameters();
                    p.Add("@IncomeOrderId", incomeOrder.Id);

                    // Set the supplier , set the person model for the supplier

                    incomeOrder.Supplier = connection.QuerySingle<SupplierModel>("spIncomeOrder_GetSupplierByIncomeOrderId", p, commandType: CommandType.StoredProcedure);
                    var s = new DynamicParameters();
                    s.Add("@SupplierId", incomeOrder.Supplier.Id);
                    incomeOrder.Supplier.Person = connection.QuerySingle<PersonModel>("spSupplier_GetPersonBySupplierId", s, commandType: CommandType.StoredProcedure);

                    // set the store model for the IncomeOrder 
                    incomeOrder.Store = connection.QuerySingle<StoreModel>("spIncomeOrder_GetStoreIdByIncomeOrderId", p, commandType: CommandType.StoredProcedure);


                    foreach (StoreModel ss in stores)
                    {
                        if (ss.Id == incomeOrder.Store.Id)
                        {
                            incomeOrder.Store = ss;
                        }
                    }

                    // set the Staff model for the IncomeOrder ,   set the person model for this staff , Set the permission model for the staff 
                    // TODO - Do we need to set all stores for this staff member
                    incomeOrder.Staff = connection.QuerySingle<StaffModel>("spIncomeOrder_GetStaffByIncomeOrderId", p, commandType: CommandType.StoredProcedure);
                    var dd = new DynamicParameters();
                    dd.Add("@StaffId", incomeOrder.Staff.Id);
                    incomeOrder.Staff.Person = connection.QuerySingle<PersonModel>("spStaff_GetPersonByStaffId", dd, commandType: CommandType.StoredProcedure);
                    incomeOrder.Staff.Permission = connection.QuerySingle<PermissionModel>("spStaff_GetPermissionByStaffId", dd, commandType: CommandType.StoredProcedure);

                    // Set the products - IncomeOrderProduct - for the model
                    incomeOrder.IncomeOrderProducts = connection.Query<IncomeOrderProductModel>("dbo.spIncomeOrder_GetIncomeOrderProductByIncomeOrderId", p, commandType: CommandType.StoredProcedure).ToList();

                    foreach (IncomeOrderProductModel incomeOrderProduct in incomeOrder.IncomeOrderProducts)
                    {
                        var o = new DynamicParameters();
                        o.Add("@IncomeOrderProductId", incomeOrderProduct.Id);
                        incomeOrderProduct.Product = connection.QuerySingle<ProductModel>("spIncomeOrder_GetProductByIncomeOrderProductId", o, commandType: CommandType.StoredProcedure);
                    }

                }

            }

            return incomeOrders;
        }





    }
}
