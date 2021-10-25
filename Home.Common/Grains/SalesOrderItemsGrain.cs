using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Home.Common.DAL;
using Home.Common.Models;

namespace Home.Common.Grains
{
    public class SalesOrderItemsGrain : ISalesOrderItemsGrain
    {
        private List<SalesOrderItem> salesOrderDetails;
        private IDAL dal;

        public SalesOrderItemsGrain(IDAL pDal)
        {
            this.dal = pDal;
            this.salesOrderDetails = dal.FindAll<SalesOrderItem>();
        }

        public void Delete(int id)
        {
            this.dal.Delete<SalesOrderItem>(id);

            var salesOrderDetail = this.salesOrderDetails.FirstOrDefault(p => p.Id.Equals(id));
            if (salesOrderDetail != null)
                this.salesOrderDetails.Remove(salesOrderDetail);
        }

        public SalesOrderItem Find(int id)
        {
            var salesOrderDetail = this.salesOrderDetails.FirstOrDefault(p => p.Id.Equals(id));

            return salesOrderDetail;
        }

        public List<SalesOrderItem> FindAll()
        {
            return this.salesOrderDetails;
        }

        public void Insert(SalesOrderItem t)
        {
            if (this.salesOrderDetails.Exists(p => p.Id.Equals(t.Id)))
                throw new Exception("This sales order item already exists");
            int newId = this.dal.Insert<SalesOrderItem>(t);
            t.Id = newId;
            this.salesOrderDetails.Add(t);
        }

        public void Update(SalesOrderItem t)
        {
            this.dal.Update <SalesOrderItem>(t);

            var productOption = this.salesOrderDetails.FirstOrDefault(p => p.Id.Equals(t.Id));
            if (productOption != null)
            {
                productOption.Description = t.Description;
                productOption.Item = t.Item;
                productOption.Quantity = t.Quantity;
                productOption.Price = t.Price;
                productOption.Discount = t.Discount;
                productOption.SalesOrderID = t.SalesOrderID;
            }
        }
    }
}
