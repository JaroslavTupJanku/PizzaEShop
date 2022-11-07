using PizzaEShop.Core;
using PizzaEShop.Core.Enums;
using PizzaEShop.Data.Entity;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaEShop.ViewModels
{
    public class ShoppingCartViewModel
    {
        private readonly PizzaManager manager;

        public ObservableCollection<OrderEntity> OrderEntities { get; private set; } = null!;
        public string HOvno { get; } = "HOVNO";

        public ShoppingCartViewModel(PizzaManager manager)
        {
            this.manager = manager;
            AddTest();
            UpdateList();
        }

        public void AddTest()
        {

            var manager = new PizzaManager();

            var entity = new OrderEntity()
            {
                Address = "BAddress",
                Time = DateTime.Now,
                Pizzas = new List<PizzaEntity>()
                {
                    new PizzaEntity()
                    {
                        Gorgonzola = 2
                    }
                }
            };
            _ = Task.Run(async () => await manager.PostOrder(entity));
        }

        public  void UpdateList()
        {
            var list = Task.Run(async () => await manager.GetOrders());
            OrderEntities = new ObservableCollection<OrderEntity>(test);
        }

    }
}
