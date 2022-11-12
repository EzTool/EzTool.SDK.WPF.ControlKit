using EzTool.SDK.WPF.ControlKit.DEMO.Views.Main;
using EzTool.SDK.WPF.Unicorn;

using System;

namespace EzTool.SDK.WPF.ControlKit.DEMO
{
    public  class AppEntry
    {
        [STAThread]
        public static void Main()
        {
            Beginer.StartWith<MainViewModel>();
        }
    }
}
