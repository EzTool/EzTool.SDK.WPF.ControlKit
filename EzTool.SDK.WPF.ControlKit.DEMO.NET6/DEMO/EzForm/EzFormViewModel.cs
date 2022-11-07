using EzTool.SDK.WPF.Unicorn.BaseObjects;

namespace EzTool.SDK.WPF.ControlKit.DEMO.EzForm
{
    public class EzFormViewModel : BaseViewModel<EzFormView>
    {
        protected override object InitialViewContext()
        {
            return new EzFormViewContext()
            {
                Presenter = Presenter,
                HostHashCode = HostHashCode,
                HashCode = GetHashCode().ToString()
            };
        }
    }

    public class EzFormViewContext : BaseViewContext
    {
        public string HostHashCode { get; set; }
        public string HashCode { get; set; }
    }
}
