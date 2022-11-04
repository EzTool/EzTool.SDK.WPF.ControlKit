using EzTool.SDK.WPF.Mask.HumbleObjects;
using EzTool.SDK.WPF.ViewActions.Interface;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzTool.SDK.WPF.ControlKit.DEMO.EzRibbonWindow
{
    public class EzRibbonWindowViewModel : IWindowView
    {

        #region -- 變數宣告 ( Declarations ) --   
        #endregion

        #region -- 建構/解構 ( Constructors/Destructor ) --
        #endregion

        #region -- 事件處理 ( Event Handlers ) --
        #endregion

        #region -- 靜態方法 (Shared Method ) --
        #endregion

        #region -- 方法 ( Public Method ) --
        #endregion

        #region -- 屬性 ( Properties ) --
        #endregion

        #region -- 事件 ( Events ) --
        #endregion

        #region -- 介面實做 ( Implements ) - [IWindowView] --

        public IPresenter Presenter { get; set; }
        public string DTO { get; set; }

        public void ExitView()
        {
            throw new NotImplementedException();
        }

        public void ShowDialog()
        {
            new DispatcherProxy().Invoke(() =>
            {
                new EzRibbonWindowView().ShowDialog();
            });
        }

        #endregion

        #region -- 介面實做 ( Implements ) - [InterfaceName] --
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
