using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public static class Supplier
    {
        /// <summary>
        /// Get the all the suppliers in the database And set the personModel for each one
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        public static List<SupplierModel> GetSuppliers(string db)
        {

            List<SupplierModel> suppliers;
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnVal(db)))
            {
                suppliers = connection.Query<SupplierModel>("dbo.spSupplier_GetAll").ToList();
                foreach ( SupplierModel supplier in suppliers)
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
        public static void CreateSupplier(SupplierModel supplier , string db)
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
