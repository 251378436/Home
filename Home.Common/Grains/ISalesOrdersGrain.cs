using System;
using System.Collections.Generic;
using Home.Common.Models;

namespace Home.Common.Grains
{
    /// <summary>
    /// This interface contains methods of operating SalesOrder records
    /// </summary>
    public interface ISalesOrdersGrain : IGrain
    {
        /// <summary>
        /// Get single record of SalesOrder by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        SalesOrder Find(int id);

        /// <summary>
        /// Get all the list of SalesOrder records 
        /// </summary>
        /// <returns></returns>
        List<SalesOrder> FindAll();

        /// <summary>
        /// Update the SalesOrder
        /// </summary>
        /// <param name="t"></param>
        void Update(SalesOrder t);

        /// <summary>
        /// Insert the new SalesOrder record
        /// </summary>
        /// <param name="t"></param>
        void Insert(SalesOrder t);

        /// <summary>
        /// Delete the SalesOrder record
        /// </summary>
        /// <param name="id"></param>
        void Delete(int id);
    }
}
