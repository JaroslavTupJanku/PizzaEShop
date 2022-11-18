using PizzaEShop.Core.Enums;
using PizzaEShop.Core.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace PizzaEShop.View.Converters
{
    public class FullAddressConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var item = (OrderDTO)value;
            return item.Address == string.Empty || item.Address == string.Empty || item.Address == string.Empty
                ? "Do vlastních rukou"
                : $"{item.Address} {item.City}, {item.PSC}";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
