using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xero.Common.Models;

namespace Xero.Common.DAL
{
    /// <summary>
    /// this interface has Create, Update, Find, Delete methods
    /// </summary>
    public interface IDAL
    {
        /// <summary>
        /// Get the single record of record by id from Database
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        T Find<T>(Guid id) where T : BaseModel;

        /// <summary>
        /// Get all the list of records from Database
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        List<T> FindAll<T>() where T : BaseModel;

        /// <summary>
        /// Update the record in Database
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        void Update<T>(T t) where T : BaseModel;

        /// <summary>
        /// Insert the new record in Database
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        void Insert<T>(T t) where T : BaseModel;

        /// <summary>
        /// Delete the record by id from Database
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        void Delete<T>(Guid id) where T : BaseModel;
    }
}
