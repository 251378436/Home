using Home.API.Filters;
using Home.Common.Grains;
using Home.Common.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Home.API.Controllers
{
    [ServiceFilter(typeof(ControllerActionFilter))]
    [ApiController]
    [Route("[controller]")]
    public class SalesOrdersController : ControllerBase
    {
        private readonly ILogger<SalesOrdersController> _logger;
        private ISalesOrdersGrain salesOrdersGrain;

        public SalesOrdersController(ILogger<SalesOrdersController> logger, ISalesOrdersGrain salesOrdersGrain)
        {
            _logger = logger;
            this.salesOrdersGrain = salesOrdersGrain;
        }

        [ServiceFilter(typeof(ActionActionFilter))]
        [HttpGet]
        [Authorize]
        public ActionResult<IEnumerable<SalesOrder>> GetAll()
        {
            var salesOrders = salesOrdersGrain.FindAll();
            return salesOrders;
        }

        [HttpGet("{salesOrderId}")]
        [Authorize("read:messages")]
        public ActionResult<SalesOrder> GetSalesOrder(int salesOrderId)
        {
            var salesOrder = this.salesOrdersGrain.Find(salesOrderId);

            if (salesOrder == null)
                return NotFound();

            return salesOrder;
        }

        [HttpGet("GetByCustomerName")]
        public ActionResult<IEnumerable<SalesOrder>> GetByCustomerName([FromQuery] string customerName)
        {
            if (string.IsNullOrWhiteSpace(customerName))
                return null;

            var salesOrders = this.salesOrdersGrain.FindAll().Where(s => s.Customer.ToLower().Contains(customerName.ToLower())).ToList();
            return salesOrders;
        }

        [HttpPut]
        public ActionResult Update(int id, [FromBody]SalesOrder salesOrder)
        {
            salesOrder.Id = id;
            this.salesOrdersGrain.Update(salesOrder);

            return Ok();
        }

        [HttpPost]
        public ActionResult Create([FromBody] SalesOrder salesOrder)
        {
            this.salesOrdersGrain.Insert(salesOrder);

            return Ok();
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            this.salesOrdersGrain.Delete(id);

            return Ok();
        }
    }
}
