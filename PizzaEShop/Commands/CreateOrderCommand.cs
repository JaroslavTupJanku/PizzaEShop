using PizzaEShop.Core;
using PizzaEShop.Core.Model;
using PizzaEShop.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Loader;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PizzaEShop.Commands
{
    public class CreateOrderCommand : ICommand
    {
        private readonly ShoppingCart cart;
        private bool isTransportNeeded;
        private string[] addressString = null!;

        public CreateOrderCommand(ShoppingCart cart)
        {
            this.cart = cart;
        }

        public bool CanExecute(object? parameter)
        {
            var objectCollection = (object[])parameter!;
            isTransportNeeded = (bool)objectCollection[3];
            
            addressString = Array.ConvertAll(objectCollection.SkipLast(1).ToArray(), x => x.ToString()!);
            return addressString.Length == 3;
        }

        public void Execute(object? parameter)
        {
            if (isTransportNeeded && addressString.Any(x => x == string.Empty))
            {
                MessageBox.Show("The address is not complete.");
                return;
            }

            var psc = addressString[2] == string.Empty ? 0 : Convert.ToInt32(addressString[2]);
            var order = new OrderDTO( DateTime.Now.Date, addressString[1], addressString[0],psc, cart.TotalPrice, cart.Pizzas);
            OnOrderCreate?.Invoke(this, order);
        }

        public event EventHandler<OrderDTO>? OnOrderCreate;
        public event EventHandler? CanExecuteChanged;
    }
}
