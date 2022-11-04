using EzTool.SDK.WPF.ControlKit.DEMO.EzWindow;
using EzTool.SDK.WPF.MVVM.Interfaces;
using EzTool.SDK.WPF.Unicorn.BaseObjects;
using EzTool.SDK.WPF.ViewActions.Enums;
using EzTool.SDK.WPF.ViewActions;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EzTool.SDK.WPF.ControlKit.DEMO.EzRibbonWindow;

namespace EzTool.SDK.WPF.ControlKit.DEMO.Main.Events
{
    public class MainViewPopupEzRibbonWindowEvent : BaseViewEvent<MainViewContext>
    {
        public override IEventResponse Execute()
        {
            var objRequire = DisplayRequire.Initial(
               ViewActionType.PopupWindow,
               typeof(EzRibbonWindowViewModel).FullName);

            ViewContext.Presenter.OnViewEvent(objRequire);
            return base.Execute();
        }
    }
}
