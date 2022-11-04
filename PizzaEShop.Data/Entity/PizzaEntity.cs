using PizzaEShop.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaEShop.Data.Entity
{
    public  class PizzaEntity
    {
        public DateTime Time { get; set; }
        public PizzaType PizzaType { get; set; }
        public string Adresa { get; set; }
        public List<int> IngredienceValue { get; set; }

        public PizzaEntity(PizzaType pizzaType, DateTime time, List<int> ingredienceValue, string adresa)
        {
            IngredienceValue = ingredienceValue;
            Adresa = adresa;
            PizzaType = pizzaType;
            Time = time;
        }
    }
}
