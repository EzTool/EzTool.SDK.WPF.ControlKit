using System;
using System.Diagnostics;

namespace EzTool.SDK.WPF.Utilities
{
    /// <summary>
    /// 提供 XAML 繫結錯誤觀察。
    /// </summary>
    public class BindingErrorListener : TraceListener
    {

        #region -- 變數宣告 ( Declarations ) --   

        private Action<string> logAction = new((s) => { });

        #endregion

        #region -- 靜態方法 (Shared Method ) --

        public static void Listen(Action<string> logAction)
        {
            PresentationTraceSources.DataBindingSource.Listeners
                .Add(new BindingErrorListener() { logAction = logAction });
        }

        public static void Notify(string? pi_sMessage)
        {
            var objListeners = PresentationTraceSources.DataBindingSource.Listeners;

            foreach (TraceListener objListener in objListeners)
            {
                objListener.WriteLine(pi_sMessage ?? string.Empty);
            }
        }

        #endregion

        #region -- 衍生函式 ( Protected Method ) -- 

        public override void Write(string? message) { logAction.Invoke(message ?? string.Empty); }
        public override void WriteLine(string? message) { logAction.Invoke(message ?? string.Empty); }

        #endregion

    }
}
