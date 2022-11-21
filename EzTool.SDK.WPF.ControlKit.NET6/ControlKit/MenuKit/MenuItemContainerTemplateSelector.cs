using System.Windows.Controls;
using System.Windows;
using EzTool.SDK.WPF.HumbleObjects;
using EzTool.SDK.WPF.Utilities;

namespace EzTool.SDK.WPF.ControlKit.MenuKit
{
    /// <summary>
    /// https://stackoverflow.com/questions/31214027/how-to-correctly-bind-a-viewmodel-which-include-separators-to-wpfs-menu
    /// </summary>
    public class MenuItemContainerTemplateSelector : ItemContainerTemplateSelector
    {
        public override DataTemplate? SelectTemplate(object item, ItemsControl parentItemsControl)
        {
            if (item == null)
            {
                var sSeparatorItemTemplateKey = $@"SeparatorItemTemplate";
                var sAssemblyName = GetType().Assembly.GetName().Name;
                var sSourcePath = $@"/{sAssemblyName};component/ControlKit/MenuKit/SeparatorItemDataTemplate.xaml";
                var objUri = new System.Uri(sSourcePath ?? string.Empty, System.UriKind.RelativeOrAbsolute);
                var objSeparatorItemTemplateRedource = new ResourceDictionary { Source = objUri };

                return (DataTemplate)objSeparatorItemTemplateRedource[sSeparatorItemTemplateKey ?? string.Empty];
            }
            else
            {
                var objParentItemResources = parentItemsControl.Resources;
                var sMenuItemTemplateKey = $@"MenuItemTemplate";

                if (parentItemsControl is EzAutoMenuItem objEzAutoMenuItem)
                {
                    if (objEzAutoMenuItem.MenuItemTemplate == null)
                    {
                        sMenuItemTemplateKey = objEzAutoMenuItem.MenuItemTemplateKey;
                    }
                    else
                    {
                        return objEzAutoMenuItem.MenuItemTemplate;
                    }
                }

                if (objParentItemResources != null)
                {
                    var objFindResult = parentItemsControl.TryFindResource(sMenuItemTemplateKey);

                    if (objFindResult != null)
                    {
                        return (DataTemplate)objFindResult;
                    }
                }
            }

            var sMessage = EmbedFileReader.Initial().Read($@"NoMenuItemTemplateMsg.txt");
            BindingErrorListener.Notify(sMessage ?? string.Empty);

            return null;
        }
    }
}
