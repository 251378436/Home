using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xero.Common.Factory;
using Xero.Common.Helpers;
using Xero.Common.Models;

namespace Xero.Common.DAL
{
    /// <summary>
    /// This class is implementation of Interface IDAL
    /// </summary>
    public class DAL : IDAL
    {
        public DAL()
        {
        }

        public T Find<T>(Guid id) where T : BaseModel
        {
            using (var conn = DBFactory.NewConnection())
            {
                conn.Open();
                var sql = $"{TSqlHelper<T>.FindSql}'{id}'";
                var cmd = new SqlCommand(sql, conn);

                var reader = cmd.ExecuteReader();
                var list = this.ReaderToList<T>(reader);
                var result = list.FirstOrDefault();

                return result;
            }
        }

        public List<T> FindAll<T>() where T : BaseModel
        {
            using (var conn = DBFactory.NewConnection())
            {
                conn.Open();
                var sql = TSqlHelper<T>.FindAllSql;
                var cmd = new SqlCommand(sql, conn);

                var reader = cmd.ExecuteReader();
                var result = this.ReaderToList<T>(reader);

                return result;
            }
        }

        public void Insert<T>(T t) where T : BaseModel
        {
            Type type = typeof(T);
            var propArray = type.GetDBProperties();
            var parameters = propArray.Select(p => new SqlParameter($"@{p.Name}", p.GetValue(t) ?? DBNull.Value)).ToArray();

            using (var conn = DBFactory.NewConnection())
            {
                conn.Open();
                var sql = TSqlHelper<T>.InsertSql;
                var cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddRange(parameters);
                int iResult = cmd.ExecuteNonQuery();

                if (iResult <= 0)
                    throw new Exception("Error inserting data into Database!");
            }
        }

        public void Update<T>(T t) where T : BaseModel
        {
            Type type = typeof(T);
            var propArray = type.GetDBProperties().Where(p => !p.Name.Equals("Id"));
            var parameters = propArray.Select(p => new SqlParameter($"@{p.Name}", p.GetValue(t) ?? DBNull.Value)).ToArray();

            using (var conn = DBFactory.NewConnection())
            {
                conn.Open();
                var sql = $"{TSqlHelper<T>.UpdateSql}'{t.Id}'";
                var cmd = new SqlCommand(sql, conn);

                cmd.Parameters.AddRange(parameters);
                int iResult = cmd.ExecuteNonQuery();

                if (iResult <= 0)
                    throw new Exception("Update the data does not exist");
            }
        }

        public void Delete<T>(Guid id) where T : BaseModel
        {
            using (var conn = DBFactory.NewConnection())
            {
                conn.Open();
                var sql = $"{TSqlHelper<T>.DeleteSql}'{id}'";
                var cmd = new SqlCommand(sql, conn);

                int iResult = cmd.ExecuteNonQuery();

                if (iResult <= 0)
                    throw new Exception("Update the data does not exist");
            }
        }

        private List<T> ReaderToList<T>(SqlDataReader reader) where T : BaseModel
        {
            Type type = typeof(T);
            List<T> list = new List<T>();
            while (reader.Read())
            {
                T t = (T)Activator.CreateInstance(type);
                foreach (var prop in type.GetDBProperties())
                {
                    object oValue = reader[prop.Name];
                    if (oValue is DBNull)
                        oValue = null;
                    prop.SetValue(t, oValue);
                }
                list.Add(t);
            }
            return list;
        }
    }
}
