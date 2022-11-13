using PizzaEShop.Core.Model;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaEShop.Models
{
    public class ShoppingCart
    {
        public IList<PizzaDTO> Pizzas { get; } = new List<PizzaDTO>();

        public void Add(PizzaDTO pizza)
        {
            this.Pizzas.Add(pizza);
        }

        public void Remove(PizzaDTO pizza)
        {
            this.Pizzas.Remove(pizza);
        }

    }
}
