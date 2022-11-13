using PizzaEShop.Core.Enums;
using PizzaEShop.View.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PizzaEShop.Models
{
    public class ControlProvider
    {
        public void SetPizzaControl(ControlType type)
        {
            UserControl control = type switch 
            {
                ControlType.PizzaMenuControl => new PizzaMenuControl(),
                ControlType.ShoppingCartControl => new ShoppingCartControl(),
                ControlType.FavoritOrderControl => new FavoritOrderControl(),
                ControlType.OrderHistoryContoro => new OrderHistoryControl(),
                _ => throw new Exception("UserControl has not been found.")
            };

            OnUserControlChanged?.Invoke(this, control);
        }

        public event EventHandler<UserControl>? OnUserControlChanged;
    }
}
