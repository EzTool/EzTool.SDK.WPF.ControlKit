using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows;

namespace EzTool.SDK.WPF.Utilities.Converters
{
    public class NullToValueConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
            {
                return parameter;
            }

            return DependencyProperty.UnsetValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value == null;
        }
    }
}
