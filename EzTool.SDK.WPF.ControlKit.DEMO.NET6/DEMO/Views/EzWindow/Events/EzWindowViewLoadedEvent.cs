using EzTool.SDK.WPF.Mask.HumbleObjects;
using EzTool.SDK.WPF.MVVM.Interfaces;
using EzTool.SDK.WPF.Unicorn.BaseObjects;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzTool.SDK.WPF.ControlKit.DEMO.Views.EzWindow.Events
{
    public class EzWindowViewLoadedEvent : BaseViewEvent<EzWindowViewContext>
    {
        public override IEventResponse Execute()
        {
            new DispatcherProxy().Invoke(() =>
            {
                ViewContext.MenuItems.Add(new MenuItemContext()
                {
                    Header = $@"Item_Loaded"
                });
            });

            return base.Execute();
        }
    }
}
