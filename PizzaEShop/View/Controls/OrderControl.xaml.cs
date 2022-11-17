using Microsoft.Extensions.DependencyInjection;
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
    /// Interaction logic for AddressControl.xaml
    /// </summary>
    public partial class OrderControl : UserControl
    {
        public OrderControl()
        {
            DataContext = App.AppHost?.Services.GetService<OrderViewModel>();
            InitializeComponent();
        }
    }
}
