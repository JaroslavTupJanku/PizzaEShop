using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaEShop.Models
{
    public class OrdersManager
    {
        private Order order;
        public IList<Order> ActualOrders { get; private set; } = new List<Order>();

        public OrdersManager()
        {

        }

        public void AddOrder(Order order) => ActualOrders.Add(order);
        public void RemoveOrder(Order order) => ActualOrders.Remove(order);




    }
}
