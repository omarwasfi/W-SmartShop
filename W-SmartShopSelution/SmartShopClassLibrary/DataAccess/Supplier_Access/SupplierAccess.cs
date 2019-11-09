using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public static class SupplierAccess
    {
        /// <summary>
        /// Get all suppliers from the database - without setting the person model -
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        public static List<SupplierModel> GetSuppliersFromTheDatabase(string db)
        {
            List<SupplierModel> suppliers;

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnVal(db)))
            {
                suppliers = connection.Query<SupplierModel>("dbo.spSupplier_GetAll").ToList();

            }

            foreach (SupplierModel supplier in suppliers)
            {
                supplier.Person = new PersonModel();
            }

            return suppliers;
        }

        /// <summary>
        ///  /// Sets The Person Model for each supplier in the list
        ///   -Open the connection
        ///   -set the id of the person foreach supplier
        ///   -Close the connection
        ///   -match the IDs to the publicVariables.People AND set the person model for each supplierModel
        /// </summary>
        /// <param name="suppliers"></param>
        /// <param name="people"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public static List<SupplierModel>SetThePersonModelForEachSupplierFromTheDatabase(List<SupplierModel>suppliers , List<PersonModel>people, string db)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnVal(db)))
            {
                foreach(SupplierModel supplier in suppliers)
                {
                    var p = new DynamicParameters();
                    p.Add("@SupplierId", supplier.Id);
                    supplier.Person.Id = connection.QuerySingle<int>("spSupplier_GetPersonIdBySupplierId", p, commandType: CommandType.StoredProcedure);
                }
            }

            foreach(SupplierModel supplierModel in suppliers)
            {
                supplierModel.Person = people.Find(x => x.Id == supplierModel.Person.Id);
            }

            return suppliers;
        }

        /// <summary>
        /// -OLD- Get the all the suppliers in the database And set the personModel for each one
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        public static List<SupplierModel> GetSuppliers(string db)
        {

            List<SupplierModel> suppliers;
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnVal(db)))
            {
                suppliers = connection.Query<SupplierModel>("dbo.spSupplier_GetAll").ToList();
                foreach (SupplierModel supplier in suppliers)
                {
                    var p = new DynamicParameters();
                    p.Add("@SupplierId", supplier.Id);
                    supplier.Person = connection.QuerySingle<PersonModel>("spSupplier_GetPersonBySupplierId", p, commandType: CommandType.StoredProcedure);
                }
            }

            return suppliers;


        }


        /// <summary>
        /// Add a new supplier to the database
        /// </summary>
        /// <param name="supplier"></param>
        /// <param name="db"></param>
        public static void CreateSupplier(SupplierModel supplier, string db)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnVal(db)))
            {
                var p = new DynamicParameters();
                p.Add("@PersonId", supplier.Person.Id);
                p.Add("@Company", supplier.Company);

                p.Add("@Id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
                connection.Execute("dbo.spSupplier_Create", p, commandType: CommandType.StoredProcedure);
                supplier.Id = p.Get<int>("@Id");

            }
        }

    }
}
