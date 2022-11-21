using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Windows.Input;

namespace EzTool.SDK.WPF.ControlKit.DEMO.Views
{

    /// <summary>
    /// https://stackoverflow.com/questions/31214027/how-to-correctly-bind-a-viewmodel-which-include-separators-to-wpfs-menu
    /// </summary>
    public class MenuItemContainerTemplateSelector : ItemContainerTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, ItemsControl parentItemsControl)
        {           
            if(item == null)
            {
                return (DataTemplate)parentItemsControl.FindResource($@"SeparaterItemTemplate");
            }
            return (DataTemplate)parentItemsControl.FindResource($@"MenuItemTemplate");
        }
    }
}
