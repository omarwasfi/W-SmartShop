using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public static class TransformAccess
    {
        /// <summary>
        /// Get all transforms from the database 
        /// Without Set the StoreModel , staffModel , ToStoreModel
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
        public static List<TransformModel>GetTrasformsFromTheDatabase(string db)
        {
            List<TransformModel> transforms = new List<TransformModel>();
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnVal(db)))
            {
                transforms = connection.Query<TransformModel>("spTransform_GetAll").ToList();
            }
            foreach(TransformModel transform in transforms)
            {
                transform.Staff = new StaffModel();
                transform.Store = new StoreModel();
                transform.ToStore = new StoreModel();
            }

            return transforms;
        }

        /// <summary>
        /// Match the staffs With Each Transform From the database
        /// </summary>
        /// <param name="transforms"></param>
        /// <param name="staffs"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public static List<TransformModel> SetTheStaffForEachTransformFromTheDatabase(List<TransformModel>transforms,List<StaffModel>staffs,string db)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnVal(db)))
            {
                foreach (TransformModel transformModel in transforms)
                {
                    var p = new DynamicParameters();
                    p.Add("@TransformId", transformModel.Id);

                    transformModel.Staff.Id = connection.QuerySingle<int>("spTransform_GetStaffIdByTransformId", p, commandType: CommandType.StoredProcedure);
                }
            }

            foreach(TransformModel transform in transforms) 
            {
                transform.Staff = staffs.Find(x => x.Id == transform.Staff.Id);
            }

                return transforms;
        }

        /// <summary>
        /// Match the stores With Each Transform.Store From the database
        /// </summary>
        /// <param name="transforms"></param>
        /// <param name="stores"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public static List<TransformModel> SetTheStoreForEachTransformFromTheDatabase(List<TransformModel> transforms, List<StoreModel>stores, string db)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnVal(db)))
            {
                foreach (TransformModel transformModel in transforms)
                {
                    var p = new DynamicParameters();
                    p.Add("@TransformId", transformModel.Id);

                    transformModel.Store.Id = connection.QuerySingle<int>("spTransform_GetStoreIdByTransformId", p, commandType: CommandType.StoredProcedure);
                }
            }

            foreach (TransformModel transform in transforms)
            {
                transform.Store = stores.Find(x => x.Id == transform.Store.Id);
            }

            return transforms;
        }

        /// <summary>
        /// Match the stores With Each Transform.ToStore From the database
        /// </summary>
        /// <param name="transforms"></param>
        /// <param name="stores"></param>
        /// <param name="db"></param>
        /// <returns></returns>
        public static List<TransformModel> SetTheToStoreForEachTransformFromTheDatabase(List<TransformModel> transforms, List<StoreModel> stores, string db)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnVal(db)))
            {
                foreach (TransformModel transformModel in transforms)
                {
                    var p = new DynamicParameters();
                    p.Add("@TransformId", transformModel.Id);

                    transformModel.ToStore.Id = connection.QuerySingle<int>("spTransform_GetToStoreIdByTransformId", p, commandType: CommandType.StoredProcedure);
                }
            }

            foreach (TransformModel transform in transforms)
            {
                transform.ToStore = stores.Find(x => x.Id == transform.Store.Id);
            }

            return transforms;
        }
    }
}
