using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PizzaEShop.Core;
using PizzaEShop.Core.Interfaces;
using PizzaEShop.Data;
using PizzaEShop.Data.Repository;
using PizzaEShop.Models;
using PizzaEShop.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
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
                    services.AddSingleton<ControlProvider>();
                    services.AddSingleton<OrderManager>();
                    services.AddSingleton<ShoppingCart>();
                    services.AddSingleton<IPizzaBuilder, PizzaBuilder>();
                    services.AddSingleton<MainViewModel>();
                    services.AddSingleton<OrderViewModel>();
                    services.AddSingleton<OrderRepository>();

                    services.AddTransient<IControlViewModel, FavoritOrderViewModel>();
                    services.AddTransient<IControlViewModel, OrderHistoryViewModel>();
                    services.AddTransient<IControlViewModel, ShoppingCartViewModel>();
                    services.AddTransient<IControlViewModel, PizzaMenuViewModel>();
                    services.AddTransient<IngredientsViewModel>();
                }).Build();
        }

    }
}
