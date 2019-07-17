using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Library
{
    public static class GlobalConfig
    {
        public static DataAccess Connection { get; private set; }

        public static void InitializeConnection()
        {
            DataAccess sql = new DataAccess();
            Connection = sql;
        }
        public static string CnnVal(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }

        /// <summary>
        /// Called At the Login Screen to Make sure that the store is in the database
        /// if in the database return store model
        /// if not return storemodel with Id = -1
        /// </summary>
        /// <returns> store model </returns>
        public static StoreModel GetTheStoreFromTheDatabase()
        {
            
            return Connection.CheckByEnumIsThisStoreExist(StoreName.Ma3adiStore);
                    
            

        }

    }
}
