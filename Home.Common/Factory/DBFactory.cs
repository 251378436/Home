using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Data.SqlClient;
using System.IO;
using System.Text;

namespace Xero.Common.Factory
{
    /// <summary>
    /// Using DBFactory to initialize the connection string of Database
    /// </summary>
    public class DBFactory
    {
        private static string ConnectionString = "";
        static DBFactory()
        {
            
            // Using Static constructor can make sure this is only running once
            var connstr = ConfigurationPath.GetSectionKey("DBConnection");
            var dbDirectory = Directory.GetCurrentDirectory();
      
            ConnectionString = connstr.Replace("{DataDirectory}", dbDirectory);
        }

        /// <summary>
        /// Create a new Database SQL Connection
        /// </summary>
        /// <returns></returns>
        public static SqlConnection NewConnection()
        {
            return new SqlConnection(ConnectionString);
        }
    }
}
