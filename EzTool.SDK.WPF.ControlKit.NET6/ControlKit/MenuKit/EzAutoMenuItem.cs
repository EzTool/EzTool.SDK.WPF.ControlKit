using System.Security.Cryptography.X509Certificates;
using System.Windows;
using System.Windows.Controls;

namespace EzTool.SDK.WPF.ControlKit.MenuKit
{
    public class EzAutoMenuItem : MenuItem
    {
        #region -- 建構/解構 ( Constructors/Destructor ) --

        public EzAutoMenuItem()
        {
            DefaultStyleKey = typeof(EzAutoMenuItem);
        }

        #endregion

        #region -- 屬性 ( Properties ) --

        #region MenuItemTemplate

        public DataTemplate MenuItemTemplate
        {
            get => (DataTemplate)GetValue(MenuItemTemplateProperty);
            set => SetValue(MenuItemTemplateProperty, value);
        }

        public static readonly DependencyProperty MenuItemTemplateProperty =
            DependencyProperty.Register(
                nameof(MenuItemTemplate),
                typeof(DataTemplate),
                typeof(EzAutoMenuItem), null);

        #endregion

        #region MenuItemTemplateKey

        public string MenuItemTemplateKey
        {
            get => (string)GetValue(MenuItemTemplateKeyProperty);
            set => SetValue(MenuItemTemplateKeyProperty, value);
        }

        public static readonly DependencyProperty MenuItemTemplateKeyProperty =
            DependencyProperty.Register(
                nameof(MenuItemTemplateKey),
                typeof(string),
                typeof(EzAutoMenuItem), new FrameworkPropertyMetadata($@"MenuItemTemplate"));

        #endregion

        #endregion

    }
}
