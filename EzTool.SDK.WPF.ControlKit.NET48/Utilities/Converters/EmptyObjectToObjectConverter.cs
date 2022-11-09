using System;
using System.Windows.Data;
using System.Windows;
using System.Globalization;

namespace EzTool.SDK.WPF.Utilities.Converters
{
    public class EmptyObjectToObjectConverter : DependencyObject, IValueConverter
    {

        #region -- 屬性 ( Properties ) --

        #region EmptyValue

        public static readonly DependencyProperty EmptyValueProperty =
            DependencyProperty.Register(nameof(EmptyValue), typeof(object), 
                typeof(EmptyObjectToObjectConverter), 
                new PropertyMetadata(default(object)));

        public object EmptyValue
        {
            get => (object)GetValue(EmptyValueProperty);
            set => SetValue(EmptyValueProperty, value);
        }

        #endregion

        #region NotEmptyValue

        public static readonly DependencyProperty NotEmptyValueProperty =
            DependencyProperty.Register(
                nameof(NotEmptyValue), 
                typeof(object), 
                typeof(EmptyObjectToObjectConverter), 
                new PropertyMetadata(default(object)));

        public object NotEmptyValue
        {
            get => (object)GetValue(NotEmptyValueProperty);
            set => SetValue(NotEmptyValueProperty, value);
        }

        #endregion

        #endregion

        #region -- 介面實做 ( Implements ) - [IValueConverter] --

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return EmptyValue;
            else
                return NotEmptyValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}
