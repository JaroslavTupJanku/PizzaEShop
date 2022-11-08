using PizzaEShop.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaEShop.Models
{
    public class PizzaModel
    {
        public PizzaType Type { get; set; } = PizzaType.None;
        public int Price { get; set; } = int.MinValue;
        public Dictionary<IngredientType, int> Ingrediets { get; set; }

        public PizzaModel(PizzaBuilder builder)
        {
            Type = builder.Type;
            Price = builder.PizzaPrice;
            Ingrediets = builder.Ingredients!;
        }
    }

    public class PizzaBuilder
    {
        public PizzaType Type { get; private set; } = PizzaType.None;
        public int IngredientPrice { get; private set; }
        public int PizzaPrice { get; private set; }
        public Dictionary<IngredientType, int> Ingredients { get; private set; } = new Dictionary<IngredientType, int>();

        public PizzaBuilder SetPizzaType(PizzaType pizza)
        {
            this.Type = pizza;
            return this;
        }

        public PizzaBuilder SetIngrediets(IngredientType key, int value)
        {
            this.Ingredients.Add(key, value);
            IngredientPrice += value * 10;
            return this;
        }

        public PizzaBuilder SetCost(int price)
        {
            this.PizzaPrice = price;
            return this;
        }

        public PizzaModel Build()
        {
            if (Type is PizzaType.None || Ingredients is null)
            {
                throw new Exception("Objednavka nelze vytvorit");
            }

            return new PizzaModel(this);
        }
    }
}
