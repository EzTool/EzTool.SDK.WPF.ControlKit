using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace EzTool.SDK.WPF.Utilities.Converters
{
    public class EmptyObjectToVisibilityConverter : DependencyObject, IValueConverter
    {

        #region -- 建構/解構 ( Constructors/Destructor ) --

        public EmptyObjectToVisibilityConverter()
        {
            EmptyValue = Visibility.Collapsed;
            NotEmptyValue = Visibility.Visible;
        }

        #endregion

        #region -- 屬性 ( Properties ) --

        #region EmptyValue

        public static readonly DependencyProperty EmptyValueProperty =
            DependencyProperty.Register(nameof(EmptyValue), typeof(Visibility), typeof(EmptyObjectToVisibilityConverter), new PropertyMetadata(default(Visibility)));

        public Visibility EmptyValue
        {
            get => (Visibility)GetValue(EmptyValueProperty);
            set => SetValue(EmptyValueProperty, value);
        }

        #endregion

        #region NotEmptyValue

        public static readonly DependencyProperty NotEmptyValueProperty =
            DependencyProperty.Register(nameof(NotEmptyValue), typeof(Visibility), typeof(EmptyObjectToVisibilityConverter), new PropertyMetadata(default(Visibility)));

        public Visibility NotEmptyValue
        {
            get => (Visibility)GetValue(NotEmptyValueProperty);
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
