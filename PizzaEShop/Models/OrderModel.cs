using PizzaEShop.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaEShop.Models
{
    public class OrderModel
    {
        public DateTime Time { get; set; }
        public string Address { get; set; } = string.Empty;
        public PizzaModel[] Pizzas { get; set; } = null!;
    }
}
