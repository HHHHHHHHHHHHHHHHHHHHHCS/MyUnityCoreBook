using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogReplace : ILogHandler
{
    public bool showLog;
    private ILogHandler defaultHandler = Debug.unityLogger.logHandler;


    public LogReplace()
    {
        Debug.unityLogger.logHandler = this;
        Application.logMessageReceived += Send;
    }

    public void LogException(Exception exception, UnityEngine.Object context)
    {
        defaultHandler.LogException(exception, context);
    }

    public void LogFormat(LogType logType, UnityEngine.Object context, string format, params object[] args)
    {
        if(showLog)
        {
            defaultHandler.LogFormat(logType, context, format, args);
        }
    }

    public void Send(string condition, string stackTrace, LogType type)
    {
        //发送Log给服务器
        if (type == LogType.Error || type == LogType.Exception)
        {
            Debug.Log($"Send Error|Exception Log condition:{condition},stackTrace:{stackTrace},type:{type}");
        }
        else
        {
        }
  
    }
}
