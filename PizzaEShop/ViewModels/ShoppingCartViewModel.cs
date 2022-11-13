using CommunityToolkit.Mvvm.Input;
using PizzaEShop.Core;
using PizzaEShop.Core.Enums;
using PizzaEShop.Core.Interfaces;
using PizzaEShop.Core.Model;
using PizzaEShop.Data.Entity;
using PizzaEShop.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PizzaEShop.ViewModels
{
    public class ShoppingCartViewModel : IControlViewModel
    {
        private readonly ShoppingCart cart = null!;

        public bool Enabled { get; }  = false;

        public ObservableCollection<PizzaDTO> Pizzas { get; private set; } = null!;
        public ControlType ControlType { get; } = ControlType.ShoppingCartControl;
        public ICommand RemovePizzaCMD { get; } 

        public ShoppingCartViewModel(ShoppingCart cart)
        {
            this.cart = cart;
            RemovePizzaCMD = new RelayCommand<PizzaDTO>((pizza) => RemovePizza(pizza!));
            Pizzas = new ObservableCollection<PizzaDTO>(cart.Pizzas);
        }

        public void RemovePizza(PizzaDTO pizza)
        {
            cart.Remove(pizza);
            Pizzas.Remove(pizza);
        }

    }
}
