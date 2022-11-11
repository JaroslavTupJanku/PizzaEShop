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

        public OrderRepository()
        {

        }

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


            throw new NotImplementedException();
            //return entities.Select(x => new OrderDTO
            //{
            //    Address = x.Address,
            //    Time = x.Time,
            //    Pizzas = x.Pizzas!.Select(x => Convert(x)).ToArray()   //ConvertToModel(x.Pizzas!)
            //})
            //.ToArray();
        }

        public PizzaEntity ConvertBack (PizzaDTO pizza)
        {
            var dict = pizza.Ingrediets;
            return new PizzaEntity()
            {
                PizzaCost = pizza.Price,
                PizzaType = pizza.Type,
                Gorgonzola = dict[IngredientType.Gorgonzola],
                Mozzarela = dict[IngredientType.Mozzarela],
                Rukola = dict[IngredientType.Rukola],
                Hermelin = dict[IngredientType.Hermelín],
                Kukurice = dict[IngredientType.Kukřice],
                Losos = dict[IngredientType.Losos],
                Vejce = dict[IngredientType.Vejce],
                Zizaly = dict[IngredientType.Žížaly],
                Salam = dict[IngredientType.Salám],
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
