using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace EzTool.SDK.WPF.ControlKit.FormKit
{
    public class EzFormTitle : ContentControl
    {

        #region -- 建構/解構 ( Constructors/Destructor ) --

        public EzFormTitle()
        {
            DefaultStyleKey = typeof(EzFormTitle);
            EzForm.SetIsItemItsOwnContainer(this, true);
        }

        #endregion

        #region -- 事件處理 ( Event Handlers ) --

        #region OnDescriptionChanged

        protected virtual void OnDescriptionChanged(object oldValue, object newValue) { }
        private static void OnDescriptionChanged(DependencyObject obj, DependencyPropertyChangedEventArgs args)
        {
            var oldValue = args.OldValue;
            var newValue = args.NewValue;
            
            if(oldValue != newValue && obj is EzFormTitle objTitle)
            {
                objTitle.OnDescriptionChanged(oldValue, newValue);
            }
        }

        #endregion

        #endregion

        #region -- 屬性 ( Properties ) --

        #region Description

        public object Description
        {
            get => GetValue(DescriptionProperty);
            set => SetValue(DescriptionProperty, value);
        }
        public static readonly DependencyProperty DescriptionProperty =
            DependencyProperty.Register(
                nameof(Description),
                typeof(object),
                typeof(EzFormTitle), new PropertyMetadata(default, OnDescriptionChanged));

        #endregion

        #endregion

    }
}
