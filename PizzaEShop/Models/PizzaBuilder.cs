using PizzaEShop.Core.Enums;
using PizzaEShop.Core.Interfaces;
using PizzaEShop.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaEShop.Models
{

    public class PizzaBuilder : IPizzaBuilder
    {
        public PizzaType Type { get; private set; } = PizzaType.None;
        public int IngredientPrice { get; private set; }
        public int PizzaPrice { get; private set; }

        public Dictionary<IngredientType, int> Ingredients { get; private set; } = new Dictionary<IngredientType, int>();

        public IPizzaBuilder SetPizzaType(PizzaType pizza)
        {
            this.Type = pizza;
            return this;
        }

        public IPizzaBuilder SetIngrediets(IngredientType key, int value)
        {
            this.Ingredients.Add(key, value);
            IngredientPrice += value * 10;
            return this;
        }

        public IPizzaBuilder SetCost(int price)
        {
            this.PizzaPrice = price;
            return this;
        }

        public PizzaDTO Build()
        {
            if (Type is PizzaType.None || Ingredients is null)
            {
                throw new Exception("Objednavka nelze vytvorit");
            }

            return new PizzaDTO(this);
        }
    }
}
