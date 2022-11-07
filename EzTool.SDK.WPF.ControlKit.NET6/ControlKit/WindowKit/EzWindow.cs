using EzTool.SDK.WPF.ControlKit.FunctionBarKit;

using System.Windows;
using System.Windows.Media;

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

        #region -- 事件處理 ( Event Handlers ) --

        /// <summary>
        /// 處理 FunctionBar 屬性異動事件。
        /// </summary>
        /// <param name="oldValue">FunctionBar 屬性的原值。</param>
        /// <param name="newValue">FunctionBar 屬性的新值。</param>
        protected virtual void OnFunctionBarChanged(EzWindowFunctionBar oldValue, EzWindowFunctionBar newValue) { }
        protected virtual void OnMainFunctionBarChanged(EzWindowFunctionBar oldValue, EzWindowFunctionBar newValue) { }

        private static void OnFunctionBarChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            var oldValue = (EzWindowFunctionBar)args.OldValue;
            var newValue = (EzWindowFunctionBar)args.NewValue;

            if (oldValue != newValue && obj is EzWindow objWindow)
            {
                objWindow?.OnFunctionBarChanged(oldValue, newValue);
            }
        }

        private static void OnMainFunctionBarChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            var oldValue = (EzWindowFunctionBar)args.OldValue;
            var newValue = (EzWindowFunctionBar)args.NewValue;

            if (oldValue != newValue && obj is EzWindow objWindow)
            {
                objWindow?.OnMainFunctionBarChanged(oldValue, newValue);
            }
        }

        #endregion

        #region -- 屬性 ( Properties ) --

        #region TitleBackground

        public Brush TitleBarBackground
        {
            get { return (Brush)GetValue(TitleBackgroundProperty); }
            set { SetValue(TitleBackgroundProperty, value); }
        }

        public static readonly DependencyProperty TitleBackgroundProperty =
            DependencyProperty.Register(nameof(TitleBarBackground),
                typeof(Brush), typeof(EzWindow),
                new FrameworkPropertyMetadata(SystemColors.ActiveBorderBrush));

        #endregion

        #region FunctionBar

        public EzWindowFunctionBar FunctionBar
        {
            get => (EzWindowFunctionBar)GetValue(FunctionBarProperty);
            set => SetValue(FunctionBarProperty, value);
        }

        public static readonly DependencyProperty FunctionBarProperty =
            DependencyProperty.Register(
                nameof(FunctionBar),
                typeof(EzWindowFunctionBar),
                typeof(EzWindow), new PropertyMetadata(default(EzWindowFunctionBar), OnFunctionBarChanged));

        #endregion

        #region MainFunctionBar

        public EzWindowFunctionBar MainFunctionBar
        {
            get => (EzWindowFunctionBar)GetValue(MainFunctionBarProperty);
            set => SetValue(MainFunctionBarProperty, value);
        }

        public static readonly DependencyProperty MainFunctionBarProperty =
            DependencyProperty.Register(
                nameof(MainFunctionBar),
                typeof(EzWindowFunctionBar),
                typeof(EzWindow), new PropertyMetadata(default(EzWindowFunctionBar), OnMainFunctionBarChanged));

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
