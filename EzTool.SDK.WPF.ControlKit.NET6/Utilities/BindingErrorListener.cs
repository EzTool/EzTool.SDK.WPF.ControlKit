using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EzTool.SDK.WPF.Utilities
{
    public class BindingErrorListener : TraceListener
    {
        private Action<string> logAction;
        public static void Listen(Action<string> logAction)
        {
            PresentationTraceSources.DataBindingSource.Listeners
                .Add(new BindingErrorListener() { logAction = logAction });
        }
        public static void Notify(string pi_sMessage)
        {
            var objListeners = PresentationTraceSources.DataBindingSource.Listeners;
            foreach (TraceListener objListener in objListeners)
            {
                objListener.WriteLine(pi_sMessage);
            }
        }
        public override void Write(string message) { logAction.Invoke(message); }
        public override void WriteLine(string message) { logAction.Invoke(message); }
    }
}
