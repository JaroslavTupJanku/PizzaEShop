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
        private UserControl[] userControls = new UserControl[]
        {
            new FavoritOrderControl(),
            new OrderHistoryControl(),
            new PizzaMenuControl(),
            new ShoppingCartControl(),
        };

        public void SetPizzaControl(ControlType type)
        {
            var control = userControls.Where(x => (ControlType)x.Tag == type).FirstOrDefault()
                ?? throw new Exception("UserControl has not been found.");

            OnUserControlChanged?.Invoke(this, control);
        }


        public event EventHandler<UserControl>? OnUserControlChanged;
    }
}
