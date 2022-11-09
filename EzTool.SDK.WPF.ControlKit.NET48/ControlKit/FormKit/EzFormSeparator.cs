using System.Windows.Controls;

namespace EzTool.SDK.WPF.ControlKit.FormKit
{
    public class EzFormSeparator : Separator
    {
        public EzFormSeparator()
        {
            DefaultStyleKey = typeof(EzFormSeparator);
            EzForm.SetIsItemItsOwnContainer(this, true);
        }
    }
}
