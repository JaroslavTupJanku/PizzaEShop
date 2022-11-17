using PizzaEShop.Core.Enums;
using PizzaEShop.Core;
using PizzaEShop.Data.Entity;
using PizzaEShop.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Windows;
using PizzaEShop.Commands;

namespace PizzaEShop.ViewModels
{
    public class OrderViewModel : ObservableObject
    {
        private readonly ShoppingCart cart;
        private readonly ControlProvider provider;
        private readonly OrderManager manager;
        private bool isTransportByCar;
        private int orderPrize;
        private int transportCost;

        public ICommand GoBackCommand { get; set; }
        public CreateOrderCommand CreateOrderCommand { get; set; }

        public bool IsTransportByCar 
        { 
            get => isTransportByCar; 
            set 
            {
                SetProperty(ref isTransportByCar, value);   
                TransportCost = value is true ? 30 : 0;
            }
        }

        public int TransportCost 
        { 
            get => transportCost;
            set
            {
                SetProperty(ref transportCost, value);
                OrderPrize = value is 0 ? OrderPrize -30 : OrderPrize + 30;
            }
        }

        public int OrderPrize
        {
            get => orderPrize;
            set => SetProperty(ref orderPrize, value);
        }


        public OrderViewModel(ShoppingCart cart, ControlProvider provider, OrderManager manager)
        {
            this.cart = cart;
            this.provider = provider;
            this.manager = manager;
            OrderPrize = cart.TotalPrice;

            this.GoBackCommand = new RelayCommand(() => provider.SetPizzaControl(ControlType.ShoppingCartControl));
            this.CreateOrderCommand = new CreateOrderCommand(cart);

            this.CreateOrderCommand.OnOrderCreate += CreateOrderCommand_OnOrderCreate;
        }

        private async void CreateOrderCommand_OnOrderCreate(object? sender, Core.Model.OrderDTO e)
        {
            await this.manager.InsertOrder(e);
            if (MessageBox.Show("Objednávka byla přijata") == MessageBoxResult.OK)
            {
                provider.SetPizzaControl(ControlType.PizzaMenuControl);
            }
            
        }
    }

}
