using CommunityToolkit.Mvvm.Input;
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
        public UserControl userControl = new PizzaMenuControl();
        public RelayCommand GoToShoppingCartCMD { get; }
        public RelayCommand GoToMainPageCMD { get; }

        public UserControl? Control
        {
            get => userControl;
            private set
            {
                userControl = value!;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Control)));
            }
        }

        public MainViewModel(ControlProvider provider)
        {
            provider.OnUserControlChanged += Settings_OnUserControlChanged;

            GoToMainPageCMD = new RelayCommand(GetMainPage!);
            GoToShoppingCartCMD = new RelayCommand(GetShoppingCart!);
        }

        private void GetMainPage() => Control = new PizzaMenuControl();
        private void GetShoppingCart() => Control = new ShoppingCartControl();

        public event PropertyChangedEventHandler? PropertyChanged;

        private void Settings_OnUserControlChanged(object? sender, UserControl e)
        {
            this.Control = e;
        }

    }
}
