using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Library
{
    public static class GlobalConfig
    {
        public static DataAccess Connection { get; private set; }


        public static NumberValidation NumberValidation { get; set; } = new NumberValidation();
        public static ProductValidator ProductValidator { get; set; }

        public static void InitializeConnection()
        {
            DataAccess sql = new DataAccess();
            Connection = sql;
        }

        /// <summary>
        /// The Connection streing
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string CnnVal(string name)
        {
           

            return ConfigurationManager.ConnectionStrings[name].ConnectionString;

            //string path = Path.GetFullPath(Environment.CurrentDirectory);
            // string databaseName = "SmartShopDatabase.mdf";

            //return @" data source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + path + @"\" + databaseName + ";Integrated Security=True";
            //return @" data source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\SSData"+@"\" + databaseName + ";Integrated Security=True";


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
