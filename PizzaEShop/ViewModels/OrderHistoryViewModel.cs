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
    public class OrderHistoryViewModel : IControlViewModel
    {
        private readonly OrderManager manager;
        private readonly ShoppingCart cart;


        public ICommand AddToFavoritOrderdCMD { get; set; }
        public ObservableCollection<OrderDTO> Orders { get; private set; } = null!;
        public ControlType ControlType => ControlType.OrderHistoryContoro;

        public OrderHistoryViewModel(OrderManager manager, ShoppingCart cart)
        {
            AddToFavoritOrderdCMD = new RelayCommand<OrderDTO>(async (dto) => await AddToFavoritOrder(dto!));


            this.manager = manager;
            this.cart = cart;
            UpdateList();
        }

        public async Task AddToFavoritOrder(OrderDTO order) => await manager.SetFavoritOrderd(order);

        public void UpdateList()
        {
            var list = Task.Run(async () => await manager.GetAllOrders());

            Orders = new ObservableCollection<OrderDTO>(list.Result);
        }
    }
}
