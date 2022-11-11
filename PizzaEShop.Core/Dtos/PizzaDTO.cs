using PizzaEShop.Core.Enums;
using PizzaEShop.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaEShop.Core.Model
{
    public class PizzaDTO
    {
        public PizzaType Type { get; } = PizzaType.None;
        public int Price { get; } = int.MinValue;
        public Dictionary<IngredientType, int> Ingrediets { get; }

        public PizzaDTO(PizzaType type, int price, Dictionary<IngredientType, int> ingrediets)
        {
            Type = type;
            Price = price;
            Ingrediets = ingrediets;
        }

        public PizzaDTO(IPizzaBuilder builder)
        {
            Type = builder.Type;
            Price = builder.PizzaPrice;
            Ingrediets = builder.Ingredients!;
        }
    }
}
