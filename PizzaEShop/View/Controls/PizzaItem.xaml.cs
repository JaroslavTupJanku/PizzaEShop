using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using PizzaEShop.Core.Enums;
using PizzaEShop.Core.Interfaces;
using PizzaEShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PizzaEShop.View.Controls
{
    /// <summary>
    /// Interaction logic for PizzaItem.xaml
    /// </summary>
    public partial class PizzaItem : UserControl
    {
        public PizzaType PizzaType
        {
            get => (PizzaType)GetValue(TextBoxProperty);
            set => SetValue(TextBoxProperty, value);
        }

        public int PizzaPrice
        {
            get => (int)GetValue(PizzaPriceTBProperty);
            set => SetValue(PizzaPriceTBProperty, value);
        }

        public ICommand MyCommand
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        public string Ingredients
        {
            get => (string)GetValue(IngredientsTBProperty);
            set => SetValue(IngredientsTBProperty, value);
        }

        public static readonly DependencyProperty TextBoxProperty =
            DependencyProperty.Register("PizzaType", typeof(PizzaType), typeof(PizzaItem), new
            PropertyMetadata(PizzaType.None, new PropertyChangedCallback(OnPizzaTypeChanged)));

        public static readonly DependencyProperty PizzaPriceTBProperty =
            DependencyProperty.Register("PizzaPrice", typeof(int), typeof(PizzaItem), new
            PropertyMetadata(0, new PropertyChangedCallback(OnPriceChanged)));


        public static readonly DependencyProperty IngredientsTBProperty =
            DependencyProperty.Register("Ingredients", typeof(string), typeof(PizzaItem), new
            PropertyMetadata(string.Empty, new PropertyChangedCallback(OnIngreditesChanged)));

        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register("MyCommand", typeof(ICommand), typeof(PizzaItem), new 
            UIPropertyMetadata(null));

        private static void OnPizzaTypeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) => (d as PizzaItem)!.OnPizzaTypeChanged(e);
        private static void OnPriceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) => (d as PizzaItem)!.OnPriceChanged(e);
        private static void OnIngreditesChanged(DependencyObject d, DependencyPropertyChangedEventArgs e) => (d as PizzaItem)!.OnIngreditesChanged(e);


        public PizzaItem()
        {
            InitializeComponent();
            //MyButton.DataContext = App.AppHost!.Services.GetServices<PizzaItemViewModel>();
        }

        private void OnPizzaTypeChanged(DependencyPropertyChangedEventArgs e) => typeTB.Text = $"{(int)e.NewValue}.{e.NewValue}";
        private void OnPriceChanged(DependencyPropertyChangedEventArgs e) => priceTB.Text = $"{e.NewValue}Kč";
        private void OnIngreditesChanged(DependencyPropertyChangedEventArgs e) => descriptionTB.Text = $"{e.NewValue}";
    }
}
