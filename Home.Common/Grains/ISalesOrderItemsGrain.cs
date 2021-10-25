using System;
using System.Collections.Generic;
using Xero.Common.Models;

namespace Xero.Common.Grains
{
    /// <summary>
    /// This interface contains methods of operating SalesOrderItem records
    /// </summary>
    public interface ISalesOrderItemsGrain : IGrain
    {
        /// <summary>
        /// Get single record of SalesOrderItem by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        SalesOrderItem Find(Guid id);

        /// <summary>
        /// Get all the list of SalesOrderItem records 
        /// </summary>
        /// <returns></returns>
        List<SalesOrderItem> FindAll();

        /// <summary>
        /// Update the SalesOrderItem
        /// </summary>
        /// <param name="t"></param>
        void Update(SalesOrderItem t);

        /// <summary>
        /// Insert the new SalesOrderItem record
        /// </summary>
        /// <param name="t"></param>
        void Insert(SalesOrderItem t);

        /// <summary>
        /// Delete the SalesOrderItem record
        /// </summary>
        /// <param name="id"></param>
        void Delete(Guid id);
    }
}
