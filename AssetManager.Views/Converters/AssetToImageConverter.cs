using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace AssetManager.Views.Converters
{
    public class AssetToImageConverter : IValueConverter
    {
        public Dictionary<Type, string> ImageSources { get; } = new Dictionary<Type, string>();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return ImageSources[value.GetType()];
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
