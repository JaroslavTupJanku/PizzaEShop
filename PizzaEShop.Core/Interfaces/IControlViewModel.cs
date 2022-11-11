using PizzaEShop.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace PizzaEShop.Core.Interfaces
{
    public interface IControlViewModel
    {
        ControlType ControlType { get; }
    }
}
