using System.Windows.Controls;
using System.Windows;
using System.IO;
using System.Text;
using System.Windows.Markup;
using System.Collections.Generic;

namespace EzTool.SDK.WPF.ControlKit.MenuKit
{
    /// <summary>
    /// https://stackoverflow.com/questions/31214027/how-to-correctly-bind-a-viewmodel-which-include-separators-to-wpfs-menu
    /// </summary>
    public class MenuItemContainerTemplateSelector : ItemContainerTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, ItemsControl parentItemsControl)
        {
            DataTemplate objReturn;
            MemoryStream ms;

            ResourceDictionary objResources = parentItemsControl.Resources;


            if (item == null)
            {
                ms = new MemoryStream(Encoding.UTF8.GetBytes(
                   $@"<DataTemplate xmlns=""http://schemas.microsoft.com/winfx/2006/xaml/presentation""
                                                                 xmlns:x=""http://schemas.microsoft.com/winfx/2006/xaml""                                                                             
                                                                 xmlns:c=""clr-namespace:MyApp.Converters;assembly=MyApp"">
                            <Separator />
                          </DataTemplate>"));
            }
            else
            {
                if (objResources != null && objResources.Count > 0)
                {
                    foreach (System.Collections.DictionaryEntry objResource in objResources)
                    {
                        if (objResource.Key is string sKey
                            && sKey == $@"ItemTemplate"
                            && objResource.Value is DataTemplate objTemplate)
                        {
                            objReturn = objTemplate;
                        }
                    }
                }

                ms = new MemoryStream(Encoding.UTF8.GetBytes(
                    $@"<DataTemplate xmlns=""http://schemas.microsoft.com/winfx/2006/xaml/presentation""
                                                                 xmlns:x=""http://schemas.microsoft.com/winfx/2006/xaml""                                                                             
                                                                 xmlns:c=""clr-namespace:MyApp.Converters;assembly=MyApp"">
                            <MenuItem Header=""{{Binding Header}}"" 
                                      Command=""{{Binding Command}}""
                                      />
                          </DataTemplate>"));

            }
            objReturn = (DataTemplate)XamlReader.Load(ms);

            return objReturn;
        }
    }
}
