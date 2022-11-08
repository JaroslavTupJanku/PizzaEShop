using Microsoft.EntityFrameworkCore;
using PizzaEShop.Core.Enums;
using PizzaEShop.Data;
using PizzaEShop.Data.Entity;
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
        private readonly SqlEFDataContext dbContext = new SqlEFDataContext();
        private readonly PizzaBuilder builder;

        public OrderManager(PizzaBuilder builder)
        {
            this.builder = builder;
        }

        public async Task PostOrder(OrderModel order)
        {
            var entity = new OrderEntity()
            {
                Address = order.Address,
                Time = order.Time,
                Pizzas = order.Pizzas.Select(x => Frnda(x)).ToList()
            };

            _ = await dbContext.Database.EnsureCreatedAsync()
                ? await dbContext.AddAsync(entity)
                : throw new Exception("A database is not Created.");

            dbContext.SaveChanges();
        }

        public async Task<OrderModel[]> GetOrders()
        {
            var entities = await dbContext.Database.EnsureDeletedAsync()
                ? await dbContext.Orders.ToListAsync()
                : throw new Exception("A database is not Created.");

            entities.ForEach(async x => x.Pizzas = await dbContext.Pizzas
                  .Where(y => y.Order.Id == x.Id).ToListAsync());

            return entities.Select(x => new OrderModel
            {
                Address = x.Address,
                Time = x.Time,
                Pizzas = x.Pizzas!.Select(x => Kunda(x)).ToArray()   //ConvertToModel(x.Pizzas!)
            })
            .ToArray();
        }


        private PizzaEntity[] ConvertToEntity(PizzaModel[] models)
        {
            var entities = new List<PizzaEntity>();
            foreach (var pizza in entities)
            {

            }
            return entities.ToArray();
        }

        public PizzaEntity Frnda(PizzaModel pizza)
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

        public PizzaModel Kunda(PizzaEntity entity)
        {
            builder.SetPizzaType(entity.PizzaType);
            builder.SetCost((int)entity.PizzaCost);
            builder.SetIngrediets(IngredientType.Mozzarela, entity.Mozzarela);
            builder.SetIngrediets(IngredientType.Gorgonzola, entity.Gorgonzola);
            builder.SetIngrediets(IngredientType.Hermelín, entity.Hermelin);
            builder.SetIngrediets(IngredientType.Vejce, entity.Vejce);
            builder.SetIngrediets(IngredientType.Rukola, entity.Rukola);
            builder.SetIngrediets(IngredientType.Kukřice, entity.Kukurice);
            builder.SetIngrediets(IngredientType.Žížaly, entity.Zizaly);
            builder.SetIngrediets(IngredientType.Salám, entity.Salam);
            builder.SetIngrediets(IngredientType.Losos, entity.Losos);
            return builder.Build();
        }
    }
}

        //private PizzaModel[] ConvertToModel(ICollection<PizzaEntity> entities)
        //{
        //    return entities.Select(x => Kunda(x)).ToArray();
        //    var pizzas = new List<PizzaModel>();

        //    foreach (var pizza in entities)
        //    {
        //        builder.SetPizzaType(pizza.PizzaType);
        //        builder.SetCost((int)pizza.PizzaCost);
        //        builder.SetIngrediets(IngredientType.Mozzarela, pizza.Mozzarela);
        //        builder.SetIngrediets(IngredientType.Gorgonzola, pizza.Gorgonzola);
        //        builder.SetIngrediets(IngredientType.Hermelín, pizza.Hermelin);
        //        builder.SetIngrediets(IngredientType.Vejce, pizza.Vejce);
        //        builder.SetIngrediets(IngredientType.Rukola, pizza.Rukola);
        //        builder.SetIngrediets(IngredientType.Kukřice, pizza.Kukurice);
        //        builder.SetIngrediets(IngredientType.Žížaly, pizza.Zizaly);
        //        builder.SetIngrediets(IngredientType.Losos, pizza.Losos);
        //        pizzas.Add(builder.Build());
        //    }
        //    return pizzas.ToArray();
        //}