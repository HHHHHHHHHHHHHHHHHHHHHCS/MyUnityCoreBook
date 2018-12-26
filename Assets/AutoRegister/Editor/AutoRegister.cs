using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


/// <summary>
/// 参考AutoServer
/// </summary>
[InitializeOnLoad]
public class AutoRegister
{
    private static List<IEditorState> list = new List<IEditorState>();


    static AutoRegister()
    {
        return;
        if (!EditorApplication.isPlayingOrWillChangePlaymode)
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
        Init();

        EditorApplication.update -= ScriptLoaod;
        EditorApplication.update += IdleUpdate;
    }

    private static void IdleUpdate()
    {
        if (EditorApplication.isPlayingOrWillChangePlaymode)
        {
            foreach (var item in list)
            {
                item.PreRun();
            }

            EditorApplication.update -= IdleUpdate;
        }
    }

    private static void ScriptRunning()
    {
        Init();
        EditorApplication.update -= ScriptRunning;
        EditorApplication.update += RunningUpdate;
    }

    private static void RunningUpdate()
    {
        if (!EditorApplication.isPlayingOrWillChangePlaymode)
        {
            foreach (var item in list)
            {
                item.WillEndRun();
            }
            EditorApplication.update -= RunningUpdate;
            EditorApplication.update += ScriptLoaod;
        }
    }

    private static void Init()
    {
        list.Clear();
        var ops = GetAllImplementTypes<IEditorState>(System.AppDomain.CurrentDomain);

        foreach (var op in ops)
        {
            op.StartEditor();
            list.Add(op);
        }
    }

    private static T[] GetAllImplementTypes<T>(System.AppDomain appDomain) where T : class
    {
        var result = new List<T>();
        var assemblies = appDomain.GetAssemblies();
        foreach (var assembly in assemblies)
        {
            var types = assembly.GetTypes();
            foreach (var type in types)
            {
                if (typeof(T).IsAssignableFrom(type))
                {
                    if (!type.IsAbstract)
                    {
                        var tar = assembly.CreateInstance(type.FullName) as T;
                        result.Add(tar);
                    }
                }
            }
        }

        return result.ToArray();
    }
}
