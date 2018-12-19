using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogReplace : ILogHandler
{
    private ILogHandler defaultHandler = Debug.unityLogger.logHandler;

    public LogReplace()
    {
        Debug.unityLogger.logHandler = this;
    }

    public void LogException(Exception exception, UnityEngine.Object context)
    {
        defaultHandler.LogException(exception, context);
    }

    public void LogFormat(LogType logType, UnityEngine.Object context, string format, params object[] args)
    {
        if(LogManager.enable)
        {
            defaultHandler.LogFormat(logType, context, format, args);
        }
    }
}
