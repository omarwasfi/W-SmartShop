using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public static class DeTransformAccess
    {

        /// <summary>
        /// Add detransform to the database
        /// </summary>
        /// <param name="deTransform"></param>
        /// <param name="db"></param>
        /// <returns>Retunr DeTransform With the new Id</returns>
        public static DeTransformModel AddDeTransformToTheDatabase(DeTransformModel deTransform, string db)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnVal(db)))
            {
                var p = new DynamicParameters();
                p.Add("@StaffId", deTransform.Staff.Id);
                p.Add("@StoreId", deTransform.Store.Id);
                p.Add("@Date", deTransform.Date);
                p.Add("@TotalMoney", deTransform.TotalMoney);
                p.Add("@FromStoreId", deTransform.FromStore.Id);
                p.Add("@Id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);
                connection.Execute("dbo.spDeTransform_Create", p, commandType: CommandType.StoredProcedure);
                deTransform.Id = p.Get<int>("@Id");
            }
            return deTransform;
        }

        /// <summary>
        /// Get all DeTransforms From the database
        /// without Setting the staffModel or the storeModel Or the fromStoreModel
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        public static List<DeTransformModel> GetDeTrasformsFromTheDatabase(string db)
        {
            List<DeTransformModel> deTransforms = new List<DeTransformModel>();
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnVal(db)))
            {
                deTransforms = connection.Query<DeTransformModel>("spDeTransform_GetAll").ToList();
            }
            foreach (DeTransformModel deTransform in deTransforms)
            {
                deTransform.Staff = new StaffModel();
                deTransform.Store = new StoreModel();
                deTransform.FromStore = new StoreModel();
            }

            return deTransforms;
        }

        /// <summary>
        /// Match The staffs with the DeTransforms From The database
        /// </summary>
        /// <param name="deTransforms"></param>
        /// <param name="staffs"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public static List<DeTransformModel> SetTheStaffForEachDeTransformFromTheDatabase(List<DeTransformModel> deTransforms, List<StaffModel> staffs, string db)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnVal(db)))
            {
                foreach (DeTransformModel deTransformModel in deTransforms)
                {
                    var p = new DynamicParameters();
                    p.Add("@DeTransformId", deTransformModel.Id);

                    deTransformModel.Staff.Id = connection.QuerySingle<int>("spDeTransform_GetStaffIdByDeTransformId", p, commandType: CommandType.StoredProcedure);
                }
            }

            foreach (DeTransformModel deTransform in deTransforms)
            {
                deTransform.Staff = staffs.Find(x => x.Id == deTransform.Staff.Id);
            }

            return deTransforms;
        }

        /// <summary>
        /// Match The stores with the DeTransforms.Store From The database
        /// </summary>
        /// <param name="DeTransforms"></param>
        /// <param name="stores"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public static List<DeTransformModel> SetTheStoreForEachDeTransformFromTheDatabase(List<DeTransformModel> DeTransforms, List<StoreModel> stores, string db)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnVal(db)))
            {
                foreach (DeTransformModel deTransformModel in DeTransforms)
                {
                    var p = new DynamicParameters();
                    p.Add("@DeTransformId", deTransformModel.Id);

                    deTransformModel.Store.Id = connection.QuerySingle<int>("spDeTransform_GetStoreIdByDeTransformId", p, commandType: CommandType.StoredProcedure);
                }
            }

            foreach (DeTransformModel deTransform in DeTransforms)
            {
                deTransform.Store = stores.Find(x => x.Id == deTransform.Store.Id);
            }

            return DeTransforms;
        }

        /// <summary>
        /// Match The stores with the DeTransforms.FromStore From The database
        /// </summary>
        /// <param name="deTransforms"></param>
        /// <param name="stores"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public static List<DeTransformModel> SetTheFromStoreForEachDeTransformFromTheDatabase(List<DeTransformModel> deTransforms, List<StoreModel> stores, string db)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnVal(db)))
            {
                foreach (DeTransformModel deTransformModel in deTransforms)
                {
                    var p = new DynamicParameters();
                    p.Add("@DeTransformId", deTransformModel.Id);

                    deTransformModel.FromStore.Id = connection.QuerySingle<int>("spDeTransform_GetFromStoreIdByDeTransformId", p, commandType: CommandType.StoredProcedure);
                }
            }

            foreach (DeTransformModel deTransform in deTransforms)
            {
                deTransform.FromStore = stores.Find(x => x.Id == deTransform.FromStore.Id);
            }

            return deTransforms;
        }

    }
}
