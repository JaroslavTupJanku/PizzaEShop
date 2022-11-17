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
        private readonly OrderRepository repository;

        public OrderManager()
        {
            this.repository = new OrderRepository();
        }

        public async Task InsertOrder(OrderDTO order)
        {
            await repository.PostOrder(order);
        }

        public async Task<OrderDTO[]> GetAllOrders()
        {
            return await repository.GetOrders();
        }

    }
}