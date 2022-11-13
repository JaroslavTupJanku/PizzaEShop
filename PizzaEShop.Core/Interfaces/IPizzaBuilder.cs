using PizzaEShop.Core.Enums;
using PizzaEShop.Core.Model;
using System.Collections.Generic;

namespace PizzaEShop.Core.Interfaces
{
    public interface IPizzaBuilder
    {
        int PizzaPrice { get; }
        Dictionary<IngredientType, int> Ingredients { get; }
        int IngredientPrice { get; }
        PizzaType Type { get; }

        PizzaDTO Build();
        IPizzaBuilder SetPrice(int price);
        IPizzaBuilder SetIngrediets(IngredientType key, int value);
        IPizzaBuilder SetPizzaType(PizzaType pizza);
    }
}