using GalaSoft.MvvmLight.Command;
using PizzaEShop.Commands;
using PizzaEShop.Models;
using PizzaEShop.View.Controls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;

namespace PizzaEShop.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private UserControl? control = new ShoppingCartControl();

        public RelayCommand GoToShoppingCartCMD { get; }
        public RelayCommand GoToMainPageCMD { get; }
        public UserControl? Control 
        { 
            get => control;
            private set
            { 
                control = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Control)));
            }  
        
        } 
        public List<Pizza> PizzaList { get; } = new List<Pizza>();

        public MainViewModel()
        {
            GoToMainPageCMD = new RelayCommand(GetMainPage);
            GoToShoppingCartCMD = new RelayCommand(GetShoppingCart);
        }

        private void GetMainPage() => Control = new PizzaMenuControl();
        private void GetShoppingCart() => Control = new ShoppingCartControl();

        public event PropertyChangedEventHandler? PropertyChanged;

    }
}
