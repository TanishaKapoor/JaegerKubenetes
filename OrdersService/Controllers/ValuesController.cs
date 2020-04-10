using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace OrdersService.Controllers
{
    [Route("orders")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        List<Order> _orderDb = new List<Order>();
        public ValuesController()
        {
            _orderDb = OrdersDatabase.orderDb;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(_orderDb);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            var customerOrders = _orderDb.Where(c => c.customerId == id).Select(c=> new {c.orderId,c.orderAmount,c.orderDate }).ToList();
            return Ok(customerOrders);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
