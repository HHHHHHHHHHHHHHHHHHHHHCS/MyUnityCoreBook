using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

/// <summary>
/// Unity点击 Play的时候脚本会清除内存中的缓存 重新执行start
/// 然后退出的时候 不会执行start
/// 所以需要闭环服务
/// </summary>
[InitializeOnLoad]
public class AutoServer
{

    static AutoServer()
    {
        return;
        if(!EditorApplication.isPlayingOrWillChangePlaymode)
        {
            EditorApplication.update += ScriptLoaod;
        }
        else
        {
            EditorApplication.update += ScriptRunning;
        }

    }

    private static void ScriptLoaod()
    {
        EditorApplication.update -= ScriptLoaod;
        EditorApplication.update += IdleUpdate;
    }

    private static void IdleUpdate()
    {
        CheckAndShow();
        if(EditorApplication.isPlayingOrWillChangePlaymode)
        {
            EditorApplication.update -= IdleUpdate;
        }
    }

    private static void ScriptRunning()
    {
        EditorApplication.update -= ScriptRunning;
        EditorApplication.update += RunningUpdate;
    }

    private static void RunningUpdate()
    {
        CheckAndShow();
        if (!EditorApplication.isPlayingOrWillChangePlaymode)
        {
            EditorApplication.update -= RunningUpdate;
            EditorApplication.update += ScriptLoaod;
        }
    }

    private static void CheckAndShow()
    {
        var now = System.DateTime.Now;
        if(now.Hour==17&&now.Minute==0&&now.Second==0)
        {
            if (EditorUtility.DisplayDialog("吃饭啦!!!", "五点钟该吃饭了"
                ,"走起","算球!"))
            {
                Application.OpenURL("https://www.baidu.com/");
            }

        }
    }
}
