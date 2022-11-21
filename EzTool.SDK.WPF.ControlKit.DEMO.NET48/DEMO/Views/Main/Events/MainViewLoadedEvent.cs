using EzTool.SDK.WPF.MVVM.Interfaces;
using EzTool.SDK.WPF.Unicorn.BaseObjects;
using EzTool.SDK.WPF.Unicorn.Extension;

namespace EzTool.SDK.WPF.ControlKit.DEMO.Views.Main.Events
{
    public class MainViewLoadedEvent : BaseViewEvent<MainViewContext>
    {
        public override IEventResponse Execute()
        {
            ViewContext.Presenter.ChangeWindowTitle("易用工具控項集-範例");
            return base.Execute();
        }
    }
}
