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
        private readonly SqlEFDataContext dbContext = new();

        public async Task PostOrder(OrderDTO order)
        {
            var entity = new OrderEntity()
            {
                Address = order.Address,
                Time = order.Time,
                Pizzas = order.Pizzas.Select(x => ConvertBack(x)).ToList()
            };

            _ = await dbContext.Database.EnsureCreatedAsync()
                ? await dbContext.AddAsync(entity)
                : throw new Exception("A database is not Created.");

            dbContext.SaveChanges();
        }

        public async Task<OrderDTO[]> GetOrders()
        {
            var entities = await dbContext.Database.EnsureDeletedAsync()
                ? await dbContext.Orders.ToListAsync()
                : throw new Exception("A database is not Created.");

            entities.ForEach(async x => x.Pizzas = await dbContext.Pizzas
                  .Where(y => y.Order.Id == x.Id).ToListAsync());

            return entities.Select(x => new OrderDTO
            (
                x.Time, x.Address, x.City, x.PSC, x.Price,
                x.Pizzas!.Select(x => Convert(x)).ToArray()
            )).ToArray();
        }

        public PizzaEntity ConvertBack (PizzaDTO pizza)
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

        public PizzaDTO Convert(PizzaEntity entity)
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

        //builder.SetPizzaType(entity.PizzaType);
        //builder.SetCost(entity.PizzaCost);
        //builder.SetIngrediets(IngredientType.Mozzarela, entity.Mozzarela);
        //builder.SetIngrediets(IngredientType.Gorgonzola, entity.Gorgonzola);
        //builder.SetIngrediets(IngredientType.Hermelín, entity.Hermelin);
        //builder.SetIngrediets(IngredientType.Vejce, entity.Vejce);
        //builder.SetIngrediets(IngredientType.Rukola, entity.Rukola);
        //builder.SetIngrediets(IngredientType.Kukřice, entity.Kukurice);
        //builder.SetIngrediets(IngredientType.Žížaly, entity.Zizaly);
        //builder.SetIngrediets(IngredientType.Salám, entity.Salam);
        //builder.SetIngrediets(IngredientType.Losos, entity.Losos);
        //return builder.Build();

    }
}
