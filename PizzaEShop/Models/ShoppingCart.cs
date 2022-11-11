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
        private readonly IList<PizzaDTO> pizzas = new List<PizzaDTO>();

        public void Add(PizzaDTO pizza)
        {
            this.pizzas.Add(pizza);
        }

        public void Remove(PizzaDTO pizza)
        {
            this.pizzas.Remove(pizza);
        }

    }
}
