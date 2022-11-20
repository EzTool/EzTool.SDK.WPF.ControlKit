using System.Windows.Controls;
using System.Windows;
using System.IO;
using System.Text;
using System.Windows.Markup;
using System.Collections.Generic;
using EzTool.SDK.WPF.Exceptions;
using EzTool.SDK.WPF.HumbleObjects;
using EzTool.SDK.WPF.Utilities;

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
                var sSourcePath = $@"/EzTool.SDK.WPF.ControlKit;component/ControlKit/MenuKit/SeparatorDataTemplate.xaml";
                var objUri = new System.Uri(sSourcePath, System.UriKind.RelativeOrAbsolute);
                var objSeparatorItemTemplateRedource = new ResourceDictionary { Source = objUri };

                return (DataTemplate)objSeparatorItemTemplateRedource["SeparatorItemTemplate"];
            }
            else
            {
                var objParentItemResources = parentItemsControl.Resources;
                var sMenuItemTemplateKey = $@"MenuItemTemplate";

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
            BindingErrorListener.Notify(sMessage);

            return null;
        }
    }
}
