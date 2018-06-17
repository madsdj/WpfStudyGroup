using System;
using System.Collections.Immutable;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

namespace AssetManager.Views.Converters
{
    public class ObjectToPropertiesConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return null;

            return value
                .GetType()
                .GetProperties()
                .OrderBy(pi => pi.Name)
                .Select(pi => new { pi.Name, Value = pi.GetValue(value) })
                .ToImmutableList();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
