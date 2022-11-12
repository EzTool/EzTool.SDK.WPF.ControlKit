using EzTool.SDK.WPF.MVVM.Interfaces;
using EzTool.SDK.WPF.Unicorn.BaseObjects;
using EzTool.SDK.WPF.ViewActions.Enums;
using EzTool.SDK.WPF.ViewActions;
using EzTool.SDK.WPF.ControlKit.DEMO.Views.NormalRibbonWindow;

namespace EzTool.SDK.WPF.ControlKit.DEMO.Views.Main.Events
{
    public class MainViewPopupNormalRibbonWindowEvent : BaseViewEvent<MainViewContext>
    {
        public override IEventResponse Execute()
        {
            var objRequire = DisplayRequire.Initial(
               ViewActionType.PopupWindow,
               typeof(NormalRibbonWindowViewModel).FullName);

            ViewContext.Presenter.OnViewEvent(objRequire);
            return base.Execute();
        }
    }
}
