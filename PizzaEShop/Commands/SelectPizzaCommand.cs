using PizzaEShop.Core.Enums;
using PizzaEShop.Models;
using PizzaEShop.View;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PizzaEShop.Commands
{
    public class SelectPizzaCommand : ICommand
    {
        private readonly OrderBuilder builder;

        public SelectPizzaCommand(OrderBuilder builder)
        {
            this.builder = builder;
        }

        public bool CanExecute(object? parameter)
        {
            return parameter is not null && 
                   parameter is PizzaType;
        }


        public void Execute(object? parameter)
        {
            var view = new IngredientsWindow();

            builder.SetPizzaType((PizzaType)parameter!);
            view.ShowDialog();
        }

        public event EventHandler? CanExecuteChanged;
    }
}
