using System.Windows;
using System.Windows.Controls;

namespace EzTool.SDK.WPF.ControlKit.FormKit
{
    public class EzFormItem : ContentControl
    {

        #region -- 建構/解構 ( Constructors/Destructor ) --

        public EzFormItem()
        {
            DefaultStyleKey = typeof(EzFormItem);
        }

        #endregion

        #region -- 事件處理 ( Event Handlers ) --

        #region OnLabelChanged

        protected virtual void OnLabelChanged(object oldValue, object newValue) { }
        private static void OnLabelChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            var oldValue = (object)args.OldValue;
            var newValue = (object)args.NewValue;

            if (oldValue != newValue && obj is EzFormItem objItem)
            {
                objItem?.OnLabelChanged(oldValue, newValue);
            }
        }

        #endregion

        #region OnLabelTemplateChanged

        protected virtual void OnLabelTemplateChanged(DataTemplate oldValue, DataTemplate newValue) { }
        private static void OnLabelTemplateChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            var oldValue = (DataTemplate)args.OldValue;
            var newValue = (DataTemplate)args.NewValue;

            if (oldValue != newValue && obj is EzFormItem objItem)
            {
                objItem?.OnLabelTemplateChanged(oldValue, newValue);
            }
        }

        #endregion

        #endregion

        #region -- 屬性 ( Properties ) --

        #region LabelVerticalAlignment

        /// <summary>
        /// 获取或设置LabelVerticalAlignment的值
        /// </summary>  
        public VerticalAlignment LabelVerticalAlignment
        {
            get => (VerticalAlignment)GetValue(LabelVerticalAlignmentProperty);
            set => SetValue(LabelVerticalAlignmentProperty, value);
        }

        /// <summary>
        /// 标识 LabelVerticalAlignment 依赖属性。
        /// </summary>
        public static readonly DependencyProperty LabelVerticalAlignmentProperty =
            DependencyProperty.Register(nameof(LabelVerticalAlignment), typeof(VerticalAlignment), typeof(EzFormItem), new PropertyMetadata(default(VerticalAlignment), OnLabelVerticalAlignmentChanged));

        private static void OnLabelVerticalAlignmentChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            var oldValue = (VerticalAlignment)args.OldValue;
            var newValue = (VerticalAlignment)args.NewValue;
            if (oldValue == newValue)
                return;

            var target = obj as EzFormItem;
            target?.OnLabelVerticalAlignmentChanged(oldValue, newValue);
        }

        /// <summary>
        /// LabelVerticalAlignment 属性更改时调用此方法。
        /// </summary>
        /// <param name="oldValue">LabelVerticalAlignment 属性的旧值。</param>
        /// <param name="newValue">LabelVerticalAlignment 属性的新值。</param>
        protected virtual void OnLabelVerticalAlignmentChanged(VerticalAlignment oldValue, VerticalAlignment newValue)
        {
        }

        #endregion

        #region IsRequiredProperty

        public bool IsRequired
        {
            get => (bool)GetValue(IsRequiredProperty);
            set => SetValue(IsRequiredProperty, value);
        }

        public static readonly DependencyProperty IsRequiredProperty =
            DependencyProperty.Register(
                nameof(IsRequired),
                typeof(bool),
                typeof(EzFormItem), new PropertyMetadata(default(bool)));

        #endregion

        #region Description

        public object Description
        {
            get => (object)GetValue(DescriptionProperty);
            set => SetValue(DescriptionProperty, value);
        }

        public static readonly DependencyProperty DescriptionProperty =
            DependencyProperty.Register(
                nameof(Description),
                typeof(object),
                typeof(EzFormItem), new PropertyMetadata(default(object)));


        #endregion

        #region Label

        public object Label
        {
            get => (object)GetValue(LabelProperty);
            set => SetValue(LabelProperty, value);
        }

        public static readonly DependencyProperty LabelProperty =
            DependencyProperty.Register(
                nameof(Label),
                typeof(object), typeof(EzFormItem), new PropertyMetadata(default, OnLabelChanged));

        #endregion

        #region LabelTemplate

        public DataTemplate LabelTemplate
        {
            get => (DataTemplate)GetValue(LabelTemplateProperty);
            set => SetValue(LabelTemplateProperty, value);
        }

        public static readonly DependencyProperty LabelTemplateProperty =
           DependencyProperty.Register(
               nameof(LabelTemplate),
               typeof(DataTemplate),
               typeof(EzFormItem), new PropertyMetadata(default(DataTemplate), OnLabelTemplateChanged));

        #endregion

        #endregion

    }
}
