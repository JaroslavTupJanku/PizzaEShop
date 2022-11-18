using Microsoft.EntityFrameworkCore;
using PizzaEShop.Core.Enums;
using PizzaEShop.Core.Interfaces;
using PizzaEShop.Core.Model;
using PizzaEShop.Data.Entity;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaEShop.Data.Repository
{
    public class OrderRepository
    {
        public async Task PostOrder(OrderDTO order)
        {
            var entity = new OrderEntity()
            {
                Address = order.Address,
                Time = order.Time,
                Price = order.Price,
                Pizzas = order.Pizzas.Select(x => ConvertBack(x)).ToList()
            };

            using var dbContext = new SqlEFDataContext();
            bool vytvorena = await dbContext.Database.EnsureCreatedAsync();
            await dbContext.AddAsync(entity);
            dbContext.SaveChanges();

        }

        public async Task<OrderDTO[]> GetOrders()
        {
            using var dbContext = new SqlEFDataContext();
            bool vytovrena = await dbContext.Database.EnsureCreatedAsync();
            var entities = await dbContext.Orders.ToListAsync();
            entities.ForEach(async x => x.Pizzas = await dbContext.Pizzas
                  .Where(y => y.Order.Id == x.Id).ToListAsync());

            return entities.Select(x => new OrderDTO
            (
                x.Time, x.Address, x.City, x.PSC, x.Price,
                x.Pizzas!.Select(x => Convert(x)).ToArray(),
                x.IsFavorit, x.Id
            )).ToArray();
        }

        public async Task SetFavoritOrder(OrderDTO order, bool favorit)
        {
            using var dbContext = new SqlEFDataContext();
            bool vytvorena = await dbContext.Database.EnsureCreatedAsync();

            if ((await dbContext.Orders.ToListAsync()).Where(x => 
                x.Id == order.Id).FirstOrDefault() is OrderEntity entity && entity.IsFavorit == !favorit)
            {
                entity.IsFavorit = favorit;
                dbContext.Update(entity);
                dbContext.SaveChanges();
            }
           
        }

        private PizzaEntity ConvertBack (PizzaDTO pizza)
        {
            var dict = pizza.Ingrediets;
            return new PizzaEntity()
            {
                PizzaCost = pizza.Price,
                PizzaType = pizza.Type,
                Gorgonzola = dict is null || !dict.ContainsKey(IngredientType.Gorgonzola) ? 0 : dict[IngredientType.Gorgonzola],
                Mozzarela = dict is null || !dict.ContainsKey(IngredientType.Mozzarela) ? 0 : dict[IngredientType.Mozzarela],
                Rukola = dict is null || !dict.ContainsKey(IngredientType.Rukola) ? 0 : dict[IngredientType.Rukola],
                Hermelin = dict is null || !dict.ContainsKey(IngredientType.Hermelín) ? 0 : dict[IngredientType.Hermelín],
                Kukurice = dict is null || !dict.ContainsKey(IngredientType.Kukřice) ? 0 : dict[IngredientType.Kukřice],
                Losos = dict is null || !dict.ContainsKey(IngredientType.Losos) ? 0 : dict[IngredientType.Losos],
                Vejce = dict is null || !dict.ContainsKey(IngredientType.Vejce) ? 0 : dict[IngredientType.Vejce],
                Zizaly = dict is null || !dict.ContainsKey(IngredientType.Žížaly) ? 0 : dict[IngredientType.Žížaly],
                Salam = dict is null || !dict.ContainsKey(IngredientType.Salám) ? 0 : dict[IngredientType.Salám],
            };
        }

        private PizzaDTO Convert(PizzaEntity entity)
        {         
            return new PizzaDTO(entity.PizzaType, entity.PizzaCost, new Dictionary<IngredientType, int>() 
            {
                {IngredientType.Mozzarela, entity.Mozzarela },
                {IngredientType.Rukola, entity.Rukola },
                {IngredientType.Gorgonzola, entity.Gorgonzola },
                {IngredientType.Hermelín, entity.Hermelin },
                {IngredientType.Vejce, entity.Vejce },
                {IngredientType.Žížaly, entity.Zizaly },
                {IngredientType.Salám, entity.Salam },
                {IngredientType.Losos, entity.Losos },
                {IngredientType.Kukřice, entity.Kukurice },

            });
        }
    }
}
