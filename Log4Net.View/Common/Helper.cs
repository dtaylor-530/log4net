using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Log4NetWPF.Common
{

    public class LogHelper
    {
        public static void LogMessage(string message,
              [System.Runtime.CompilerServices.CallerMemberName] string memberName = "",
              [System.Runtime.CompilerServices.CallerFilePath] string sourceFilePath = "",
              [System.Runtime.CompilerServices.CallerLineNumber] int sourceLineNumber = 0)
        {
            Log4NetWPF.Log.Write(Log4NetWPF.LogLevel.Debug, "message: " + message +
           " member name: " + memberName +
        " source file path: " + sourceFilePath +
           " source line number: " + sourceLineNumber);
        }
    }

}
