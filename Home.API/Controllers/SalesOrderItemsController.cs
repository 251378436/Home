using Home.Common.Grains;
using Home.Common.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Home.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SalesOrderItemsController : ControllerBase
    {
        private readonly ILogger<SalesOrderItemsController> _logger;
        private ISalesOrderItemsGrain salesOrderItemsGrain;

        public SalesOrderItemsController(ILogger<SalesOrderItemsController> logger, ISalesOrderItemsGrain salesOrderItemsGrain)
        {
            _logger = logger;
            this.salesOrderItemsGrain = salesOrderItemsGrain;
        }

        [HttpGet("{SalesOrderId}/Items")]
        public ActionResult<IEnumerable<SalesOrderItem>> GetBySalesOrderId(int SalesOrderId)
        {
            var salesOrderItems = salesOrderItemsGrain.FindAll().Where(s => s.SalesOrderID.Equals(SalesOrderId)).ToList();
            return salesOrderItems;
        }

        [HttpGet("{salesOrderItemId}")]
        public ActionResult<SalesOrderItem> GetSalesOrderItem(int salesOrderItemId)
        {
            var salesOrderItem = this.salesOrderItemsGrain.Find(salesOrderItemId);

            if (salesOrderItem == null)
                return NotFound();

            return salesOrderItem;
        }

        [HttpPut]
        public ActionResult Update(int id, [FromBody]SalesOrderItem salesOrderItem)
        {
            salesOrderItem.Id = id;
            this.salesOrderItemsGrain.Update(salesOrderItem);

            return Ok();
        }

        [HttpPost]
        public ActionResult Create([FromBody] SalesOrderItem salesOrderItem)
        {
            this.salesOrderItemsGrain.Insert(salesOrderItem);

            return Ok();
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            this.salesOrderItemsGrain.Delete(id);

            return Ok();
        }
    }
}
