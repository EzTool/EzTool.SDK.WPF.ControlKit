using EzTool.SDK.WPF.MVVM.Interfaces;
using EzTool.SDK.WPF.Unicorn.BaseObjects;
using EzTool.SDK.WPF.Unicorn.Extension;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzTool.SDK.WPF.ControlKit.DEMO.EzWindow.Events
{
    public class EzWindowViewFunctionBarNotifyMsgEvent : BaseViewEvent<EzWindowViewContext>
    {
        public override IEventResponse Execute()
        {
            var objResult = ViewContext.Presenter.ShowNotify("test msg", ViewContext.HashCode);
            return base.Execute();
        }
    }
}
