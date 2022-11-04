using System.Windows;
using System.Windows.Controls.Ribbon;
using System.Windows.Media;

namespace EzTool.SDK.WPF.ControlKit.WindowKit
{
    [StyleTypedProperty(Property = nameof(RibbonStyle), StyleTargetType = typeof(Ribbon))]
    public class EzRibbonWindow : RibbonWindow
    {

        #region -- 建構/解構 ( Constructors/Destructor ) --

        public EzRibbonWindow()
        {
            DefaultStyleKey = typeof(EzRibbonWindow);
        }

        #endregion

        #region -- 事件處理 ( Event Handlers ) --

        #region OnRibbonStyleChanged

        /// <summary>
        /// 處理 RibbonStyle 相依屬性改變事件。
        /// </summary>
        /// <param name="oldValue">RibbonStyle 屬性的原值。</param>
        /// <param name="newValue">RibbonStyle 屬性的新值。</param>
        protected virtual void OnRibbonStyleChanged(Style oldValue, Style newValue)
        {
            Resources.Remove(typeof(Ribbon));
            if (newValue != null)
            {
                Resources.Add(typeof(Ribbon), newValue);
            }
        }

        private static void OnRibbonStyleChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            var oldValue = (Style)args.OldValue;
            var newValue = (Style)args.NewValue;

            if (oldValue != newValue && obj is EzRibbonWindow objWindow)
            {
                objWindow?.OnRibbonStyleChanged(oldValue, newValue);
            }
        }

        #endregion

        #region OnFunctionBarChanged

        /// <summary>
        /// 處理 FunctionBar 相依屬性異動事件。
        /// </summary>
        /// <param name="oldValue">FunctionBar 屬性的原值。</param>
        /// <param name="newValue">FunctionBar 屬性的新值。</param>
        protected virtual void OnFunctionBarChanged(EzWindowFunctionBar oldValue, EzWindowFunctionBar newValue) { }

        private static void OnFunctionBarChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            var oldValue = (EzWindowFunctionBar)args.OldValue;
            var newValue = (EzWindowFunctionBar)args.NewValue;

            if (oldValue != newValue && obj is EzRibbonWindow objWindow)
            {
                objWindow?.OnFunctionBarChanged(oldValue, newValue);
            }
        }

        #endregion

        #endregion

        #region -- 屬性 ( Properties ) --

        #region RibbonStyle

        public Style RibbonStyle
        {
            get => (Style)GetValue(RibbonStyleProperty);
            set => SetValue(RibbonStyleProperty, value);
        }

        public static readonly DependencyProperty RibbonStyleProperty =
            DependencyProperty.Register(nameof(RibbonStyle), typeof(Style), typeof(EzRibbonWindow), new PropertyMetadata(default(Style), OnRibbonStyleChanged));

        #endregion

        #region TitleBackground

        public Brush TitleBarBackground
        {
            get { return (Brush)GetValue(TitleBackgroundProperty); }
            set { SetValue(TitleBackgroundProperty, value); }
        }

        public static readonly DependencyProperty TitleBackgroundProperty =
            DependencyProperty.Register(nameof(TitleBarBackground),
                typeof(Brush), typeof(EzRibbonWindow),
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
                typeof(EzRibbonWindow), new PropertyMetadata(default(EzWindowFunctionBar), OnFunctionBarChanged));

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
                typeof(EzRibbonWindow), new FrameworkPropertyMetadata(false));

        public static readonly DependencyProperty IsNonClientActiveProperty =
            IsNonClientActivePropertyKey.DependencyProperty;

        #endregion

        #endregion

    }
}
