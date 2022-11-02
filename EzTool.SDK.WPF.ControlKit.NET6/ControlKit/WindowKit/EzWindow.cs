using System.Windows;

namespace EzTool.SDK.WPF.ControlKit.WindowKit
{
    public class EzWindow : Window
    {


        #region -- 變數宣告 ( Declarations ) --   
        #endregion

        #region -- 建構/解構 ( Constructors/Destructor ) --

        public EzWindow()
        {
            DefaultStyleKey = typeof(EzWindow);
        }

        #endregion

        #region -- 事件處理 ( Event Handlers ) --
        #endregion

        #region -- 靜態方法 (Shared Method ) --
        #endregion

        #region -- 方法 ( Public Method ) --
        #endregion

        #region -- 屬性 ( Properties ) --

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
                typeof(EzWindow), new FrameworkPropertyMetadata(false));

#pragma warning disable SA1202 // Elements must be ordered by access
        public static readonly DependencyProperty IsNonClientActiveProperty = IsNonClientActivePropertyKey.DependencyProperty;
#pragma warning restore SA1202 // Elements must be ordered by access

        #endregion

        #endregion

        #region -- 事件 ( Events ) --
        #endregion

        #region -- 介面實做 ( Implements ) - [InterfaceName] --
        #endregion

        #region -- 私有函式 ( Private Method) --
        #endregion

        #region -- 衍生函式 ( Protected Method ) -- 
        #endregion

        #region -- 抽象函式 ( Abstract Method ) --        
        #endregion
    }
}
