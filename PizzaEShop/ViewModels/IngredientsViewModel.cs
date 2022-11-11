using CommunityToolkit.Mvvm.Input;
using PizzaEShop.Core;
using PizzaEShop.Core.Enums;
using PizzaEShop.Core.Interfaces;
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
        private readonly OrderManager manager;
        private readonly IPizzaBuilder builder;

        public ObservableCollection<IngredientCounter> Ingredients { get; private set; } = new ObservableCollection<IngredientCounter>();
        public RelayCommand<IngredientType> AddIngredientCMD { get; }
        public RelayCommand<IngredientType> RemoveIngredientCMD { get; } 
        public RelayCommand<ICloseable> AddOrderCommand { get; }
        public RelayCommand<ICloseable> AddOrderAndContinueCommand { get; }


        public IngredientsViewModel(OrderManager manager, IPizzaBuilder builder)
        {
            Ingredients.Add(new IngredientCounter(IngredientType.Mozzarela));
            Ingredients.Add(new IngredientCounter(IngredientType.Hermelín));
            Ingredients.Add(new IngredientCounter(IngredientType.Losos));
            Ingredients.Add(new IngredientCounter(IngredientType.Vejce));
            Ingredients.Add(new IngredientCounter(IngredientType.Gorgonzola));
            Ingredients.Add(new IngredientCounter(IngredientType.Žížaly));
            Ingredients.Add(new IngredientCounter(IngredientType.Losos));
            Ingredients.Add(new IngredientCounter(IngredientType.Salám));
            Ingredients.Add(new IngredientCounter(IngredientType.Rukola));

            this.manager = manager;
            this.builder = builder;

            AddIngredientCMD = new RelayCommand<IngredientType>((type) => AddIngredience(type));
            RemoveIngredientCMD = new RelayCommand<IngredientType>((type) => RemoveIngredience(type));
            AddOrderCommand = new RelayCommand<ICloseable>(ShowShoppingCart!);
            AddOrderAndContinueCommand = new RelayCommand<ICloseable>(AddOrderToManger!);
        }

        public void AddIngredience(IngredientType type) => Ingredients.Where(x => x.IngredientType == type).FirstOrDefault()!.Add();
        public void RemoveIngredience(IngredientType type) => Ingredients.Where(x => x.IngredientType == type).FirstOrDefault()!.Remove();

        private void AddOrderToManger(ICloseable window)
        {
            window.Close();
            //manager.AddOrder(builder.SetIngrediets(Ingredients.ToArray()).Build());
        }

        private void ShowShoppingCart(ICloseable window)
        {
            //var view = new ShoppingCartWindow();
            AddOrderToManger(window);
        }
    }
}
