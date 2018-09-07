using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Data;

namespace AssetManager.Views.Converters
{
    public class AssetToImageConverter : IValueConverter
    {
        public string FallbackValue { get; set; }
        public Dictionary<Type, string> ImageSources { get; } = new Dictionary<Type, string>();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return null;
            if (ImageSources.TryGetValue(value.GetType(), out string s)) return s;
            return FallbackValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
