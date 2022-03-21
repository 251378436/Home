using System;
using System.Collections.Generic;
using Home.Common.Models;

namespace Home.Common.Grains
{
    /// <summary>
    /// This interface contains methods of operating SalesOrder records
    /// </summary>
    public interface IFilesGrain : IGrain
    {
        /// <summary>
        /// Get single record of File by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Files Find(int id);

        /// <summary>
        /// Get all the list of Files records 
        /// </summary>
        /// <returns></returns>
        List<Files> FindAll();

        /// <summary>
        /// Insert the new File record
        /// </summary>
        /// <param name="t"></param>
        void Insert(Files t);

        /// <summary>
        /// Delete the File record
        /// </summary>
        /// <param name="id"></param>
        void Delete(int id);
    }
}
