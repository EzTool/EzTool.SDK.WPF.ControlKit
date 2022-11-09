using EzTool.SDK.WPF.MVVM.Interfaces;
using EzTool.SDK.WPF.Unicorn.BaseObjects;
using EzTool.SDK.WPF.Unicorn.Extension;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzTool.SDK.WPF.ControlKit.DEMO.EzRibbonWindow.Events
{
    public class EzRibbonWindowCopyEven : BaseViewEvent<EzRibbonWindowViewContext>
    {
        public override IEventResponse Execute()
        {
            ViewContext.Presenter.ShowNotify("hi", ViewContext.HashCode);
            return base.Execute();
        }
    }
}
