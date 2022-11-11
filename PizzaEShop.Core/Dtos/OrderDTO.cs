using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PizzaEShop.Core.Model
{
    public class OrderDTO
    {
        public DateTime Time { get; }
        public string Address { get; } = string.Empty;
        public IList<PizzaDTO> Pizzas { get; set; } = null!;

        public OrderDTO(DateTime time, string address)
        {
            Time = time;
            Address = address;
        }

        public void AddPizza(PizzaDTO pizza)
        {
            Pizzas.Add(pizza);
        }

        public void RemotePizza(PizzaDTO pizza)
        {
            if (!Pizzas.Contains(pizza))
            {
                Pizzas.Remove(pizza);
            }
        }
    }

}
