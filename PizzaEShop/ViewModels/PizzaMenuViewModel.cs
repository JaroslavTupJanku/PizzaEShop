using CommunityToolkit.Mvvm.Input;
using PizzaEShop.Core.Enums;
using PizzaEShop.Core.Interfaces;
using PizzaEShop.Core.Model;
using PizzaEShop.Models;
using PizzaEShop.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PizzaEShop.ViewModels
{
    public class PizzaMenuViewModel
    {
        private readonly IPizzaBuilder builder;

        public RelayCommand<PizzaType> Command { get; }
        public List<PizzaDTO> PizzaList { get; } = new List<PizzaDTO>();

        public PizzaMenuViewModel(IPizzaBuilder builder)
        {
            this.builder = builder;
            Command = new RelayCommand<PizzaType>((type) => ShowIngredientsWindow(type));

            PizzaList.Add(new PizzaDTO(PizzaType.Margherita, 144, new() { { IngredientType.Rukola, 1 }, { IngredientType.Mozzarela, 1 } }));
            PizzaList.Add(new PizzaDTO(PizzaType.Fungi, 151, new() { { IngredientType.Gorgonzola, 1 }, { IngredientType.Hermelín, 1 }, { IngredientType.Kukřice, 1 } }));
            PizzaList.Add(new PizzaDTO(PizzaType.Hawai, 144, new() { { IngredientType.Losos, 1 }, { IngredientType.Žížaly, 1 } }));
            PizzaList.Add(new PizzaDTO(PizzaType.Diavolo, 151, new() { { IngredientType.Vejce, 1 }, { IngredientType.Losos, 1 }, { IngredientType.Gorgonzola, 1 } }));
            PizzaList.Add(new PizzaDTO(PizzaType.QuattroFormaggi, 151, new() { { IngredientType.Hermelín, 1 }, { IngredientType.Gorgonzola, 1 }, { IngredientType.Mozzarela, 1 } }));
            PizzaList.Add(new PizzaDTO(PizzaType.Capricciosa, 151, new() { { IngredientType.Salám, 1 }, { IngredientType.Vejce, 1 }, { IngredientType.Žížaly, 1 }, { IngredientType.Losos, 1 } }));
            PizzaList.Add(new PizzaDTO(PizzaType.Salami, 151, new() { { IngredientType.Salám, 1 }, { IngredientType.Žížaly, 1 } }));
            PizzaList.Add(new PizzaDTO(PizzaType.Tonno, 151, new() { { IngredientType.Losos, 1 }, { IngredientType.Vejce, 1 } }));
        }

        public void ShowIngredientsWindow(PizzaType type)
        {
            builder.SetPizzaType(type);
            var view = new IngredientsWindow();
            view.ShowDialog();
        }
    }
}
