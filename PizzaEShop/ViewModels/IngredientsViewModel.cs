using GalaSoft.MvvmLight.Command;
using PizzaEShop.Commands;
using PizzaEShop.Core.Enums;
using PizzaEShop.Models;
using PizzaEShop.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PizzaEShop.ViewModels
{
    public class IngredientsViewModel
    {
        private readonly OrdersManager manager;
        private readonly OrderBuilder builder;

        public ObservableCollection<Ingredient> Ingredients { get; private set; } = new ObservableCollection<Ingredient>();
        public ICommand AddIngredientCMD { get; } = new AddIngredientCommand();
        public ICommand RemoveIngredientCMD { get; } = new RemoveIngredientCommand();
        public RelayCommand<ICloseable> AddOrderCommand { get; }
        public RelayCommand<ICloseable> AddOrderAndContinueCommand { get; }


        public IngredientsViewModel(OrdersManager manager, OrderBuilder builder)
        {
            Ingredients.Add(new Ingredient(IngredientType.Mozzarela, 45));
            Ingredients.Add(new Ingredient(IngredientType.Hermelín, 35));
            Ingredients.Add(new Ingredient(IngredientType.Losos, 40));
            Ingredients.Add(new Ingredient(IngredientType.Vejce, 35));

            this.manager = manager;
            this.builder = builder;

            AddOrderCommand = new RelayCommand<ICloseable>(ShowShoppingCart);
            AddOrderAndContinueCommand = new RelayCommand<ICloseable>(AddOrderToManger);
        }
        
        private void AddOrderToManger(ICloseable window)
        {
            window.Close();
            manager.AddOrder(builder.SetIngrediets(Ingredients.ToArray()).Build());
        }

        private void ShowShoppingCart(ICloseable window)
        {
            //var view = new ShoppingCartWindow();

            AddOrderToManger(window);
            //view.ShowDialog();
        }
    }
}
