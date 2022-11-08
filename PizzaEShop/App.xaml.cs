using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PizzaEShop.Core;
using PizzaEShop.Models;
using PizzaEShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace PizzaEShop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IHost? AppHost { get; private set; }

        public App()
        {
            AppHost = Host.CreateDefaultBuilder()
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddSingleton<OrderManager>();
                    services.AddSingleton<PizzaBuilder>();
                    services.AddSingleton<MainViewModel>();
                    services.AddSingleton<IngredientsViewModel>();
                    services.AddSingleton<PizzaMenuViewModel>();
                    services.AddSingleton<ShoppingCartViewModel>();
                }).Build();
        }

    }
}
