using EzTool.SDK.WPF.ControlKit.DEMO.Views.EzForm;
using EzTool.SDK.WPF.MVVM.Interfaces;
using EzTool.SDK.WPF.Unicorn.BaseObjects;
using EzTool.SDK.WPF.ViewActions;

namespace EzTool.SDK.WPF.ControlKit.DEMO.Views.Main.Events
{
    public class MainViewShowFormExampleEvent : BaseViewEvent<MainViewContext>
    {
        public override IEventResponse Execute()
        {
            var sOperator = typeof(EzFormViewModel).FullName;
            var objRequire = DisplayRequire.Initial( ViewActions.Enums.ViewActionType.Dialog, sOperator, ViewContext.HashCode);

            ViewContext.Presenter.OnViewEvent(objRequire);

            return base.Execute();
        }
    }
}
