using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LogManager
{
    private static LogReplace replace = new LogReplace();
    public static bool EnableLog
    {
        get => replace.showLog;
        set => replace.showLog = value;
    }

    static LogManager()
    {
        EnableLog = true;
    }


    public static void Log(string format, params object[] args)
    {
        //Debug.unityLogger.logEnabled = enable;
        if (EnableLog)
        {
            if (string.IsNullOrEmpty(format))
            {
                return;
            }
            if (args.Length == 0)
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
