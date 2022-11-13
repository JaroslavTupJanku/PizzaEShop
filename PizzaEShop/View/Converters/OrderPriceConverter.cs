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
    public class OrderPriceConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var price = 0;
            if (value is ICollection<PizzaDTO> pizzas)
            {
                foreach(var pizza in pizzas)
                {
                    price = pizza.Price;
                    pizza.Ingrediets.ToList().ForEach(x => price += (int)x.Key * x.Value);
                }
            }

            return $"{price} Kč";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
