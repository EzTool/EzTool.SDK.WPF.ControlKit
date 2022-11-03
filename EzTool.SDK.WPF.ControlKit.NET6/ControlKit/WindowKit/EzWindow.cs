using System.Windows;

namespace EzTool.SDK.WPF.ControlKit.WindowKit
{
    public class EzWindow : Window
    {
        #region -- 建構/解構 ( Constructors/Destructor ) --

        public EzWindow()
        {
            DefaultStyleKey = typeof(EzWindow);
        }

        #endregion

        #region -- 屬性 ( Properties ) --

        #region FunctionBar

        //public WindowFunctionBar FunctionBar
        //{
        //    get => (WindowFunctionBar)GetValue(FunctionBarProperty);
        //    set => SetValue(FunctionBarProperty, value);
        //}

        //public static readonly DependencyProperty FunctionBarProperty =
        //  DependencyProperty.Register(nameof(FunctionBar), typeof(WindowFunctionBar), typeof(EzWindow), new PropertyMetadata(default(WindowFunctionBar), OnFunctionBarChanged));

        #endregion

        #region IsNonClientActive

        public bool IsNonClientActive
        {
            get
            {
                return (bool)GetValue(IsNonClientActiveProperty);
            }
        }

        private static readonly DependencyPropertyKey IsNonClientActivePropertyKey =
            DependencyProperty.RegisterReadOnly(
                "IsNonClientActive", typeof(bool), 
                typeof(EzWindow), new FrameworkPropertyMetadata(false));

        public static readonly DependencyProperty IsNonClientActiveProperty = 
            IsNonClientActivePropertyKey.DependencyProperty;

        #endregion

        #endregion

    }
}
