using EzTool.SDK.Router.Core.Interface;
using EzTool.SDK.WPF.ControlKit.DEMO.EzRibbonWindow.Events;
using EzTool.SDK.WPF.ControlKit.DEMO.EzWindow;
using EzTool.SDK.WPF.Mask;
using EzTool.SDK.WPF.Mask.Core.Interfaces;
using EzTool.SDK.WPF.Mask.HumbleObjects;
using EzTool.SDK.WPF.Region.Core.Interfaces;
using EzTool.SDK.WPF.Unicorn.BaseObjects;
using EzTool.SDK.WPF.Unicorn.Utilities;
using EzTool.SDK.WPF.ViewActions.Interface;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EzTool.SDK.WPF.ControlKit.DEMO.EzRibbonWindow
{
    public class EzRibbonWindowViewModel : IWindowView, IHostView, IDialogView
    {

        #region -- 變數宣告 ( Declarations ) --   

        private Func<bool> l_objIsWaiting = new Func<bool>(() => { return false; });

        #endregion

        #region -- 屬性 ( Properties ) --

        public EzRibbonWindowView ViewWindow { get; set; }
        private MaskLayer ViewMask { get; set; }
        private IRegionHost RegionHost { get; set; }

        #endregion

        #region -- 介面實做 ( Implements ) - [IWindowView] --

        public IPresenter Presenter { get; set; }
        public string DTO { get; set; }

        public void ExitView()
        {

        }

        public void ShowDialog()
        {
            var objDataContext = new EzRibbonWindowViewContext()
            {
                Presenter = Presenter,
                HashCode = GetHashCode().ToString(),
                IsShowProgress = false
            };
            var objCopyEvent = new EzRibbonWindowCopyEven() { ViewContext = objDataContext };

            objDataContext.RelayCommand.Register(objCopyEvent);
            new DispatcherProxy().Invoke(() =>
            {
                var objViewControl = ViewControlBuilder.Build<EzRibbonWindowMainView>(objDataContext);

                ViewMask = MaskLayer.Initial(objDataContext);
                ViewMask.Mount(objViewControl);
                ViewWindow = new EzRibbonWindowView() { DataContext = objDataContext };
                ViewWindow.AppGrid.Children.Add((UIElement)ViewMask.Container);
                ViewWindow.Show();
            });
        }

        #endregion

        #region -- 介面實做 ( Implements ) - [IHostView] --

        public bool IsHostOf(IRequire pi_objRequire)
        {
            return true;
        }

        public void Embed(IClientView pi_objView)
        {
            throw new NotImplementedException();
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


        #endregion

        #region -- 介面實做 ( Implements ) - [IDialogView] --

        public void Waitting()
        {
            while (l_objIsWaiting.Invoke())
            {
                System.Threading.Thread.Sleep(10);
            }
        }

        #endregion

    }

    public class EzRibbonWindowViewContext : BaseViewContext
    {
        public IPresenter Presenter { get; set; }
        public string HashCode { get; set; }
        public bool IsShowProgress { get; set; }
    }
}
