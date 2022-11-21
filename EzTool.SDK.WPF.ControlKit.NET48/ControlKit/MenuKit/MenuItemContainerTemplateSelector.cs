using System.Windows.Controls;
using System.Windows;
using EzTool.SDK.WPF.HumbleObjects;
using EzTool.SDK.WPF.Utilities;
using EzTool.SDK.WPF.Exceptions;

namespace EzTool.SDK.WPF.ControlKit.MenuKit
{
    /// <summary>
    /// https://stackoverflow.com/questions/31214027/how-to-correctly-bind-a-viewmodel-which-include-separators-to-wpfs-menu
    /// </summary>
    public class MenuItemContainerTemplateSelector : ItemContainerTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, ItemsControl parentItemsControl)
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

                if (parentItemsControl is EzAutoMenuItem objEzAutoMenuItem)
                {
                    if (objEzAutoMenuItem.MenuItemTemplate != null)
                    {
                        return objEzAutoMenuItem.MenuItemTemplate;
                    }
                    else if (objEzAutoMenuItem.ItemTemplate != null)
                    {
                       return  objEzAutoMenuItem.ItemTemplate;
                    }
                    else
                    {
                        var sMenuItemTemplateKey = objEzAutoMenuItem.MenuItemTemplateKey;
                        var objParentItemResources = parentItemsControl.Resources;

                        if (objParentItemResources != null)
                        {
                            var objFindResult = parentItemsControl.TryFindResource(sMenuItemTemplateKey);

                            if (objFindResult != null)
                            {
                                return (DataTemplate)objFindResult;
                            }
                        }
                    }
                }
            }

            var sMessageFile = $@"NoMenuItemTemplateMsg.txt";
            var sMessage = EmbedFileReader.Initial().Read(sMessageFile);

            BindingErrorListener.Notify(sMessage ?? string.Empty);
            throw new EzToolControlKitException(sMessage);            
        }
    }
}
