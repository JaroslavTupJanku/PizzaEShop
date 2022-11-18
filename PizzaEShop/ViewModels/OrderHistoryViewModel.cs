﻿using CommunityToolkit.Mvvm.Input;
using PizzaEShop.Core;
using PizzaEShop.Core.Enums;
using PizzaEShop.Core.Interfaces;
using PizzaEShop.Core.Model;
using PizzaEShop.Models;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PizzaEShop.ViewModels
{
    public class OrderHistoryViewModel : IControlViewModel
    {
        private readonly OrderManager manager;

        public ICommand SetFavoritOrderCMD { get; set; }
        public ObservableCollection<OrderDTO> Orders { get; private set; } = new();
        public ControlType ControlType => ControlType.OrderHistoryContoro;

        public OrderHistoryViewModel(OrderManager manager)
        {
            SetFavoritOrderCMD = new RelayCommand<OrderDTO>(async (dto) => await SetFavoritOrder(dto!));

            this.manager = manager;
            UpdateList();
        }

        public async Task SetFavoritOrder(OrderDTO order)
        {
            await manager.SetFavoritOrderd(order, true);
            UpdateList();
        }

        public void UpdateList()
        {
            Orders.Clear();
            var list = Task.Run(async () => await manager.GetAllOrders());
            list.Result.ToList().ForEach(o => Orders.Add(o));
        }
    }
}
