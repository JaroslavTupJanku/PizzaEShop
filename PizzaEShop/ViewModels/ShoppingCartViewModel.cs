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
        public ObservableCollection<PizzaEntity> PizzaEntities { get; } = new();
        public string HOvno { get; } = "HOVNO";
        public ShoppingCartViewModel()
        {
            PizzaEntities.Add(new PizzaEntity(PizzaType.Fungi, DateTime.Now, new List<int> { 1, 2, 3, 4, 5, 6 }, "Purkynova 12"));
            PizzaEntities.Add(new PizzaEntity(PizzaType.Fungi, DateTime.Now, new List<int> { 1, 2, 3, 4, 5, 6 }, "Purkynova 12"));
        }
    }
}
