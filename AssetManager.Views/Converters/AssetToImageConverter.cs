using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace AssetManager.Views.Converters
{
    public class AssetToImageConverter : IValueConverter
    {
        public ImageSource FallbackValue { get; set; }
        public Dictionary<Type, ImageSource> ImageSources { get; } = new Dictionary<Type, ImageSource>();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return null;
            if (ImageSources.TryGetValue(value.GetType(), out ImageSource imageSource)) return imageSource;
            return FallbackValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
