using PizzaEShop.Commands;
using PizzaEShop.Core.Enums;
using PizzaEShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PizzaEShop.ViewModels
{
    public class PizzaMenuViewModel
    {
        public ICommand Command { get; }
        public List<Pizza> PizzaList { get; } = new List<Pizza>();

        public PizzaMenuViewModel(PizzaBuilder builder)
        {
            Command = new SelectPizzaCommand(builder);

            PizzaList.Add(new Pizza() { Type = PizzaType.Margherita, Price = 152, Weight = 52 });
            PizzaList.Add(new Pizza() { Type = PizzaType.Diavolo, Price = 152, Weight = 52 });
        }
    }
}
