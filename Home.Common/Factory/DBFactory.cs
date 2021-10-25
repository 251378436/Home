using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.IO;

namespace Home.Common.Factory
{
    /// <summary>
    /// Using DBFactory to initialize the connection string of Database
    /// </summary>
    public class DBFactory
    {
        private string connectionString = "";

        public DBFactory()
        {
        }

        public DBFactory(IConfiguration configuration)
        {
            var connstr = configuration.GetSection("DBConnection").Value;
            var dbDirectory = $"{Directory.GetCurrentDirectory()}\\App_Data";

            this.connectionString = connstr.Replace("{DataDirectory}", dbDirectory);
        }

        /// <summary>
        /// Create a new Database SQL Connection
        /// </summary>
        /// <returns></returns>
        public SqlConnection NewConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}