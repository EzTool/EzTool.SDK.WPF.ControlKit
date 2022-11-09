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
        private string l_sStyleName;

        public string HostHashCode { get; set; }
        public string HashCode { get; set; }

        public string StyleName
        {
            get { return l_sStyleName; }
            set
            {
                l_sStyleName = value;
                base.OnPropertyChanged(nameof(StyleName));
            }
        }
    }
}
