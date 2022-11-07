using EzTool.SDK.WPF.ControlKit.FunctionBarKit;

using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Markup;

namespace EzTool.SDK.WPF.ControlKit.FormKit
{
    [StyleTypedProperty(Property = "ItemContainerStyle", StyleTargetType = typeof(EzFormItem))]
    public partial class EzForm : HeaderedItemsControl
    {
        #region -- 變數宣告 ( Declarations ) --   

        private DataTemplate _labelMemberTemplate;

        #endregion

        #region -- 建構/解構 ( Constructors/Destructor ) --

        public EzForm() { DefaultStyleKey = typeof(EzForm); }

        #endregion

        #region -- 事件處理 ( Event Handlers ) --

        #region OnFunctionBarChanged

        protected virtual void OnFunctionBarChanged(FormFunctionBar oldValue, FormFunctionBar newValue) { }
        private static void OnFunctionBarChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            var oldValue = (FormFunctionBar)args.OldValue;
            var newValue = (FormFunctionBar)args.NewValue;

            if (oldValue != newValue && obj is EzForm objForm)
            {
                objForm?.OnFunctionBarChanged(oldValue, newValue);
            }
        }

        #endregion

        #region OnLabelMemberPathChanged

        protected virtual void OnLabelMemberPathChanged(string oldValue, string newValue)
        {
            _labelMemberTemplate = null; // refresh the label member template.
            int count = Items.Count;
            for (int i = 0; i < count; i++)
            {
                if (ItemContainerGenerator.ContainerFromIndex(i) is EzFormItem formItem)
                {
                    PrepareFormItem(formItem, Items[i]);
                }
            }
        }

        private static void OnLabelMemberPathChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            var oldValue = (string)args.OldValue;
            var newValue = (string)args.NewValue;

