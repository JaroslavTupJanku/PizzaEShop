using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore.Update.Internal;
using PizzaEShop.Core;
using PizzaEShop.Core.Enums;
using PizzaEShop.Core.Interfaces;
using PizzaEShop.Core.Model;
using PizzaEShop.Data.Entity;
using PizzaEShop.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PizzaEShop.ViewModels
{
    public class ShoppingCartViewModel : ObservableObject, IControlViewModel
    {
        private readonly ShoppingCart cart = null!;
        private readonly ControlProvider provider;
        private int totalPrice = int.MinValue;

        public bool Enabled { get; } = false;
        public ICommand RemovePizzaCMD { get; }
        public ICommand GoToAddressControlCMD { get; }
        public ICommand GoToMenuControlCMD { get; }

        public ObservableCollection<PizzaDTO> Pizzas { get; private set; } = null!;
        public ControlType ControlType { get; } = ControlType.ShoppingCartControl;
        public int TotalPrice
        {
            get => totalPrice;
            private set => SetProperty(ref totalPrice, value);
        }

        public ShoppingCartViewModel(ShoppingCart cart, ControlProvider provider)
        {
            this.cart = cart;
            this.provider = provider;

            RemovePizzaCMD = new RelayCommand<PizzaDTO>((pizza) => RemovePizza(pizza!));
            GoToAddressControlCMD = new RelayCommand(() => GotoAddressControl());
            GoToMenuControlCMD = new RelayCommand(() => GoToPizzaMenuControl());

            Pizzas = new ObservableCollection<PizzaDTO>(cart.Pizzas);
            TotalPrice = cart.TotalPrice;
        }

        public void RemovePizza(PizzaDTO pizza)
        {
            cart.Remove(pizza);
            Pizzas.Remove(pizza);
            TotalPrice = cart.TotalPrice;
        }

        public void GotoAddressControl() => provider.SetPizzaControl(ControlType.AddresControl);
        public void GoToPizzaMenuControl() => provider.SetPizzaControl(ControlType.PizzaMenuControl);


    }
}
