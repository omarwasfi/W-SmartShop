﻿using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Library
{
    public static class OrderAccess
    {

        /// <summary>
        /// Gets Empty Order that have Id  ,
        /// The order should Have The main info of thist variables:
        /// CustomerId, DataTimeOfTheOrder, StoreId, StaffId
        /// </summary>
        /// <param name="order">order model</param>
        /// <param name="db"> Database Connection Name </param>
        public static OrderModel AddOrderToTheDatabase(OrderModel order, string db)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnVal(db)))
            {
                var p = new DynamicParameters();
                p.Add("@CustomerId", order.Customer.Id);
                p.Add("@DateTimeOfTheOrder", order.DateTimeOfTheOrder);
                p.Add("@StoreId", order.Store.Id);
                p.Add("@StaffId", order.Staff.Id);
                p.Add("@Details", order.Details);
                p.Add("@Id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
                connection.Execute("dbo.spOrders_CreateOrder", p, commandType: CommandType.StoredProcedure);
                order.Id = p.Get<int>("@Id");
            }
            return order;
        }

        /// <summary>
        /// Get all Orders From the database without the CustomerModel ,storemodel , staffmodel , List of the OrderProductModel
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        public static List<OrderModel> GetOrdersFromTheDatabase(string db)
        {
            List<OrderModel> orders = new List<OrderModel>();
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnVal(db)))
            {
                orders = connection.Query<OrderModel>("dbo.spOrders_GetAll").ToList();
            }

            foreach (OrderModel order in orders)
            {
                order.Customer = new CustomerModel();
                order.Store = new StoreModel();
                order.Staff = new StaffModel();
                order.OrderProducts = new List<OrderProductModel>();
                order.OrderPayments = new List<OrderPaymentModel>();
            }

            return orders;
        }

        /// <summary>
        /// match customermodels foreach order From the database
        /// </summary>
        /// <param name="orders"></param>
        /// <param name="customers"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public static List<OrderModel> SetTheCustomerForEachOrderFromTheDatabase(List<OrderModel> orders, List<CustomerModel> customers, string db)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnVal(db)))
            {
                foreach (OrderModel order in orders)
                {
                    var p = new DynamicParameters();
                    p.Add("@OrderId", order.Id);

                    order.Customer.Id = connection.QuerySingle<int>("spOrders_GetCustomerIdByOrderId", p, commandType: CommandType.StoredProcedure);
                }
            }

            foreach (OrderModel orderModel in orders)
            {
                orderModel.Customer = customers.Find(x => x.Id == orderModel.Customer.Id);
            }

            return orders;
        }
               
        /// <summary>
        /// match StoreModels foreach order From the database
        /// </summary>
        /// <param name="orders"></param>
        /// <param name="stores"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public static List<OrderModel> SetTheStoreForEachOrderFromTheDatabase(List<OrderModel> orders, List<StoreModel> stores, string db)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnVal(db)))
            {
                foreach (OrderModel order in orders)
                {
                    var p = new DynamicParameters();
                    p.Add("@OrderId", order.Id);

                    order.Store.Id = connection.QuerySingle<int>("spOrders_GetStoreIdByOrderId", p, commandType: CommandType.StoredProcedure);
                }
            }

            foreach (OrderModel orderModel in orders)
            {
                orderModel.Store = stores.Find(x => x.Id == orderModel.Store.Id);
            }

            return orders;
        }


        /// <summary>
        /// match StaffModels foreach order From the database
        /// </summary>
        /// <param name="orders"></param>
        /// <param name="staffs"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public static List<OrderModel> SetTheStaffForEachOrderFromTheDatabase(List<OrderModel> orders, List<StaffModel> staffs, string db)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnVal(db)))
            {
                foreach (OrderModel order in orders)
                {
                    var p = new DynamicParameters();
                    p.Add("@OrderId", order.Id);

                    order.Staff.Id = connection.QuerySingle<int>("spOrders_GetStaffIdByOrderId", p, commandType: CommandType.StoredProcedure);
                }
            }

            foreach (OrderModel orderModel in orders)
            {
                orderModel.Staff = staffs.Find(x => x.Id == orderModel.Staff.Id);
            }

            return orders;
        }


        /// <summary>
        /// match OrderProducts foreach order From the database
        /// </summary>
        /// <param name="orders"></param>
        /// <param name="staffs"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public static List<OrderModel> SetTheOrderProductsForEachOrderFromTheDatabase(List<OrderModel> orders, List<OrderProductModel>orderProducts, string db)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnVal(db)))
            {
                foreach (OrderModel order in orders)
                {

                    List<int> OrderProductsId = new List<int>();

                    var p = new DynamicParameters();
                    p.Add("@OrderId", order.Id);

                    OrderProductsId = connection.Query<int>("dbo.spOrders_GetOrderProductIdByOrderId", p, commandType: CommandType.StoredProcedure).ToList();

                    foreach(int id in OrderProductsId)
                    {
                        order.OrderProducts.Add(new OrderProductModel { Id = id });
                    }

                }
            }

            foreach (OrderModel orderModel in orders)
            {
                List<int> OrderProductsId = new List<int>();
                foreach(OrderProductModel orderProductModel in orderModel.OrderProducts)
                {
                    OrderProductsId.Add(orderProductModel.Id);
                }

                orderModel.OrderProducts = new List<OrderProductModel>();

                foreach(int id in OrderProductsId)
                {
                    orderModel.OrderProducts.Add(orderProducts.Find(x => x.Id == id));
                }

            }

            return orders;
        }

        /// <summary>
        /// Match the OrderPayments With Each Order From the database
        /// </summary>
        /// <param name="orders"></param>
        /// <param name="orderPayments"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public static List<OrderModel>SetTheOrderPaymentsForEachOrderFromTheDatabase(List<OrderModel>orders,List<OrderPaymentModel>orderPayments,string db)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnVal(db)))
            {
                foreach(OrderModel order in orders)
                {
                    List<int> OrderPaymentIds = new List<int>();

                    var p = new DynamicParameters();
                    p.Add("@OrderId", order.Id);
                    OrderPaymentIds = connection.Query<int>("dbo.spOrder_GetOrderPaymentIdByOrderId", p, commandType: CommandType.StoredProcedure).ToList();

                    foreach(int id in OrderPaymentIds)
                    {
                        order.OrderPayments.Add(new OrderPaymentModel { Id = id });
                    }
                }
            }

            foreach (OrderModel orderModel in orders)
            {
                List<int> OrderPaymentIds = new List<int>();
                foreach (OrderPaymentModel orderPayment in orderModel.OrderPayments)
                {
                    OrderPaymentIds.Add(orderPayment.Id);
                }

                orderModel.OrderPayments = new List<OrderPaymentModel>();

                foreach (int id in OrderPaymentIds)
                {
                    orderModel.OrderPayments.Add(orderPayments.Find(x => x.Id == id));
                }

            }

            return orders;
        }

        /// <summary>
        /// Delete Order from the database
        /// </summary>
        /// <param name="orderProduct"></param>
        /// <param name="db"></param>
        public static void RemoveOrder(OrderModel order, string db)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnVal(db)))
            {
                var p = new DynamicParameters();
                p.Add("@Id", order.Id);
                connection.Execute("dbo.spOrder_Delete", p, commandType: CommandType.StoredProcedure);
            }
        }

       

        /// <summary>
        /// update the order data , Total Price , details
        /// </summary>
        /// <param name="order"></param>
        /// <param name="db"></param>
        public static OrderModel UpdateOrderData(OrderModel order, string db)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnVal(db)))
            {
                var p = new DynamicParameters();
                p.Add("@Id", order.Id);
               
                p.Add("@Details", order.Details);
                connection.Execute("dbo.spOrder_Update", p, commandType: CommandType.StoredProcedure);
            }
            return order;
        }

        /// <summary>
        /// -OLD- get all the orders from the database ,
        /// - set the customerModel foreach order
        ///     - Set the PersonModel for the customer
        /// - set the storemodel foreach order,
        /// - set the staffModel foreach order,
        /// - set the list OrderProdcut for each order
        /// - set the prodcut foreach OrderProdcut
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        public static List<OrderModel> GetOrders(string db)
        {
            List<OrderModel> orders = new List<OrderModel>();
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnVal(db)))
            {
                orders = connection.Query<OrderModel>("dbo.spOrders_GetAll").ToList();

                // Is here couse store bugs skip it to the next foreach ->>> this is just to set the store model foreach order !!
                /*
                stores = connection.Query<StoreModel>("select * from Store").ToList();
                foreach (StoreModel s in stores)
                {
                    s.Name = connection.QuerySingle<string>("select Neme from Store where Id = " + s.Id + ";");
                }*/

                List<StoreModel> stores = new List<StoreModel>();
                stores = GlobalConfig.Connection.GetAllStores();

                foreach (OrderModel order in orders)
                {
                    var p = new DynamicParameters();
                    p.Add("@OrderId", order.Id);

                    // set the customer model for the order , set the personModel for this customer
                    order.Customer = connection.QuerySingle<CustomerModel>("spOrders_GetCustomerByOrderId", p, commandType: CommandType.StoredProcedure);
                    var c = new DynamicParameters();
                    c.Add("@CustomerId", order.Customer.Id);
                    order.Customer.Person = connection.QuerySingle<PersonModel>("spCustomer_GetPersonByCustomerId", c, commandType: CommandType.StoredProcedure);

                    // set the store model for the order
                    order.Store = connection.QuerySingle<StoreModel>("spOrders_GetStoreIdByOrderId", p, commandType: CommandType.StoredProcedure);

                    foreach (StoreModel s in stores)
                    {
                        if (s.Id == order.Store.Id)
                        {
                            order.Store = s;
                        }
                    }

                    // set the Staff model for the order ,   set the person model for this staff , Set the permission model for the staff
                    // TODO - Do we need to set all stores for this staff member
                    order.Staff = connection.QuerySingle<StaffModel>("spOrders_GetStaffByOrderId", p, commandType: CommandType.StoredProcedure);
                    var ss = new DynamicParameters();
                    ss.Add("@StaffId", order.Staff.Id);
                    order.Staff.Person = connection.QuerySingle<PersonModel>("spStaff_GetPersonByStaffId", ss, commandType: CommandType.StoredProcedure);
                    order.Staff.Permission = connection.QuerySingle<PermissionModel>("spStaff_GetPermissionByStaffId", ss, commandType: CommandType.StoredProcedure);

                    order.OrderProducts = connection.Query<OrderProductModel>("dbo.spOrders_GetOrderProductsByOrderId", p, commandType: CommandType.StoredProcedure).ToList();
                    foreach (OrderProductModel orderProduct in order.OrderProducts)
                    {
                        var o = new DynamicParameters();
                        o.Add("@OrderProductId", orderProduct.Id);
                        orderProduct.Product = connection.QuerySingle<ProductModel>("spOrders_GetProdcutByOrderProductId", o, commandType: CommandType.StoredProcedure);

                        // TODO - Thist Products Don't have brand Or Category
                    }
                }
            }
            return orders;
        }
    }
}