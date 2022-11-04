using PizzaEShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PizzaEShop.Commands
{
    public class AddIngredientCommand : ICommand
    {
        public bool CanExecute(object? parameter)
        {
            return parameter is Ingredient;
        }

        public void Execute(object? parameter)
        {
            (parameter as Ingredient)!.Add();
        }

        public event EventHandler? CanExecuteChanged;
    }
}
