using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public static class CustomerAccess
    {
        /// <summary>
        /// Get all Customers From the database - Without setting the person model -
        /// </summary>
        /// <returns></returns>
        public static List<CustomerModel> GetCustomersFromTheDatabae(string db)
        {
            List<CustomerModel> customers = new List<CustomerModel>();
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnVal(db)))
            {
                customers = connection.Query<CustomerModel>("dbo.spCustomer_GetAll").ToList();
            }

            foreach(CustomerModel customer in customers)
            {
                customer.Person = new PersonModel();
            }
            return customers;
        }

        /// <summary>
        /// Create Customer in the database and get Customer model with the new Id
        /// </summary>
        /// <returns></returns>
        public static CustomerModel AddCustomerToTheDatabase(CustomerModel customer, string db)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnVal(db)))
            {

                var p = new DynamicParameters();
                p.Add("@PersonId", customer.Person.Id);

                p.Add("@Id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
                connection.Execute("dbo.spCustomer_Create", p, commandType: CommandType.StoredProcedure);
                customer.Id = p.Get<int>("@Id");
            }
            return customer;
        }

        /// <summary>
        /// Sets The Person Model for each customer in the list
        ///   -Open the connection
        ///   -set the id of the person foreach customer
        ///   -Close the connection
        ///   -match the IDs to the publicVariables.People AND set the person model for each CustomerModel
        /// <param name="customers"></param>
        /// <param name="people"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public static List<CustomerModel> SetThePersonModelForEachCustomerFromTheDatabase(List<CustomerModel>customers,List<PersonModel>people , string db)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnVal(db)))
            {
                foreach (CustomerModel customer in customers)
                {
                    var p = new DynamicParameters();
                    p.Add("@CustomerId", customer.Id);
                    customer.Person.Id = connection.QuerySingle<int>("spCustomer_GetPersonIdByCustomerId", p, commandType: CommandType.StoredProcedure);
                }
            }

            foreach(CustomerModel customerModel in customers)
            {
                customerModel.Person = people.Find(x => x.Id == customerModel.Person.Id);
            }

            return customers;
        }

        /// <summary>
        /// -OLD- Get all customers and set the person model for each one
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
                    customer.Person = connection.QuerySingle<PersonModel>("spCustomer_GetPersonByCustomerId", p, commandType: CommandType.StoredProcedure);
                }
            }
            return customers;


        }

        

        /// <summary>
        /// Create Customer in the database and no return value Use CreateCustomer To get the new customerModel
        /// </summary>
        public static void CreateCustomer_NoReturn(CustomerModel customer, string db)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnVal(db)))
            {

                var p = new DynamicParameters();
                p.Add("@PersonId", customer.Person.Id);

                p.Add("@Id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
                connection.Execute("dbo.spCustomer_Create", p, commandType: CommandType.StoredProcedure);
                customer.Id = p.Get<int>("@Id");
            }
        }


    }
}
