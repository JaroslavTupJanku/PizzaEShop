using PizzaEShop.Core.Enums;
using PizzaEShop.Core.Model;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PizzaEShop.Models
{
    public class ShoppingCart
    {
        public IList<PizzaDTO> Pizzas { get; private set; } = new List<PizzaDTO>();
        public int TotalPrice { get; private set; } = 0 ;

        public void Add(PizzaDTO pizza)
        {
            this.Pizzas.Add(pizza);
            UpdatePrice(pizza.Price + CountIngrediencePrice(pizza.Ingrediets));
        }

        public void Remove(PizzaDTO pizza)
        {
            this.Pizzas.Remove(pizza);
            UpdatePrice(-(pizza.Price + CountIngrediencePrice(pizza.Ingrediets)));
        }

        public void UpdatePrice(int price)
        {
            TotalPrice += price;
        }

        public void Reset()
        {
            this.Pizzas.Clear();
            TotalPrice = 0;
        }

        private int CountIngrediencePrice(Dictionary<IngredientType, int> ingredients)
        {
            return ingredients.Sum(x => (int)x.Key * x.Value);
        }
    }
}
