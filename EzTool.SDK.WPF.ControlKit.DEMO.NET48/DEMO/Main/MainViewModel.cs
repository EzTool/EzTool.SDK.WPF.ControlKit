using EzTool.SDK.WPF.Unicorn.BaseObjects;

namespace EzTool.SDK.WPF.ControlKit.DEMO.Main
{
    public class MainViewModel : BaseViewModel<MainView>
    {
        protected override object InitialViewContext()
        {
            return new MainViewContext()
            {
                Presenter = Presenter ,
                HostHashCode = HostHashCode,
                HashCode = GetHashCode().ToString()
            };
        }
    }

    public class MainViewContext : BaseViewContext
    {
        public string HostHashCode { get; set; }
        public string HashCode { get; set; }
    }
}
