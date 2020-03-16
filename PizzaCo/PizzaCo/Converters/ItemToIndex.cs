using System;
using Xamarin.Forms;
using PizzaCo.Models;
using System.Collections.ObjectModel;
using System.Collections;
using System.Globalization;

namespace PizzaCo.Converters
{
    public class ItemToIndex : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if(value != null && value.GetType() == typeof(PizzaFavorite))
            {
                var listView = parameter as ListView;
                var list = listView.ItemsSource as IList;
                return list.IndexOf(value) + 1;

            }
            return null;

        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
