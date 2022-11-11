using Microsoft.Extensions.DependencyInjection;
using PizzaEShop.Core.Enums;
using PizzaEShop.Core.Interfaces;
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
    /// Interaction logic for FavoritOrderControl.xaml
    /// </summary>
    public partial class FavoritOrderControl : UserControl
    {
        public FavoritOrderControl()
        {
            DataContext = App.AppHost!.Services.GetServices<IControlViewModel>()
                          .FirstOrDefault(x => x.ControlType == ControlType.FavoritOrderControl);
            InitializeComponent();
        }
    }
}
