using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using PizzaEShop.Core;
using PizzaEShop.Core.Enums;
using PizzaEShop.Core.Interfaces;
using PizzaEShop.Core.Model;
using PizzaEShop.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace PizzaEShop.ViewModels
{
    public class FavoritOrderViewModel : ObservableObject, IControlViewModel
    {
        private readonly OrderManager manager;
        private readonly ShoppingCart cart;
        private Visibility isControlVisible;

        public ICommand UnsetFavoritOrderCMD { get; set; }
        public ICommand AddPizzasToCartCMD { get; set; }

        public Visibility IsControlVisible
        {
            get => isControlVisible;
            set => SetProperty(ref isControlVisible, value);
        }

        public ObservableCollection<OrderDTO> FavoritOrders { get; private set; } = new();
        public ControlType ControlType => ControlType.FavoritOrderControl;

        public FavoritOrderViewModel(OrderManager manager, ShoppingCart cart)
        {
            AddPizzasToCartCMD = new RelayCommand<OrderDTO>((dto) => AddPizzaToShoppingCart(dto!));
            UnsetFavoritOrderCMD = new RelayCommand<OrderDTO>(async (dto) => await UnsetFavoritOrder(dto!));

            this.manager = manager;
            this.cart = cart;
            UpdateList();
        }

        public void AddPizzaToShoppingCart(OrderDTO order) => order.Pizzas.ToList().ForEach(x => cart.Add(x));

        public async Task UnsetFavoritOrder(OrderDTO order)
        {
            await manager.SetFavoritOrderd(order, false);
            UpdateList();
        }

        public void UpdateList()
        {
            FavoritOrders.Clear();
            var list = Task.Run(async () => await manager.GetAllOrders());
            list.Result.ToList().Where(x => x.IsFavorit == true).ToList().ForEach(o => FavoritOrders.Add(o));
            IsControlVisible = FavoritOrders.Count <= 0 ? Visibility.Hidden: Visibility.Visible;
        }
    }
}
