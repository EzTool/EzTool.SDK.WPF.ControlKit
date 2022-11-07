using System.Windows;
using System.Windows.Controls;

namespace EzTool.SDK.WPF.ControlKit.PageTitleKit
{
    public class EzPageTitle : ContentControl
    {
        static EzPageTitle()
        {
            DefaultStyleKeyProperty.OverrideMetadata(
                typeof(EzPageTitle), 
                new FrameworkPropertyMetadata(typeof(EzPageTitle)));
        }
    }
}
