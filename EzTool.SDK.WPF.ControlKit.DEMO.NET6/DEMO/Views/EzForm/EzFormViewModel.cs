using EzTool.SDK.WPF.ControlKit.DEMO.Enums;
using EzTool.SDK.WPF.Unicorn.BaseObjects;

namespace EzTool.SDK.WPF.ControlKit.DEMO.Views.EzForm
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
        private SizeType l_nSizeType;
        private string l_sSize;

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
        public string Size
        {
            get { return l_sSize; }
            set
            {
                l_sSize = value;
                base.OnPropertyChanged(nameof(Size));
            }
        }
        public SizeType SizeType
        {
            get { return l_nSizeType; }
            set
            {
                l_nSizeType = value;
                Size = value.ToString();
                OnPropertyChanged(nameof(SizeType));    
            }
        }
    }
}