            if (oldValue != newValue && obj is EzForm objForm)
            {
                objForm?.OnLabelMemberPathChanged(oldValue, newValue);
            }
        }

        #endregion

        #region OnFormPropertyChanged

        private static void OnFormPropertyChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            if (args.OldValue == args.NewValue)
                return;

            if (args.OldValue != args.NewValue
                && obj is FrameworkElement content
                && content.Parent is EzForm form
                && form.ItemContainerGenerator.ContainerFromItem(content) is EzFormItem formItem)
            {
                form.PrepareFormFrameworkElement(formItem, content);
            }
        }

        #endregion

        #endregion

        #region -- 屬性 ( Properties ) --

        #region FunctionBar

        public FormFunctionBar FunctionBar
        {
            get => (FormFunctionBar)GetValue(FunctionBarProperty);
            set => SetValue(FunctionBarProperty, value);
        }

        public static readonly DependencyProperty FunctionBarProperty =
            DependencyProperty.Register(
                nameof(FunctionBar),
                typeof(FormFunctionBar),
                typeof(EzForm), new PropertyMetadata(default(FormFunctionBar), OnFunctionBarChanged));

        #endregion

        #region LabelMemberPath

        public string LabelMemberPath
        {
            get => (string)GetValue(LabelMemberPathProperty);
            set => SetValue(LabelMemberPathProperty, value);
        }
        public static readonly DependencyProperty LabelMemberPathProperty =
           DependencyProperty.Register(
               nameof(LabelMemberPath),
               typeof(string),
               typeof(EzForm), new PropertyMetadata(default(string), OnLabelMemberPathChanged));

        #endregion

        #region  EzForm.IsItemItsOwnContainer

        public static void SetIsItemItsOwnContainer(FrameworkElement obj, bool value) => obj.SetValue(IsItemItsOwnContainerProperty, value);
        public static bool GetIsItemItsOwnContainer(FrameworkElement obj) => (bool)obj.GetValue(IsItemItsOwnContainerProperty);
        public static readonly DependencyProperty IsItemItsOwnContainerProperty =
            DependencyProperty.RegisterAttached(
                "IsItemItsOwnContainer",
                typeof(bool),
                typeof(EzForm), new PropertyMetadata(default(bool), OnFormPropertyChanged));

        #endregion

        #region EzForm.Label

        public static object GetLabel(FrameworkElement obj) => obj.GetValue(LabelProperty);
        public static void SetLabel(FrameworkElement element, object value) => element.SetValue(LabelProperty, value);
        public static readonly DependencyProperty LabelProperty =
            DependencyProperty.RegisterAttached(
                "Label",
                typeof(object),
                typeof(EzForm), new PropertyMetadata(default, OnFormPropertyChanged));

        #endregion

        #region EzForm.Description

        public static object GetDescription(FrameworkElement obj) => obj.GetValue(DescriptionProperty);
        public static void SetDescription(FrameworkElement obj, object value) => obj.SetValue(DescriptionProperty, value);
        public static readonly DependencyProperty DescriptionProperty =
           DependencyProperty.RegisterAttached(
               "Description",
               typeof(object),
               typeof(EzForm), new PropertyMetadata(default, OnFormPropertyChanged));


        #endregion

        #region EzForm.IsRequired

        public static bool GetIsRequired(FrameworkElement obj) => (bool)obj.GetValue(IsRequiredProperty);
        public static void SetIsRequired(FrameworkElement obj, bool value) => obj.SetValue(IsRequiredProperty, value);
        public static readonly DependencyProperty IsRequiredProperty =
            DependencyProperty.RegisterAttached(
                "IsRequired",
                typeof(bool),
                typeof(EzForm), new PropertyMetadata(default(bool), OnFormPropertyChanged));

        #endregion

        #region EzForm.ContainerStyle

        public static Style GetContainerStyle(FrameworkElement obj) => (Style)obj.GetValue(ContainerStyleProperty);
        public static void SetContainerStyle(FrameworkElement obj, Style value) => obj.SetValue(ContainerStyleProperty, value);
        public static readonly DependencyProperty ContainerStyleProperty =
            DependencyProperty.RegisterAttached(
                "ContainerStyle",
                typeof(Style),
                typeof(EzForm), new PropertyMetadata(default(Style), OnFormPropertyChanged));

        #endregion

        #region EzForm.LabelTemplate

        public static DataTemplate GetLabelTemplate(FrameworkElement element) => (DataTemplate)element.GetValue(LabelTemplateProperty);
        public static void SetLabelTemplate(FrameworkElement obj, DataTemplate value) => obj.SetValue(LabelTemplateProperty, value);
        public static readonly DependencyProperty LabelTemplateProperty =
            DependencyProperty.RegisterAttached(
                "LabelTemplate",
                typeof(DataTemplate),
                typeof(EzForm), new PropertyMetadata(default(DataTemplate), OnFormPropertyChanged));

        #endregion 

        #endregion

        #region -- 私有函式 ( Private Method) --

        private void PrepareFormFrameworkElement(EzFormItem formItem, FrameworkElement content)
        {
            formItem.Label = GetLabel(content);
            formItem.Description = GetDescription(content);
            formItem.IsRequired = GetIsRequired(content);
            formItem.ClearValue(DataContextProperty);
            Style style = GetContainerStyle(content);
            if (style != null)
                formItem.Style = style;
            else if (ItemContainerStyle != null)
                formItem.Style = ItemContainerStyle;
            else
                formItem.ClearValue(FrameworkElement.StyleProperty);

            DataTemplate labelTemplate = GetLabelTemplate(content);
            if (labelTemplate != null)
                formItem.LabelTemplate = labelTemplate;

            var binding = new Binding(nameof(Visibility))
            {
                Source = content,
                Mode = BindingMode.OneWay
            };
            formItem.SetBinding(VisibilityProperty, binding);
        }

        private void PrepareFormItem(EzFormItem formItem, object item)
        {
            if (formItem != item && item is not FrameworkElement)
            {
                formItem.LabelTemplate = GetLabelMemberTemplate();
                formItem.Label = item;
            }
        }

        private DataTemplate GetLabelMemberTemplate()
        {
            if (_labelMemberTemplate == null)
            {
                _labelMemberTemplate = (DataTemplate)XamlReader.Parse(@"
                    <DataTemplate xmlns=""http://schemas.microsoft.com/winfx/2006/xaml/presentation""
                                xmlns:x=""http://schemas.microsoft.com/winfx/2006/xaml"">
                    		<TextBlock Text=""{Binding " + LabelMemberPath + @"}"" VerticalAlignment=""Center""/>
                    </DataTemplate>");
            }

            return _labelMemberTemplate;
        }

        #endregion

        #region -- 覆寫函式 ( Override Method ) -- 

        protected override bool IsItemItsOwnContainerOverride(object item)
        {
            bool isItemItsOwnContainer = false;
            if (item is FrameworkElement element)
                isItemItsOwnContainer = GetIsItemItsOwnContainer(element);

            return item is EzFormItem || isItemItsOwnContainer;
        }

        protected override DependencyObject GetContainerForItemOverride()
        {            
            return new EzFormItem();
        }

        protected override void PrepareContainerForItemOverride(DependencyObject element, object item)
        {
            base.PrepareContainerForItemOverride(element, item);

            if (element is EzFormItem formItem && item is EzFormItem == false)
            {
                if (item is FrameworkElement content)
                    PrepareFormFrameworkElement(formItem, content);
                else
                    PrepareFormItem(formItem, item);
            }
        }

        protected override bool ShouldApplyItemContainerStyle(DependencyObject container, object item)
        {
            return container is EzFormItem;
        }

        #endregion

    }
}
