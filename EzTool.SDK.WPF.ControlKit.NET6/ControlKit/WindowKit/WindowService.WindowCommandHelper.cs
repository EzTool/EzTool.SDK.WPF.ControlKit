using System.Windows.Input;
using System.Windows.Media;
using System.Windows;

namespace EzTool.SDK.WPF.ControlKit.WindowKit
{
    public partial class WindowService
    {
        private class WindowCommandHelper
        {
            #region -- 變數宣告 ( Declarations ) --   

            private readonly Window _window;

            #endregion

            #region -- 建構/解構 ( Constructors/Destructor ) --

            public WindowCommandHelper(Window window)
            {
                _window = window;
            }

            #endregion

            #region -- 事件處理 ( Event Handlers ) --

            private void OnCanResizeWindow(object sender, CanExecuteRoutedEventArgs e)
            {
                e.CanExecute = _window.ResizeMode == ResizeMode.CanResize || _window.ResizeMode == ResizeMode.CanResizeWithGrip;
            }

            private void OnCanMinimizeWindow(object sender, CanExecuteRoutedEventArgs e)
            {
                e.CanExecute = _window.ResizeMode != ResizeMode.NoResize;
            }

            private void OnCloseWindow(object sender, ExecutedRoutedEventArgs e)
            {
                _window.Close();
            }

            private void OnMaximizeWindow(object sender, ExecutedRoutedEventArgs e)
            {
                SystemCommands.MaximizeWindow(_window);
                e.Handled = true;
            }

            private void OnMinimizeWindow(object sender, ExecutedRoutedEventArgs e)
            {
                SystemCommands.MinimizeWindow(_window);
                e.Handled = true;
            }

            private void OnRestoreWindow(object sender, ExecutedRoutedEventArgs e)
            {
                SystemCommands.RestoreWindow(_window);
                e.Handled = true;
            }

            private void OnShowSystemMenu(object sender, ExecutedRoutedEventArgs e)
            {
                Point point = _window.PointToScreen(new Point(0, 0));
                var dipScale = WindowParameters.DpiX / 96d;
                if (_window.WindowState == WindowState.Maximized)
                {
                    // 因为不想在最大化时改变标题高度，所以这里的计算方式和标准计算方式不一样
                    point.X += (SystemParameters.WindowNonClientFrameThickness.Left + WindowParameters.PaddedBorderThickness.Left) * dipScale;
                    point.Y += (SystemParameters.WindowNonClientFrameThickness.Top +
                                WindowParameters.PaddedBorderThickness.Top +
                                SystemParameters.WindowResizeBorderThickness.Top -
                                _window.BorderThickness.Top)
                                * dipScale;
                }
                else
                {
                    point.X += _window.BorderThickness.Left * dipScale;
                    point.Y += SystemParameters.WindowNonClientFrameThickness.Top * dipScale;
                }

                CompositionTarget compositionTarget = PresentationSource.FromVisual(_window).CompositionTarget;
                SystemCommands.ShowSystemMenu(_window, compositionTarget.TransformFromDevice.Transform(point));
                e.Handled = true;
            }

            #endregion

            #region -- 方法 ( Public Method ) --

            public void ActiveCommands()
            {
                _window.CommandBindings.Add(new CommandBinding(SystemCommands.CloseWindowCommand, OnCloseWindow));
                _window.CommandBindings.Add(new CommandBinding(SystemCommands.MaximizeWindowCommand, OnMaximizeWindow, OnCanResizeWindow));
                _window.CommandBindings.Add(new CommandBinding(SystemCommands.MinimizeWindowCommand, OnMinimizeWindow, OnCanMinimizeWindow));
                _window.CommandBindings.Add(new CommandBinding(SystemCommands.RestoreWindowCommand, OnRestoreWindow, OnCanResizeWindow));
                _window.CommandBindings.Add(new CommandBinding(SystemCommands.ShowSystemMenuCommand, OnShowSystemMenu));
            }

            #endregion

        }

    }
}
