using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Library
{
    public static class Order
    {

        /// <summary>
        /// Gets Empty Order that have Id  , 
        /// The order should Have The main info of thist variables:
        /// CustomerId, DataTimeOfTheOrder, StoreId, StaffId,TotalPrice
        /// </summary>
        /// <param name="order">order model</param>
        /// <param name="db"> Database Connection Name </param>
        public static OrderModel GetEmptyOrderFromTheDatabase(OrderModel order, string db)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnVal(db)))
            {

                var p = new DynamicParameters();
                p.Add("@CustomerId", order.Customer.Id);
                p.Add("@DateTimeOfTheOrder", order.DateTimeOfTheOrder);
                p.Add("@StoreId", order.Store.Id);
                p.Add("@StaffId", order.Staff.Id);
                p.Add("@TotalPrice", order.TotalPrice);
                p.Add("@Details", order.Details);
                p.Add("@Id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
                connection.Execute("dbo.spOrders_CreateOrder", p, commandType: CommandType.StoredProcedure);
                order.Id = p.Get<int>("@Id");
            }
            return order;
                
            
        }


        /// <summary>
        /// get all the orders from the database , 
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
                        if(s.Id == order.Store.Id)
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
                    


                    order.Products = connection.Query<OrderProductModel>("dbo.spOrders_GetOrderProductsByOrderId", p, commandType: CommandType.StoredProcedure).ToList();
                    foreach(OrderProductModel orderProduct in order.Products)
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

        /// <summary>
        /// Filter list of orders by Customer
        /// </summary>
        /// <param name="orders"></param>
        /// <param name="customer"></param>
        /// <returns></returns>
        public static List<OrderModel> FilterOrdersByCustomer(List<OrderModel> orders , CustomerModel customer )
        {
            List<OrderModel> FOrders = new List<OrderModel>();

            foreach(OrderModel order in orders)
            {
                if (order.Customer.Id == customer.Id)
                {
                    FOrders.Add(order);
                }
            }

            return FOrders;

        }

        /// <summary>
        /// Filter orders by order id
        /// </summary>
        /// <param name="orders"></param>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public static List<OrderModel>FilterOrdersByOrderId(List<OrderModel> orders , string orderId)
        {
            List<OrderModel> fOrders = new List<OrderModel>();
            foreach(OrderModel order in orders)
            {
                if(Regex.IsMatch(order.Id.ToString(), Regex.Escape(orderId), RegexOptions.IgnoreCase))
                {
                    fOrders.Add(order);
                }
            }

            return fOrders;

        }


        /// <summary>
        /// Filter orders by Customer name
        /// </summary>
        /// <param name="orders"></param>
        /// <param name="customerName"></param>
        /// <returns></returns>
        public static List<OrderModel> FilterOrdersByCustomerName(List<OrderModel> orders, string customerName)
        {
            List<OrderModel> fOrders = new List<OrderModel>();
            foreach (OrderModel order in orders)
            {
                if (Regex.IsMatch(order.Customer.Person.FullName, Regex.Escape(customerName), RegexOptions.IgnoreCase))
                {
                    fOrders.Add(order);
                }
            }

            return fOrders;

        }


        /// <summary>
        /// Filter orders by Date
        /// </summary>
        /// <param name="orders"></param>
        /// <param name="date"></param>
        /// <returns></returns>
        public static List<OrderModel> FilterOrdersByDate(List<OrderModel> orders, DateTime date)
        {
            List<OrderModel> fOrders = new List<OrderModel>();
            foreach (OrderModel order in orders)
            {

                if(order.DateTimeOfTheOrder.Year == date.Year && order.DateTimeOfTheOrder.Month == date.Month && order.DateTimeOfTheOrder.Day == date.Day)
                {
                    fOrders.Add(order);
                }

            }

            return fOrders;

        }

    }
}
