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
        /// Get all customers and set the person model for each one
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        public static List<CustomerModel> GetCustomers(string db)
        {

            List<CustomerModel> customers;
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnVal(db)))
            {
                customers = connection.Query<CustomerModel>("dbo.spCustomer_GetAll").ToList();
                foreach (CustomerModel customer in customers)
                {
                    var p = new DynamicParameters();
                    p.Add("@CustomerId", customer.Id);
                    customer.Person = connection.QuerySingle<PersonModel>("spCategory_GetPersonByCategoryId", p, commandType: CommandType.StoredProcedure);
                }
            }
            return customers;


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
