using System.Windows;
using System.Windows.Input;

namespace EzTool.SDK.WPF.Utilities.Common
{
    public class FocusService
    {

        #region -- 事件處理 ( Event Handlers ) --

        private static void OnIsAutoFocusChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            var oldValue = (bool)args.OldValue;
            var newValue = (bool)args.NewValue;
            
            if (oldValue != newValue && obj is FrameworkElement objElement)
            {
                objElement.Loaded -= OnTargetLoaded;
                if(newValue)
                {
                    objElement.Loaded += OnTargetLoaded;
                }
            }
        }

        private static void OnTargetLoaded(object sender, RoutedEventArgs e)
        {
            var element = sender as FrameworkElement;
            if (System.ComponentModel.DesignerProperties.GetIsInDesignMode(element))
                return;

            var request = new TraversalRequest(FocusNavigationDirection.Next);
            element.MoveFocus(request);
        }

        #endregion

        #region -- 屬性 ( Properties ) --

        #region IsAutoFocus

        public static bool GetIsAutoFocus(DependencyObject obj) => (bool)obj.GetValue(IsAutoFocusProperty);
        public static void SetIsAutoFocus(DependencyObject obj, bool value) => obj.SetValue(IsAutoFocusProperty, value);
        public static readonly DependencyProperty IsAutoFocusProperty =
            DependencyProperty.RegisterAttached(
                "IsAutoFocus",
                typeof(bool),
                typeof(FocusService), new PropertyMetadata(default(bool), OnIsAutoFocusChanged));

        #endregion 

        #endregion

    }
}
