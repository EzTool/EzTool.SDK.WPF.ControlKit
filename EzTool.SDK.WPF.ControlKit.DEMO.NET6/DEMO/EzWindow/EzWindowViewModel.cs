using EzTool.SDK.WPF.Unicorn.HumbleObjects;
using EzTool.SDK.WPF.ViewActions.Interface;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzTool.SDK.WPF.ControlKit.DEMO.EzWindow
{
    public class EzWindowViewModel : IWindowView
    {
        public IPresenter Presenter { get; set; }
        public string DTO { get; set; }

        public void ExitView()
        {
            
        }

        public void ShowDialog()
        {
            new DispatcherProxy().Invoke(() =>
            {
                new EzWindowView().ShowDialog();
            });
        }
    }
}
