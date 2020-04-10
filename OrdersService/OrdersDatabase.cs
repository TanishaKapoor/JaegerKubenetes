using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrdersService
{
    public static class OrdersDatabase
    {
        public static List<Order> orderDb = new List<Order>
        {
            new Order{orderId=1,customerId=1,orderAmount=230,orderDate="14-Apr-2020"},
            new Order{orderId=2,customerId=1,orderAmount=330,orderDate="15-Apr-2020"},
            new Order{orderId=3,customerId=2,orderAmount=430,orderDate="16-Apr-2020"},
            new Order{orderId=4,customerId=2,orderAmount=530,orderDate="17-Apr-2020"},
        };
    }
}
