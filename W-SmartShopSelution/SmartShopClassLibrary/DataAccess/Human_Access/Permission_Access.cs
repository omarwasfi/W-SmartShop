using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public static class Permission_Access
    {
        /// <summary>
        /// Gets all the Permissions From the database
        /// </summary>
        /// <returns></returns>
       public static List<PermissionModel> GetAllPermissionsFromTheDatabase(string db)
        {
            List<PermissionModel> permissions = new List<PermissionModel>();

            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnVal(db)))
            {

                permissions = connection.Query<PermissionModel>("spPermission_GetAll").ToList();

            }

                return permissions;
        }
    }
}
