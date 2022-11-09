using System.Windows;
using System.Windows.Controls;

namespace EzTool.SDK.WPF.ControlKit.FormKit
{
    public class EzFormHeader : ContentControl
    {
        static EzFormHeader()
        {
            DefaultStyleKeyProperty.OverrideMetadata(
                typeof(EzFormHeader),
                new FrameworkPropertyMetadata(typeof(EzFormHeader)));
        }

    }
}
