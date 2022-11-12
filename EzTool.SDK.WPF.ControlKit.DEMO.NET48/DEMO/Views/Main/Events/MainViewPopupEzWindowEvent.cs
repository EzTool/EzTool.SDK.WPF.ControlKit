using EzTool.SDK.WPF.ControlKit.DEMO.Views.EzWindow;
using EzTool.SDK.WPF.MVVM.Interfaces;
using EzTool.SDK.WPF.Unicorn.BaseObjects;
using EzTool.SDK.WPF.ViewActions;
using EzTool.SDK.WPF.ViewActions.Enums;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzTool.SDK.WPF.ControlKit.DEMO.Views.Main.Events
{
    public class MainViewPopupEzWindowEvent : BaseViewEvent<MainViewContext>
    {
        public override IEventResponse Execute()
        {
            var objRequire = DisplayRequire.Initial(
                ViewActionType.PopupWindow, 
                typeof(EzWindowViewModel).FullName);

            ViewContext.Presenter.OnViewEvent(objRequire);
            return base.Execute();
        }
    }
}
