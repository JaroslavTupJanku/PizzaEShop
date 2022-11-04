using PizzaEShop.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaEShop.Models
{
    public class Order
    {
        private PizzaType type;
        private Ingredient[] ingredients;

        private PizzaType Type => type;
        private Ingredient[]? Ingredients => ingredients;

        public Order(OrderBuilder builder)
        {
            type = builder.Type;
            ingredients = builder.Ingredients!;  
        }
    }

    public class OrderBuilder
    {
        public  PizzaType Type { get; private set; } = PizzaType.None;
        public  Ingredient[]? Ingredients { get; private set; }

        public OrderBuilder SetPizzaType(PizzaType pizza)
        {
            this.Type = pizza;
            return this;
        }

        public OrderBuilder SetIngrediets(Ingredient[] ingredients)
        {
            this.Ingredients = ingredients;
            return this;
        }

        public Order Build()
        {
            if (Type is PizzaType.None || Ingredients is null)
            {
                throw new Exception("Objednavka nelze vytvorit");
            }

            return new Order(this);
        }
    }
}
