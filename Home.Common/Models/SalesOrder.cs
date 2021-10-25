using System.Collections.Generic;
using Xero.Common.Attributes;

namespace Xero.Common.Models
{
    public class SalesOrder : BaseModel
    {
        [DBField]
        public string Customer { get; set; }

        [DBField]
        public decimal Amount { get; set; }

        [DBField]
        public decimal Discount { get; set; }

        public List<SalesOrderItem> SalesOrderDetails { get; set; }
    }
}