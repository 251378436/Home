using System.Collections.Generic;
using Home.Common.Attributes;

namespace Home.Common.Models
{
    public class SalesOrder : BaseModel
    {
        [DBField]
        public string Customer { get; set; }

        [DBField]
        public decimal Amount { get; set; }

        [DBField]
        public decimal Discount { get; set; }

        public List<SalesOrderItem> SalesOrderItems { get; set; }

        public SalesOrder() : base()
        {
            this.SalesOrderItems = new List<SalesOrderItem>();
        }
    }
}