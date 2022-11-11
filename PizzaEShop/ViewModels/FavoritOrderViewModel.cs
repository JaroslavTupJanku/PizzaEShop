using PizzaEShop.Core.Enums;
using PizzaEShop.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaEShop.ViewModels
{
    public class FavoritOrderViewModel : IControlViewModel
    {
        public ControlType ControlType => ControlType.FavoritOrderControl;
    }
}
