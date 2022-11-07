using System.Windows.Controls;
using System.Windows.Input;

namespace EzTool.SDK.WPF.ControlKit.ScrollViewerKit
{
    public class EzScrollViewer : ScrollViewer
    {

        #region -- 事件處理 ( Event Handlers ) --

        protected override void OnMouseWheel(MouseWheelEventArgs e)
        {
            if (ViewportHeight + VerticalOffset >= ExtentHeight && e.Delta <= 0)
                return;

            if (VerticalOffset == 0 && e.Delta >= 0)
                return;

            base.OnMouseWheel(e);
        }

        #endregion

    }
}
