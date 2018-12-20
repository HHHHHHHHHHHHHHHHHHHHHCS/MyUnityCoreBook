using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Flags]
public enum MaskDef
{
    Sys = 1 << 0,//系统
    Now = 1 << 1,//本地
    Friend = 1 << 2,//朋友
    Guild = 1 << 3,//工会
    Local = 1 << 4,//本地
    World = 1 << 5,//世界
    Err = 1 << 6,//警告
}

public static class MaskDefExt
{
    public static bool IsEnabled(this MaskDef mask, MaskDef flag)
    {
        return (mask & flag) != 0;
    }

    public static MaskDef Enable(this MaskDef mask, MaskDef flag)
    {
        mask |= flag;
        return mask;
    }

    public static MaskDef Disable(this MaskDef mask, MaskDef flag)
    {
        mask &= ~flag;
        return mask;
    }
}

public static class MaskLogManager
{
    private static MaskDef Mask { get; set; } = MaskDef.Sys;
    private static LogReplace replace = new LogReplace();

    public static bool EnableLog
    {
        get => replace.showLog;
        set=> replace.showLog = value;
    }

    static MaskLogManager()
    {
        EnableLog = true;
    }
    
    public static void EnableTag(MaskDef def)
    {
        Mask=  Mask.Enable( def);
    }

    public static void DisableTag(MaskDef def)
    {
        Mask = Mask.Disable(def);
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

    public static void ErrorLog(string format, params object[] args)
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
                Debug.LogError(format);
            }
            else
            {
                Debug.LogErrorFormat(format, args);
            }
        }
    }

    public static void SysLog(string format,params object[] args)
    {
        if(Mask.IsEnabled(MaskDef.Sys))
        {
            Log(format, args);
        }
    }

    public static void NowLog(string format, params object[] args)
    {
        if (Mask.IsEnabled(MaskDef.Now))
        {
            Log(format, args);
        }
    }

    public static void FriendLog(string format, params object[] args)
    {
        if (Mask.IsEnabled(MaskDef.Friend))
        {
            Log(format, args);
        }
    }

    public static void ErrLog(string format, params object[] args)
    {
        if (Mask.IsEnabled(MaskDef.Err))
        {
            ErrorLog(format, args);
        }
    }
}

