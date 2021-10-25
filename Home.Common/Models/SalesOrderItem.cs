using Xero.Common.Attributes;

namespace Xero.Common.Models
{
    public class SalesOrderItem : BaseModel
    {
        [DBField]
        public string Item { get; set; }

        [DBField]
        public int Quantity { get; set; }

        [DBField]
        public decimal Price { get; set; }

        [DBField]
        public decimal Discount { get; set; }

        [DBField]
        public int SalesOrderID { get; set; }
    }
}
