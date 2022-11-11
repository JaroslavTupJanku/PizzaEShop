using CommunityToolkit.Mvvm.Input;
using PizzaEShop.Core;
using PizzaEShop.Core.Enums;
using PizzaEShop.Core.Interfaces;
using PizzaEShop.Models;
using PizzaEShop.View;
using PizzaEShop.View.Controls;
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
        private readonly ShoppingCart cart;
        private readonly ControlProvider provider;
        private readonly IPizzaBuilder builder;

        public ObservableCollection<IngredientCounter> Ingredients { get; private set; } = new ObservableCollection<IngredientCounter>();
        public RelayCommand<IngredientType> AddIngredientCMD { get; }
        public RelayCommand<IngredientType> RemoveIngredientCMD { get; }
        public RelayCommand<ICloseable> AddOrderCommand { get; }
        public RelayCommand<ICloseable> AddOrderAndContinueCommand { get; }


        public IngredientsViewModel(IPizzaBuilder builder, ShoppingCart cart, ControlProvider provider)
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

            AddIngredientCMD = new RelayCommand<IngredientType>((type) => AddIngredience(type));
            RemoveIngredientCMD = new RelayCommand<IngredientType>((type) => RemoveIngredience(type));
            AddOrderCommand = new RelayCommand<ICloseable>(GoToShoppingCart!);
            AddOrderAndContinueCommand = new RelayCommand<ICloseable>(AddPizzaToCart!);

            this.builder = builder;
            this.cart = cart;
            this.provider = provider;
        }

        public void AddIngredience(IngredientType type) => Ingredients.Where(x => x.IngredientType == type).FirstOrDefault()!.Add();
        public void RemoveIngredience(IngredientType type) => Ingredients.Where(x => x.IngredientType == type).FirstOrDefault()!.Remove();
        private void GoToShoppingCart(ICloseable window)
        {
            AddPizzaToCart(window);
            provider.SetPizzaControl(ControlType.ShoppingCartControl);
            window.Close();
        }


        // DO JEDNE METODZ
        private void AddPizzaToCart(ICloseable window)
        {
            if (builder.Type == PizzaType.None)
                throw new Exception("No Pizza Added.");

            Ingredients.ToList().ForEach(counter =>
            {
                if (counter.Count > 0)
                    builder.SetIngrediets(counter.IngredientType, counter.Count);
            });

            cart.Add(builder.Build());
            provider.SetPizzaControl(ControlType.PizzaMenuControl);
            window.Close();
        }

    }
}
