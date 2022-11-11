using Microsoft.EntityFrameworkCore;
using PizzaEShop.Core.Enums;
using PizzaEShop.Core.Interfaces;
using PizzaEShop.Core.Model;
using PizzaEShop.Data;
using PizzaEShop.Data.Entity;
using PizzaEShop.Data.Repository;
using PizzaEShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaEShop.Core
{
    public class OrderManager
    {
        private OrderDTO order;  
        private readonly IPizzaBuilder builder;
        private readonly OrderRepository repository;

        public OrderManager()
        {
            this.repository = new OrderRepository();
        }

        public void InsertOrder(PizzaDTO pizza)
        {

            order.Pizzas.Add(pizza);
        }

        public void GetAllOrders(PizzaDTO pizza)
        {
            if (!order.Pizzas.Contains(pizza))
            {
                order.Pizzas.Remove(pizza);
            }
        }

    }
}