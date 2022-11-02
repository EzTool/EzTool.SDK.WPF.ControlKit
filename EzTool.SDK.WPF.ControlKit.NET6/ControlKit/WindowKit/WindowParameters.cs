using EzTool.SDK.WPF.Utilities.Common;

using System.Reflection;
using System.Security;
using System.Windows;

namespace EzTool.SDK.WPF.ControlKit.WindowKit
{
    public static class WindowParameters
    {
        #region -- 變數宣告 ( Declarations ) --   

        private static Thickness? _paddedBorderThickness;

        private static double? _ribbonContextualTabGroupHeight;

        #endregion

        #region -- 屬性 ( Properties ) --

        public static Thickness PaddedBorderThickness
        {
            [SecurityCritical]
            get
            {
                if (_paddedBorderThickness == null)
                {
                    var paddedBorder = NativeMethods.GetSystemMetrics(SM.CXPADDEDBORDER);
                    var dpi = GetDpi();
                    Size frameSize = new Size(paddedBorder, paddedBorder);
                    Size frameSizeInDips = DpiHelper.DeviceSizeToLogical(frameSize, dpi / 96.0, dpi / 96.0);
                    _paddedBorderThickness = new Thickness(frameSizeInDips.Width, frameSizeInDips.Height, frameSizeInDips.Width, frameSizeInDips.Height);
                }

                return _paddedBorderThickness.Value;
            }
        }
        public static double RibbonContextualTabGroupHeight
        {

            get
            {
                if (_ribbonContextualTabGroupHeight == null)
                {
                    _ribbonContextualTabGroupHeight = SystemParameters.WindowNonClientFrameThickness.Top + (1d * GetDpi() / 96.0);
                }

                return _ribbonContextualTabGroupHeight.Value;
            }
        }
        public static double GetDpi()
        {
            var dpiXProperty = typeof(SystemParameters).GetProperty("DpiX", BindingFlags.NonPublic | BindingFlags.Static);

            var dpiX = (int)dpiXProperty.GetValue(null, null);
            return dpiX;
        }

        #endregion

    }
}
