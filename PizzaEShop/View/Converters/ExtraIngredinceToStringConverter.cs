using PizzaEShop.Core.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace PizzaEShop.View.Converters
{
    public class ExtraIngredinceToStringConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var res = string.Empty;
            if (value is Dictionary<IngredientType, int> Ingrediets)
            {
                Ingrediets.ToList().ForEach(x => res += $"+ {x.Value}x {x.Key}, ");
            }

            return res != string.Empty ? res.Remove(res.Length - 2) : res;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
