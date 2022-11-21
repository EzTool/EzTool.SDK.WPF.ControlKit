using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EzTool.SDK.WPF.ControlKit.RadioButtonKit
{

    public class EzRadioButton : RadioButton
    {

        #region -- 建構/解構 ( Constructors/Destructor ) --

        public EzRadioButton()
        {
            DefaultStyleKey = typeof(EzRadioButton);
        }

        #endregion

        #region -- 屬性 ( Properties ) --

        #region OptionMarkSize

        public int OptionMarkSize
        {
            get => (int)GetValue(OptionMarkSizeProperty);
            set => SetValue(OptionMarkSizeProperty, value);
        }

        public static readonly DependencyProperty OptionMarkSizeProperty =
            DependencyProperty.Register(
                nameof(OptionMarkSize),
                typeof(int),
                typeof(EzRadioButton), new FrameworkPropertyMetadata(10));

        #endregion 

        #region OptionMarkFill

        public Brush OptionMarkFill
        {
            get => (Brush)GetValue(OptionMarkFillProperty);
            set => SetValue(OptionMarkFillProperty, value);
        }

        public static readonly DependencyProperty OptionMarkFillProperty =
            DependencyProperty.Register(
                nameof(OptionMarkFill),
                typeof(Brush),
                typeof(EzRadioButton), new FrameworkPropertyMetadata(new SolidColorBrush(Colors.Black)));

        #endregion 

        #endregion

    }
}
