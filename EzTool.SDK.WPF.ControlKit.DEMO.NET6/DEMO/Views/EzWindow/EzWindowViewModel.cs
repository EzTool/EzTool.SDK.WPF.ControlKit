using EzTool.SDK.Router.Core.Interface;
using EzTool.SDK.WPF.ControlKit.DEMO.Views.EzWindow.Events;
using EzTool.SDK.WPF.Mask;
using EzTool.SDK.WPF.Mask.Core.Interfaces;
using EzTool.SDK.WPF.Region.Core.Interfaces;
using EzTool.SDK.WPF.Unicorn.BaseObjects;
using EzTool.SDK.WPF.Unicorn.HumbleObjects;
using EzTool.SDK.WPF.Unicorn.Utilities;
using EzTool.SDK.WPF.ViewActions.Interface;

using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace EzTool.SDK.WPF.ControlKit.DEMO.Views.EzWindow
{
    public class EzWindowViewModel : IHostView, IWindowView, IDialogView
    {
        #region -- 變數宣告 ( Declarations ) --   

        private Func<bool> l_objIsWaiting = new Func<bool>(() => { return false; });

        #endregion

        #region -- 屬性 ( Properties ) --

        public EzWindowView ViewWindow { get; set; }
        private MaskLayer ViewMask { get; set; }
        private IRegionHost RegionHost { get; set; }

        #endregion

        public IPresenter Presenter { get; set; }
        public string DTO { get; set; }

        public void ExitView()
        {

        }

        public void ShowDialog()
        {
            var objDataContext = new EzWindowViewContext()
            {
                Presenter = Presenter,
                HashCode = GetHashCode().ToString(),
                IsShowProgress = false
            };
            var objMsgEvent = new EzWindowViewFunctionBarNotifyMsgEvent() { ViewContext = objDataContext };

            objDataContext.RelayCommand.Register(objMsgEvent);

            new DispatcherProxy().Invoke(() =>
            {
                var objViewControl = ViewControlBuilder.Build<EzWindowMainView>(objDataContext);

                ViewMask = MaskLayer.Initial(objDataContext);
                ViewMask.Mount(objViewControl);
                ViewWindow = new EzWindowView() { DataContext = objDataContext };
                ViewWindow.AppGrid.Children.Add((UIElement)ViewMask.Container);
                ViewWindow.Show();
            });
        }

        public void Embed(IClientView pi_objView)
        {
            throw new NotImplementedException();
        }
        public bool IsHostOf(IRequire pi_objRequire)
        {
            return true;
        }

        public IDialogView Popup(IClientView pi_objView)
        {
            if (pi_objView is IMaskDialogView objDialogView)
            {
                var bIsWait = true;
                var objOnDialogExit = default(Action);

                objOnDialogExit = new Action(() =>
                {
                    new DispatcherProxy().Invoke(() =>
                    {
                        bIsWait = false;
                        objDialogView.ViewExited -= objOnDialogExit;
                    });
                });

                l_objIsWaiting = new Func<bool>(() => { return bIsWait; });
                objDialogView.ViewExited += objOnDialogExit;
                ViewMask.Popup(objDialogView);
            }

            return this;
        }

        #region -- 介面實做 ( Implements ) - [IDialogView] --

        public virtual void Waitting()
        {
            while (l_objIsWaiting.Invoke())
            {
                System.Threading.Thread.Sleep(10);
            }
        }

        #endregion
    }

    public class EzWindowViewContext : BaseViewContext
    {
        private ObservableCollection<MenuItemContext> l_objMenuItems =
            new ObservableCollection<MenuItemContext>()
            {
                new MenuItemContext(){Header=$@"ItemA"},
                null,
                new MenuItemContext(){Header=$@"ItemB"}
            };

        public string HashCode { get; set; } = string.Empty;

        public ObservableCollection<MenuItemContext> MenuItems
        {
            get { return l_objMenuItems; }
            set
            {
                l_objMenuItems = value;
                OnPropertyChanged(nameof(MenuItems));
            }
        }
    }
}
