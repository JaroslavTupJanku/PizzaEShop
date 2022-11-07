using Microsoft.EntityFrameworkCore;
using PizzaEShop.Data;
using PizzaEShop.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaEShop.Core
{
    public class PizzaManager
    {
        private readonly SqlEFDataContext dbContext = new SqlEFDataContext();

        public async Task PostOrder(OrderEntity order)
        {
            //if (await dbContext.Database.EnsureCreatedAsync())
            //{
                await dbContext.AddAsync(order);
                dbContext.SaveChanges();
//
        }

        public async Task<List<OrderEntity>> GetOrders()
        {
            var test = dbContext.Database.EnsureCreated();
            return await dbContext.Orders.ToListAsync();
            //return await dbContext.Database.EnsureDeletedAsync()
            //    ? await dbContext.Orders.ToListAsync()
            //    : new List<OrderEntity>();
        }

    }
}
