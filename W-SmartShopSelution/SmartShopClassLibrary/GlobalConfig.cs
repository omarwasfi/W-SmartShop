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
    }
}
