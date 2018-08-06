using System;
using System.Collections.Generic;
using System.Windows;
using AssetManager.ViewModels;

namespace AssetManager.Views
{
    public class ColorSchemeManager : IColorSchemeManager
    {
        private readonly Dictionary<ColorScheme, ResourceDictionary> _colorSchemes;

        public ColorSchemeManager()
        {
            _colorSchemes = new Dictionary<ColorScheme, ResourceDictionary>
            {
                { ColorScheme.Dark, new ResourceDictionary { Source = new Uri("/AssetManager.Views;component/ColorSchemes/Dark.xaml", UriKind.RelativeOrAbsolute) } },
                { ColorScheme.Light, new ResourceDictionary { Source = new Uri("/AssetManager.Views;component/ColorSchemes/Light.xaml", UriKind.RelativeOrAbsolute) } },
                { ColorScheme.Blue, new ResourceDictionary { Source = new Uri("/AssetManager.Views;component/ColorSchemes/Blue.xaml", UriKind.RelativeOrAbsolute) } },
                { ColorScheme.Pink, new ResourceDictionary { Source = new Uri("/AssetManager.Views;component/ColorSchemes/Pink.xaml", UriKind.RelativeOrAbsolute) } },
            };

            Application.Current.Resources.MergedDictionaries.Add(_colorSchemes[_current]);
        }

        private ColorScheme _current = ColorScheme.Light;
        public ColorScheme Current
        {
            get { return _current; }
            set
            {
                if (_current != value)
                {
                    Application.Current.Resources.MergedDictionaries.Remove(_colorSchemes[_current]);
                    _current = value;
                    Application.Current.Resources.MergedDictionaries.Add(_colorSchemes[_current]);
                }
            }
        }
    }
}
