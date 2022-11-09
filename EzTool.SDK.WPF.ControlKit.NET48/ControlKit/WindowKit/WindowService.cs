using System.Windows.Input;
using System.Windows;

namespace EzTool.SDK.WPF.ControlKit.WindowKit
{
    public partial class WindowService
    {

        #region -- 事件處理 ( Event Handlers ) --

        private static void OnIsBindingToSystemCommandsChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            var bIsNewValue = (bool)args.NewValue;

            if (bIsNewValue && obj is Window window)
            {
                new WindowCommandHelper(window).ActiveCommands();
            }
        }

        private static void OnIsDragMoveEnabledChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            var bOldValue = (bool)args.OldValue;
            var bNewValue = (bool)args.NewValue;

            if (bOldValue != bNewValue && obj is Window objWindow)
            {
                if (bNewValue)
                    objWindow.MouseLeftButtonDown += OnWindowMouseLeftButtonDown;
                else
                    objWindow.MouseLeftButtonDown -= OnWindowMouseLeftButtonDown;
            }
        }

        private static void OnWindowMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ButtonState == MouseButtonState.Pressed && sender is Window objWindow)
            {
                objWindow.DragMove();
            }
        }

        #endregion

        #region -- 屬性 ( Properties ) --

        #region IsBindingToSystemCommands

        /// <summary>
        /// IsBindingToSystemCommands 依賴屬性。
        /// </summary>
        public static readonly DependencyProperty IsBindingToSystemCommandsProperty =
            DependencyProperty.RegisterAttached("IsBindingToSystemCommands",
                typeof(bool), typeof(WindowService),
                new PropertyMetadata(default(bool), OnIsBindingToSystemCommandsChanged));

        /// <summary>
        /// 取得指定物件的 IsBindingToSystemCommands 依賴屬性的值。
        /// </summary>
        /// <param name="obj">待讀取屬性的目標物件。</param>
        /// <returns>讀取 IsBindingToSystemCommands 依賴屬性的值。</returns>
        public static bool GetIsBindingToSystemCommands(Window obj) => (bool)obj.GetValue(IsBindingToSystemCommandsProperty);

        /// <summary>
        /// 設定指定物件的 IsBindingToSystemCommands 依賴屬性的值。
        /// </summary>
        /// <param name="obj">待設定屬性的目標物件。</param>
        /// <param name="value">設定 IsBindingToSystemCommands 依賴屬性的值。</param>
        public static void SetIsBindingToSystemCommands(Window obj, bool value) => obj.SetValue(IsBindingToSystemCommandsProperty, value);

        #endregion

        #region IsDragMoveEnabled

        /// <summary>
        /// IsDragMoveEnabled 依賴屬性。
        /// </summary>
        public static readonly DependencyProperty IsDragMoveEnabledProperty =
            DependencyProperty.RegisterAttached("IsDragMoveEnabled",
                typeof(bool), typeof(WindowService),
                new PropertyMetadata(default(bool), OnIsDragMoveEnabledChanged));

        /// <summary>
        /// 取得指定物件的 IsDragMoveEnabled 依賴屬性的值。
        /// </summary>
        /// <param name="obj">待讀取屬性的目標物件。</param>
        /// <returns>讀取 IsDragMoveEnabled 依賴屬性的值。</returns>
        public static bool GetIsDragMoveEnabled(DependencyObject obj) => (bool)obj.GetValue(IsDragMoveEnabledProperty);

        /// <summary>
        /// 設定指定物件的 IsDragMoveEnabled 依賴屬性的值。
        /// </summary>
        /// <param name="obj">待設定屬性的目標物件。</param>
        /// <param name="value">設定 IsDragMoveEnabled 依賴屬性的值。</param>
        public static void SetIsDragMoveEnabled(DependencyObject obj, bool value) => obj.SetValue(IsDragMoveEnabledProperty, value);

        #endregion

        #endregion

    }
}
