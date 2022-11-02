using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace EzTool.SDK.WPF.Utilities.Converters
{
    public class BoolToObjectConverter : DependencyObject, IValueConverter
    {

        #region -- 屬性 ( Properties ) --

        #region TrueValue

        public static readonly DependencyProperty TrueValueProperty =
            DependencyProperty.Register(nameof(TrueValue), typeof(object), typeof(BoolToObjectConverter), new PropertyMetadata());

        public object TrueValue
        {
            get => (object)GetValue(TrueValueProperty);
            set => SetValue(TrueValueProperty, value);
        }

        #endregion

        #region FalseValue

        public static readonly DependencyProperty FalseValueProperty =
            DependencyProperty.Register(nameof(FalseValue), typeof(object), typeof(BoolToObjectConverter), new PropertyMetadata());

        public object FalseValue
        {
            get => (object)GetValue(FalseValueProperty);
            set => SetValue(FalseValueProperty, value);
        }

        #endregion

        #endregion

        #region -- 介面實做 ( Implements ) - [IValueConverter] --

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var boolValue = value is bool && (bool)value;

            return boolValue ? TrueValue : FalseValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}
