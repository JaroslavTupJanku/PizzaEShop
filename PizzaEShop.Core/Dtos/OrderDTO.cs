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
        public int Price { get;}
        public int PSC { get; }
        public DateTime Time { get; }

        public string Address { get; } = string.Empty;
        public string City { get; } = string.Empty;

        public IList<PizzaDTO> Pizzas { get; } = null!;

        public OrderDTO(DateTime time, string address, string city, int psc, int price, IList<PizzaDTO> pizzas)
        {
            Time = time;
            PSC = psc;
            Price = price;
            Pizzas = pizzas;
            City = city;
            Address = address;
        }
    }

}
