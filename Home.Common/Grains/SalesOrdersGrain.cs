using System;
using System.Collections.Generic;
using System.Linq;
using Xero.Common.DAL;
using Xero.Common.Models;

namespace Xero.Common.Grains
{
    public class SalesOrdersGrain : ISalesOrdersGrain
    {
        private List<SalesOrder> salesOrders;
        private IDAL dal;

        public SalesOrdersGrain(IDAL pDal)
        {
            this.dal = pDal;
            this.salesOrders = dal.FindAll<SalesOrder>();
        }

        public void Delete(Guid id)
        {
            this.dal.Delete<SalesOrder>(id);

            var salesOrder = this.salesOrders.FirstOrDefault(p => p.Id.Equals(id));
            if (salesOrder != null)
                this.salesOrders.Remove(salesOrder);
        }

        public SalesOrder Find(Guid id)
        {
            var salesOrder = this.salesOrders.FirstOrDefault(p => p.Id.Equals(id));

            return salesOrder;
        }

        public List<SalesOrder> FindAll()
        {
            return this.salesOrders;
        }

        public void Insert(SalesOrder t)
        {
            if (this.salesOrders.Exists(p => p.Id.Equals(t.Id)))
                throw new Exception("This sales order already exists");
            this.dal.Insert<SalesOrder>(t);

            this.salesOrders.Add(t);
        }

        public void Update(SalesOrder t)
        {
            this.dal.Update<SalesOrder>(t);

            var salesOrder = this.salesOrders.FirstOrDefault(p => p.Id.Equals(t.Id));
            if (salesOrder != null)
            {
                salesOrder.Description = t.Description;
                salesOrder.Customer = t.Customer;
                salesOrder.Amount = t.Amount;
                salesOrder.Discount = t.Discount;
            }
        }
    }
}