using PizzaEShop.Core;
using PizzaEShop.Core.Model;
using PizzaEShop.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PizzaEShop.Commands
{
    public class CreateOrderCommand : ICommand
    {
        private readonly ShoppingCart cart;
        private string[] addressString = null!;

        public CreateOrderCommand(ShoppingCart cart)
        {
            this.cart = cart;
        }

        public bool CanExecute(object? parameter)
        {
            addressString = Array.ConvertAll((object[]) parameter!, x => x.ToString()!); ;
            return addressString.Length == 3;
        }

        public void Execute(object? parameter)
        {
            var order = new OrderDTO
            (
                DateTime.Now.Date, 
                addressString[1], 
                addressString[0],
                addressString[2] == string.Empty? 0 : Convert.ToInt32(addressString[2]), 
                cart.TotalPrice, 
                cart.Pizzas
            );
            OnOrderCreate?.Invoke(this, order);
        }

        public event EventHandler<OrderDTO>? OnOrderCreate;
        public event EventHandler? CanExecuteChanged;
    }
}
