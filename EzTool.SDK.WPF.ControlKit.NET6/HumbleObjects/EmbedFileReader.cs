using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace EzTool.SDK.WPF.HumbleObjects
{
    public class EmbedFileReader
    {

        #region -- 變數宣告 ( Declarations ) --   

        private readonly Assembly l_objTargetAssembly;

        #endregion

        #region -- 建構/解構 ( Constructors/Destructor ) --

        private EmbedFileReader(Assembly pi_objTargetAssembly)
        {
            l_objTargetAssembly = pi_objTargetAssembly;
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
            var objDefaultCheck = new Func<string, bool>(
                (sKey) =>
                {
                    return sKey.EndsWith(pi_sFileName);
                });

            return Read(objDefaultCheck);
        }

        public string Read(Func<string, bool> pi_objCondition)
        {
            var sReturn = string.Empty;
            var objIsThisResource = pi_objCondition ?? new Func<string, bool>((sName) => { return false; });
            var sTargetResourceName = l_objTargetAssembly.GetManifestResourceNames().Single(objIsThisResource);

            if (string.IsNullOrEmpty(sTargetResourceName) == false)
            {
                var objStream = l_objTargetAssembly.GetManifestResourceStream(sTargetResourceName);

                sReturn = objStream != null ? 
                    new StreamReader(objStream).ReadToEnd() : 
                    string.Empty;
            }

            return sReturn;
        }

        #endregion

    }
}
