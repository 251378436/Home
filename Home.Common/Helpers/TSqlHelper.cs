using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xero.Common.Attributes;
using Xero.Common.Models;

namespace Xero.Common.Helpers
{
    /// <summary>
    /// This static can generate Find, FindAll, Update, Insert, Delete Sql query
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class TSqlHelper<T> where T : BaseModel
    {
        static TSqlHelper()
        {
            Type type = typeof(T);
            var properties = type.GetDBProperties();
            string columnString = string.Join(",", properties.Select(p => $"[{p.Name}]"));

            // Create Find Sql
            FindSql = $"SELECT {columnString} FROM [{type.Name}] where Id =";

            // Create Find All Sql
            FindAllSql = $"SELECT {columnString} FROM [{type.Name}];";

            // Create Update Sql
            var propertiesWithoutId = properties.Where(p => !p.Name.Equals("Id"));
            string parameterStringWithoutId = string.Join(",", propertiesWithoutId.Select(p => $"[{p.Name}]=@{p.Name}"));
            UpdateSql = $"UPDATE [{type.Name}] SET {parameterStringWithoutId} where Id=";

            // Create Insert Sql
            string parameterString = string.Join(",", properties.Select(p => $"@{p.Name}"));
            InsertSql = $"INSERT INTO [{type.Name}] ({columnString}) VALUES ({parameterString});";

            // Create Delete Sql
            DeleteSql = $"DELETE FROM [{type.Name}] where Id =";
        }

        public static string FindSql = null;
        public static string FindAllSql = null;
        public static string UpdateSql = null;
        public static string InsertSql = null;
        public static string DeleteSql = null;
    }
}
