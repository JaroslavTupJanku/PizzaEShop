using PizzaEShop.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace PizzaEShop.View.Converters
{
    public class IngredientsToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var res = string.Empty;
            if (value is List<Ingredient> Ingrediets)
            {
                Ingrediets.ForEach(x => res = res + $"{x} ");
            }

            return res;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
