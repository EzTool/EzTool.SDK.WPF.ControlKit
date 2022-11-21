using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace EzTool.SDK.WPF.ControlKit.CheckBoxKit
{

    public class EzCheckBox : CheckBox
    {
        #region -- 建構/解構 ( Constructors/Destructor ) --

        public EzCheckBox()
        {
            DefaultStyleKey = typeof(EzCheckBox);
        }

        #endregion

        #region -- 屬性 ( Properties ) --

        #region CheckMarkSize

        public int CheckMarkSize
        {
            get => (int)GetValue(CheckMarkSizeProperty);
            set => SetValue(CheckMarkSizeProperty, value);
        }

        public static readonly DependencyProperty CheckMarkSizeProperty =
            DependencyProperty.Register(
                nameof(CheckMarkSize),
                typeof(int),
                typeof(EzCheckBox), new FrameworkPropertyMetadata(16));

        #endregion 

        #region CheckMarkFill

        public Brush CheckMarkFill
        {
            get => (Brush)GetValue(CheckMarkFillProperty);
            set => SetValue(CheckMarkFillProperty, value);
        }

        public static readonly DependencyProperty CheckMarkFillProperty =
            DependencyProperty.Register(
                nameof(CheckMarkFill),
                typeof(Brush),
                typeof(EzCheckBox), new FrameworkPropertyMetadata(new SolidColorBrush(Colors.Black)));

        #endregion 

        #endregion
    }
}
