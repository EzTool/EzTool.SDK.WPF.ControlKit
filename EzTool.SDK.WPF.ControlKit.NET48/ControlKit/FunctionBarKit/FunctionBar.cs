using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace EzTool.SDK.WPF.ControlKit.FunctionBarKit
{
    public class FunctionBar : HeaderedItemsControl
    {
        #region -- 建構/解構 ( Constructors/Destructor ) --

        public FunctionBar() { }

        #endregion

        #region -- 屬性 ( Properties ) --

        public ObservableCollection<object> Options { get; } = new ObservableCollection<object>();

        #endregion

    }
}
