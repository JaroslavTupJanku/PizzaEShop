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
            IngredientPrice += value * (int)key;
            return this;
        }

        public IPizzaBuilder SetPrice(int price)
        {
            this.PizzaPrice = price;
            return this;
        }

        public PizzaDTO Build()
        {
            try     { return new PizzaDTO(this); } 
            catch   { throw new Exception("Objednavka nelze vytvorit"); }
            finally { ResetBuilder(); }
        }

        private void ResetBuilder()
        {
            IngredientPrice = 0;
            Type = PizzaType.None;
            Ingredients = new Dictionary<IngredientType, int>();
        }

    }
}
