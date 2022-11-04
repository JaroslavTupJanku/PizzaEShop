using PizzaEShop.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaEShop.Models
{
    public class Pizza
    {
        public PizzaType Type { get; set; } = PizzaType.None;
        public int Price { get; set; } = int.MinValue;
        public int Weight { get; set; } = int.MinValue;
        public IList<IngredientType> Ingrediets { get; set; } = new List<IngredientType>() { IngredientType.Mozzarela, IngredientType.Kukřice };

        public Pizza()
        {

        }
    }
}
