using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Text;

/// <summary>
/// 菜单的勾选状态模式
/// </summary>
public class MaskMenu
{
    private const string channelFsy = "MaskMenu/Channel/Fsy";
    private const string channelProcess = "MaskMenu/Channel/Process";
    private const string channelNetWork = "MaskMenu/Channel/NetWork";

    private static void FindNameByFlag(string name)
    {
        UnityEditor.Menu.SetChecked(name, !UnityEditor.Menu.GetChecked(name));
    }

    [MenuItem(channelFsy)]
    private static void FindByFsy()
    {
        FindNameByFlag(channelFsy);
    }

    [MenuItem(channelProcess)]
    private static void FindByProcess()
    {
        FindNameByFlag(channelProcess);
    }

    [MenuItem(channelNetWork)]
    private static void FindByNetWork()
    {
        FindNameByFlag(channelNetWork);
    }
}
