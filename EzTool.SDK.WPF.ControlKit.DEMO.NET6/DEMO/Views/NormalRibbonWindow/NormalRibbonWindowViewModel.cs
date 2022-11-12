using EzTool.SDK.Router.Core.Interface;
using EzTool.SDK.WPF.ControlKit.DEMO.Views.EzWindow;
using EzTool.SDK.WPF.Mask;
using EzTool.SDK.WPF.Mask.Core.Interfaces;
using EzTool.SDK.WPF.Region.Core.Interfaces;
using EzTool.SDK.WPF.Unicorn.BaseObjects;
using EzTool.SDK.WPF.Unicorn.HumbleObjects;
using EzTool.SDK.WPF.Unicorn.Utilities;
using EzTool.SDK.WPF.ViewActions.Interface;

using System;
using System.Windows;

namespace EzTool.SDK.WPF.ControlKit.DEMO.Views.NormalRibbonWindow
{
    public class NormalRibbonWindowViewModel : IWindowView, IHostView, IDialogView
    {

        #region -- 變數宣告 ( Declarations ) --   

        private Func<bool> l_objIsWaiting = new Func<bool>(() => { return false; });

        #endregion

        #region -- 屬性 ( Properties ) --

        public NormalRibbonWindowView ViewWindow { get; set; }
        private MaskLayer ViewMask { get; set; }
        private IRegionHost RegionHost { get; set; }

        #endregion

        #region -- 介面實做 ( Implements ) - [IWindowView] --

        public IPresenter Presenter { get; set; }
        public string DTO { get; set; }

        public void ExitView()
        {
            throw new NotImplementedException();
        }


        public void ShowDialog()
        {
            var objDataContext = new NormalRibbonWindowViewContext()
            {
                Presenter = Presenter,
                HashCode = GetHashCode().ToString(),
                IsShowProgress = false
            };         

            new DispatcherProxy().Invoke(() =>
            {
                var objViewControl = ViewControlBuilder.Build<EzWindowMainView>(objDataContext);

                ViewMask = MaskLayer.Initial(objDataContext);
                ViewMask.Mount(objViewControl);
                ViewWindow = new NormalRibbonWindowView() { DataContext = objDataContext };
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

        public virtual void Waitting()
        {
            while (l_objIsWaiting.Invoke())
            {
                System.Threading.Thread.Sleep(10);
            }
        }

        #endregion
    }

    public class NormalRibbonWindowViewContext : BaseViewContext
    {
        public string HashCode { get; set; }
    }
}
