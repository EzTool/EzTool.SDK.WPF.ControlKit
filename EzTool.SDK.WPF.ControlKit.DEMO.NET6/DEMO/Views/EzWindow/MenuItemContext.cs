using EzTool.SDK.WPF.Unicorn.BaseObjects;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzTool.SDK.WPF.ControlKit.DEMO.Views.EzWindow
{
    public class MenuItemContext : BaseViewContext
    {
        private string l_sHeader = string.Empty;

        public string Header
        {
            get { return l_sHeader; }
            set
            {
                l_sHeader = value;
                base.OnPropertyChanged(nameof(Header));
            }
        }
    }
}
