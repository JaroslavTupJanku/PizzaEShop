using PizzaEShop.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaEShop.Data.Entity
{
    public  class OrderEntity
    {
        public int Id { get; set; } 
        public DateTime Time { get; set; }

        public bool IsFavorit { get; set; }
        public string Address { get; set; } = string.Empty;

        public ICollection<PizzaEntity>? Pizzas { get; set; }

    }
}
