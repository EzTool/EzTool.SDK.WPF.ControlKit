using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace EzTool.SDK.WPF.HumbleObjects
{
    public class EmbedFileReader
    {

        #region -- 變數宣告 ( Declarations ) --   

        private Assembly l_objTargetAssembly;

        #endregion

        #region -- 建構/解構 ( Constructors/Destructor ) --

        public EmbedFileReader(Assembly pi_objTargetAssembly)
        {
            this.l_objTargetAssembly = pi_objTargetAssembly;
        }

        #endregion

        #region -- 靜態方法 (Shared Method ) --

        public static EmbedFileReader Initial(Assembly? pi_objTargetAssembly = null)
        {
            var objTargetAssembly = pi_objTargetAssembly ?? Assembly.GetCallingAssembly();

            return new EmbedFileReader(objTargetAssembly);
        }

        #endregion

        #region -- 方法 ( Public Method ) --

        public string Read(string pi_sFileName)
        {
            return Read(new Func<string, bool>((sResourceKey) =>
            {
                return sResourceKey.EndsWith(pi_sFileName);
            }));
        }
        public string Read(Func<string, bool> pi_objCondition)
        {
            var sReturn = string.Empty;
            var objCondition = pi_objCondition ?? new Func<string, bool>((sName) => { return false; });
            var sResourceName = l_objTargetAssembly.GetManifestResourceNames().Single(objCondition);

            if (string.IsNullOrEmpty(sResourceName) == false)
            {
                var objStream = l_objTargetAssembly.GetManifestResourceStream(sResourceName);

                sReturn = objStream != null ? new StreamReader(objStream).ReadToEnd() : String.Empty;
            }

            return sReturn;
        }

        #endregion

    }
}
