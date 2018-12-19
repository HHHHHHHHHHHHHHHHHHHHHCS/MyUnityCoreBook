using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogManager
{
    private static LogReplace replace = new LogReplace();
    public static bool enable = true;
    public static void Log(string format,params object[] args)
    {
        //Debug.unityLogger.logEnabled = enable;
        if (enable)
        {
            if(format.Length==0)
            {
                return;
            }
            if(args.Length==0)
            {
                Debug.Log(format);
            }
            else
            {
                Debug.LogFormat(format, args);
            }
        }

    }
}
