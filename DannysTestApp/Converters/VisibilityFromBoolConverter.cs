using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace DannysTestApp.Converters
{
    public class VisibilityFromBoolConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            var boolValue = (bool)value;
            return boolValue ? Visibility.Visible : Visibility.Collapsed;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            var visibility = (Visibility)value;
            return visibility == Visibility.Visible;
        }
    }
}
