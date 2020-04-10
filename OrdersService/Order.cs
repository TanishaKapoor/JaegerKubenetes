using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrdersService
{
    public class Order
    {
        public int orderId { get; set; }
        public int customerId { get; set; }
        public int orderAmount { get; set; }
        public string orderDate { get; set; }
    }
}
