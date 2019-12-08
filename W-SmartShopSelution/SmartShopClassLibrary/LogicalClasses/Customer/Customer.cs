using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public static class Customer
    {

        /// <summary>
        /// Get all the orders that the customer made with the organization
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        public static List<OrderModel> GetOrders(CustomerModel customer)
        {
            return PublicVariables.Orders.FindAll(x => x.Customer == customer);
        }

        // TODO - Need Some changes HERE (Change the way we get default customer)
        /// <summary>
        /// Get the default Customer With the default person
        /// </summary>
        /// <returns></returns>
        public static CustomerModel GetDefaultCustomer()
        {
            PersonModel person = new PersonModel { Id = 1000000, FirstName = "Default" };
            CustomerModel customer = new CustomerModel { Id = 5000000 , Person = person };

            return customer;
        }



       
    }
}
