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
using System.Windows.Controls;
using System.Windows.Input;

namespace PizzaEShop.ViewModels
{
    public class FavoritOrderViewModel : IControlViewModel
    {
        private readonly OrderManager manager;
        private readonly ShoppingCart cart;

        public ICommand AddPizzasToCartCMD { get; set; }
        public ObservableCollection<OrderDTO> FavoritOrders { get; private set; } = null!;
        public ControlType ControlType => ControlType.FavoritOrderControl;

        public FavoritOrderViewModel(OrderManager manager, ShoppingCart cart)
        {

            AddPizzasToCartCMD = new RelayCommand<OrderDTO>((dto) => AddPizzaToShoppingCart(dto!));
            this.manager = manager;
            this.cart = cart;

            UpdateList();
        }

        public void AddPizzaToShoppingCart(OrderDTO order) => order.Pizzas.ToList().ForEach(x => cart.Add(x));

        public void UpdateList()
        {
            var list = Task.Run(async () => await manager.GetAllOrders());
            FavoritOrders = new ObservableCollection<OrderDTO>(list.Result.Where(x => x.IsFavorit == true));
        }
    }
}
