using System;
using System.Windows;
using System.Windows.Data;

namespace EzTool.SDK.WPF.Utilities.Converters
{
    public class EnumToBoolConverter : IValueConverter
    {

        #region -- 介面實做 ( Implements ) - [IValueConverter] --

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var sParameter = parameter.ToString();

            if (Enum.IsDefined(value.GetType(), value) == false)
                return DependencyProperty.UnsetValue;

            object parameterValue = Enum.Parse(value.GetType(), sParameter);

            return parameterValue.Equals(value);
        }

        public object ConvertBack(object value, Type targetType, object pi_objParameter, System.Globalization.CultureInfo culture)
        {
            var sParameter = pi_objParameter.ToString();
            var objReturn = Enum.Parse(targetType, sParameter);

            if (objReturn != null)
            {
                return objReturn;
            }
            else
            {
                return DependencyProperty.UnsetValue;
            }
        }

        #endregion

    }
}
